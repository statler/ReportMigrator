using cpModel.Helpers;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public partial class CostCodeDto : CostCodeBaseDto, IEditableObject
    {
        //This frees up the inheritance chain as opposed to EditableModelBase<T>. I dont need it, but kept it for example
        EditableModelHelper<CostCodeDto> _editableImplementation = new EditableModelHelper<CostCodeDto>();
        public void BeginEdit() => _editableImplementation.BeginEdit();
        public void CancelEdit() => _editableImplementation.CancelEdit();
        public void EndEdit() => _editableImplementation.EndEdit();
    }
}
