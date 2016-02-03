namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.fileType = new System.Windows.Forms.RadioButton();
            this.folderType = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.originalName = new System.Windows.Forms.RadioButton();
            this.defaultName = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.autoFill = new System.Windows.Forms.CheckBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.noRepeat = new System.Windows.Forms.CheckBox();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cocos2DAtlas = new System.Windows.Forms.CheckBox();
            this.noDataFile = new System.Windows.Forms.CheckBox();
            this.ignoreOffset = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(121, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(121, 42);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(247, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(374, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(28, 20);
            this.button1.TabIndex = 3;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSourceImage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Source Data";
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(121, 16);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(247, 20);
            this.textBox3.TabIndex = 7;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.Location = new System.Drawing.Point(12, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Output Name";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(374, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(28, 20);
            this.button2.TabIndex = 10;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSourceData_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(374, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(28, 20);
            this.button3.TabIndex = 13;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnOutputDirectory_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(12, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Output Directory";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(127, 16);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(241, 20);
            this.textBox4.TabIndex = 11;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.button4.Location = new System.Drawing.Point(6, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 67);
            this.button4.TabIndex = 14;
            this.button4.Text = "Cut";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(656, 483);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(83, 23);
            this.button5.TabIndex = 15;
            this.button5.Text = "Exit";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // fileType
            // 
            this.fileType.AutoSize = true;
            this.fileType.Checked = true;
            this.fileType.Location = new System.Drawing.Point(12, 19);
            this.fileType.Name = "fileType";
            this.fileType.Size = new System.Drawing.Size(41, 17);
            this.fileType.TabIndex = 18;
            this.fileType.TabStop = true;
            this.fileType.Text = "File";
            this.fileType.UseVisualStyleBackColor = true;
            this.fileType.CheckedChanged += new System.EventHandler(this.radioButtonFile_CheckedChanged);
            // 
            // folderType
            // 
            this.folderType.AutoSize = true;
            this.folderType.Location = new System.Drawing.Point(12, 43);
            this.folderType.Name = "folderType";
            this.folderType.Size = new System.Drawing.Size(54, 17);
            this.folderType.TabIndex = 19;
            this.folderType.TabStop = true;
            this.folderType.Text = "Folder";
            this.folderType.UseVisualStyleBackColor = true;
            this.folderType.CheckedChanged += new System.EventHandler(this.radioButtonFolder_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.folderType);
            this.groupBox1.Controls.Add(this.fileType);
            this.groupBox1.Location = new System.Drawing.Point(426, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(106, 73);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source Type";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 73);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "File";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Location = new System.Drawing.Point(6, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 48);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Folder";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Source Directory";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(374, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(28, 20);
            this.button8.TabIndex = 3;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonSourceDirectory_Click);
            // 
            // textBox5
            // 
            this.textBox5.Enabled = false;
            this.textBox5.Location = new System.Drawing.Point(127, 42);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(241, 20);
            this.textBox5.TabIndex = 1;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox8);
            this.groupBox4.Controls.Add(this.groupBox2);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.groupBox1);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(536, 236);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Source Input";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.originalName);
            this.groupBox8.Controls.Add(this.defaultName);
            this.groupBox8.Location = new System.Drawing.Point(426, 152);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(103, 74);
            this.groupBox8.TabIndex = 24;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Output Name";
            // 
            // originalName
            // 
            this.originalName.AutoSize = true;
            this.originalName.Enabled = false;
            this.originalName.Location = new System.Drawing.Point(6, 42);
            this.originalName.Name = "originalName";
            this.originalName.Size = new System.Drawing.Size(88, 17);
            this.originalName.TabIndex = 1;
            this.originalName.Text = "OriginalName";
            this.originalName.UseVisualStyleBackColor = true;
            this.originalName.CheckedChanged += new System.EventHandler(this.originalName_CheckedChanged);
            // 
            // defaultName
            // 
            this.defaultName.AutoSize = true;
            this.defaultName.Checked = true;
            this.defaultName.Enabled = false;
            this.defaultName.Location = new System.Drawing.Point(6, 19);
            this.defaultName.Name = "defaultName";
            this.defaultName.Size = new System.Drawing.Size(87, 17);
            this.defaultName.TabIndex = 0;
            this.defaultName.TabStop = true;
            this.defaultName.Text = "DefaultName";
            this.defaultName.UseVisualStyleBackColor = true;
            this.defaultName.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Location = new System.Drawing.Point(6, 152);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(414, 74);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Source Output";
            // 
            // autoFill
            // 
            this.autoFill.AutoSize = true;
            this.autoFill.Checked = true;
            this.autoFill.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoFill.Location = new System.Drawing.Point(554, 55);
            this.autoFill.Name = "autoFill";
            this.autoFill.Size = new System.Drawing.Size(81, 17);
            this.autoFill.TabIndex = 27;
            this.autoFill.Text = "Info Auto-fill";
            this.autoFill.UseVisualStyleBackColor = true;
            this.autoFill.CheckedChanged += new System.EventHandler(this.checkBoxAutoFill_CheckedChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 501);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(526, 23);
            this.progressBar1.TabIndex = 28;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(6, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(356, 216);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 30;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.pictureBox1);
            this.groupBox6.Controls.Add(this.label8);
            this.groupBox6.Location = new System.Drawing.Point(18, 254);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(368, 241);
            this.groupBox6.TabIndex = 31;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Source Image";
            // 
            // noRepeat
            // 
            this.noRepeat.AutoSize = true;
            this.noRepeat.Location = new System.Drawing.Point(554, 99);
            this.noRepeat.Name = "noRepeat";
            this.noRepeat.Size = new System.Drawing.Size(78, 17);
            this.noRepeat.TabIndex = 32;
            this.noRepeat.Text = "No Repeat";
            this.noRepeat.UseVisualStyleBackColor = true;
            this.noRepeat.CheckedChanged += new System.EventHandler(this.checkBoxNoRepeat_CheckedChanged);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.button6.Location = new System.Drawing.Point(6, 92);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(86, 67);
            this.button6.TabIndex = 33;
            this.button6.Text = "Create Repeat";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.buttonFormRepeatImg_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.button4);
            this.groupBox7.Controls.Add(this.button6);
            this.groupBox7.Location = new System.Drawing.Point(650, 277);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(99, 167);
            this.groupBox7.TabIndex = 34;
            this.groupBox7.TabStop = false;
            // 
            // cocos2DAtlas
            // 
            this.cocos2DAtlas.AutoSize = true;
            this.cocos2DAtlas.Checked = true;
            this.cocos2DAtlas.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cocos2DAtlas.Location = new System.Drawing.Point(554, 32);
            this.cocos2DAtlas.Name = "cocos2DAtlas";
            this.cocos2DAtlas.Size = new System.Drawing.Size(96, 17);
            this.cocos2DAtlas.TabIndex = 35;
            this.cocos2DAtlas.Text = "Cocos2D Atlas";
            this.cocos2DAtlas.UseVisualStyleBackColor = true;
            this.cocos2DAtlas.CheckedChanged += new System.EventHandler(this.cocos2DAtlas_CheckedChanged);
            // 
            // noDataFile
            // 
            this.noDataFile.AutoSize = true;
            this.noDataFile.Location = new System.Drawing.Point(554, 76);
            this.noDataFile.Name = "noDataFile";
            this.noDataFile.Size = new System.Drawing.Size(79, 17);
            this.noDataFile.TabIndex = 36;
            this.noDataFile.Text = "No Datafile";
            this.noDataFile.UseVisualStyleBackColor = true;
            this.noDataFile.CheckedChanged += new System.EventHandler(this.noDataFile_CheckedChanged);
            // 
            // ignoreOffset
            // 
            this.ignoreOffset.AutoSize = true;
            this.ignoreOffset.Location = new System.Drawing.Point(554, 122);
            this.ignoreOffset.Name = "ignoreOffset";
            this.ignoreOffset.Size = new System.Drawing.Size(87, 17);
            this.ignoreOffset.TabIndex = 37;
            this.ignoreOffset.Text = "Ignore Offset";
            this.ignoreOffset.UseVisualStyleBackColor = true;
            this.ignoreOffset.CheckedChanged += new System.EventHandler(this.ignoreOffset_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 536);
            this.Controls.Add(this.ignoreOffset);
            this.Controls.Add(this.noDataFile);
            this.Controls.Add(this.cocos2DAtlas);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.noRepeat);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.autoFill);
            this.Controls.Add(this.groupBox4);
            this.Name = "Form1";
            this.Text = "Texture Unpacker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.RadioButton fileType;
        private System.Windows.Forms.RadioButton folderType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox autoFill;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox noRepeat;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.RadioButton originalName;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton defaultName;
        private System.Windows.Forms.CheckBox cocos2DAtlas;
        private System.Windows.Forms.CheckBox noDataFile;
        private System.Windows.Forms.CheckBox ignoreOffset;
    }
}

