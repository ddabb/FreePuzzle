using FreePuzzle.Models.Card;
using FreePuzzle.Service.Modules;
using System.Collections.Generic;

namespace FreePuzzle.Service
{
    public class GetFightAgainstLandlordAllCountCountService : FreePuzzleServiceBase
	{

        public Solution Solve()
        {
			freeSql.Insert<Card1>(new List<Card1> { new Card1(4,0,0) ,
				  new Card1(0,4,0) ,
				  new Card1(0,0,4) ,
				  new Card1(3,0,1) ,
				  new Card1(3,1,0) ,
				  new Card1(0,1,3) ,
				  new Card1(0,3,1) ,
				  new Card1(1,0,3) ,
				  new Card1(1,3,0) ,
				  new Card1(2,2,0) ,
				  new Card1(2,0,2) ,
				  new Card1(2,1,1) ,
				  new Card1(1,1,2) ,
				  new Card1(1,2,1) ,
				  new Card1(0,2,2) ,
		}).ExecuteAffrows();

			var result=freeSql.Select<Card1>().ToList();


			return new Solution();
        }
    }
}
