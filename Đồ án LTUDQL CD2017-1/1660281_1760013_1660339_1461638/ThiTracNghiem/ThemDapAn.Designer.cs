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
            this.ckbDung.Location = new System.Drawing.Point(38, 88);
            this.ckbDung.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ckbDung.Name = "ckbDung";
            this.ckbDung.Size = new System.Drawing.Size(89, 17);
            this.ckbDung.TabIndex = 13;
            this.ckbDung.Text = "Đáp án đúng";
            this.ckbDung.UseVisualStyleBackColor = true;
            // 
            // txtDapAn
            // 
            this.txtDapAn.Location = new System.Drawing.Point(93, 61);
            this.txtDapAn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDapAn.Name = "txtDapAn";
            this.txtDapAn.Size = new System.Drawing.Size(165, 20);
            this.txtDapAn.TabIndex = 10;
            // 
            // btnThemDapAn
            // 
            this.btnThemDapAn.Location = new System.Drawing.Point(142, 108);
            this.btnThemDapAn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThemDapAn.Name = "btnThemDapAn";
            this.btnThemDapAn.Size = new System.Drawing.Size(91, 34);
            this.btnThemDapAn.TabIndex = 12;
            this.btnThemDapAn.Text = "Thêm đáp án";
            this.btnThemDapAn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 61);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Đáp án:";
            // 
            // ThemDapAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 167);
            this.Controls.Add(this.ckbDung);
            this.Controls.Add(this.txtDapAn);
            this.Controls.Add(this.btnThemDapAn);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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