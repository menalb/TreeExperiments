using Tree.Core;
using Xunit;

namespace Tree.Tests
{
    public class LowestCommonAncestorTests
    {
        private readonly Node _root;
        private readonly BinaryTree _sut;

        public LowestCommonAncestorTests()
        {
            _root = GetTreeRootNode();
            _sut = new BinaryTree(_root);
        }

        [Fact]
        public void GivenABinaryTree_WhenTheTwoNodesAreOnTheRightSideOfTheTree_ItReturnsTheLCA()
        {            
            var lca = _sut.findLCA(6, 7);

            Assert.Equal(3, lca);
        }

        [Fact]
        public void GivenABinaryTree_WhenTheTwoNodesAreOnTheLeftSideOfTheTree_ItReturnsTheLCA()
        {            
            var lca = _sut.findLCA(4, 5);

            Assert.Equal(2, lca);
        }

        [Fact]
        public void GivenABinaryTree_WhenTheTwoNodesHaveDifferentDepthInTheTree_ItReturnsTheLCA()
        {            
            var lca = _sut.findLCA(2, 87);

            Assert.Equal(1, lca);
        }

        [Fact]
        public void GivenABinaryTree_WhenOneOfTHeNodesIaTheRootOfTheTree_ItReturnsTheRoot()
        {            
            var lca = _sut.findLCA(1, 87);

            Assert.Equal(_root.key, lca);
        }

        [Fact]
        public void GivenABinaryTree_WhenTheRootIsTheLCA_ItReturnsTheRoot()
        {            
            var lca = _sut.findLCA(4, 7);

            Assert.Equal(_root.key, lca);
        }

        [Fact]
        public void GivenABinaryTree_WhenOneOfTHeTwoNodesIsNotInTheTree_ItReturnsNoValue()
        {            
            var lca = _sut.findLCA(10, 7);

            Assert.False(lca.HasValue);
        }

        /// <summary>
        /// build binarytree
        ///       1
        ///  2        3
        /// 4 5    6     7
        ///       11 34 67 87
        /// </summary>
        /// <returns></returns>
        private static Node GetTreeRootNode()
        {
            Node root = Node.CreateNewNode(1);
            Node left = Node.CreateNewNode(2);
            left.Left = Node.CreateNewNode(4);
            left.Right = Node.CreateNewNode(5);
            root.Left = left;
            Node right = Node.CreateNewNode(3);
            right.Left = Node.CreateNewNode(6);
            right.Right = Node.CreateNewNode(7);
            right.Left.Left= Node.CreateNewNode(11);
            right.Left.Right= Node.CreateNewNode(34);
            right.Right.Left= Node.CreateNewNode(67);
            right.Right.Right= Node.CreateNewNode(87);
            root.Right = right;

            return root;
        }
    }
}