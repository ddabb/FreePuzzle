﻿namespace FreePuzzle.Models.Card
{
    public class CardK : CardBase
    {
        public CardK() : base() { }
        public CardK(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "King"; } }
    }
}
