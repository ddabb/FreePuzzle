namespace FreePuzzle.Models.Card
{
    public class CardGroup : CardBase
    {
        public CardGroup() : base() { }
        public int GroupIndex { get; set; }
        public CardGroup(long landlord, long farmer1, long farmer2,int groupIndex) : base(landlord, farmer1, farmer2) { GroupIndex = groupIndex; }
        public override string Name => "卡牌1,2,3,4,5在农民和地主手中的组合数";
    }
}
