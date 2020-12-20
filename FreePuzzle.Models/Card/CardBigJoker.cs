namespace FreePuzzle.Models.Card
{
    public class CardBigJoker : CardBase
    {
        public CardBigJoker(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "大鬼"; } }
    }
}
