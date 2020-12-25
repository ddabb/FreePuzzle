using FreePuzzle.Models.Card;
using FreePuzzle.Service.Modules;
using System.Collections.Generic;

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

			return new Solution();
		}
	}
}
