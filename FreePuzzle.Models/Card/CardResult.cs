using FreeSql.DataAnnotations;

namespace FreePuzzle.Models.Card
{
    [Index("{tablename}_idx_AllCount", "AllCount")]
    public class CardResult
    {
        public long group1_Landlord { get; set; }
        public long group1_Farmer1 { get; set; }
        public long group1_Farmer2 { get; set; }
        public long group2_Landlord { get; set; }
        public long group2_Farmer2 { get; set; }
        public long group1Count { get; set; }
        public long group3_Landlord { get; set; }
        public long group3Count { get; set; }
        public long group2Count { get; set; }
        public long group3_Farmer2 { get; set; }
        public long group3_Farmer1 { get; set; }
        public long group2_Farmer1 { get; set; }

        public long AllCount { get; set; }
    }
}
