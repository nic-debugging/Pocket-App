﻿using PocketUI_Final_3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PocketUI_Final_3
{
    public partial class UserControlFileDisplay : UserControl
    {
        public event EventHandler DeleteButtonClicked;
        public event EventHandler LabelClicked;
        public event EventHandler PictureBoxClicked;

        //public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime TimeInserted { get; set; }
        //public Image PictureBox_File_Image { get; set; }


        public PictureBox PictureBoxControl { get; } = new PictureBox();

        public UserControlFileDisplay()
        {
            InitializeComponent();

            deleteButton.Image = Properties.Resources.RedCrossImage;

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
            // Raise the DeleteButtonClicked event when the delete button is clicked
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void Label_File_Name_Click(object sender, EventArgs e)
        {
            // Raise LabelClicked event when label is clicked
            LabelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void PictureBox_File_Image_Click(object sender, EventArgs e)
        {
            // Raise PictureBoxClicked event when picture box is clicked
            PictureBoxClicked?.Invoke(this, EventArgs.Empty);
        }

        /*
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Raise the DeleteButtonClicked event when the delete button is clicked
            DeleteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        // Other methods and properties...

        
        private void Label_File_Name_Click(object sender, EventArgs e)
        {
            // Handle the click event for the label here
            // You can choose to open the file or perform any other action
            var clickedControl = sender as UserControlFileDisplay;
            //OpenFile(clickedControl.FilePath);
        }

        private void PictureBox_File_Image_Click(object sender, EventArgs e)
        {
            // Handle the click event for the picture box here
            // You can choose to open the file or perform any other action
            var clickedControl = sender as UserControlFileDisplay;
            //OpenFile(clickedControl.FilePath);
        }

        private void pictureBox_File_Image_Click_1(object sender, EventArgs e)
        {

        }
        /*
        private void OpenFile(string filePath)
        {
            try
            {
                System.Diagnostics.Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}");
            }
        }
        */


    }

}


