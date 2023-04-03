using cpModel.Helpers;
using cpModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class ContractNoticeDto : ContractNotice_baseDto, ILockableEntity
    {
        public string ConHtml { get; set; }

        //Necessary to override JSON ignore on base
        new public ICollection<CnToDto> CnTos => base.CnTos;

    }
}
