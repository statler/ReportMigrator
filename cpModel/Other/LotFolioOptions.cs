using cpModel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Other
{

    public class LotFolioOptions
    {
        public HashSet<int> HsLotIds { get; set; } = null;
        public bool ConfirmAllLots { get; set; } = false;
        public FolioFeatureInclusionEnum InclTestRequest { get; set; }
        public FolioFeatureInclusionEnum InclSurvey { get; set; }
        public FolioFeatureInclusionEnum InclNcr { get; set; }
        public FolioFeatureInclusionEnum InclApproval { get; set; }
        public FolioFeatureInclusionEnum InclLot { get; set; }
        public FolioFeatureInclusionEnum InclAtp { get; set; }
        public FolioFeatureInclusionEnum InclChecklist { get; set; }
        public FolioFeatureInclusionEnum InclPhotos { get; set; }
        public FolioFeatureInclusionEnum InclFilestoreDocs { get; set; }


        public LotFolioOptions()
        {

        }
    }
    //public class FolioOptions
    //{
    //    public int folderStructureOption { get; set; }
    //    public bool fullRegister { get; set; }
    //    public bool showLotQty { get; set; }
    //    public bool showLotDocs { get; set; }

    //    public FolioOptions()
    //    {

    //    }

    //    public FolioOptions(int FolderStructureOption, bool FullRegister, bool ShowLotQty, bool ShowLotDocs)
    //    {
    //        folderStructureOption = FolderStructureOption;
    //        fullRegister = FullRegister;
    //        showLotQty = ShowLotQty;
    //        showLotDocs = ShowLotDocs;
    //    }
    //}
}
