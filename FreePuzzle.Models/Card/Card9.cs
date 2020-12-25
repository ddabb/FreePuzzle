namespace FreePuzzle.Models.Card
{
    public class Card9 : CardBase
    {
        public Card9() : base() { }
        public Card9(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "9"; } }
    }
}
