namespace ThiTracNghiem
{
    partial class ThemDapAn
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
            this.ckbDung = new System.Windows.Forms.CheckBox();
            this.txtDapAn = new System.Windows.Forms.TextBox();
            this.btnThemDapAn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ckbDung
            // 
            this.ckbDung.AutoSize = true;
            this.ckbDung.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckbDung.Location = new System.Drawing.Point(132, 175);
            this.ckbDung.Name = "ckbDung";
            this.ckbDung.Size = new System.Drawing.Size(112, 21);
            this.ckbDung.TabIndex = 13;
            this.ckbDung.Text = "Đáp án đúng";
            this.ckbDung.UseVisualStyleBackColor = true;
            // 
            // txtDapAn
            // 
            this.txtDapAn.Location = new System.Drawing.Point(203, 81);
            this.txtDapAn.Multiline = true;
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.Size = new System.Drawing.Size(219, 71);
            this.txtDapAn.TabIndex = 10;
            // 
            // btnThemDapAn
            // 
            this.btnThemDapAn.Location = new System.Drawing.Point(271, 200);
            this.btnThemDapAn.Name = "btnThemDapAn";
            this.btnThemDapAn.Size = new System.Drawing.Size(121, 42);
            this.btnThemDapAn.TabIndex = 12;
            this.btnThemDapAn.Text = "Thêm đáp án";
            this.btnThemDapAn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đáp án:";
            // 
            // ThemDapAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ckbDung);
            this.Controls.Add(this.txtDapAn);
            this.Controls.Add(this.btnThemDapAn);
            this.Controls.Add(this.label2);
            this.Name = "ThemDapAn";
            this.Text = "Thêm đáp án";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckbDung;
        private System.Windows.Forms.TextBox txtDapAn;
        private System.Windows.Forms.Button btnThemDapAn;
        private System.Windows.Forms.Label label2;
    }
}