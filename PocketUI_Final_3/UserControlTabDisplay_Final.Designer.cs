namespace PocketUI_Final_3
{
    partial class UserControlTabDisplay_Final
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
            label_Tab_Name = new Label();
            pictureBox_Tab_Image = new PictureBox();
            deleteButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox_Tab_Image).BeginInit();
            SuspendLayout();
            // 
            // label_Tab_Name
            // 
            label_Tab_Name.AutoSize = true;
            label_Tab_Name.BackColor = Color.LightGray;
            label_Tab_Name.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Tab_Name.Location = new Point(0, 0);
            label_Tab_Name.Name = "label_Tab_Name";
            label_Tab_Name.Size = new Size(29, 45);
            label_Tab_Name.TabIndex = 0;
            label_Tab_Name.Text = " ";
            label_Tab_Name.Click += label_Tab_Name_Click_1;
            // 
            // pictureBox_Tab_Image
            // 
            pictureBox_Tab_Image.Location = new Point(0, 48);
            pictureBox_Tab_Image.Name = "pictureBox_Tab_Image";
            pictureBox_Tab_Image.Size = new Size(261, 133);
            pictureBox_Tab_Image.TabIndex = 1;
            pictureBox_Tab_Image.TabStop = false;
            pictureBox_Tab_Image.Click += PictureBox_Tab_Image_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(218, 0);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(49, 52);
            deleteButton.TabIndex = 2;
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click_1;
            // 
            // UserControlTabDisplay_Final
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(deleteButton);
            Controls.Add(pictureBox_Tab_Image);
            Controls.Add(label_Tab_Name);
            Name = "UserControlTabDisplay_Final";
            Size = new Size(267, 180);
            ((System.ComponentModel.ISupportInitialize)pictureBox_Tab_Image).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Tab_Name;
        private PictureBox pictureBox_Tab_Image;
        private Button deleteButton;
    }
}
