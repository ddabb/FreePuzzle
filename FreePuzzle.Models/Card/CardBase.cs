using System;

namespace FreePuzzle.Models.Card
{
    public abstract class CardBase: ICardBase
    {
        public CardBase() { }
        public CardBase(long landlord, long farmer1, long farmer2)
        {
            Landlord = landlord;
            Farmer1 = farmer1;
            Farmer2 = farmer2;
            CardAllCount = landlord + farmer1 + farmer2;

        }

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


        public T Set<T>(T t, long landlord, long farmer1, long farmer2) where T : CardBase
        {
            t= t.Clone(t);
            t.Landlord = landlord;
            t.Farmer1 = farmer1;
            t.Farmer2 = farmer2;
            t.CardAllCount = landlord + farmer1 + farmer2;
            return t;
        }

        public T Clone<T>(T t) where T : CardBase
        {
            return (T)t.MemberwiseClone();
        }





        /// <summary>
        /// 卡牌总计数
        /// </summary>
        public long CardAllCount { get; set; }
    }
}
