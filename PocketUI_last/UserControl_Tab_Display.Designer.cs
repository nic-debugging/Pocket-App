namespace PocketUI_last
{
    partial class UserControl_Tab_Display_Final
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_Tab_Image = new System.Windows.Forms.PictureBox();
            this.label_Tab_title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Tab_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Tab_Image
            // 
            this.pictureBox_Tab_Image.Location = new System.Drawing.Point(0, 48);
            this.pictureBox_Tab_Image.Name = "pictureBox_Tab_Image";
            this.pictureBox_Tab_Image.Size = new System.Drawing.Size(264, 142);
            this.pictureBox_Tab_Image.TabIndex = 0;
            this.pictureBox_Tab_Image.TabStop = false;
            this.pictureBox_Tab_Image.Click += new System.EventHandler(this.pictureBox_Tab_Image_Click_1);
            // 
            // label_Tab_title
            // 
            this.label_Tab_title.AutoSize = true;
            this.label_Tab_title.BackColor = System.Drawing.Color.LightGray;
            this.label_Tab_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Tab_title.Location = new System.Drawing.Point(1, 1);
            this.label_Tab_title.Name = "label_Tab_title";
            this.label_Tab_title.Size = new System.Drawing.Size(26, 37);
            this.label_Tab_title.TabIndex = 1;
            this.label_Tab_title.Text = " ";
            // 
            // UserControl_Tab_Display_Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label_Tab_title);
            this.Controls.Add(this.pictureBox_Tab_Image);
            this.Name = "UserControl_Tab_Display_Final";
            this.Size = new System.Drawing.Size(265, 191);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Tab_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Tab_Image;
        private System.Windows.Forms.Label label_Tab_title;
    }
}
