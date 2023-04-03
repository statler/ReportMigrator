using System;

namespace cpModel.Helpers
{
    public class EditableModelHelper<T>
    {
        private T Cache { get; set; }

        private object CurrentModel
        {
            get { return this; }
        }

        bool _isEditing = false;
        public void BeginEdit()
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

        public void EndEdit()
        {
            _isEditing = false;
            Cache = default;
        }

        public void CancelEdit()
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
    }
}
