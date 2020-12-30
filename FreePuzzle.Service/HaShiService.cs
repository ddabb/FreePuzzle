using System.Collections.Generic;
using System.Linq;
namespace FreePuzzle.Service
{
    public class HaShiService : FreePuzzleServiceBase
    {

        public List<Node> Solve()
        {
            List<Node> nodeList = new List<Node>
            {
                new Node(2,2),
                new Node(5,3),
                new Node(8,2),
                new Node(10,2),
                new Node(11,4),
                new Node(13,2),
                new Node(15,1),
                new Node(17,4),
                new Node(18,2),
                new Node(21,2),
                new Node(23,3),
                new Node(25,2),
                new Node(29,3),
                new Node(31,2),
                new Node(33,2),
                new Node(35,2),
                new Node(37,3),
                new Node(39,3),
                new Node(43,3),
                new Node(45,3),
                new Node(47,2),
                new Node(49,3),
                new Node(51,2),
                new Node(53,2),
                new Node(57,2),
                new Node(59,2),
                new Node(61,2),
                new Node(64,2),
                new Node(65,4),
                new Node(67,3),
                new Node(69,1),
                new Node(71,5),
                new Node(72,1),
                new Node(74,2),
                new Node(77,3),
                new Node(80,2),
            };
            foreach (var item in nodeList)
            {
                item.SetAdjacentIndex(nodeList);
            }

            return nodeList;
        }

    }

    public class IndexMap
    {
        public int StartIndex;
        public int EndIndex;
        public IndexMap (int startIndex,int endIndex)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
        }

    }

    public class Node
    {
        public int Index { get; set; }
        public int Value { get; set; }

        public int Width = 9;

        public int TopIndex { get; set; }

        public int LeftIndex { get; set; }

        public int BottomIndex { get; set; }

        public int RightIndex { get; set; }

        public List<IndexMap>  IndexMaps
        {
            get
            {
                List<IndexMap> map = new List<IndexMap>();
                if (TopIndex!=0)
                {
                    map.Add(new IndexMap(Index, TopIndex));
                }
                if (LeftIndex!=0)
                {
                    map.Add(new IndexMap(Index, LeftIndex));
                }
                if (RightIndex != 0)
                {
                    map.Add(new IndexMap(Index, RightIndex));
                }
                if (BottomIndex != 0)
                {
                    map.Add(new IndexMap(Index, BottomIndex));
                }
                return map;
            }

        }

        public Node(int index, int value, int width = 9)
        {
            this.Index = index;
            this.Value = value;
        }

        public int Row
        {
            get
            {
                if (Index % 9 == 0)
                    return Index / 9;
                else
                {
                    return (Index / 9) + 1;
                }
            }

        }

        public void SetAdjacentIndex(List<Node> nodes)
        {
            var otherNode = nodes.Where(c => c.Index != Index).ToList();
            if (otherNode.Exists(c => c.Column == this.Column && c.Row < this.Row))
            {
                TopIndex = otherNode.Where(c => c.Column == this.Column && c.Row < this.Row).OrderBy(c => c.Index).Last().Index;
            }
            if (otherNode.Exists(c => c.Column == this.Column && c.Row > this.Row))
            {
                BottomIndex = otherNode.Where(c => c.Column == this.Column && c.Row > this.Row).OrderBy(c => c.Index).First().Index;
            }
            if (otherNode.Exists(c => c.Row == this.Row && c.Column < this.Column))
            {
                LeftIndex = otherNode.Where(c => c.Row == this.Row && c.Column < this.Column).OrderBy(c => c.Index).Last().Index;
            }
            if (otherNode.Exists(c => c.Row == this.Row && c.Column > this.Column))
            {
                RightIndex = otherNode.Where(c => c.Row == this.Row && c.Column > this.Column).OrderBy(c => c.Index).First().Index;
            }
        }

        public int Column
        {
            get
            {
                if (Index % 9 == 0)
                    return 9;
                else
                {
                    return Index % 9;
                }
            }

        }
    }
}
