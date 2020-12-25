namespace FreePuzzle.Models.Card
{
    public class Card6 : CardBase
    {
        public Card6() : base() { }
        public Card6(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "6"; } }
    }
}
