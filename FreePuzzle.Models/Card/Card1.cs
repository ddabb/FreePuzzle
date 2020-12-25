namespace FreePuzzle.Models.Card
{
    public class Card1 : CardBase
    {
        public Card1() : base() { }
        public Card1(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2){ }

        public override string Name { get { return "A"; } }
    }
}
