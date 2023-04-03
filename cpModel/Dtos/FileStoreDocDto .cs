
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.IO;

namespace cpModel.Dtos
{
    public class FileStoreDocDto : ILockableEntity
    {
        public int FileStoreDocId { get; set; }        
        public int? FilestoreDocNo { get; set; }
        public DateTime? FileDate { get; set; }
        public string Description { get; set; }
        public string Filename { get; set; }
        public string FilenameOriginal { get; set; }

        public int? OptimisticLockField { get; set; }
        public string Extension => Path.GetExtension(Filename);
    }
}
