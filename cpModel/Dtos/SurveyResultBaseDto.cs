using cpModel.Helpers;
using cpModel.Interfaces;
using System;
using System.ComponentModel;

namespace cpModel.Dtos
{
    public class SurveyResultBaseDto : ILockableEntity
    {
        public int SurveyResultId { get; set; }
        public int? SurveyResultSetId { get; set; }
        public decimal? Xcoord { get; set; }
        public decimal? Ycoord { get; set; }
        public decimal? Zcoord { get; set; }
        public double? Zdesign { get; set; }
        private bool? _IsNonCompliant;
        public bool? IsNonCompliant
        {
            get => _IsNonCompliant ?? false;
            set => _IsNonCompliant = value;
        }
        public string Comment { get; set; }

        public int? OptimisticLockField { get; set; }
    }
}
