// <auto-generated>
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using cpModel.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

namespace cpModel.Models
{
    public partial class IncidentType: IReplicableEntity, ILockableEntity
    {
        public Guid? UniqueId { get; set; }
        public string HrId { get; set; }
        public int IncidentTypeId { get; set; }
        public string IncidentTypeName { get; set; }

        [ConcurrencyCheck]
        public int? OptimisticLockField { get; set; }

        // Reverse navigation
        public virtual ICollection<Incident> Incidents { get; set; }

        public IncidentType()
        {
            Incidents = new HashSet<Incident>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
