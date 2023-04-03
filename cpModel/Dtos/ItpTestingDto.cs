using System;

namespace cpModel.Dtos
{
    public partial class ItpTestingDto
    {
        public int ItpTestId { get; set; }
        public int? ItpDetailId { get; set; }
        public int? TestMethodId { get; set; }
        public decimal? FreqNorm { get; set; }
        public decimal? FreqRed { get; set; }
        public decimal? FreqLotNorm { get; set; }
        public decimal? FreqLotRed { get; set; }
        public string Unit { get; set; }
        public int? QuantityBasis { get; set; }
        public string Compliance { get; set; }
        public int? OrSet { get; set; }
        public string Comment { get; set; }
        public bool? IsOptional { get; set; }
        public bool? IsDefault { get; set; }

        public string TestMethodName { get; set; }
        public string TestString
        {
            get
            {
                string orSetMark = OrSet == null ? "" : " *Alternative test available*";
                string IsOptionalMark = IsOptional ?? false ? " *Optional*" : "";
                return string.Format("{0} {1} {2}", TestMethodName, orSetMark, IsOptionalMark);
            }
        }

        public string FreqString
        {
            get
            {
                string FreqString = FreqNorm == 0 ? "<No Freq>" : string.Format("1 per {0:#,##0.#}{1}", FreqNorm, Unit ?? "");
                string FreqLotString = FreqLotNorm == 0 ? "<No Lot Min>" : string.Format("{0:n0} per lot", FreqLotNorm);
                string FreqStringR = FreqRed == 0 ? "<No Freq>" : string.Format("1 per {0:#,##0.#}{1}", FreqRed, Unit ?? "");
                string FreqLotStringR = FreqLotRed == 0 ? "<No Lot Min>" : string.Format("{0:n0} per lot", FreqLotRed);
                return $"{FreqString} || {FreqLotString} (N)" + Environment.NewLine + $"{FreqStringR} || {FreqLotStringR} (R)";
            }
        }


    }

}
