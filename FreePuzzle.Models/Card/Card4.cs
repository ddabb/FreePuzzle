namespace FreePuzzle.Models.Card
{
    public class Card4 : CardBase
    {
        public Card4() : base() { }
        public Card4(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "4"; } }
    }
}
