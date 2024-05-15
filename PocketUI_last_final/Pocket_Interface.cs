using HtmlAgilityPack;
using Microsoft.Office.Interop.Outlook;
using Microsoft.VisualBasic.Devices;
using MimeKit;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using PuppeteerSharp;
using System;
using System.Data;
using System.Net;
using System.Security.Policy;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Net.NetworkInformation;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using Dapper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using Tab = PocketLibrary_temp.Tab;
using System.Drawing;
using static System.Net.WebRequestMethods;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Threading.Tasks;
using PocketLibrary_temp;
//using PocketLibrary_temp;


namespace PocketUI_last
{
    public partial class Pocket_Interface : Form
    {

        private List<BothTabsFiles> _ItemsBoth;
        private List<PocketLibrary_temp.Tab> _ItemsTabs;
        private List<Files> _ItemsFiles;

        public Pocket_Interface()
        {
            InitializeComponent();

            List<BothTabsFiles> data =
                    GlobalConfig.Connection.ApplyFilterSort_Both("ORDER BY timeInserted DESC");
            _ItemsBoth = data.ToList();
            BindData("Both");

            _ItemsBoth = new List<BothTabsFiles>();
            _ItemsTabs = new List<PocketLibrary_temp.Tab>();

            this.AllowDrop = true;
            this.DragEnter += new DragEventHandler(Pocket_Interface_DragEnter);
            this.DragDrop += new DragEventHandler(Pocket_Interface_DragDrop);

        }

        // DragEnter triggered when dragged data enters drop target area.
        // Useful for determining whether the drop is allowed.
        private void Pocket_Interface_DragEnter(object sender, DragEventArgs e)
        {

            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                // Invalid object
                e.Effect = DragDropEffects.None;
            }
        }


        private async void Pocket_Interface_DragDrop(object sender, DragEventArgs e)
        {

            string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

            // multiple files can be dropped, so loop thru all
            foreach (string filePath in filePaths)
            {
                Files newFile = ExtractFileInfo(filePath);


                GlobalConfig.Connection.createFile(newFile);

            }
        }



        private void Pocket_Interface_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_settings_Click(object sender, EventArgs e)
        {

        }

