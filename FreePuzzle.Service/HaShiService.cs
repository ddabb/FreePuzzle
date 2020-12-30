using System.Collections.Generic;

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

            return nodeList;
        }

    }

    public class Node
    {
        public int Index { get; set; }
        public int Value { get; set; }

        public Node(int index, int value)
        {
            this.Index = index;
            this.Value = value;
        }
    }
}
