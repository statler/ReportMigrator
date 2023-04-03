using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Enums
{
    public class ReportEnums
    {
        [Flags()]
        public enum CLprintOption
        {
            showSignatureBlock = 1,
            showApproveBlock = 2,
            showVerifiedBlock = 4,
            showCheckBlock = 8,
            showNCR = 16,
            showComments = 32,
            showQty = 64,
            showXtraQty = 128
        }
        [Flags()]
        public enum CLElecprintOption
        {
            showApprovalLog = 1
        }
        [Flags()]
        public enum LotConfprintOption
        {
            showGeometry = 1,
            showDates = 2,
            showNotes = 4,
            showNCR = 8,
            showATP = 16,
            showQty = 32,
            showVRN = 64,
            showTestReq = 128,
            showTestResult = 256,
            showPhoto = 512,
            showRelated = 1024,
            showWorkArea = 2048,
            showOtherDetails = 4096,
            showSignOff = 8192,
            showAppSignOff = 16384,
            showQVC = 32768,
            showDirectApproval = 65536
        }
        [Flags()]
        public enum NCRprintOption
        {
            showPhotos = 1,
            showCloseOut = 2,
            showRootCause = 4,
            showApprovalLog = 8
        }

        [Flags()]
        public enum ContractNoticePrintOption
        {
            useSeparateFolders = 1,
            includeReferenceInFileName = 2,
            includeDescriptionInFileName = 4,
            includeAttachments = 8,
            includeNotices = 16,
            includeOther = 32,
            includeControlledDocs = 64
        }
    }
}
