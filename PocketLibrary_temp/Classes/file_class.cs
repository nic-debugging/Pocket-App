using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PocketLibrary_temp
{
    //public class Image
    public class Files
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }

        // can be null, non-image files
        public byte[]? FileImage { get; set; }
        public DateTime TimeInserted { get; set; }

        public Files(string filePath, string fileName, string fileExtension, byte[] fileImage, DateTime timeInserted)
        {
            FilePath = filePath;
            FileName = fileName;
            FileExtension = fileExtension;
            FileImage = fileImage;
            //TimeInserted = DateTime.Now;
            TimeInserted = timeInserted;
        }

    }
}