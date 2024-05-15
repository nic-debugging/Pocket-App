using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketLibrary_temp
{
    public interface IDataConnection
    {
        Tab createTab(Tab newTab);
        //Tag createTag(Tag newTag);
        Files createFile(Files newFile);

        List<BothTabsFiles> ApplyFilterSort_Both(string sortType);
        List<PocketLibrary_temp.Tab> ApplyFilterSort_Tabs(string sortType);

        List<Files> ApplyFilterSort_Files(string sortType);

        //void DeleteTab(DateTime TimeInserted);


    }
}
