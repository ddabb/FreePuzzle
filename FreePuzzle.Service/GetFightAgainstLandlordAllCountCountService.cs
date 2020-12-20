using FreePuzzle.Models.Card;
using FreePuzzle.Service.Modules;
using System.Collections.Generic;

namespace FreePuzzle.Service
{
    public class GetFightAgainstLandlordAllCountCountService : FreePuzzleServiceBase
	{
		public IEnumerable<ICardBase> cards { get; set; }

		public GetFightAgainstLandlordAllCountCountService(IEnumerable<ICardBase> cards):base()
		{
			this.cards = cards;
		}


		public Solution Solve()
        {
			foreach (var item in cards)
			{

				if (new List<string> { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Queen", "King" }.Contains(item.Name))
				{
		
					//List<ICardBase> cards = new List<ICardBase>
					//{
					//temp,
					////item.Clone().Set(0, 4, 0),
					////item.Clone().Set(0, 0, 4),
					////item.Clone().Set(3, 0, 1),
					////item.Clone().Set(3, 1, 0),
					////item.Clone().Set(0, 1, 3),
					////item.Clone().Set(0, 3, 1),
					////item.Clone().Set(1, 0, 3),
					////item.Clone().Set(1, 3, 0),
					////item.Clone().Set(2, 2, 0),
					////item.Clone().Set(2, 0, 2),
					////item.Clone().Set(2, 1, 1),
					////item.Clone().Set(1, 1, 2),
					////item.Clone().Set(1, 2, 1),
					////item.Clone().Set(0, 2, 2),
					//};
					 item.Set(4, 0, 0);
					freeSql.Insert(item).ExecuteAffrows();















				}
                else if (new List<string> { "大鬼", "小鬼"}.Contains(item.Name))
                {
					//freeSql.Insert(item.Clone().Set(1, 0, 0));
					//freeSql.Insert(item.Clone().Set(0, 1, 0));
					//freeSql.Insert(item.Clone().Set(0, 1, 1));
				}

			}


			return new Solution();
        }
    }
}
