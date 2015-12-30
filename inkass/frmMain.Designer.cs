namespace inkass
{
    partial class frmMain
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbPath1 = new System.Windows.Forms.TextBox();
            this.btnPath1 = new System.Windows.Forms.Button();
            this.btnPath2 = new System.Windows.Forms.Button();
            this.tbPath2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOptions = new System.Windows.Forms.Button();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDt = new System.Windows.Forms.DateTimePicker();
            this.btnPath3 = new System.Windows.Forms.Button();
            this.tbPath3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSaveXXI = new System.Windows.Forms.Button();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Файл для загрузки";
            // 
            // tbPath1
            // 
            this.tbPath1.Location = new System.Drawing.Point(21, 77);
            this.tbPath1.Name = "tbPath1";
            this.tbPath1.Size = new System.Drawing.Size(416, 20);
            this.tbPath1.TabIndex = 3;
            // 
            // btnPath1
            // 
            this.btnPath1.Location = new System.Drawing.Point(443, 74);
            this.btnPath1.Name = "btnPath1";
            this.btnPath1.Size = new System.Drawing.Size(44, 24);
            this.btnPath1.TabIndex = 4;
            this.btnPath1.Text = "{...}";
            this.btnPath1.UseVisualStyleBackColor = true;
            this.btnPath1.Click += new System.EventHandler(this.btnPath1_Click);
            // 
            // btnPath2
            // 
            this.btnPath2.Location = new System.Drawing.Point(443, 123);
            this.btnPath2.Name = "btnPath2";
            this.btnPath2.Size = new System.Drawing.Size(44, 24);
            this.btnPath2.TabIndex = 7;
            this.btnPath2.Text = "{...}";
            this.btnPath2.UseVisualStyleBackColor = true;
            this.btnPath2.Click += new System.EventHandler(this.btnPath2_Click);
            // 
            // tbPath2
            // 
            this.tbPath2.Location = new System.Drawing.Point(21, 126);
            this.tbPath2.Name = "tbPath2";
            this.tbPath2.Size = new System.Drawing.Size(416, 20);
            this.tbPath2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Путь для выгрузки";
            // 
            // btnOptions
            // 
            this.btnOptions.Location = new System.Drawing.Point(395, 277);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(92, 36);
            this.btnOptions.TabIndex = 15;
            this.btnOptions.Text = "Настройки";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // ofd
            // 
            this.ofd.Filter = "Xml файлы (*.xml)|*.xml|Все файлы (*.*)|*.*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Дата";
            // 
            // tbDt
            // 
            this.tbDt.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tbDt.Location = new System.Drawing.Point(21, 25);
            this.tbDt.Name = "tbDt";
            this.tbDt.Size = new System.Drawing.Size(91, 20);
            this.tbDt.TabIndex = 1;
            // 
            // btnPath3
            // 
            this.btnPath3.Location = new System.Drawing.Point(443, 173);
            this.btnPath3.Name = "btnPath3";
            this.btnPath3.Size = new System.Drawing.Size(44, 24);
            this.btnPath3.TabIndex = 10;
            this.btnPath3.Text = "{...}";
            this.btnPath3.UseVisualStyleBackColor = true;
            this.btnPath3.Click += new System.EventHandler(this.btnPath3_Click);
            // 
            // tbPath3
            // 
            this.tbPath3.Location = new System.Drawing.Point(21, 176);
            this.tbPath3.Name = "tbPath3";
            this.tbPath3.Size = new System.Drawing.Size(416, 20);
            this.tbPath3.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Путь для выгрузки в Инверсию";
            // 
            // btnSaveXXI
            // 
            this.btnSaveXXI.Location = new System.Drawing.Point(297, 277);
            this.btnSaveXXI.Name = "btnSaveXXI";
            this.btnSaveXXI.Size = new System.Drawing.Size(92, 36);
            this.btnSaveXXI.TabIndex = 14;
            this.btnSaveXXI.Text = "Выгрузить в XXI";
            this.btnSaveXXI.UseVisualStyleBackColor = true;
            this.btnSaveXXI.Click += new System.EventHandler(this.btnSaveXXI_Click);
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(21, 226);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(416, 20);
            this.tbUserName.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Имя пользователя";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 343);
            this.Controls.Add(this.tbUserName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveXXI);
            this.Controls.Add(this.btnPath3);
            this.Controls.Add(this.tbPath3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnPath2);
            this.Controls.Add(this.tbPath2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPath1);
            this.Controls.Add(this.tbPath1);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Инкассация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPath1;
        private System.Windows.Forms.Button btnPath1;
        private System.Windows.Forms.Button btnPath2;
        private System.Windows.Forms.TextBox tbPath2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker tbDt;
        private System.Windows.Forms.Button btnPath3;
        private System.Windows.Forms.TextBox tbPath3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSaveXXI;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label5;
    }
}

