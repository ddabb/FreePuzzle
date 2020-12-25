namespace FreePuzzle.Models.Card
{
    public class CardQ : CardBase
    {
        public CardQ() : base() { }
        public CardQ(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "Queen"; } }
    }
}
