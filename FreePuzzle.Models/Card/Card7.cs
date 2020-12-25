namespace FreePuzzle.Models.Card
{
    public class Card7 : CardBase
    {
        public Card7() : base() { }
        public Card7(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "7"; } }
    }
}
