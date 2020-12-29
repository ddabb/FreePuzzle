using FreePuzzle.Models.Card;
using FreePuzzle.Service.Modules;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FreePuzzle.Service
{
    public class GetFightAgainstLandlordAllCountService : FreePuzzleServiceBase
    {
        public IEnumerable<ICardBase> cards { get; set; }

        public GetFightAgainstLandlordAllCountService(IEnumerable<ICardBase> cards) : base()
        {
            this.cards = cards;
        }

        /// <summary>
        /// 获取卡牌T在玩家地主和两个农民的可能数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> GetNormalCardList<T>(T t) where T : CardBase, new()
        {
            List<T> cardList = new List<T>()
            {
                t.Set(t,4, 0, 0),
                t.Set(t,0, 4, 0),
                t.Set(t,0, 0, 4),
                t.Set(t,3, 0, 1),
                t.Set(t,3, 1, 0),
                t.Set(t,0, 1, 3),
                t.Set(t,0, 3, 1),
                t.Set(t,1, 0, 3),
                t.Set(t,1, 3, 0),
                t.Set(t,2, 2, 0),
                t.Set(t,2, 0, 2),
                t.Set(t,2, 1, 1),
                t.Set(t,1, 1, 2),
                t.Set(t,1, 2, 1),
                t.Set(t,0, 2, 2)
            };
            return cardList;
        }
        public List<T> GetJokerCardList<T>(T t) where T : CardBase, new()
        {
            List<T> cardList = new List<T>()
            {
                t.Set(t,1, 0, 0),
                t.Set(t,0, 1, 0),
                t.Set(t,0, 0, 1),
            };
            return cardList;
        }

        public Task<Solution> GetSolveAsync()
        {
   
            return Task.FromResult(Solve());
        }


        public Solution Solve()
        {
            try
            {
                List<Card1> card1s = GetNormalCardList(new Card1());
                List<Card2> Card2s = GetNormalCardList(new Card2());
                List<Card3> Card3s = GetNormalCardList(new Card3());
                List<Card4> Card4s = GetNormalCardList(new Card4());
                List<Card5> Card5s = GetNormalCardList(new Card5());
                List<Card6> Card6s = GetNormalCardList(new Card6());
                List<Card7> Card7s = GetNormalCardList(new Card7());
                List<Card8> Card8s = GetNormalCardList(new Card8());
                List<Card9> Card9s = GetNormalCardList(new Card9());
                List<Card10> Card10s = GetNormalCardList(new Card10());
                List<CardJ> CardJs = GetNormalCardList(new CardJ());
                List<CardQ> CardQs = GetNormalCardList(new CardQ());
                List<CardK> CardKs = GetNormalCardList(new CardK());
                List<CardSmallJoker> smallJokers = GetJokerCardList(new CardSmallJoker());
                List<CardBigJoker> bigJokers = GetJokerCardList(new CardBigJoker());
                freeSql.Delete<Card1>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card2>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card3>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card4>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card5>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card6>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card7>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card8>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card9>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<Card10>().Where("landlord<> -1").ExecuteAffrows();
                freeSql.Delete<CardJ>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<CardQ>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<CardK>().Where("landlord<>-1").ExecuteAffrows();
                freeSql.Delete<CardSmallJoker>().Where("landlord<> -1").ExecuteAffrows();
                freeSql.Delete<CardBigJoker>().Where("landlord<> -1").ExecuteAffrows();    
                freeSql.Select<DistinctGroup>().Count();
                freeSql.Select<CardGroup>().Count();
                freeSql.Select<CardResult>().Count();
                freeSql.Ado.ExecuteNonQuery("truncate table DistinctGroup;  ");
                freeSql.Ado.ExecuteNonQuery("truncate table CardGroup;  ");
                freeSql.Ado.ExecuteNonQuery("truncate table CardResult;  ");

                freeSql.Insert(card1s).ExecuteAffrows();
                freeSql.Insert(Card2s).ExecuteAffrows();
                freeSql.Insert(Card3s).ExecuteAffrows();
                freeSql.Insert(Card4s).ExecuteAffrows();
                freeSql.Insert(Card5s).ExecuteAffrows();
                freeSql.Insert(Card6s).ExecuteAffrows();
                freeSql.Insert(Card7s).ExecuteAffrows();
                freeSql.Insert(Card8s).ExecuteAffrows();
                freeSql.Insert(Card9s).ExecuteAffrows();
                freeSql.Insert(Card10s).ExecuteAffrows();
                freeSql.Insert(CardJs).ExecuteAffrows();
                freeSql.Insert(CardQs).ExecuteAffrows();
                freeSql.Insert(CardKs).ExecuteAffrows();
                freeSql.Insert(smallJokers).ExecuteAffrows();
                freeSql.Insert(bigJokers).ExecuteAffrows();

                var batchid = Guid.NewGuid().ToString().Replace("-", "");




                freeSql.Select<Card1, Card2, Card3, Card4, Card5>().Where(t => t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord <= 20
                   && t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1 <= 17
                   && t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2 <= 17
                ).InsertInto<CardGroup>("", t => new CardGroup
                {

                    Landlord = t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord,
                    Farmer1 = t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1,
                    Farmer2 = t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2,
                    GroupIndex = 1
                }

                );

                                freeSql.Select<Card6, Card7, Card8, Card9, Card10>().Where(t => t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord <= 20
                   && t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1 <= 17
                   && t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2 <= 17
                ).InsertInto<CardGroup>("", t => new CardGroup
                {

                    Landlord = t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord,
                    Farmer1 = t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1,
                    Farmer2 = t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2,
                    GroupIndex = 2
                }

                );
                                freeSql.Select<CardJ, CardQ, CardK, CardSmallJoker, CardBigJoker>().Where(t => t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord <= 20
                   && t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1 <= 17
                   && t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2 <= 17
                ).InsertInto<CardGroup>("", t => new CardGroup
                {

                    Landlord = t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord,
                    Farmer1 = t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1,
                    Farmer2 = t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2,
                    GroupIndex = 3
                }

                );

                (from a in freeSql.Select<CardGroup>().Where(c => c.GroupIndex == 1).Distinct()
                 select a).InsertInto<DistinctGroup>("", c => new DistinctGroup { GroupIndex = 1, Farmer1 = c.Farmer1, Landlord = c.Landlord, Farmer2 = c.Farmer2 });
                (from a in freeSql.Select<CardGroup>().Where(c => c.GroupIndex == 2).Distinct()
                 select a).InsertInto<DistinctGroup>("", c => new DistinctGroup { GroupIndex = 2, Farmer1 = c.Farmer1, Landlord = c.Landlord, Farmer2 = c.Farmer2 });
                (from a in freeSql.Select<CardGroup>().Where(c => c.GroupIndex == 3).Distinct()
                 select a).InsertInto<DistinctGroup>("", c => new DistinctGroup { GroupIndex = 3, Farmer1 = c.Farmer1, Landlord = c.Landlord, Farmer2 = c.Farmer2 });

                var sq11 = freeSql.Select<CardGroup>().Where(c => c.GroupIndex == 1).Distinct().ToList(x => new { x.Landlord, x.Farmer1, x.Farmer2 });

                freeSql.Select<DistinctGroup, DistinctGroup, DistinctGroup>().Where(t => t.t1.GroupIndex == 1 && t.t2.GroupIndex == 2 && t.t3.GroupIndex == 3
                  && t.t1.Landlord + t.t2.Landlord + t.t3.Landlord == 20
                  && t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 == 17
                 && t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 == 17)
                    .InsertInto<CardResult>("", t => new CardResult
                    {
                        group1_Landlord = t.t1.Landlord,
                        group1_Farmer1 = t.t1.Farmer1,
                        group1_Farmer2 = t.t1.Farmer2,
                        group2_Landlord = t.t2.Landlord,
                        group2_Farmer1 = t.t2.Farmer1,
                        group2_Farmer2 = t.t2.Farmer2,
                        group3_Landlord = t.t3.Landlord,
                        group3_Farmer1 = t.t3.Farmer1,
                        group3_Farmer2 = t.t3.Farmer2,
                        group1Count = 0,
                        group2Count = 0,
                        group3Count = 0,
                        AllCount = 0

                    }
                              );



                freeSql.Update<CardResult>()
                       .SetRaw("group1count=(select count(1) from CardGroup where groupindex=1 and landlord=group1_landlord and farmer1=group1_farmer1 and farmer2=group1_farmer2)")
                       .SetRaw("group2count=(select count(1) from CardGroup where groupindex=2 and landlord=group2_Landlord and farmer1=group2_farmer1 and farmer2=group2_farmer2)")
                       .SetRaw("group3count=(select count(1) from CardGroup where groupindex=3 and landlord=group3_Landlord and farmer1=group3_Farmer1 and farmer2=group3_farmer2)")
                       .Where("1=1").ExecuteAffrows();


                freeSql.Update<CardResult>().Set((item) =>
                new CardResult
                {
                    AllCount = item.group1Count * item.group2Count * item.group3Count
                }).Where(c => true).ExecuteAffrows();
                ;
                var allCount = freeSql.Select<CardResult>().Sum(c => c.AllCount);
                return new Solution() { Desciption = "总组合个数是" + allCount };
            }
            catch (System.Exception ex)
            {

                throw;
            }

        }

        private string IntoNewTable(string tableName, string sql)
        {
            return sql.Replace("FROM", $"INTO {tableName} FROM");
        }
    }
}
