
using AutoCopy.Controls;

namespace AutoCopy
{
    partial class Demo
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
            this.resource_lbl = new System.Windows.Forms.Label();
            this.ftp_lbl = new System.Windows.Forms.Label();
            this.confirm_btn = new System.Windows.Forms.Button();
            this.user_pw_lbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pw_txt = new AutoCopy.Controls.TextBoxEx();
            this.user_txt = new AutoCopy.Controls.TextBoxEx();
            this.ftp_input = new AutoCopy.Controls.TextBoxEx();
            this.resource_input = new AutoCopy.Controls.TextBoxEx();
            this.stop_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // resource_lbl
            // 
            this.resource_lbl.AutoSize = true;
            this.resource_lbl.Location = new System.Drawing.Point(200, 50);
            this.resource_lbl.Name = "resource_lbl";
            this.resource_lbl.Size = new System.Drawing.Size(65, 12);
            this.resource_lbl.TabIndex = 0;
            this.resource_lbl.Text = "监视的路径";
            // 
            // ftp_lbl
            // 
            this.ftp_lbl.AutoSize = true;
            this.ftp_lbl.Location = new System.Drawing.Point(200, 140);
            this.ftp_lbl.Name = "ftp_lbl";
            this.ftp_lbl.Size = new System.Drawing.Size(86, 12);
            this.ftp_lbl.TabIndex = 2;
            this.ftp_lbl.Text = "FTP服务器路径";
            // 
            // confirm_btn
            // 
            this.confirm_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.confirm_btn.Location = new System.Drawing.Point(200, 328);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(75, 23);
            this.confirm_btn.TabIndex = 4;
            this.confirm_btn.Text = "开始监视";
            this.confirm_btn.UseVisualStyleBackColor = false;
            this.confirm_btn.Click += new System.EventHandler(this.confirm_btn_Click);
            // 
            // user_pw_lbl
            // 
            this.user_pw_lbl.AutoSize = true;
            this.user_pw_lbl.Location = new System.Drawing.Point(200, 220);
            this.user_pw_lbl.Name = "user_pw_lbl";
            this.user_pw_lbl.Size = new System.Drawing.Size(71, 12);
            this.user_pw_lbl.TabIndex = 5;
            this.user_pw_lbl.Text = "用户名/密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // pw_txt
            // 
            this.pw_txt.Location = new System.Drawing.Point(383, 250);
            this.pw_txt.Name = "pw_txt";
            this.pw_txt.PlaceHolderStr = "密码";
            this.pw_txt.Size = new System.Drawing.Size(172, 19);
            this.pw_txt.TabIndex = 8;
            this.pw_txt.TextChanged += new System.EventHandler(this.pw_txt_TextChanged);
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(200, 250);
            this.user_txt.Name = "user_txt";
            this.user_txt.PlaceHolderStr = "用户名";
            this.user_txt.Size = new System.Drawing.Size(100, 19);
            this.user_txt.TabIndex = 6;
            // 
            // ftp_input
            // 
            this.ftp_input.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ftp_input.Location = new System.Drawing.Point(200, 170);
            this.ftp_input.Name = "ftp_input";
            this.ftp_input.PlaceHolderStr = "请输入目标FTP路径";
            this.ftp_input.Size = new System.Drawing.Size(300, 23);
            this.ftp_input.TabIndex = 3;
            // 
            // resource_input
            // 
            this.resource_input.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.resource_input.Location = new System.Drawing.Point(200, 80);
            this.resource_input.Name = "resource_input";
            this.resource_input.PlaceHolderStr = "请输入要监视的文件路径";
            this.resource_input.Size = new System.Drawing.Size(300, 23);
            this.resource_input.TabIndex = 1;
            // 
            // stop_btn
            // 
            this.stop_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.stop_btn.Location = new System.Drawing.Point(200, 328);
            this.stop_btn.Name = "stop_btn";
            this.stop_btn.Size = new System.Drawing.Size(75, 23);
            this.stop_btn.TabIndex = 9;
            this.stop_btn.Text = "停止监视";
            this.stop_btn.UseVisualStyleBackColor = false;
            this.stop_btn.Visible = false;
            this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stop_btn);
            this.Controls.Add(this.pw_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.user_pw_lbl);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.ftp_input);
            this.Controls.Add(this.ftp_lbl);
            this.Controls.Add(this.resource_input);
            this.Controls.Add(this.resource_lbl);
            this.Name = "Demo";
            this.Text = "Demo";
            this.Activated += new System.EventHandler(this.Demo_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resource_lbl;
        private System.Windows.Forms.Label ftp_lbl;
        private System.Windows.Forms.Button confirm_btn;
        private TextBoxEx resource_input;
        private TextBoxEx ftp_input;
        private System.Windows.Forms.Label user_pw_lbl;
        private System.Windows.Forms.Label label2;
        private TextBoxEx user_txt;
        private TextBoxEx pw_txt;
        private System.Windows.Forms.Button stop_btn;
    }
}

