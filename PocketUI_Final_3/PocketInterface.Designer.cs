namespace PocketUI_Final_3
{
    partial class PocketInterface
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_URL = new Label();
            textBox_url_input_box = new TextBox();
            button_add_tab = new Button();
            button_settings = new Button();
            label_Filter_by = new Label();
            checkBox_Tabs = new CheckBox();
            checkBox_Files = new CheckBox();
            checkBox_Time = new CheckBox();
            label_Sort_by = new Label();
            checkBox_Alphabetical_order = new CheckBox();
            checkBox_Image_size = new CheckBox();
            button_apply_filters_sort = new Button();
            label_order = new Label();
            flowLayoutPanel_Display = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label_URL
            // 
            label_URL.AutoSize = true;
            label_URL.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_URL.Location = new Point(175, 22);
            label_URL.Name = "label_URL";
            label_URL.Size = new Size(83, 45);
            label_URL.TabIndex = 1;
            label_URL.Text = "URL:";
            // 
            // textBox_url_input_box
            // 
            textBox_url_input_box.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox_url_input_box.Location = new Point(264, 22);
            textBox_url_input_box.Name = "textBox_url_input_box";
            textBox_url_input_box.Size = new Size(622, 50);
            textBox_url_input_box.TabIndex = 2;
            // 
            // button_add_tab
            // 
            button_add_tab.BackColor = Color.WhiteSmoke;
            button_add_tab.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_add_tab.Location = new Point(892, 22);
            button_add_tab.Name = "button_add_tab";
            button_add_tab.Size = new Size(167, 90);
            button_add_tab.TabIndex = 3;
            button_add_tab.Text = "Add tab";
            button_add_tab.UseVisualStyleBackColor = false;
            button_add_tab.Click += button_add_tab_Click_1;
            // 
            // button_settings
            // 
            button_settings.BackColor = Color.CornflowerBlue;
            button_settings.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_settings.Location = new Point(6, 7);
            button_settings.Name = "button_settings";
            button_settings.Size = new Size(163, 85);
            button_settings.TabIndex = 4;
            button_settings.Text = "Settings";
            button_settings.UseVisualStyleBackColor = false;
            // 
            // label_Filter_by
            // 
            label_Filter_by.AutoSize = true;
            label_Filter_by.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Filter_by.Location = new Point(6, 119);
            label_Filter_by.Name = "label_Filter_by";
            label_Filter_by.Size = new Size(134, 45);
            label_Filter_by.TabIndex = 5;
            label_Filter_by.Text = "Filter by";
            // 
            // checkBox_Tabs
            // 
            checkBox_Tabs.AutoSize = true;
            checkBox_Tabs.BackgroundImageLayout = ImageLayout.None;
            checkBox_Tabs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox_Tabs.Location = new Point(15, 167);
            checkBox_Tabs.Name = "checkBox_Tabs";
            checkBox_Tabs.Size = new Size(86, 36);
            checkBox_Tabs.TabIndex = 6;
            checkBox_Tabs.Text = "Tabs";
            checkBox_Tabs.UseVisualStyleBackColor = true;
            // 
            // checkBox_Files
            // 
            checkBox_Files.AutoSize = true;
            checkBox_Files.BackgroundImageLayout = ImageLayout.None;
            checkBox_Files.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox_Files.Location = new Point(15, 209);
            checkBox_Files.Name = "checkBox_Files";
            checkBox_Files.Size = new Size(87, 36);
            checkBox_Files.TabIndex = 7;
            checkBox_Files.Text = "Files";
            checkBox_Files.UseVisualStyleBackColor = true;
            // 
            // checkBox_Time
            // 
            checkBox_Time.AutoSize = true;
            checkBox_Time.BackgroundImageLayout = ImageLayout.None;
            checkBox_Time.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox_Time.Location = new Point(15, 346);
            checkBox_Time.Name = "checkBox_Time";
            checkBox_Time.Size = new Size(93, 36);
            checkBox_Time.TabIndex = 8;
            checkBox_Time.Text = "Time";
            checkBox_Time.UseVisualStyleBackColor = true;
            // 
            // label_Sort_by
            // 
            label_Sort_by.AutoSize = true;
            label_Sort_by.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_Sort_by.Location = new Point(12, 298);
            label_Sort_by.Name = "label_Sort_by";
            label_Sort_by.Size = new Size(121, 45);
            label_Sort_by.TabIndex = 9;
            label_Sort_by.Text = "Sort by";
            // 
            // checkBox_Alphabetical_order
            // 
            checkBox_Alphabetical_order.AutoSize = true;
            checkBox_Alphabetical_order.BackgroundImageLayout = ImageLayout.None;
            checkBox_Alphabetical_order.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox_Alphabetical_order.Location = new Point(12, 430);
            checkBox_Alphabetical_order.Name = "checkBox_Alphabetical_order";
            checkBox_Alphabetical_order.Size = new Size(171, 36);
            checkBox_Alphabetical_order.TabIndex = 10;
            checkBox_Alphabetical_order.Text = "Alphabetical";
            checkBox_Alphabetical_order.UseVisualStyleBackColor = true;
            checkBox_Alphabetical_order.CheckedChanged += checkBox_Alphabetical_order_CheckedChanged;
            // 
            // checkBox_Image_size
            // 
            checkBox_Image_size.AutoSize = true;
            checkBox_Image_size.BackgroundImageLayout = ImageLayout.None;
            checkBox_Image_size.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            checkBox_Image_size.Location = new Point(15, 388);
            checkBox_Image_size.Name = "checkBox_Image_size";
            checkBox_Image_size.Size = new Size(153, 36);
            checkBox_Image_size.TabIndex = 11;
            checkBox_Image_size.Text = "Image size";
            checkBox_Image_size.UseVisualStyleBackColor = true;
            // 
            // button_apply_filters_sort
            // 
            button_apply_filters_sort.BackColor = Color.DarkGray;
            button_apply_filters_sort.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_apply_filters_sort.Location = new Point(13, 538);
            button_apply_filters_sort.Name = "button_apply_filters_sort";
            button_apply_filters_sort.Size = new Size(156, 83);
            button_apply_filters_sort.TabIndex = 12;
            button_apply_filters_sort.Text = "Apply";
            button_apply_filters_sort.UseVisualStyleBackColor = false;
            button_apply_filters_sort.Click += button_apply_filters_sort_Click_1;
            // 
            // label_order
            // 
            label_order.AutoSize = true;
            label_order.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_order.Location = new Point(37, 469);
            label_order.Name = "label_order";
            label_order.Size = new Size(71, 32);
            label_order.TabIndex = 13;
            label_order.Text = "order";
            label_order.Click += label1_Click_1;
            // 
            // flowLayoutPanel_Display
            // 
            flowLayoutPanel_Display.AllowDrop = true;
            flowLayoutPanel_Display.AutoScroll = true;
            flowLayoutPanel_Display.BackColor = Color.LightGray;
            flowLayoutPanel_Display.Location = new Point(190, 120);
            flowLayoutPanel_Display.Name = "flowLayoutPanel_Display";
            flowLayoutPanel_Display.Size = new Size(871, 499);
            flowLayoutPanel_Display.TabIndex = 14;
            flowLayoutPanel_Display.Paint += flowLayoutPanel_Display_Paint_2;
            // 
            // PocketInterface
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1071, 633);
            Controls.Add(flowLayoutPanel_Display);
            Controls.Add(label_order);
            Controls.Add(checkBox_Alphabetical_order);
            Controls.Add(button_apply_filters_sort);
            Controls.Add(checkBox_Image_size);
            Controls.Add(label_Sort_by);
            Controls.Add(checkBox_Time);
            Controls.Add(checkBox_Files);
            Controls.Add(checkBox_Tabs);
            Controls.Add(label_Filter_by);
            Controls.Add(button_settings);
            Controls.Add(button_add_tab);
            Controls.Add(textBox_url_input_box);
            Controls.Add(label_URL);
            Name = "PocketInterface";
            Text = "Pocket";
            Load += PocketInterface_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label_URL;
        private TextBox textBox_url_input_box;
        private Button button_add_tab;
        private Button button_settings;
        private Label label_Filter_by;
        private CheckBox checkBox_Tabs;
        private CheckBox checkBox_Files;
        private CheckBox checkBox_Time;
        private Label label_Sort_by;
        private CheckBox checkBox_Alphabetical_order;
        private CheckBox checkBox_Image_size;
        private Button button_apply_filters_sort;
        private Label label_order;
        private FlowLayoutPanel flowLayoutPanel_Display;
    }
}
