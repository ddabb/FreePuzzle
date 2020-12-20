namespace FreePuzzle.Models.Card
{
    public interface ICardBase
    {
        void Set(long landlord, long farmer1, long farmer2);

        CardBase Clone();

       string Name { get; }
    }
}
