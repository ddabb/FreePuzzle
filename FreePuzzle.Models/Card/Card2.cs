namespace FreePuzzle.Models.Card
{
    public class Card2 : CardBase
    {
        public Card2() : base() { }
        public Card2(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "2"; } }
    }
}
