namespace PocketUI_Final_3
{
    partial class UserControlFileDisplay
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
            label_File_Name = new Label();
            pictureBox_File_Image = new PictureBox();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_File_Image).BeginInit();
            SuspendLayout();
            // 
            // label_File_Name
            // 
            label_File_Name.AllowDrop = true;
            label_File_Name.AutoSize = true;
            label_File_Name.BackColor = Color.LightGray;
            label_File_Name.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_File_Name.Location = new Point(0, 0);
            label_File_Name.Name = "label_File_Name";
            label_File_Name.Size = new Size(29, 45);
            label_File_Name.TabIndex = 0;
            label_File_Name.Text = " ";
            // 
            // pictureBox_File_Image
            // 
            pictureBox_File_Image.Location = new Point(0, 50);
            pictureBox_File_Image.Name = "pictureBox_File_Image";
            pictureBox_File_Image.Size = new Size(229, 130);
            pictureBox_File_Image.TabIndex = 1;
            pictureBox_File_Image.TabStop = false;
            pictureBox_File_Image.Click += PictureBox_File_Image_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(194, 2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(35, 37);
            deleteButton.TabIndex = 2;
            deleteButton.UseVisualStyleBackColor = true;
            // 
            // UserControlFileDisplay
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(deleteButton);
            Controls.Add(pictureBox_File_Image);
            Controls.Add(label_File_Name);
            Name = "UserControlFileDisplay";
            Size = new Size(229, 176);
            ((System.ComponentModel.ISupportInitialize)pictureBox_File_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_File_Name;
        private PictureBox pictureBox_File_Image;
        private Button deleteButton;
    }
}
