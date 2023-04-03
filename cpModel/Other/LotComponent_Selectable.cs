using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace cpModel.Other
{

    public class LotComponent_Selectable : IOrderable
    {
        public bool IsSelected { get; set; }
        public string DocName { get; set; }
        public string DocTypeString
        {
            get { return Enum.GetName(typeof(LotComponentType), DocType); }
        }
        public decimal? OrderId { get => ItemOrder; set => ItemOrder = value ?? 0; }

        public LotComponentType DocType { get; set; }
        public decimal ItemOrder { get; set; }
        public int ComponentId { get; set; }
        public int? FsRelatedkeyId { get; set; }

        public LotComponent_Selectable(string DocName, LotComponentType DocType, int ComponentId, decimal ItemOrder, bool isSelected = true, int? fsRelatedkeyId = null)
        {
            IsSelected = isSelected;
            this.DocName = DocName;
            this.DocType = DocType;
            this.ItemOrder = ItemOrder;
            this.ComponentId = ComponentId;
            this.FsRelatedkeyId = fsRelatedkeyId;
        }

        public LotComponent_Selectable(string DocName, LotComponentType DocType, decimal ItemOrder, bool isSelected = true, int? fsRelatedkeyId = null)
        {
            IsSelected = isSelected;
            this.DocName = DocName;
            this.DocType = DocType;
            this.ItemOrder = ItemOrder;
        }

        public LotComponent_Selectable(LotComponent_Selectable doc, bool? isSelected = null)
        {
            if (isSelected == null) IsSelected = doc.IsSelected;
            else IsSelected = isSelected ?? true;
            DocName = doc.DocName;
            DocType = doc.DocType;
            ItemOrder = doc.ItemOrder;
            ComponentId = doc.ComponentId;
            FsRelatedkeyId = doc.FsRelatedkeyId;
        }
        public LotComponent_Selectable()
        {
        }
    }

}