        private void listBox_everything_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Checks for presence of a URL in data text of dragged object 
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Returns true/false if it's a tab</returns>
        private async Task<bool> isTabCheck(string data)
        {

            if (!Uri.TryCreate(data, UriKind.Absolute, out var uriResult))
            {
                MessageBox.Show("Invalid URL format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Additional URL check if user not offline!
            if (IsNetworkAvailable())
            {
                return await IsUrlReachableAsync(data);
            }
            else
            {
                MessageBox.Show("Currently offline, URL validility check is limited");
                return true;
            }
        }

        private async Task<bool> IsUrlReachableAsync(string url)
        {
            try
            {

                using HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                client.DefaultRequestHeaders.Add("Cookie", "your_cookie_here");


                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                return true;
            }
            catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.Forbidden)
            {
                // Catches "https://chat.openai.com/"'s exception.  is still a valid URL
                return true; //return true, as "https://chat.openai.com/" is still a valid URL
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }



        // INFO EXTRACTION METHODS

        private string ExtractTabInfo(string url)
        {
            HtmlWeb web = new();
            HtmlAgilityPack.HtmlDocument doc = web.Load(url);

            string title = doc.DocumentNode.SelectSingleNode("//title").InnerText;

            return title;
        }



        private async Task<byte[]> ExtractPreviewImage(string url)
        {
            try
            {
                await new BrowserFetcher().DownloadAsync();
                using var browser = await Puppeteer.LaunchAsync(new LaunchOptions
                {
                    Headless = true
                });

                using var page = await browser.NewPageAsync();

                await page.GoToAsync(url);

                await page.SetViewportAsync(new ViewPortOptions { Width = 1280, Height = 800 });

                var screenshotOptions = new ScreenshotOptions { FullPage = false, Clip = new PuppeteerSharp.Media.Clip { X = 0, Y = 0, Width = 1280, Height = 800 } };
                var screenshot = await page.ScreenshotDataAsync(screenshotOptions);

                await browser.CloseAsync();

                return screenshot;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("OFFLINE, Error capturing preview image: " + ex.Message);
                return null;
            }
        }


        private Files ExtractFileInfo(string filePath)
        {

            string fileName = System.IO.Path.GetFileName(filePath);
            string fileExtension = System.IO.Path.GetExtension(filePath);
            byte[]? fileImage = null;

            if (IsImageFile(fileExtension)) // Display the image if file is an image
            {
                fileImage = System.IO.File.ReadAllBytes(filePath);
            }
            // Maybe add more ifs for other file types

            Files newFile = new(filePath, fileName, fileExtension, fileImage, DateTime.Now);

            return newFile;
        }

        private bool IsImageFile(string fileExtension)
        {
            List<string> imageExtensions = new List<string> { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };
            return imageExtensions.Contains(fileExtension.ToLower());
        }

        private void Pocket_Interface_Tab_Display_UserControl(PocketLibrary_temp.Tab newTab)
        {
            UserControl_Tab_Display_Final customControl = new UserControl_Tab_Display_Final();

            customControl.Name = newTab.TimeInserted.ToString(); // UNIQUE IDENTIFIER
            customControl.TabTitle = newTab.TabTitle;
            customControl.PictureBox_Tab_Image.Image = ConvertImageToBitmap(newTab.TabImage);
            customControl.TabLink = newTab.TabLink; // for opening url in browser!
            customControl.TimeInserted = newTab.TimeInserted; // for deleting and recognizing correct tab to delete in sql!

            customControl.Visible = true;


            /* CLICK FUNCTIONALITY, GETTING IT BACK FROM userControl */
            customControl.TabClicked += UserControl_Tab_Display_Final_Click;

            customControl.LabelClicked += label_Tab_title_Click;
            customControl.PictureBoxClicked += pictureBox_Tab_Image_Click;

            customControl.DeleteButtonClicked += Tab_DeleteButton_Click;

            flowLayoutPanel_Display.Controls.Add(customControl);

            // Memory leak check
            customControl.Disposed += (sender, e) =>
            {
                customControl.Dispose();
                customControl = null;
            };

        }
        private void Tab_DeleteButton_Click(object sender, EventArgs e)
        {
            SqlConnector connector = new SqlConnector();

            if (sender is UserControl_Tab_Display_Final customControl)
            {
                connector.DeleteTab(customControl.TimeInserted);
            }
        }
        private void File_DeleteButton_Click(object sender, EventArgs e)
        {
            SqlConnector connector = new SqlConnector();

            if (sender is UserControl_File_Display fileDisplay)
            {

                // NEEDS BOTH TIMEINSERTED AND SOMETHING ELSE TO IDENTIFY FILE DROPPED 
                // AT SAME TIME
                connector.DeleteFile(fileDisplay.TimeInserted);
            }
        }

        private void Pocket_Interface_File_Display_UserControl(PocketLibrary_temp.Files newFile)
        {
            UserControl_File_Display customControl = new UserControl_File_Display();

            customControl.FileName = newFile.FileName;
            customControl.FilePath = newFile.FilePath;
            customControl.TimeInserted = newFile.TimeInserted; // for deleting and recognizing correct tab to delete in sql!

            customControl.PictureBox_File_Image.SizeMode = PictureBoxSizeMode.Zoom;
            customControl.PictureBox_File_Image.Image = ConvertImageToBitmap(newFile.FileImage);

            customControl.Click += (sender, e) => OpenFile(newFile.FilePath);
            customControl.LabelClicked += label_File_Name_Click;
            customControl.PictureBoxClicked += pictureBox_File_Image_Click;
            customControl.DeleteButtonClicked += File_DeleteButton_Click;

            flowLayoutPanel_Display.Controls.Add(customControl);
        }

        private void label_File_Name_Click(object sender, EventArgs e)
        {
            var clickedControl = sender as UserControl_File_Display;
            OpenFile(clickedControl.FilePath);
        }

        private void pictureBox_File_Image_Click(object sender, EventArgs e)
        {
            var clickedControl = sender as UserControl_File_Display;
            OpenFile(clickedControl.FilePath);
        }

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


        private Bitmap ConvertImageToBitmap(byte[] imageBytes)
        {

            if (!IsNetworkAvailable())
            {
                // TODO - or add custom text: Image unavailable offline

                return TextToBitmap("Image not available offline.");
            }


            if (imageBytes == null)
            {
                return TextToBitmap("Image not available.");
            }

            using (MemoryStream stream = new MemoryStream(imageBytes))
            {
                return new Bitmap(stream);
            }
        }

        private Bitmap TextToBitmap(string text)
        {

            Bitmap bitmap = new Bitmap(200, 100);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, new System.Drawing.PointF(10, 10));
            }
            return bitmap;
        }


        private bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        private void textBox_url_input_box_TextChanged(object sender, EventArgs e)
        {
            // TODO - put the appearing & disappearing | thing u see
            // when u click anywhere in this file
        }

