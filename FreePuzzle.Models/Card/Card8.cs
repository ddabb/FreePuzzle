namespace FreePuzzle.Models.Card
{
    public class Card8 : CardBase
    {
        public Card8() : base() { }
        public Card8(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "8"; } }
    }
}
