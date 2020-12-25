using System;
using System.Collections.Generic;
using System.Text;

namespace FreePuzzle.Models.Card
{
    public  class Card3: CardBase
    {
        public Card3() : base() { }
        public Card3(long landlord, long farmer1, long farmer2) : base(landlord, farmer1, farmer2) { }
        public override string Name { get { return "3"; } }
    }
}
