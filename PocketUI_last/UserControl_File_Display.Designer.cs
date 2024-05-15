namespace PocketUI_last
{
    partial class UserControl_File_Display
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
            this.label_File_name = new System.Windows.Forms.Label();
            this.pictureBox_File_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_File_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // label_File_name
            // 
            this.label_File_name.AutoSize = true;
            this.label_File_name.BackColor = System.Drawing.Color.LightGray;
            this.label_File_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_File_name.Location = new System.Drawing.Point(3, 0);
            this.label_File_name.Name = "label_File_name";
            this.label_File_name.Size = new System.Drawing.Size(26, 37);
            this.label_File_name.TabIndex = 0;
            this.label_File_name.Text = " ";
            // 
            // pictureBox_File_Image
            // 
            this.pictureBox_File_Image.Location = new System.Drawing.Point(0, 44);
            this.pictureBox_File_Image.Name = "pictureBox_File_Image";
            this.pictureBox_File_Image.Size = new System.Drawing.Size(272, 137);
            this.pictureBox_File_Image.TabIndex = 1;
            this.pictureBox_File_Image.TabStop = false;
            this.pictureBox_File_Image.Click += new System.EventHandler(this.pictureBox_File_Image_Click_1);
            // 
            // UserControl_File_Display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox_File_Image);
            this.Controls.Add(this.label_File_name);
            this.Name = "UserControl_File_Display";
            this.Size = new System.Drawing.Size(273, 182);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_File_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_File_name;
        private System.Windows.Forms.PictureBox pictureBox_File_Image;
    }
}
