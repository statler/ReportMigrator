
using System.ComponentModel.DataAnnotations.Schema;

namespace cpModel.Models
{
    public partial class WorkflowActionPoint
    {
        [NotMapped]
        public float XF
        {
            get
            {
                return (float)(X ?? 0);
            }
            set
            {
                X = (decimal)value;
            }
        }
        [NotMapped]
        public float YF
        {
            get
            {
                return (float)(Y ?? 0);
            }
            set
            {
                Y = (decimal)value;
            }
        }

    }
}
// </auto-generated>
