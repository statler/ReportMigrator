using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace cpModel.Dtos
{
    public partial class FsSupplierDto : IOrderableFsRelatedList
    { 
        public int FsSupplierId { get; set; }
        public int? SupplierId { get; set; }
        public int? FsId { get; set; }
        public int? FsNo { get; set; }
        public decimal? OrderId { get; set; }

        public string Filename { get; set; }
        public string FileDesc { get; set; }

        public string FsDescription => $"{FsNo}: {FileDesc}";

        public string Extension => Path.GetExtension(Filename);

        public string SupplierName { get; set; }
    }
}
