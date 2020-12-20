using System;

namespace FreePuzzle.Models.Card
{
    public abstract class CardBase: ICardBase
    {
        public CardBase() { }


        public abstract string Name { get;}
        /// <summary>
        /// 地主
        /// </summary>
        public long Landlord { get; set; }
        /// <summary>
        /// 农民1
        /// </summary>
        public long Farmer1  { get; set; }

        /// <summary>
        /// 农民2
        /// </summary>
        public long Farmer2 { get; set; }

        public void Set(long landlord, long farmer1, long farmer2)
        {
            Landlord = landlord;
            Farmer1 = farmer1;
            Farmer2 = farmer2;
            CardAllCount = landlord + farmer1 + farmer2;
          
        }

        public CardBase Clone()
        {
            return (CardBase)this.MemberwiseClone();
        }

      

        /// <summary>
        /// 卡牌总计数
        /// </summary>
        public long CardAllCount { get; set; }
    }
}
