using System.Collections.Generic;

namespace Tree.Core
{
    public class Node
    {
        public int key;
        public Node Left { get; set; }
        public Node Right { get; set; }

        public static Node CreateNewNode(int k)
        {
            return new Node { key = k };
        }
    }

    public class BinaryTree
    {
        private readonly Node _root;
        public BinaryTree(Node root)
        {
            _root = root;
        }

        private static bool findPath(Node root, IList<int> path, int k)
        {
            if (root == null) return false;

            path.Add(root.key);

            if (root.key == k) return true;

            if (root.Left != null && findPath(root.Left, path, k) ||
                (root.Right != null && findPath(root.Right, path, k)))
                return true;

            path.RemoveAt(path.Count - 1);
            return false;
        }

        public int? findLCA(int n1, int n2)
        {
            var path1 = new List<int>();
            var path2 = new List<int>();

            if (!findPath(_root, path1, n1) || !findPath(_root, path2, n2))
                return null;
            
            for (int i = 0; i < path1.Count && i < path2.Count; i++)
            {
                if (path1[i] != path2[i])
                    return path1[i - 1];
            }
            return _root.key;
        }
    }
}
