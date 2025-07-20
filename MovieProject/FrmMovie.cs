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

        private byte[] convertImageToByteArray(Image image, ImageFormat imageFormat)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, imageFormat);
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
    }
}
