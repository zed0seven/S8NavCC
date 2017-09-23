namespace S8NavCC
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.usbdbgbtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.driverbtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.upnotesbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Before using this program,";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(307, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "-   make sure you have enabled USB-debugging on your device";
            // 
            // usbdbgbtn
            // 
            this.usbdbgbtn.Location = new System.Drawing.Point(395, 31);
            this.usbdbgbtn.Name = "usbdbgbtn";
            this.usbdbgbtn.Size = new System.Drawing.Size(131, 23);
            this.usbdbgbtn.TabIndex = 2;
            this.usbdbgbtn.Text = "Enable USB-debugging";
            this.usbdbgbtn.UseVisualStyleBackColor = true;
            this.usbdbgbtn.Click += new System.EventHandler(this.usbdbgbtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "-   make sure USB-debugging drivers are installed on your computer";
            // 
            // driverbtn
            // 
            this.driverbtn.Location = new System.Drawing.Point(395, 151);
            this.driverbtn.Name = "driverbtn";
            this.driverbtn.Size = new System.Drawing.Size(131, 23);
            this.driverbtn.TabIndex = 4;
            this.driverbtn.Text = "Are drivers installed?";
            this.driverbtn.UseVisualStyleBackColor = true;
            this.driverbtn.Click += new System.EventHandler(this.driverbtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(536, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "-   when plugging in your phone, make sure its plugged in to a data transmittable" +
    " port and not a charge only port. ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(482, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "(just plug your phone directly in to your computer with the original charging cab" +
    "le and you will be fine.)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(535, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "-   now, with your device UNLOCKED, plug your device in to your computer with the" +
    " original USB charging cable";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(524, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "and wait for device drivers to be installed (popup will be displayed about device" +
    " options) and press the \'Check\'";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(525, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = " button once still with the device unlocked. There will be a popup asking if USB-" +
    "debugging should be allowed.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(512, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Check \'Always allow\' for ease of use next time. \'Device found!\' will be displayed" +
    " after pressing \'Check\' again";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(453, 16);
            this.label10.TabIndex = 11;
            this.label10.Text = "If you went through \'Before using this program.\' without any errors";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 257);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(529, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Referring to this page for instructions of how to use this program again is not n" +
    "ecessary if you dont come across";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 270);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(424, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "an error next time you\'re trying to change your Galaxy S8 or Note 8\'s Navigation " +
    "bar color";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 294);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(429, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Just plug your phone in to your computer with the screen on and proceed to press " +
    "\'Check\'";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(5, 131);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(294, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "Phone status still says \'Device not found.\'";
            // 
            // upnotesbtn
            // 
            this.upnotesbtn.Location = new System.Drawing.Point(448, 304);
            this.upnotesbtn.Name = "upnotesbtn";
            this.upnotesbtn.Size = new System.Drawing.Size(86, 23);
            this.upnotesbtn.TabIndex = 16;
            this.upnotesbtn.Text = "Update notes";
            this.upnotesbtn.UseVisualStyleBackColor = true;
            this.upnotesbtn.Click += new System.EventHandler(this.upnotesbtn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 330);
            this.Controls.Add(this.upnotesbtn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.driverbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.usbdbgbtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button usbdbgbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button driverbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button upnotesbtn;
    }
}