using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketLibrary_temp
{
    public class BothTabsFiles
    {

        public string TabTitle { get; set; }
        public string TabLink { get; set; }
        public byte[]? BothImage { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public DateTime TimeInserted { get; set; }
        public int OrderPosition { get; set; }  

        // Constructor
        public BothTabsFiles(string tabTitle, string tabLink, byte[]? bothImage, string filePath, string fileName, string fileExtension, DateTime timeInserted)
        {

            TabTitle = tabTitle;
            TabLink = tabLink;
            BothImage = bothImage;
            FilePath = filePath;
            FileName = fileName;
            FileExtension = fileExtension;
            TimeInserted = timeInserted;

        }
    }
}
