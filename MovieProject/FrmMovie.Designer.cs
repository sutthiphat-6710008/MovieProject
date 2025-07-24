﻿namespace MovieProject
{
    partial class FrmMovie
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMovie));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btMovieDirectorImage = new System.Windows.Forms.Button();
            this.btMovieImage = new System.Windows.Forms.Button();
            this.pcbMovieDirectorImage = new System.Windows.Forms.PictureBox();
            this.pcbMovieImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMovieDetail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lbMovieId = new System.Windows.Forms.Label();
            this.tbMovieName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbMovieType = new System.Windows.Forms.ComboBox();
            this.dtpMovieDate = new System.Windows.Forms.DateTimePicker();
            this.nudMovieHour = new System.Windows.Forms.NumericUpDown();
            this.nudMovieMinute = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btResetMovie = new System.Windows.Forms.Button();
            this.lvShowAllMovie = new System.Windows.Forms.ListView();
            this.btExit = new System.Windows.Forms.Button();
            this.btDeleteMovie = new System.Windows.Forms.Button();
            this.btUpdateMovie = new System.Windows.Forms.Button();
            this.btSaveMovie = new System.Windows.Forms.Button();
            this.lvShowSearchMovie = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btSearchMovie = new System.Windows.Forms.Button();
            this.tbSearchMovie = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMovieDirectorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMovieImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovieHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovieMinute)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.btMovieDirectorImage);
            this.groupBox2.Controls.Add(this.btMovieImage);
            this.groupBox2.Controls.Add(this.pcbMovieDirectorImage);
            this.groupBox2.Controls.Add(this.pcbMovieImage);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbMovieDetail);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lbMovieId);
            this.groupBox2.Controls.Add(this.tbMovieName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbbMovieType);
            this.groupBox2.Controls.Add(this.dtpMovieDate);
            this.groupBox2.Controls.Add(this.nudMovieHour);
            this.groupBox2.Controls.Add(this.nudMovieMinute);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(333, 39);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(613, 390);
            this.groupBox2.TabIndex = 53;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ข้อมูลภาพยนต์";
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(415, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(163, 23);
            this.label16.TabIndex = 26;
            this.label16.Text = "รูปตัวอย่างภาพยนต์";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(415, 212);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(176, 23);
            this.label15.TabIndex = 25;
            this.label15.Text = "รูปผู้กำกับภาพยนต์";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btMovieDirectorImage
            // 
            this.btMovieDirectorImage.Location = new System.Drawing.Point(561, 338);
            this.btMovieDirectorImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btMovieDirectorImage.Name = "btMovieDirectorImage";
            this.btMovieDirectorImage.Size = new System.Drawing.Size(47, 30);
            this.btMovieDirectorImage.TabIndex = 24;
            this.btMovieDirectorImage.Text = "...";
            this.btMovieDirectorImage.UseVisualStyleBackColor = true;
            this.btMovieDirectorImage.Click += new System.EventHandler(this.btMovieDirectorImage_Click);
            // 
            // btMovieImage
            // 
            this.btMovieImage.Location = new System.Drawing.Point(561, 166);
            this.btMovieImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btMovieImage.Name = "btMovieImage";
            this.btMovieImage.Size = new System.Drawing.Size(47, 30);
            this.btMovieImage.TabIndex = 23;
            this.btMovieImage.Text = "...";
            this.btMovieImage.UseVisualStyleBackColor = true;
            this.btMovieImage.Click += new System.EventHandler(this.btMovieImage_Click);
            // 
            // pcbMovieDirectorImage
            // 
            this.pcbMovieDirectorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbMovieDirectorImage.Location = new System.Drawing.Point(419, 238);
            this.pcbMovieDirectorImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pcbMovieDirectorImage.Name = "pcbMovieDirectorImage";
            this.pcbMovieDirectorImage.Size = new System.Drawing.Size(127, 130);
            this.pcbMovieDirectorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMovieDirectorImage.TabIndex = 22;
            this.pcbMovieDirectorImage.TabStop = false;
            // 
            // pcbMovieImage
            // 
            this.pcbMovieImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbMovieImage.InitialImage = null;
            this.pcbMovieImage.Location = new System.Drawing.Point(419, 59);
            this.pcbMovieImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pcbMovieImage.Name = "pcbMovieImage";
            this.pcbMovieImage.Size = new System.Drawing.Size(127, 130);
            this.pcbMovieImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbMovieImage.TabIndex = 21;
            this.pcbMovieImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "รหัสภาพยนต์";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อภาพยนต์";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "วันที่ออกฉาย";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbMovieDetail
            // 
            this.tbMovieDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMovieDetail.Location = new System.Drawing.Point(135, 103);
            this.tbMovieDetail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMovieDetail.Multiline = true;
            this.tbMovieDetail.Name = "tbMovieDetail";
            this.tbMovieDetail.Size = new System.Drawing.Size(251, 68);
            this.tbMovieDetail.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(11, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "ความยาว";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(11, 103);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 23);
            this.label13.TabIndex = 19;
            this.label13.Text = "รายละเอียด";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbMovieId
            // 
            this.lbMovieId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lbMovieId.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMovieId.Location = new System.Drawing.Point(135, 33);
            this.lbMovieId.Name = "lbMovieId";
            this.lbMovieId.Size = new System.Drawing.Size(251, 23);
            this.lbMovieId.TabIndex = 4;
            this.lbMovieId.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbMovieName
            // 
            this.tbMovieName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMovieName.Location = new System.Drawing.Point(135, 68);
            this.tbMovieName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbMovieName.Name = "tbMovieName";
            this.tbMovieName.Size = new System.Drawing.Size(251, 23);
            this.tbMovieName.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-13, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 23);
            this.label6.TabIndex = 6;
            this.label6.Text = "ประเภทภาพยนต์";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbMovieType
            // 
            this.cbbMovieType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbMovieType.FormattingEnabled = true;
            this.cbbMovieType.Items.AddRange(new object[] {
            "Action",
            "Adventure",
            "Drama",
            "Sci-Fi",
            "War",
            "Thiller",
            "Comedy",
            "Fantasy"});
            this.cbbMovieType.Location = new System.Drawing.Point(139, 268);
            this.cbbMovieType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbMovieType.Name = "cbbMovieType";
            this.cbbMovieType.Size = new System.Drawing.Size(248, 25);
            this.cbbMovieType.TabIndex = 7;
            // 
            // dtpMovieDate
            // 
            this.dtpMovieDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpMovieDate.Location = new System.Drawing.Point(135, 190);
            this.dtpMovieDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpMovieDate.Name = "dtpMovieDate";
            this.dtpMovieDate.Size = new System.Drawing.Size(251, 23);
            this.dtpMovieDate.TabIndex = 8;
            // 
            // nudMovieHour
            // 
            this.nudMovieHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMovieHour.Location = new System.Drawing.Point(139, 228);
            this.nudMovieHour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudMovieHour.Name = "nudMovieHour";
            this.nudMovieHour.Size = new System.Drawing.Size(43, 23);
            this.nudMovieHour.TabIndex = 9;
            // 
            // nudMovieMinute
            // 
            this.nudMovieMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudMovieMinute.Location = new System.Drawing.Point(265, 228);
            this.nudMovieMinute.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudMovieMinute.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMovieMinute.Name = "nudMovieMinute";
            this.nudMovieMinute.Size = new System.Drawing.Size(43, 23);
            this.nudMovieMinute.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(315, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 23);
            this.label8.TabIndex = 12;
            this.label8.Text = "นาที";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(187, 226);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "ชั่วโมง";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(45, 442);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(269, 23);
            this.label14.TabIndex = 51;
            this.label14.Text = "ภาพยนต์ทั้งหมด";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btResetMovie
            // 
            this.btResetMovie.Image = ((System.Drawing.Image)(resources.GetObject("btResetMovie.Image")));
            this.btResetMovie.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btResetMovie.Location = new System.Drawing.Point(987, 469);
            this.btResetMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btResetMovie.Name = "btResetMovie";
            this.btResetMovie.Size = new System.Drawing.Size(137, 69);
            this.btResetMovie.TabIndex = 57;
            this.btResetMovie.Text = "ยกเลิก";
            this.btResetMovie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btResetMovie.UseVisualStyleBackColor = true;
            this.btResetMovie.Click += new System.EventHandler(this.btResetMovie_Click);
            // 
            // lvShowAllMovie
            // 
            this.lvShowAllMovie.HideSelection = false;
            this.lvShowAllMovie.Location = new System.Drawing.Point(49, 481);
            this.lvShowAllMovie.Margin = new System.Windows.Forms.Padding(4);
            this.lvShowAllMovie.Name = "lvShowAllMovie";
            this.lvShowAllMovie.Size = new System.Drawing.Size(891, 203);
            this.lvShowAllMovie.TabIndex = 50;
            this.lvShowAllMovie.UseCompatibleStateImageBehavior = false;
            // 
            // btExit
            // 
            this.btExit.Image = ((System.Drawing.Image)(resources.GetObject("btExit.Image")));
            this.btExit.Location = new System.Drawing.Point(987, 554);
            this.btExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(137, 69);
            this.btExit.TabIndex = 58;
            this.btExit.Text = "Exit";
            this.btExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btDeleteMovie
            // 
            this.btDeleteMovie.Image = ((System.Drawing.Image)(resources.GetObject("btDeleteMovie.Image")));
            this.btDeleteMovie.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btDeleteMovie.Location = new System.Drawing.Point(987, 206);
            this.btDeleteMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDeleteMovie.Name = "btDeleteMovie";
            this.btDeleteMovie.Size = new System.Drawing.Size(137, 69);
            this.btDeleteMovie.TabIndex = 56;
            this.btDeleteMovie.Text = "ลบข้อมูล";
            this.btDeleteMovie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btDeleteMovie.UseVisualStyleBackColor = true;
            this.btDeleteMovie.Click += new System.EventHandler(this.btDeleteMovie_Click);
            // 
            // btUpdateMovie
            // 
            this.btUpdateMovie.Image = ((System.Drawing.Image)(resources.GetObject("btUpdateMovie.Image")));
            this.btUpdateMovie.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btUpdateMovie.Location = new System.Drawing.Point(987, 126);
            this.btUpdateMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btUpdateMovie.Name = "btUpdateMovie";
            this.btUpdateMovie.Size = new System.Drawing.Size(137, 69);
            this.btUpdateMovie.TabIndex = 55;
            this.btUpdateMovie.Text = "บันทึกแก้ไขข้อมูล";
            this.btUpdateMovie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btUpdateMovie.UseVisualStyleBackColor = true;
            this.btUpdateMovie.Click += new System.EventHandler(this.btUpdateMovie_Click);
            // 
            // btSaveMovie
            // 
            this.btSaveMovie.Image = ((System.Drawing.Image)(resources.GetObject("btSaveMovie.Image")));
            this.btSaveMovie.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSaveMovie.Location = new System.Drawing.Point(987, 46);
            this.btSaveMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSaveMovie.Name = "btSaveMovie";
            this.btSaveMovie.Size = new System.Drawing.Size(137, 69);
            this.btSaveMovie.TabIndex = 54;
            this.btSaveMovie.Text = "บันทึกเพิ่มข้อมูล";
            this.btSaveMovie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSaveMovie.UseVisualStyleBackColor = true;
            this.btSaveMovie.Click += new System.EventHandler(this.btSaveMovie_Click);
            // 
            // lvShowSearchMovie
            // 
            this.lvShowSearchMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvShowSearchMovie.HideSelection = false;
            this.lvShowSearchMovie.Location = new System.Drawing.Point(24, 116);
            this.lvShowSearchMovie.Margin = new System.Windows.Forms.Padding(4);
            this.lvShowSearchMovie.Name = "lvShowSearchMovie";
            this.lvShowSearchMovie.Size = new System.Drawing.Size(213, 251);
            this.lvShowSearchMovie.TabIndex = 33;
            this.lvShowSearchMovie.UseCompatibleStateImageBehavior = false;
            this.lvShowSearchMovie.ItemActivate += new System.EventHandler(this.lvShowSearchMovie_ItemActivate);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvShowSearchMovie);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btSearchMovie);
            this.groupBox1.Controls.Add(this.tbSearchMovie);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(48, 39);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(267, 390);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ค้นหาภาพยนต์";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(20, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "ชื่อภาพยนต์";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btSearchMovie
            // 
            this.btSearchMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSearchMovie.Location = new System.Drawing.Point(164, 68);
            this.btSearchMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btSearchMovie.Name = "btSearchMovie";
            this.btSearchMovie.Size = new System.Drawing.Size(75, 23);
            this.btSearchMovie.TabIndex = 22;
            this.btSearchMovie.Text = "ค้นหา";
            this.btSearchMovie.UseVisualStyleBackColor = true;
            this.btSearchMovie.Click += new System.EventHandler(this.btSearchMovie_Click);
            // 
            // tbSearchMovie
            // 
            this.tbSearchMovie.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearchMovie.Location = new System.Drawing.Point(21, 69);
            this.tbSearchMovie.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSearchMovie.Name = "tbSearchMovie";
            this.tbSearchMovie.Size = new System.Drawing.Size(137, 23);
            this.tbSearchMovie.TabIndex = 21;
            // 
            // FrmMovie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 730);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btResetMovie);
            this.Controls.Add(this.lvShowAllMovie);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btDeleteMovie);
            this.Controls.Add(this.btUpdateMovie);
            this.Controls.Add(this.btSaveMovie);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmMovie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "โปรแกรมจัดการข้อมูลภาพยนต์ ";
            this.Load += new System.EventHandler(this.FrmMovie_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMovieDirectorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbMovieImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovieHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMovieMinute)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btMovieDirectorImage;
        private System.Windows.Forms.Button btMovieImage;
        private System.Windows.Forms.PictureBox pcbMovieDirectorImage;
        private System.Windows.Forms.PictureBox pcbMovieImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMovieDetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lbMovieId;
        private System.Windows.Forms.TextBox tbMovieName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbMovieType;
        private System.Windows.Forms.DateTimePicker dtpMovieDate;
        private System.Windows.Forms.NumericUpDown nudMovieHour;
        private System.Windows.Forms.NumericUpDown nudMovieMinute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btResetMovie;
        private System.Windows.Forms.ListView lvShowAllMovie;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Button btDeleteMovie;
        private System.Windows.Forms.Button btUpdateMovie;
        private System.Windows.Forms.Button btSaveMovie;
        private System.Windows.Forms.ListView lvShowSearchMovie;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btSearchMovie;
        private System.Windows.Forms.TextBox tbSearchMovie;
    }
}

