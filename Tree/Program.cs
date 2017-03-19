using System;
using System.Collections;
using System.Collections.Generic;
using Tree.Core;

namespace Tree
{

    

    class Program
    {        
        

        static void Main(string[] args)
        {

            Node root = Node.CreateNewNode(1);
            root.Left = Node.CreateNewNode(2);
            root.Right = Node.CreateNewNode(3);

            root.Left.Left = Node.CreateNewNode(4);
            root.Left.Right = Node.CreateNewNode(5);
            root.Right.Left = Node.CreateNewNode(6);
            root.Right.Right = Node.CreateNewNode(7);

            //Console.WriteLine("LCA(4,5) = {0}", findLCA(root, 4, 5));
            //Console.WriteLine("LCA(4,6) = {0}", findLCA(root, 4, 6));
            //Console.WriteLine("LCA(3,4) = {0}", findLCA(root, 3, 4));
            //Console.WriteLine("LCA(2,4) = {0}", findLCA(root, 2, 4));
            Console.WriteLine("LCA(6,7) = {0}", new BinaryTree(root)
                . findLCA(6, 7));
            Console.WriteLine();
            Console.ReadKey();
        }

    }
}