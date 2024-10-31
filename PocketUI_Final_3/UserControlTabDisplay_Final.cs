using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketUI_Final_3
{
    public partial class UserControlTabDisplay_Final : UserControl
    {
        public event EventHandler DeleteButtonClicked;
        public event EventHandler LabelClicked;
        public event EventHandler PictureBoxClicked;

        public string TabLink { get; set; }
        public DateTime TimeInserted { get; set; }

        public UserControlTabDisplay_Final()
        {
            InitializeComponent();

            deleteButton.BackColor = Color.Transparent;

            deleteButton.Click += DeleteButton_Click;
            label_Tab_Name.Click += Label_Tab_Name_Click;
            pictureBox_Tab_Image.Click += PictureBox_Tab_Image_Click;

            // Load the image from resources
            Image image = Properties.Resources.RedCrossImage;

            Bitmap resizedImage = new Bitmap(deleteButton.Width, deleteButton.Height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, deleteButton.Width, deleteButton.Height);
            }

            deleteButton.BackgroundImage = resizedImage;
        }

        public Image PictureBox_Tab_Image
        {
            get => pictureBox_Tab_Image.Image;
            set => pictureBox_Tab_Image.Image = value;
        }

        public string TabTitle
        {
            get => label_Tab_Name.Text;
            set => label_Tab_Name.Text = value;
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Label_Tab_Name_Click(object sender, EventArgs e)
        {
            LabelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void PictureBox_Tab_Image_Click(object sender, EventArgs e)
        {
            PictureBoxClicked?.Invoke(this, EventArgs.Empty);
        }

        private void deleteButton_Click_1(object sender, EventArgs e)
        {
        }

        private void label_Tab_Name_Click_1(object sender, EventArgs e)
        {

        }

        private void UserControlTabDisplay_Final_Load(object sender, EventArgs e)
        {

        }
    }
}

