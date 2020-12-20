namespace FreePuzzle.Models.Card
{
    public class CardJ : CardBase
    {
        public CardJ(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "J"; } }
    }
}
