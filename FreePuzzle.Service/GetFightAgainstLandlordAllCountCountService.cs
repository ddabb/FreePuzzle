using FreePuzzle.Models.Card;
using FreePuzzle.Service.Modules;
using FreeSql;
using System;
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


		public class distinctgroup
		{
			public long Landlord { get; set; }
			public long Farmer1 { get; set; }
			public long Farmer2 { get; set; }
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
				freeSql.Delete<distinctgroup_1_5>().Where("landlord<> -1").ExecuteAffrows();
				freeSql.Delete<distinctgroup_6_10>().Where("landlord<> -1").ExecuteAffrows();
				freeSql.Delete<distinctgroup_J_Joker>().Where("landlord<> -1").ExecuteAffrows();
				freeSql.Delete<CardGroup>().Where("landlord<> -1").ExecuteAffrows();

				freeSql.Delete<CardResult>().Where("allcount<>-1").ExecuteAffrows();

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


				//var repo = freeSql.GetRepository<CardGroup>();
				/*		repo.AsTable(oldname => $"{oldname}{batchid}"); *///对 Log_201903 表 CRUD
				freeSql.Insert(
				freeSql.Select<Card1, Card2, Card3, Card4, Card5>().Where(t => t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord <= 20
				   && t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1 <= 17
				   && t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2 <= 17
				).ToList(t => new CardGroup { Landlord = t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord, Farmer1 = t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1, Farmer2 = t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2, GroupIndex = 1 })).ExecuteAffrows();
				freeSql.Insert(freeSql.Select<Card6, Card7, Card8, Card9, Card10>().Where(t => t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord <= 20
				   && t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1 <= 17
				   && t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2 <= 17
				).ToList(t => new CardGroup { Landlord = t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord, Farmer1 = t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1, Farmer2 = t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2, GroupIndex = 2 })).ExecuteAffrows();
				freeSql.Insert(freeSql.Select<CardJ, CardQ, CardK, CardSmallJoker, CardBigJoker>().Where(t => t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord <= 20
   && t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1 <= 17
   && t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2 <= 17
).ToList(t => new CardGroup { Landlord = t.t1.Landlord + t.t2.Landlord + t.t3.Landlord + t.t4.Landlord + t.t5.Landlord, Farmer1 = t.t1.Farmer1 + t.t2.Farmer1 + t.t3.Farmer1 + t.t4.Farmer1 + t.t5.Farmer1, Farmer2 = t.t1.Farmer2 + t.t2.Farmer2 + t.t3.Farmer2 + t.t4.Farmer2 + t.t5.Farmer2, GroupIndex = 3 })).ExecuteAffrows();

			


			//	freeSql.Ado.ExecuteNonQuery(System.Data.CommandType.Text, $"select distinct  Landlord, Farmer1,Farmer2 into distinctgroup1{batchid} from cardgroup1{batchid}");
			//	freeSql.Ado.ExecuteNonQuery(System.Data.CommandType.Text, $"select distinct  Landlord, Farmer1,Farmer2 into distinctgroup2{batchid} from cardgroup2{batchid}");
			//	freeSql.Ado.ExecuteNonQuery(System.Data.CommandType.Text, $"select distinct  Landlord, Farmer1,Farmer2 into distinctgroup3{batchid} from cardgroup3{batchid}");




			//var temp=	(from a in freeSql.Select<distinctgroup>().AsTable((type, oldname) => $"{oldname}1{batchid}")
			//	 from b in freeSql.Select<distinctgroup>().AsTable((type, oldname) => $"{oldname}2{batchid}")
			//	 from c in freeSql.Select<distinctgroup>().AsTable((type, oldname) => $"{oldname}3{batchid}")
			
			//			 where a.Landlord + b.Landlord + c.Landlord == 20
			//		&& a.Farmer1 + b.Farmer1 + c.Farmer1 == 17
			//		&& a.Farmer2 + b.Farmer2 + c.Farmer2 == 17
			//	 select new CardResult
			//	 {
			//		 group1_Landlord = a.Landlord,
			//		 group1_Farmer1 = a.Farmer1,
			//		 group1_Farmer2 = a.Farmer2,
			//		 group2_Landlord = b.Landlord,
			//		 group2_Farmer1 = b.Farmer1,
			//		 group2_Farmer2 = b.Farmer2,
			//		 group3_Landlord = c.Landlord,
			//		 group3_Farmer1 = c.Farmer1,
			//		 group3_Farmer2 = c.Farmer2,
			//		 group1Count = 0,
			//		 group2Count = 0,
			//		 group3Count = 0,
			//		 AllCount = 0
			//	 }
			//				  ).ToList();
				//.InsertInto<CardResult>("", c => new CardResult
				//			  {
				//				  group1_Landlord = c.group1_Landlord,
				//				  group1_Farmer1 = c.group1_Farmer1,
				//				  group1_Farmer2 = c.group1_Farmer2,
				//				  group2_Landlord = c.group2_Landlord,
				//				  group2_Farmer1 = c.group2_Farmer1,
				//				  group2_Farmer2 = c.group2_Farmer2,
				//				  group3_Landlord = c.group3_Landlord,
				//				  group3_Farmer1 = c.group3_Farmer1,
				//				  group3_Farmer2 = c.group3_Farmer2,
				//				  group1Count = 0,
				//				  group2Count = 0,
				//				  group3Count = 0,
				//				  AllCount = 0

				//			  }
				//			  );



				//var cardgroup1 = (from c1 in card1s
				//				  from c2 in Card2s
				//				  from c3 in Card3s
				//				  from c4 in Card4s
				//				  from c5 in Card5s
				//				  let Landlord = c1.Landlord + c2.Landlord + c3.Landlord + c4.Landlord + c5.Landlord
				//				  let Farmer1 = c1.Farmer1 + c2.Farmer1 + c3.Farmer1 + c4.Farmer1 + c5.Farmer1
				//				  let Farmer2 = c1.Farmer2 + c2.Farmer2 + c3.Farmer2 + c4.Farmer2 + c5.Farmer2
				//				  where Landlord <= 20 && Farmer1 <= 17 && Farmer2 <= 17
				//				  select new CardGroup(Landlord, Farmer1, Farmer2)).ToList();

				//var cardgroup2 = (from c6 in Card6s
				//				  from c7 in Card7s
				//				  from c8 in Card8s
				//				  from c9 in Card9s
				//				  from c10 in Card10s
				//				  let Landlord = c6.Landlord + c7.Landlord + c8.Landlord + c9.Landlord + c10.Landlord
				//				  let Farmer1 = c6.Farmer1 + c7.Farmer1 + c8.Farmer1 + c9.Farmer1 + c10.Farmer1
				//				  let Farmer2 = c6.Farmer2 + c7.Farmer2 + c8.Farmer2 + c9.Farmer2 + c10.Farmer2
				//				  where Landlord <= 20 && Farmer1 <= 17 && Farmer2 <= 17
				//				  select new CardGroup_6_7_8_9_10(Landlord, Farmer1, Farmer2)).ToList();

				//var cardgroup3 = (from c6 in CardJs
				//				  from c7 in CardQs
				//				  from c8 in CardKs
				//				  from c9 in smallJokers
				//				  from c10 in bigJokers
				//				  let Landlord = c6.Landlord + c7.Landlord + c8.Landlord + c9.Landlord + c10.Landlord
				//				  let Farmer1 = c6.Farmer1 + c7.Farmer1 + c8.Farmer1 + c9.Farmer1 + c10.Farmer1
				//				  let Farmer2 = c6.Farmer2 + c7.Farmer2 + c8.Farmer2 + c9.Farmer2 + c10.Farmer2
				//				  where Landlord <= 20 && Farmer1 <= 17 && Farmer2 <= 17
				//				  select new CardGroup_J_Q_K_Jokers(Landlord, Farmer1, Farmer2)).ToList();

				//freeSql.Select<CardGroup_1_2_3_4_5>().Distinct().ToList(x=>new { x.Landlord, x.Farmer1,x.Farmer2}).AsSelect().InsertInto<distinctgroup_1_5>("", c => new distinctgroup_1_5{Landlord=c.Landlord, Farmer1= c.Farmer1, Farmer2= c.Farmer2 });

				//freeSql.Select<CardGroup_6_7_8_9_10>().Distinct().InsertInto<distinctgroup_6_10>("", c => new distinctgroup_6_10 { Landlord = c.Landlord, Farmer1 = c.Farmer1, Farmer2 = c.Farmer2 });

				//freeSql.Select<CardGroup_J_Q_K_Jokers>().Distinct().InsertInto<distinctgroup_J_Joker>("", c => new distinctgroup_J_Joker { Landlord = c.Landlord, Farmer1 = c.Farmer1, Farmer2 = c.Farmer2 });
				//var distinctgroup1 = (from item in cardgroup1
				//					  select new { item.Landlord, item.Farmer1, item.Farmer2 }).Distinct().ToList();
				//var distinctgroup2 = (from item in cardgroup2
				//					  select new { item.Landlord, item.Farmer1, item.Farmer2 }).Distinct().ToList();
				//var distinctgroup3 = (from item in cardgroup3
				//					  select new { item.Landlord, item.Farmer1, item.Farmer2 }).Distinct().ToList();
				//var result = (from group1 in distinctgroup1
				//			  from group2 in distinctgroup2
				//			  from group3 in distinctgroup3
				//			  let Landlord = group1.Landlord + group2.Landlord + group3.Landlord
				//			  let Farmer1 = group1.Farmer1 + group2.Farmer1 + group3.Farmer1
				//			  let Farmer2 = group1.Farmer2 + group2.Farmer2 + group3.Farmer2
				//			  where Landlord == 20 && Farmer1 == 17 && Farmer2 == 17
				//			  select new CardResult
				//			  {
				//				  group1_Landlord = group1.Landlord,
				//				  group1_Farmer1 = group1.Farmer1,
				//				  group1_Farmer2 = group1.Farmer2,
				//				  group2_Landlord = group2.Landlord,
				//				  group2_Farmer1 = group2.Farmer1,
				//				  group2_Farmer2 = group2.Farmer2,
				//				  group3_Landlord = group3.Landlord,
				//				  group3_Farmer1 = group3.Farmer1,
				//				  group3_Farmer2 = group3.Farmer2,
				//				  group1Count = 0,
				//				  group2Count = 0,
				//				  group3Count = 0,
				//				  AllCount = 0
				//			  }
				//	).ToList();

				//freeSql.Insert(result).ExecuteAffrows();

				//freeSql.Update<CardResult>()
				//	   .SetRaw("group1count=(select count(1) from cardgroup_1_2_3_4_5 where landlord=group1_landlord and farmer1=group1_farmer1 and farmer2=group1_farmer2)")
				//	   .SetRaw("group2count=(select count(1) from cardgroup_6_7_8_9_10 where landlord=group2_Landlord and farmer1=group2_farmer1 and farmer2=group2_farmer2)")
				//	   .SetRaw("group3count=(select count(1) from cardgroup_j_q_k_jokers where landlord=group3_Landlord and farmer1=group3_Farmer1 and farmer2=group3_farmer2)")
				//	   .Where(c => true).ExecuteAffrows();


				//freeSql.Update<CardResult>().Set((item) =>
				//new CardResult
				//{
				//	AllCount = item.group1Count * item.group2Count * item.group3Count
				//}).Where(c => true).ExecuteAffrows();
				//;
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
