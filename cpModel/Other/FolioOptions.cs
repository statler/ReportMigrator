using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Other
{

    public class FolioOptions
    {
        public int folderStructureOption { get; set; }
        public bool fullRegister { get; set; }
        public bool showLotQty { get; set; }
        public bool showLotDocs { get; set; }

        public FolioOptions()
        {

        }

        public FolioOptions(int FolderStructureOption, bool FullRegister, bool ShowLotQty, bool ShowLotDocs)
        {
            folderStructureOption = FolderStructureOption;
            fullRegister = FullRegister;
            showLotQty = ShowLotQty;
            showLotDocs = ShowLotDocs;
        }
    }
}
