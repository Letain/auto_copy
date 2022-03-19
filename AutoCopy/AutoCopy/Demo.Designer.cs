
using AutoCopy.Control;

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
            this.resource_input = new AutoCopy.Control.TextBoxEx();
            this.ftp_lbl = new System.Windows.Forms.Label();
            this.ftp_input = new AutoCopy.Control.TextBoxEx();
            this.confirm_btn = new System.Windows.Forms.Button();
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
            this.resource_lbl.Click += new System.EventHandler(this.label1_Click);
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
            // ftp_lbl
            // 
            this.ftp_lbl.AutoSize = true;
            this.ftp_lbl.Location = new System.Drawing.Point(200, 140);
            this.ftp_lbl.Name = "ftp_lbl";
            this.ftp_lbl.Size = new System.Drawing.Size(86, 12);
            this.ftp_lbl.TabIndex = 2;
            this.ftp_lbl.Text = "FTP服务器路径";
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
            // confirm_btn
            // 
            this.confirm_btn.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.confirm_btn.Location = new System.Drawing.Point(200, 250);
            this.confirm_btn.Name = "confirm_btn";
            this.confirm_btn.Size = new System.Drawing.Size(75, 23);
            this.confirm_btn.TabIndex = 4;
            this.confirm_btn.Text = "开始监视";
            this.confirm_btn.UseVisualStyleBackColor = false;
            // 
            // Demo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.confirm_btn);
            this.Controls.Add(this.ftp_input);
            this.Controls.Add(this.ftp_lbl);
            this.Controls.Add(this.resource_input);
            this.Controls.Add(this.resource_lbl);
            this.Name = "Demo";
            this.Text = "Demo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resource_lbl;
        private System.Windows.Forms.Label ftp_lbl;
        private System.Windows.Forms.Button confirm_btn;
        private TextBoxEx resource_input;
        private TextBoxEx ftp_input;
    }
}

