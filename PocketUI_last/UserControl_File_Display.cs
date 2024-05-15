using PocketUI_last;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketUI_last
{
    public partial class UserControl_File_Display : UserControl
    {
        public event EventHandler DeleteButtonClicked;

        public UserControl_File_Display()
        {
            InitializeComponent();

            // Adjust properties of the existing deleteButton PictureBox
            //deleteButton.Image = Properties.Resources.RedCrossImage; // Set the red cross image
            //deleteButton.SizeMode = PictureBoxSizeMode.Zoom;
            //deleteButton.BackColor = Color.Transparent; // Make the background transparent

            // Attach the event handler to the existing deleteButton PictureBox
            //deleteButton.Click += DeleteButton_Click;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Raise the DeleteButtonClicked event when the delete button is clicked
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        // Other methods and properties...

        private void label_File_Name_Click(object sender, EventArgs e)
        {
            // Handle the click event for the label here
            // You can choose to open the file or perform any other action
            var clickedControl = sender as UserControl_File_Display;
            //OpenFile(clickedControl.FilePath);
        }

        private void pictureBox_File_Image_Click(object sender, EventArgs e)
        {
            // Handle the click event for the picture box here
            // You can choose to open the file or perform any other action
            var clickedControl = sender as UserControl_File_Display;
            //OpenFile(clickedControl.FilePath);
        }

        private void pictureBox_File_Image_Click_1(object sender, EventArgs e)
        {

        }
    }

}


