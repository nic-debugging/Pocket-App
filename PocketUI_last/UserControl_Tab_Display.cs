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
    public partial class UserControl_Tab_Display_Final : UserControl
    {

        // Property to track selection state
        public bool IsSelected { get; private set; }

        // Add a variable to store the currently selected tab or file
        private UserControl_Tab_Display_Final selectedTabControl = null;

        public UserControl_Tab_Display_Final()
        {
            InitializeComponent();


            //this.Click += UserControl_Tab_Display_Final_Click;
        }

        /*
        private void UserControl_Tab_Display_Final_Click(object sender, EventArgs e)
        {


            

            // Unselect the currently selected item, if any
            if (selectedTabControl != null)
            {
                //selectedTabControl.IsSelected = false;
                selectedTabControl = null;

                MessageBox.Show("cuk");

                selectedTabControl.UpdateAppearance();
            }

            // Select the clicked item
            var clickedTabControl = sender as UserControl_Tab_Display_Final;
            if (clickedTabControl != null)
            {
                clickedTabControl.IsSelected = true;
                clickedTabControl.UpdateAppearance();
                selectedTabControl = clickedTabControl;
            }
        }

        */

        // Add a property to access the selectedTabControl from outside
        public UserControl_Tab_Display_Final SelectedTabControl
        {
            get { return selectedTabControl; }
        }

        private void UpdateAppearance()
        {
            // Check if it's already selected
            if (this.BackColor != Color.LightBlue)
            {
                // Toggle the appearance to indicate selection
                this.BackColor = Color.LightBlue;
                // You can also handle deselection logic based on your requirements.
            }
            else
            {
                // Deselect logic if needed
                this.BackColor = Color.White;
            }
        }

        public string TabTitle
        {
            get { return label_Tab_title.Text; }
            set { label_Tab_title.Text = value; }

            // Example for anchoring to all sides
            // label_Tab_title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        // Expose the label for external use
        public Label GetTabTitleLabel()
        {
            return label_Tab_title;
        }

        /*
        public string TabTitle
        {
            get { return label_Tab_title.Text; }
            set { label_Tab_title.Text = value; }

            // Example for anchoring to all sides
            //label_Tab_title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        }
        */

        public PictureBox PictureBox_Tab_Image
        {
            get { return pictureBox_Tab_Image; }
            set { pictureBox_Tab_Image = value; }
        }

        public string TabLink
        {
            get { return url; }
            set { url = value; }

        }

        public void pictureBox_Tab_Image_Click(object sender, EventArgs e)
        {

        }

        public string url;

        public void label_Tab_title_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox_Tab_Image_Click_1(object sender, EventArgs e)
        {

        }

        /*
        private void UserControl_Tab_Display_Final_Click(object sender, EventArgs e)
        {
            // Assuming urlLabel is a label displaying the URL
            // string url = urlLabel.Text;

            MessageBox.Show("shit");

            if (!string.IsNullOrEmpty(url))
            {
                System.Diagnostics.Process.Start(url);
            }
            else
            {
                MessageBox.Show("GRAVE ERROR");
            }
        }

        */

        // Inside your UserControl_Tab_Display_Final class

        /*
        private void UserControl_Tab_Display_Final_Click(object sender, EventArgs e)
        {
            // Check if we have a valid URL
            if (!string.IsNullOrEmpty(url))
            {

                MessageBox.Show("HELLO");

                // Use BeginInvoke to execute the URL opening code on the UI thread
                BeginInvoke(new Action(() =>
                {
                    try
                    {
                        System.Diagnostics.Process.Start(url);
                    }
                    catch (System.ComponentModel.Win32Exception ex)
                    {
                        // Handle exceptions or log them as needed
                        MessageBox.Show($"Error opening URL: {ex.Message}");
                    }
                }));
            }
            else
            {
                MessageBox.Show("Invalid URL");
            }
        }
        */


    }
}