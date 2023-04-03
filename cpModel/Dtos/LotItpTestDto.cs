using System;

namespace cpModel.Dtos
{
    public partial class LotItpTestDto
    {
        public int LotItpTestId { get; set; }
        public int? LotItpDetailId { get; set; }
        public int? TestMethodId { get; set; }
        public decimal? FreqNorm { get; set; }
        public decimal? FreqRed { get; set; }
        public decimal? FreqLotNorm { get; set; }
        public decimal? FreqLotRed { get; set; }
        public string Unit { get; set; }
        public int? QuantityBasis { get; set; }
        public string Compliance { get; set; }
        public int? TestStatus { get; set; }
        public int? OrSet { get; set; }
        public string Comment { get; set; }
        public bool? IsOptional { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsReducedLevelOfTesting { get; set; }
        public string TestMethodName { get; set; }
        public string TestString
        {
            get
            {
                string orSetMark = OrSet == null ? "" : " *Alternative test available*";
                string IsOptionalMark = (IsOptional ?? false) ? " *Optional*" : "";
                return String.Format("{0} {1} {2}", TestMethodName, orSetMark, IsOptionalMark);
            }
        }

        public string levelString
        {
            get => (IsReducedLevelOfTesting ?? false) ? "R" : "N";
        }

        public decimal? TestFreq
        {
            get => (IsReducedLevelOfTesting ?? false) ? FreqRed : FreqNorm;
        }

        public decimal? TestFreqLot
        {
            get => (IsReducedLevelOfTesting ?? false) ? FreqLotRed : FreqLotNorm;
        }

        public string FreqString
        {
            get
            {
                string FreqString = (TestFreq == 0) ? "<No Freq>" : String.Format("1 per {0:#,##0.#}{1}", TestFreq, Unit ?? "");
                string FreqLotString = (TestFreqLot == 0) ? "<No Lot Min>" : String.Format("{0:n0} per lot", TestFreqLot);
                return String.Format("{0} || {1} ({2})", FreqString, FreqLotString, levelString);
            }
        }

        public string FreqNText { get => GetFreqText(FreqNorm, FreqLotNorm); }
        public string FreqRText { get => GetFreqText(FreqRed, FreqLotRed); }

        string GetFreqText(decimal? freq, decimal? freqlot)
        {
            string freqText = null;
            if ((freq ?? 0) > 0)
            {
                freqText = "1/" + freq.Value.ToString("G0") + " " + Unit;
                if ((freqlot ?? 0) > 0) freqText = freqText + " (Min: " + freqlot.Value.ToString("G0") + " per lot )";
            }
            else
            {
                if ((freqlot ?? 0) > 0) freqText = "Min: " + freqlot.Value.ToString("G0") + " per lot";
                else return "No red. freq. info";
            }
            return freqText;
        }

    }

}
