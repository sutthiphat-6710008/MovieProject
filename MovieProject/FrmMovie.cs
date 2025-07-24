using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MovieProject
{
    public partial class FrmMovie : Form
    {
        byte[] menuImage;
        public FrmMovie()
        {
            InitializeComponent();
        }
        private Image convertByteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn == null || byteArrayIn.Length == 0)
            {
                return null;
            }
            try
            {
                using (MemoryStream ms = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (ArgumentException ex)
            {
                // อาจเกิดขึ้นถ้า byte array ไม่ใช่ข้อมูลรูปภาพที่ถูกต้อง
                Console.WriteLine("Error converting byte array to image: " + ex.Message);
                return null;
            }
        }

        private byte[] convertImageToByteArray(Image image, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                // ป้องกัน GDI+ error
                using (Bitmap bmp = new Bitmap(image))
                {
                    bmp.Save(ms, format);
                }
                return ms.ToArray();
            }
        }
        private void getAllMovieToListView()
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Server=MSI\SQLEXPRESS;Database=movie_collection_db;Trusted_Connection=True;"))
            {
                try
                {
                    string strSQL = "SELECT movieId, movieName, movieDetail, movieDate, movieHour, movieMinute, movieType, movieImage FROM movie_tb";
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(strSQL, sqlConnection))
                    {
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        // ตั้งค่า ListView
                        lvShowAllMovie.Items.Clear();
                        lvShowAllMovie.Columns.Clear();
                        lvShowAllMovie.FullRowSelect = true;
                        lvShowAllMovie.View = View.Details;

                        if (lvShowAllMovie.SmallImageList == null)
                        {
                            lvShowAllMovie.SmallImageList = new ImageList();
                            lvShowAllMovie.SmallImageList.ImageSize = new Size(64, 64);
                            lvShowAllMovie.SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
                        }
                        lvShowAllMovie.SmallImageList.Images.Clear();

                        // กำหนด Columns
                        lvShowAllMovie.Columns.Add("รูปภาพ", 100, HorizontalAlignment.Left);
                        lvShowAllMovie.Columns.Add("ชื่อภาพยนตร์", 150, HorizontalAlignment.Left);
                        lvShowAllMovie.Columns.Add("วันที่ฉาย", 100, HorizontalAlignment.Left);
                        lvShowAllMovie.Columns.Add("เวลา", 80, HorizontalAlignment.Left);
                        lvShowAllMovie.Columns.Add("ประเภท", 100, HorizontalAlignment.Left);
                        lvShowAllMovie.Columns.Add("รายละเอียด", 200, HorizontalAlignment.Left);

                        foreach (DataRow row in dataTable.Rows)
                        {
                            ListViewItem item = new ListViewItem();

                            // แปลงภาพ
                            Image movieImage = null;
                            if (row["movieImage"] != DBNull.Value)
                            {
                                byte[] imgByte = (byte[])row["movieImage"];
                                movieImage = convertByteArrayToImage(imgByte);
                            }

                            string imageKey = null;
                            if (movieImage != null)
                            {
                                imageKey = $"movie_{row["movieId"]}";
                                lvShowAllMovie.SmallImageList.Images.Add(imageKey, movieImage);
                                item.ImageKey = imageKey;
                            }
                            else
                            {
                                item.ImageIndex = -1;
                            }

                            // เพิ่มข้อมูล
                            item.SubItems.Add(row["movieName"].ToString());

                            string date = Convert.ToDateTime(row["movieDate"]).ToString("dd/MM/yyyy");
                            item.SubItems.Add(date);

                            string time = $"{row["movieHour"]} ชม. {row["movieMinute"]} นาที";
                            item.SubItems.Add(time);

                            item.SubItems.Add(row["movieType"].ToString());

                            item.SubItems.Add(row["movieDetail"].ToString());

                            // เพิ่มลง ListView
                            lvShowAllMovie.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
                }
            }
        }

        private void FrmMovie_Load(object sender, EventArgs e)
        {
            getAllMovieToListView();

            // ปิดใช้งานปุ่ม "แก้ไข" และ "ลบ"
            btUpdateMovie.Enabled = false;
            btDeleteMovie.Enabled = false;
        }

        private void btSaveMovie_Click(object sender, EventArgs e)
        {
            // ตรวจสอบข้อมูลว่าง
            if (string.IsNullOrWhiteSpace(tbMovieName.Text) ||
                string.IsNullOrWhiteSpace(tbMovieDetail.Text) ||
                cbbMovieType.SelectedIndex == -1 ||
                pcbMovieImage.Image == null ||
                pcbMovieDirectorImage.Image == null)
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน และเลือกรูปภาพ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // เตรียมข้อมูล
            string movieName = tbMovieName.Text.Trim();
            string movieDetail = tbMovieDetail.Text.Trim();
            DateTime movieDate = dtpMovieDate.Value;
            int movieHour = (int)nudMovieHour.Value;
            int movieMinute = (int)nudMovieMinute.Value;
            string movieType = cbbMovieType.SelectedItem.ToString();

            byte[] movieImageBytes = convertImageToByteArray(pcbMovieImage.Image, ImageFormat.Jpeg);
            byte[] directorImageBytes = convertImageToByteArray(pcbMovieDirectorImage.Image, ImageFormat.Jpeg);


            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=MSI\SQLEXPRESS;Database=movie_collection_db;Trusted_Connection=True;"))
                {
                    string sql = @"INSERT INTO movie_tb 
                           (movieName, movieDetail, movieDate, movieHour, movieMinute, movieType, movieImage, movieDirectorImage)
                           VALUES (@name, @detail, @date, @hour, @minute, @type, @image, @directorImage)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name", SqlDbType.NVarChar, 150).Value = movieName;
                        cmd.Parameters.Add("@detail", SqlDbType.NVarChar, 500).Value = movieDetail;
                        cmd.Parameters.Add("@date", SqlDbType.Date).Value = movieDate;
                        cmd.Parameters.Add("@hour", SqlDbType.Int).Value = movieHour;
                        cmd.Parameters.Add("@minute", SqlDbType.Int).Value = movieMinute;
                        cmd.Parameters.Add("@type", SqlDbType.NVarChar, 150).Value = movieType;
                        cmd.Parameters.Add("@image", SqlDbType.Image).Value = movieImageBytes;
                        cmd.Parameters.Add("@directorImage", SqlDbType.Image).Value = directorImageBytes;

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("บันทึกข้อมูลภาพยนตร์สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getAllMovieToListView(); // โหลดข้อมูลใหม่
                            btResetMovie_Click(null, null);
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถบันทึกข้อมูลได้", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message);
            }
        }

        private void btMovieImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "เลือกไฟล์รูปภาพภาพยนตร์";
                openFileDialog.Filter = "ไฟล์รูปภาพ|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        pcbMovieImage.Image = selectedImage;
                        pcbMovieImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ไม่สามารถโหลดรูปภาพได้: " + ex.Message, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btMovieDirectorImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "เลือกรูปผู้กำกับ";
                openFileDialog.Filter = "ไฟล์รูปภาพ|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image selectedImage = Image.FromFile(openFileDialog.FileName);
                        pcbMovieDirectorImage.Image = selectedImage;
                        pcbMovieDirectorImage.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ไม่สามารถโหลดรูปภาพได้: " + ex.Message, "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btResetMovie_Click(object sender, EventArgs e)
        {
            // เคลียร์ข้อความ
            tbMovieName.Text = string.Empty;
            tbMovieDetail.Text = string.Empty;

            // รีเซตประเภท
            cbbMovieType.SelectedIndex = -1;

            // ตั้งค่าเวลาเป็น 0
            nudMovieHour.Value = 0;
            nudMovieMinute.Value = 0;

            // ลบรูปภาพ
            pcbMovieImage.Image = null;
            pcbMovieDirectorImage.Image = null;

            // เคลียร์ ID
            lbMovieId.Text = string.Empty;
            tbMovieName.Tag = null;

            // เปิดใช้งานปุ่มบันทึก และปิดปุ่มแก้ไข/ลบ
            btSaveMovie.Enabled = true;
            btUpdateMovie.Enabled = false;
            btDeleteMovie.Enabled = false;

            // เคลียร์ช่องค้นหาและ ListView
            tbSearchMovie.Text = string.Empty;
            lvShowSearchMovie.Items.Clear();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearchMovie_Click(object sender, EventArgs e)
        {
            string searchText = tbSearchMovie.Text.Trim();


            // ตรวจสอบว่าได้ป้อนข้อความหรือไม่
            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("กรุณาป้อนชื่อภาพยนตร์ที่ต้องการค้นหา", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(@"Server=MSI\SQLEXPRESS;Database=movie_collection_db;Trusted_Connection=True;"))
            {
                try
                {
                    string sql = "SELECT movieId, movieName FROM movie_tb WHERE movieName LIKE @search";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // เตรียม ListView
                            lvShowSearchMovie.Items.Clear();
                            lvShowSearchMovie.Columns.Clear();
                            lvShowSearchMovie.View = View.Details;
                            lvShowSearchMovie.FullRowSelect = true;

                            lvShowSearchMovie.Columns.Add("รหัส", 100);
                            lvShowSearchMovie.Columns.Add("ชื่อภาพยนตร์", 200);

                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem(reader["movieId"].ToString());
                                item.SubItems.Add(reader["movieName"].ToString());
                                lvShowSearchMovie.Items.Add(item);
                                item.Tag = reader["movieId"];
                            }

                            if (lvShowSearchMovie.Items.Count == 0)
                            {
                                MessageBox.Show("ไม่พบภาพยนตร์ที่ค้นหา", "ผลการค้นหา", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lvShowSearchMovie_ItemActivate(object sender, EventArgs e)
        {
            if (lvShowSearchMovie.SelectedItems.Count == 0 || lvShowSearchMovie.SelectedItems[0].Tag == null)
            {
                MessageBox.Show("ไม่สามารถโหลดข้อมูลได้ เนื่องจากไม่ได้เลือกภาพยนตร์อย่างถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string movieId = lvShowSearchMovie.SelectedItems[0].Tag.ToString();

            using (SqlConnection conn = new SqlConnection(@"Server=MSI\SQLEXPRESS;Database=movie_collection_db;Trusted_Connection=True;"))
            {
                string sql = "SELECT * FROM movie_tb WHERE movieId = @id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", movieId);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows && reader.Read())
                        {
                            // แสดงข้อมูลใน TextBox, ComboBox, DateTimePicker และ PictureBox
                            tbMovieName.Text = reader["movieName"].ToString();
                            tbMovieDetail.Text = reader["movieDetail"].ToString();

                            DateTime dateValue = Convert.ToDateTime(reader["movieDate"]);
                            if (dateValue >= dtpMovieDate.MinDate && dateValue <= dtpMovieDate.MaxDate)
                                dtpMovieDate.Value = dateValue;

                            nudMovieHour.Value = Convert.ToInt32(reader["movieHour"]);
                            nudMovieMinute.Value = Convert.ToInt32(reader["movieMinute"]);
                            cbbMovieType.SelectedItem = reader["movieType"].ToString();

                            // รูปภาพภาพยนตร์
                            if (reader["movieImage"] != DBNull.Value)
                            {
                                byte[] imageBytes = (byte[])reader["movieImage"];
                                pcbMovieImage.Image = convertByteArrayToImage(imageBytes);
                            }
                            else
                            {
                                pcbMovieImage.Image = null;
                            }

                            // รูปภาพผู้กำกับ
                            if (reader["movieDirectorImage"] != DBNull.Value)
                            {
                                byte[] dirImageBytes = (byte[])reader["movieDirectorImage"];
                                pcbMovieDirectorImage.Image = convertByteArrayToImage(dirImageBytes);
                            }
                            else
                            {
                                pcbMovieDirectorImage.Image = null;
                            }

                            // แสดง movieId ที่ Label
                            lbMovieId.Text = movieId;

                            // ปิดการใช้งานปุ่มบันทึก
                            btSaveMovie.Enabled = false;

                            // เปิดการใช้งานปุ่มแก้ไขและลบ
                            btUpdateMovie.Enabled = true;
                            btDeleteMovie.Enabled = true;

                            // เก็บ movieId ไว้สำหรับแก้ไขหรือลบ
                            tbMovieName.Tag = movieId;
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบข้อมูลภาพยนตร์ที่เลือก", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btDeleteMovie_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่ามี movieId อยู่ใน Tag หรือไม่
            if (tbMovieName.Tag == null)
            {
                MessageBox.Show("กรุณาเลือกภาพยนตร์ที่ต้องการลบ", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string movieId = tbMovieName.Tag.ToString();

            // กล่องยืนยัน
            DialogResult result = MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบข้อมูลภาพยนตร์นี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(@"Server=MSI\SQLEXPRESS;Database=movie_collection_db;Trusted_Connection=True;"))
                    {
                        string sql = "DELETE FROM movie_tb WHERE movieId = @id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", movieId);
                            conn.Open();

                            int rows = cmd.ExecuteNonQuery();
                            if (rows > 0)
                            {
                                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                getAllMovieToListView(); // โหลดข้อมูลใหม่
                                btResetMovie_Click(null, null); // รีเซตหน้าจอ
                            }
                            else
                            {
                                MessageBox.Show("ไม่สามารถลบข้อมูลได้", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btUpdateMovie_Click(object sender, EventArgs e)
        {
            // ตรวจสอบว่าเลือกภาพยนตร์ที่จะแก้ไขหรือไม่
            if (tbMovieName.Tag == null)
            {
                MessageBox.Show("กรุณาเลือกภาพยนตร์ที่ต้องการแก้ไข", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ตรวจสอบข้อมูลว่าง
            if (string.IsNullOrWhiteSpace(tbMovieName.Text) ||
                string.IsNullOrWhiteSpace(tbMovieDetail.Text) ||
                cbbMovieType.SelectedIndex == -1 ||
                pcbMovieImage.Image == null ||
                pcbMovieDirectorImage.Image == null)
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบถ้วน และเลือกรูปภาพ", "ข้อมูลไม่ครบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // เตรียมข้อมูล
            string movieId = tbMovieName.Tag.ToString();
            string movieName = tbMovieName.Text.Trim();
            string movieDetail = tbMovieDetail.Text.Trim();
            DateTime movieDate = dtpMovieDate.Value;
            int movieHour = (int)nudMovieHour.Value;
            int movieMinute = (int)nudMovieMinute.Value;
            string movieType = cbbMovieType.SelectedItem.ToString();

            byte[] movieImageBytes = convertImageToByteArray(pcbMovieImage.Image, ImageFormat.Jpeg);
            byte[] directorImageBytes = convertImageToByteArray(pcbMovieDirectorImage.Image, ImageFormat.Jpeg);

            try
            {
                using (SqlConnection conn = new SqlConnection(@"Server=MSI\SQLEXPRESS;Database=movie_collection_db;Trusted_Connection=True;"))
                {
                    string sql = @"UPDATE movie_tb 
                           SET movieName = @name,
                               movieDetail = @detail,
                               movieDate = @date,
                               movieHour = @hour,
                               movieMinute = @minute,
                               movieType = @type,
                               movieImage = @image,
                               movieDirectorImage = @directorImage
                           WHERE movieId = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", movieName);
                        cmd.Parameters.AddWithValue("@detail", movieDetail);
                        cmd.Parameters.AddWithValue("@date", movieDate);
                        cmd.Parameters.AddWithValue("@hour", movieHour);
                        cmd.Parameters.AddWithValue("@minute", movieMinute);
                        cmd.Parameters.AddWithValue("@type", movieType);
                        cmd.Parameters.AddWithValue("@image", movieImageBytes);
                        cmd.Parameters.AddWithValue("@directorImage", directorImageBytes);
                        cmd.Parameters.AddWithValue("@id", movieId);

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("แก้ไขข้อมูลภาพยนตร์สำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getAllMovieToListView(); // โหลดข้อมูลใหม่
                            btResetMovie_Click(null, null); // รีเซตหน้าจอ
                        }
                        else
                        {
                            MessageBox.Show("ไม่สามารถแก้ไขข้อมูลได้", "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาด: " + ex.Message, "ผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
