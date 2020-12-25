namespace FreePuzzle.Models.Card
{
    public interface ICardBase 
    {
        T Set<T>(T t,long landlord, long farmer1, long farmer2) where T:CardBase;

        T  Clone<T>(T t) where T : CardBase;

        string Name { get; }
    }
}
