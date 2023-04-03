
using cpModel.Enums;
using System;

namespace cpModel.Dtos.Report
{
    public partial class ItpTestReportDto : ItpTestingDto, IItpTestReportDto
    {
        public int RecordId => ItpTestId;
        public int? ParentId => ItpDetailId;

        public bool IsOrSet
        {
            get
            {
                return !(OrSet == null);
            }
        }

        public string QtyString
        {
            get
            {
                return ((QuantityBasisEnum?)QuantityBasis).ToString().Replace("_", "");
            }
        }

        public string NormTestString
        {
            get
            {
                string _unit = String.IsNullOrEmpty(Unit) ? "" : Unit;
                string _freqNorm = FreqNorm == 0 ? "<No Freq>" : String.Format("1 per {0:#,##0.#}{1}", FreqNorm, _unit);
                string _freqNormLot = FreqLotNorm == 0 ? "<No Lot Min>" : String.Format("{0:n0} per lot", FreqLotNorm);
                return String.Format("{0} || {1}", _freqNorm, _freqNormLot);

            }
        }

        public string RedTestString
        {
            get
            {
                string _unit = String.IsNullOrEmpty(Unit) ? "" : Unit;
                string _freqRed = FreqRed == 0 ? "<No Freq>" : String.Format("1 per {0:#,##0.#}{1}", FreqRed, _unit);
                string _freqLotRed = FreqLotRed == 0 ? "<No Lot Min>" : String.Format("{0:n0} per lot", FreqLotRed);
                return String.Format("{0} || {1}", _freqRed, _freqLotRed);

            }
        }

    }
}
