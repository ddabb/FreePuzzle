namespace FreePuzzle.Models.Card
{
    public class Card10 : CardBase
    {
        public Card10(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "10"; } }
    }
}
