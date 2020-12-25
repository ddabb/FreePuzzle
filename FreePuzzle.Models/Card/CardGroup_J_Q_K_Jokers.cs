namespace FreePuzzle.Models.Card
{
    public class CardGroup_J_Q_K_Jokers : CardBase
    {
        public CardGroup_J_Q_K_Jokers() : base() { }
        public CardGroup_J_Q_K_Jokers(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name => "卡牌JQK和大小鬼在农民和地主手中的组合数";
    }
}