        private async void button_add_tab_Click(object sender, EventArgs e)
        {
            string input = textBox_url_input_box.Text;

            if (!string.IsNullOrEmpty(input))
            {
                if (await isTabCheck(input))
                {

                    // Extract tab info from url
                    string url = input;
                    string title = ExtractTabInfo(url!);

                    byte[]? image = await ExtractPreviewImage(url!);
                    byte[] resizedImage = resizeImage(image);

                    PocketLibrary_temp.Tab newTab = new(title, url, resizedImage, DateTime.Now, 69);

                    GlobalConfig.Connection.createTab(newTab);
                }
            }
            else
            {
                MessageBox.Show("No URL entered", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Resetting input box
            textBox_url_input_box.Text = "";
        }



        private byte[] resizeImage(byte[] imageBytes)
        {
            int userControlWidth = 250;
            int userControlHeight = 143;

            using (var image = SixLabors.ImageSharp.Image.Load(imageBytes))
            {
                // Resize image
                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new SixLabors.ImageSharp.Size(userControlWidth, userControlHeight),
                    Mode = ResizeMode.Max
                }));

                using (var memoryStream = new MemoryStream())
                {
                    image.Save(memoryStream, new JpegEncoder());
                    return memoryStream.ToArray();
                }
            }
        }

        private void userControl_Tab_Display2_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel_Display_Paint(object sender, PaintEventArgs e)
        {

        }

        private void userControl_Tab_Display1_Load(object sender, EventArgs e)
        {

        }

        private void userControl_Tab_Display2_Load_1(object sender, EventArgs e)
        {

        }

        private void userControl_Tab_Display1_Load_1(object sender, EventArgs e)
        {

        }

        private void checkBox_time_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BindData(string dataType)
        {

            flowLayoutPanel_Display.Controls.Clear();

            if (dataType == "Both")
            {

                foreach (BothTabsFiles DisplayData in _ItemsBoth)
                {
                    CheckIsTabOrFile(DisplayData);
                }
            }
            else if (dataType == "Tabs")
            {
                foreach (PocketLibrary_temp.Tab DisplayData in _ItemsTabs)
                {
                    Pocket_Interface_Tab_Display_UserControl(DisplayData);

                }
            }
            else if (dataType == "Files")
            {
                foreach (Files DisplayData in _ItemsFiles)
                {
                    Pocket_Interface_File_Display_UserControl(DisplayData);
                }
            }
            else
            {
                MessageBox.Show("Bind_Data THIS NOT SUPPOSED TO HAPPEN!");
            }
        }

        private void CheckIsTabOrFile(BothTabsFiles DisplayData)
        {
            if (DisplayData.tabTitle != null)
            {
                PocketLibrary_temp.Tab displayTab = new
                    (
                    DisplayData.tabTitle,
                    DisplayData.tabLink,
                    DisplayData.bothImage,
                    DisplayData.timeInserted,
                    69
                );

                Pocket_Interface_Tab_Display_UserControl(displayTab);
            }
            else if (DisplayData.fileName != null)
            {
                Files displayFile = new
                    (
                    DisplayData.filePath,
                    DisplayData.fileName,
                    DisplayData.fileExtension,
                    DisplayData.bothImage,
                    DisplayData.timeInserted
                    );

                //


                // if no image is present, set to default file or folder icon
                if (displayFile.FileImage == null)
                {

                    FileOrFolder(displayFile.FilePath, displayFile);
                }


                Pocket_Interface_File_Display_UserControl(displayFile);
            }
            else
            {
                MessageBox.Show("Check_Data THIS NOT SUPPOSED TO HAPPEN!");
            }
        }

        private void FileOrFolder(string path, Files displayFile)
        {
            byte[] defaultIcon = null;
            Bitmap bitmap = null;

            if (Directory.Exists(path))
            {
                bitmap = Properties.Resources.folderImage;

            }
            else if (File.Exists(path))
            {
                bitmap = Properties.Resources.fileImage;

            }

            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                defaultIcon = ms.ToArray();
            }

            displayFile.FileImage = defaultIcon;
        }

        private void button_apply_filters_sort_Click(object sender, EventArgs e)
        {

            bool filterTab = checkBox_Tabs.Checked;
            bool filterFile = checkBox_Files.Checked;

            if (filterTab && filterFile)
            {
                List<BothTabsFiles> data =
                    GlobalConfig.Connection.ApplyFilterSort_Both("ORDER BY timeInserted DESC");

                _ItemsBoth = data.ToList();

                BindData("Both");
            }
            else if (filterTab)
            {
                List<PocketLibrary_temp.Tab> data =
                    GlobalConfig.Connection.ApplyFilterSort_Tabs("ORDER BY timeInserted DESC");

                _ItemsTabs = data.ToList();

                BindData("Tabs");
            }
            else if (filterFile)
            {
                List<Files> data =
                   GlobalConfig.Connection.ApplyFilterSort_Files("ORDER BY timeInserted DESC");

                _ItemsFiles = data.ToList();

                BindData("Files");
            }
            else
            {
                MessageBox.Show("Select a filter option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void checkBox_Tabs_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox_Files_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void UserControl_Tab_Display_Final_Click(object sender, EventArgs e)
        {
            OpenTab(sender as UserControl_Tab_Display_Final);
        }

        private void label_Tab_title_Click(object sender, EventArgs e)
        {
            UserControl_Tab_Display_Final_Click(sender, e);
        }

        private void pictureBox_Tab_Image_Click(object sender, EventArgs e)
        {
            UserControl_Tab_Display_Final_Click(sender, e);
        }

        private void OpenTab(UserControl_Tab_Display_Final clickedTab)
        {
            try
            {
                Task.Run(() =>
                {
                    System.Diagnostics.Process.Start(new ProcessStartInfo(clickedTab.TabLink) { UseShellExecute = true });
                });
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error opening URL: {ex.Message}");
            }
        }
    }
}

