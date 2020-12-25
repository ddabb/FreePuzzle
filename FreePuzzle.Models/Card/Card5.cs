namespace FreePuzzle.Models.Card
{
    public class Card5 : CardBase
    {
        public Card5() : base() { }
        public Card5(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "5"; } }
    }
}
