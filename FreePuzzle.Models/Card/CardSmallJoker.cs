﻿namespace FreePuzzle.Models.Card
{
    public class CardSmallJoker : CardBase
    {
        public CardSmallJoker() : base() { }
        public CardSmallJoker(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "小鬼"; } }
    }
}
