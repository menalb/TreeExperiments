using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{

    static class StackHelper
    {

        public static Node PeekOrDefault(this Stack<Node> s)
        {
            return s.Count == 0 ? null : s.Peek();
        }

        public static void PushReverse(this Stack<Node> s, List<Node> list)
        {
            foreach (var l in list.ToArray().Reverse())
            {
                s.Push(l);
            }
        }
    }

    class Node
    {
        public string Id;
        public List<Node> Children;
        public Node(string id)
        {
            Id = id;
            Children = new List<Node>();
        }

        public Node(string id, List<Node> children)
        {
            Id = id;
            Children = children;
        }

        public override bool Equals(object obj)
        {
            var node = obj as Node;
            if (node != null)
            {
                return node.Id == this.Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
        class Test
    {
        private static void nonRecursivePostOrder(Node root)
        {
            var toVisit = new Stack<Node>();
            var visitedAncestors = new Stack<Node>();
            toVisit.Push(root);
            while (toVisit.Count > 0)
            {
                var node = toVisit.Peek();
                if (node.Children.Count > 0)
                {
                    if (visitedAncestors.PeekOrDefault() != node)
                    {
                        visitedAncestors.Push(node);
                        toVisit.PushReverse(node.Children);
                        continue;
                    }
                    visitedAncestors.Pop();
                }
                Console.Write(node.Id);
                toVisit.Pop();
            }
        }

        private static Node makeTree()
        {
            var e = new Node("e");
            var f = new Node("f");
            var b = new Node("b", new List<Node> { e, f });
            var g = new Node("g");
            var c = new Node("c", new List<Node> { g });
            var h = new Node("h");
            var i = new Node("i");
            var d = new Node("d", new List<Node> { h, i });
            var a = new Node("a", new List<Node> { b, c, d });
            return a;
        }

       

    
    
    static void Main(string[] args)
        {

            int _count;
            _count = Convert.ToInt32(Console.ReadLine());

            OutputCommonManager(_count);


            Console.ReadKey();
            return;



            //       a
            //   b    c    d
            // e  f  g    h i
            // dfs: efbgchida
            var root = makeTree();
            nonRecursivePostOrder(root);
            Console.WriteLine();
        }
        public static void OutputMostPopularDestination(int count)
        {
            var destinationsRanking = new Dictionary<string, int>();

            while (count > 0)
            {
                var destination = Console.ReadLine();
                if (destinationsRanking.ContainsKey(destination))
                    destinationsRanking[destination]++;
                else
                    destinationsRanking.Add(destination, 1);
                count--;
            }
            if (destinationsRanking.Any())
                Console.WriteLine(destinationsRanking.OrderByDescending(x => x.Value).First().Key);
        }



        public static void OutputCommonManager(int count)
        {

            var l = new Dictionary<string, List<string>>();
            var first = Console.ReadLine();
            var second = Console.ReadLine();
            count = count - 1;
            while (count > 0)
            {
                var row = Console.ReadLine().Split(' ');
                if (l.ContainsKey(row[0]))
                    l[row[0]].Add(row[1]);
                else
                {
                    l.Add(row[0], new List<string> { row[1] });
                }
                count--;
            }
            string manageFirst = "";
            string manageSecond = "";
            foreach (var value in l)
            {
                if (value.Value.IndexOf(first) >= value.Value.IndexOf(second))
                {
                    Console.WriteLine(first);
                    return;
                }
                if (value.Value.IndexOf(second) >= value.Value.IndexOf(first))
                {
                    Console.WriteLine(second);
                    return;
                }

                if (value.Value.IndexOf(first) > 0)
                    manageFirst = value.Key;

                if (value.Value.IndexOf(second) > 0)
                    manageSecond = value.Key;
            }
            if (l.Where(x => x.Value.Contains(second)).First().Value.Contains(manageFirst))
            {
                Console.WriteLine(l.Where(x => x.Value.Contains(second)).First().Key);
            }
        }

    }
}
