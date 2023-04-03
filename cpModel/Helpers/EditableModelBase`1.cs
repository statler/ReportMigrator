using System;
using System.ComponentModel;

namespace cpModel.Helpers
{
    public abstract class EditableModelBase<T> : IEditableObject
    {
        private T Cache { get; set; }

        private object CurrentModel
        {
            get { return this; }
        }

        //public RelayCommand CancelEditCommand
        //{
        //    get { return new RelayCommand(CancelEdit); }
        //}

        #region IEditableObject Members


        bool _isEditing = false;
        public virtual void BeginEdit()
        {
            if (_isEditing)
                return;
            _isEditing = true;
            Cache = Activator.CreateInstance<T>();

            //Set Properties of Cache
            foreach (var info in CurrentModel.GetType().GetProperties())
            {
                if (!info.CanRead || !info.CanWrite) continue;
                try
                {
                    var oldValue = info.GetValue(CurrentModel, null);
                    Cache.GetType().GetProperty(info.Name).SetValue(Cache, oldValue, null);
                }
                catch (Exception)
                {

                }
            }
        }

        public virtual void EndEdit()
        {
            _isEditing = false;
            Cache = default(T);
        }


        public virtual void CancelEdit()
        {
            if (Cache == null) return;
            _isEditing = false;
            foreach (var info in CurrentModel.GetType().GetProperties())
            {
                if (!info.CanRead || !info.CanWrite) continue;
                try
                {
                    var oldValue = info.GetValue(Cache, null);
                    CurrentModel.GetType().GetProperty(info.Name).SetValue(CurrentModel, oldValue, null);
                }
                catch (Exception)
                {

                }
            }
        }

        #endregion
    }
}

