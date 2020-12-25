using FreePuzzle.Models.Card;
using FreePuzzle.Service.Modules;
using System.Collections.Generic;
using System.Linq;
namespace FreePuzzle.Service
{
    public class GetFightAgainstLandlordAllCountCountService : FreePuzzleServiceBase
	{
		public IEnumerable<ICardBase> cards { get; set; }

		public GetFightAgainstLandlordAllCountCountService(IEnumerable<ICardBase> cards) : base()
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

		public Solution Solve()
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
			freeSql.Delete<CardGroup_1_2_3_4_5>().Where("1=1");
			freeSql.Delete<CardGroup_6_7_8_9_10>().Where("1=1");
			freeSql.Delete<CardGroup_J_Q_K_Jokers>().Where("1=1");
			freeSql.Delete<CardGroup_J_Q_K_Jokers>().Where("1=1");
			freeSql.Delete<CardResult>().Where("1=1");
			var cardgroup1 = (from c1 in card1s
							  from c2 in Card2s
							  from c3 in Card3s
							  from c4 in Card4s
							  from c5 in Card5s
							  let Landlord = c1.Landlord + c2.Landlord + c3.Landlord + c4.Landlord + c5.Landlord
							  let Farmer1 = c1.Farmer1 + c2.Farmer1 + c3.Farmer1 + c4.Farmer1 + c5.Farmer1
							  let Farmer2 = c1.Farmer2 + c2.Farmer2 + c3.Farmer2 + c4.Farmer2 + c5.Farmer2
							  where Landlord <= 20 && Farmer1 <= 17 && Farmer2 <= 17
							  select new CardGroup_1_2_3_4_5(Landlord, Farmer1, Farmer2)).ToList();

			var cardgroup2 = (from c6 in Card6s
							  from c7 in Card7s
							  from c8 in Card8s
							  from c9 in Card9s
							  from c10 in Card10s
							  let Landlord = c6.Landlord + c7.Landlord + c8.Landlord + c9.Landlord + c10.Landlord
							  let Farmer1 = c6.Farmer1 + c7.Farmer1 + c8.Farmer1 + c9.Farmer1 + c10.Farmer1
							  let Farmer2 = c6.Farmer2 + c7.Farmer2 + c8.Farmer2 + c9.Farmer2 + c10.Farmer2
							  where Landlord <= 20 && Farmer1 <= 17 && Farmer2 <= 17
							  select new CardGroup_6_7_8_9_10(Landlord, Farmer1, Farmer2)).ToList();

			var cardgroup3 = (from c6 in CardJs
							  from c7 in CardQs
							  from c8 in CardKs
							  from c9 in smallJokers
							  from c10 in bigJokers
							  let Landlord = c6.Landlord + c7.Landlord + c8.Landlord + c9.Landlord + c10.Landlord
							  let Farmer1 = c6.Farmer1 + c7.Farmer1 + c8.Farmer1 + c9.Farmer1 + c10.Farmer1
							  let Farmer2 = c6.Farmer2 + c7.Farmer2 + c8.Farmer2 + c9.Farmer2 + c10.Farmer2
							  where Landlord <= 20 && Farmer1 <= 17 && Farmer2 <= 17
							  select new CardGroup_J_Q_K_Jokers(Landlord, Farmer1, Farmer2)).ToList();

			var distinctgroup1 = (from item in cardgroup1
								  select new { item.Landlord, item.Farmer1, item.Farmer2 }).Distinct().ToList();
			var distinctgroup2 = (from item in cardgroup2
								  select new { item.Landlord, item.Farmer1, item.Farmer2 }).Distinct().ToList();
			var distinctgroup3 = (from item in cardgroup3
								  select new { item.Landlord, item.Farmer1, item.Farmer2 }).Distinct().ToList();
			var result = (from group1 in distinctgroup1
						  from group2 in distinctgroup2
						  from group3 in distinctgroup3
						  let Landlord = group1.Landlord + group2.Landlord + group3.Landlord
						  let Farmer1 = group1.Farmer1 + group2.Farmer1 + group3.Farmer1
						  let Farmer2 = group1.Farmer2 + group2.Farmer2 + group3.Farmer2
						  where Landlord == 20 && Farmer1 == 17 && Farmer2 == 17
						  select new CardResult
						  {
							  group1_Landlord = group1.Landlord,
							  group1_Farmer1 = group1.Farmer1,
							  group1_Farmer2 = group1.Farmer2,
							  group2_Landlord = group2.Landlord,
							  group2_Farmer1 = group2.Farmer1,
							  group2_Farmer2 = group2.Farmer2,
							  group3_Landlord = group3.Landlord,
							  group3_Farmer1 = group3.Farmer1,
							  group3_Farmer2 = group3.Farmer2,
							  group1Count = 0,
							  group2Count = 0,
							  group3Count = 0,
							  AllCount = 0
						  }
				).ToList();
			freeSql.Insert(cardgroup1);
			freeSql.Insert(cardgroup2);
			freeSql.Insert(cardgroup3);
			freeSql.Insert(result);
			freeSql.Update<CardResult>().Set(item => new CardResult
			{
				group1Count = freeSql.Select<CardGroup_1_2_3_4_5>().Where(c => c.Landlord == item.group1_Landlord && c.Farmer1 == item.group1_Farmer1 && c.Farmer2 == item.group1_Farmer2).Count(),
				group2Count = freeSql.Select<CardGroup_6_7_8_9_10>().Where(c => c.Landlord == item.group2_Landlord && c.Farmer1 == item.group2_Farmer1 && c.Farmer2 == item.group2_Farmer2).Count(),
				group3Count = freeSql.Select<CardGroup_J_Q_K_Jokers>().Where(c => c.Landlord == item.group3_Landlord && c.Farmer1 == item.group3_Farmer1 && c.Farmer2 == item.group3_Farmer2).Count(),
			}).ExecuteAffrows();


			freeSql.Update<CardResult>().Set((item) =>
			new CardResult
			{
				AllCount = item.group1Count * item.group2Count * item.group3Count
			});
			;
			var allCount = freeSql.Select<CardResult>().Sum(c => c.AllCount);
			return new Solution() { Desciption = "总组合个数是" + allCount };
		}
	}
}
