using cpModel.Enums;
using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class ItpDetailDto : IEditableObject, ILockableEntity, IOrderable
    {
        EditableModelHelper<ItpDetailDto> _editableImplementation = new EditableModelHelper<ItpDetailDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();

        public int? OptimisticLockField { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public int ItpDetailId { get; set; }
        public int? ItpId { get; set; }
        public decimal? ItemOrder { get; set; }
        public string ReferenceText { get; set; }
        public string Description { get; set; }
        public string AltQvcText { get; set; }
        public int? ItemType { get; set; }
        public int? Hpwpc { get; set; }
        public string Clause { get; set; }
        public bool? InspectRequired { get; set; }
        public bool? AuthorityRequired { get; set; }
        public bool? VerifyRequired { get; set; }
        public string InspMeth { get; set; }
        public string Records { get; set; }
        public string Responsibility { get; set; }
        public bool? ItpInc { get; set; }
        public bool? QvcInc { get; set; }
        public bool HasTests => TestCount > 0;
        public bool? IsCustomQVCText => QvcTextEffective != Description;
        public int? TestCount { get; set; }

        public string QvcTextEffective
        {
            get
            {
                if (string.IsNullOrEmpty(AltQvcText) || string.IsNullOrWhiteSpace(AltQvcText.GetPlainTextFromHTML()))
                    return Description;
                else return AltQvcText;
            }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value.GetPlainTextFromHTML()))
                    AltQvcText = null;
                else AltQvcText = value;
            }
        }

        public HpWpCEnum? HpWpCTypeEnum
        {
            get => Hpwpc == null ? null : (HpWpCEnum?)Hpwpc; set => Hpwpc = (int?)value;
        }

        public ItpItemTypeEnum? ItemTypeEnum
        {
            get => ItemType == null ? null : (ItpItemTypeEnum?)ItemType; set => ItemType = (int?)value;
        }

        public string ItemTypeString => ItemTypeEnum.ToString().Replace("_", " ");
        public string HpWpCString => HpWpCTypeEnum.ToString().Replace("_", " ");

        public string QVCTextReadOnly
        {
            get
            {
                using (RichEditProcessor _richEditProcessor = new RichEditProcessor())
                {
                    if (string.IsNullOrEmpty(AltQvcText) || string.IsNullOrWhiteSpace(_richEditProcessor.GetPlainTextFromHTML(AltQvcText)))
                        return Description;
                    else return AltQvcText;
                }
            }
        }

        public decimal? OrderId { get => ItemOrder; set => ItemOrder=value; }
    }

}
