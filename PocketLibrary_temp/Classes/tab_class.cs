using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PocketLibrary_temp
{
    public class Tab
    {
        public string TabTitle { get; set; }
        public string TabLink { get; set; }
        public byte[]? TabImage { get; set; }
        public DateTime TimeInserted { get; set; }
        public int OrderPosition { get; set; }  // position sorted by time

        // Constructor
        public Tab(string tabTitle, string tabLink, byte[]? tabImage, DateTime timeInserted, int orderPosition)
        {
            TabTitle = tabTitle;
            TabLink = tabLink;
            TabImage = tabImage;
            TimeInserted = timeInserted;
            OrderPosition = orderPosition;

        }
    }
}