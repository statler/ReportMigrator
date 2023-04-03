namespace cpModel.Helpers
{
    public class ItpHelpers
    {
        public const string ITPDetailTypes = "Quality,H&S,Environmental,Community,Other,Heading";
        public const string ITPCheckTypes = "Check Item,Witness Point,Hold Point,Milestone";
        public const string QtyBasis = "Schedule Quantities,Lot Length,Lot Area,Lot Volume";

        public static string[] ITPCheckTypeArray = ITPCheckTypes.Split(',');
        public static string[] ITPDetailTypeArray = ITPDetailTypes.Split(',');
        public static string[] QtyBasisArray = QtyBasis.Split(',');

    }
}
