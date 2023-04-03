
using cpModel.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace cpModel.Dtos
{
    public partial class FsWorkflowLogDto : IOrderableFsRelatedList, IFilestoreLink, ILockableEntity
    {
        public int FsWorkflowLogId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public int? WorkflowLogId { get; set; }
        public decimal? OrderId { get; set; }
        public int? RelatedId => WorkflowLogId;
        public string RelatedName => "";
        public int? OptimisticLockField { get; set; }
        public int? ApprovalId { get; set; }
        public int? ApprovalNo { get; set; }
        public string ApprovalDesc => $"{ApprovalNo}: {LogDate:d})";

        public string Extension => Path.GetExtension(Filename);

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";
        public string FsDescriptionWithReference => $"{FsNo}: {FileDesc} ({Initials} {LogDate:d})";
        public string FirstLast { get; set; }
        public string Initials
        {
            get
            {
                var fi = "";
                var si = "";
                var spl = FirstLast.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                if (spl.Count >= 1) fi = spl[0].FirstOrDefault().ToString();
                if (spl.Count >= 2) si = spl[1].FirstOrDefault().ToString();
                return fi + si;
            }
        }

        public DateTime LogDate { get; set; }
    }
}
