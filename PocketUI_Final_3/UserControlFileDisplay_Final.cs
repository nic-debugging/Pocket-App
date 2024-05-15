using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketUI_Final_3
{
    public partial class UserControlFileDisplay_Final : UserControl
    {

        public event EventHandler DeleteButtonClicked;
        public event EventHandler LabelClicked;
        public event EventHandler PictureBoxClicked;

        public string FilePath { get; set; }
        public DateTime TimeInserted { get; set; }

        public PictureBox PictureBoxControl { get; } = new PictureBox();

        public UserControlFileDisplay_Final()
        {
            InitializeComponent();



           
            //deleteButton.Image = Properties.Resources.horsehorse;
            //deleteButton.BackgroundImageLayout = ImageLayout.Zoom;


            
            ///////////NEW SHITTTTTTTTTT
            // Load the image from resources
            Image image = Properties.Resources.RedCrossImage;

            // Resize the image to fit the button
            Bitmap resizedImage = new Bitmap(deleteButton.Width, deleteButton.Height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, deleteButton.Width, deleteButton.Height);
            }

            // Set the resized image as the button's background image
            deleteButton.BackgroundImage = resizedImage;
            ///////////NEW SHITTTTTTTTTT
            



            //deleteButton.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox_File_Image.SizeMode = PictureBoxSizeMode.Zoom;

            deleteButton.BackColor = Color.Transparent;



            deleteButton.Click += DeleteButton_Click;
            label_File_Name.Click += Label_File_Name_Click;
            pictureBox_File_Image.Click += PictureBox_File_Image_Click;


            // Set properties of PictureBoxControl
            PictureBoxControl.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBoxControl.Dock = DockStyle.Fill; // Dock to fill UserControl
            Controls.Add(PictureBoxControl); // Add PictureBoxControl to UserControl
        }

        public Image PictureBox_File_Image
        {
            get => pictureBox_File_Image.Image;
            set => pictureBox_File_Image.Image = value;
        }
        public string FileName
        {
            get => label_File_Name.Text;
            set => label_File_Name.Text = value;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Label_File_Name_Click(object sender, EventArgs e)
        {
            LabelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void PictureBox_File_Image_Click(object sender, EventArgs e)
        {
            PictureBoxClicked?.Invoke(this, EventArgs.Empty);
        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
        }

        private void label_File_Name_Click_1(object sender, EventArgs e)
        {

        }
    }
}
