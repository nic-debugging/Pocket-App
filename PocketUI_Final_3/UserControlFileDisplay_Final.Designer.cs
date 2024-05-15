namespace PocketUI_Final_3
{
    partial class UserControlFileDisplay_Final
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
            deleteButton = new Button();
            label_File_Name = new Label();
            pictureBox_File_Image = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox_File_Image).BeginInit();
            SuspendLayout();
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(219, -2);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(47, 47);
            deleteButton.TabIndex = 0;
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click_1;
            // 
            // label_File_Name
            // 
            label_File_Name.AutoSize = true;
            label_File_Name.BackColor = Color.LightGray;
            label_File_Name.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_File_Name.Location = new Point(0, 0);
            label_File_Name.Name = "label_File_Name";
            label_File_Name.Size = new Size(29, 45);
            label_File_Name.TabIndex = 1;
            label_File_Name.Text = " ";
            label_File_Name.Click += label_File_Name_Click_1;
            // 
            // pictureBox_File_Image
            // 
            pictureBox_File_Image.Location = new Point(0, 48);
            pictureBox_File_Image.Name = "pictureBox_File_Image";
            pictureBox_File_Image.Size = new Size(262, 133);
            pictureBox_File_Image.TabIndex = 2;
            pictureBox_File_Image.TabStop = false;
            // 
            // UserControlFileDisplay_Final
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(deleteButton);
            Controls.Add(pictureBox_File_Image);
            Controls.Add(label_File_Name);
            Name = "UserControlFileDisplay_Final";
            Size = new Size(266, 179);
            ((System.ComponentModel.ISupportInitialize)pictureBox_File_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button deleteButton;
        private Label label_File_Name;
        private PictureBox pictureBox_File_Image;
    }
}
