namespace FreePuzzle.Models.Card
{
    public class CardGroup_1_2_3_4_5 : CardBase
    {
        public CardGroup_1_2_3_4_5() : base() { }
        public CardGroup_1_2_3_4_5(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name => "卡牌1,2,3,4,5在农民和地主手中的组合数";
    }
}
