using System;
using System.Collections.Generic;
using DijkstraLib.Algorithm;
using DijkstraLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Web.Tests
{

    [TestClass]
    public class PathFinderTests
    {
        private PathFinder _pathFinder;
        private List<Node> _testGraph;

        [TestInitialize]
        public void Setup()
        {
            _pathFinder=new PathFinder();
            _testGraph = CreateTestGraph();
        }

        [TestMethod]
        public void ShortestaAth_FromAToF()
        {
            string fromNode = "A";
            string toNode = "E";

            var result = _pathFinder.ShotestPath(fromNode, toNode,_testGraph);

            CollectionAssert.AreEqual(new List<string> { "A", "C", "D", "E" }, result._nodeNames);
            Assert.AreEqual(18, result._distance);
        }

        [TestMethod]
        public void ShortestPath_FromEToB()
        {
            string fromNode = "E";
            string toNode = "B";

            var result = _pathFinder.ShotestPath(fromNode, toNode, _testGraph);

            CollectionAssert.AreEqual(new List<string> { "E","B" }, result._nodeNames);
            Assert.AreEqual(2, result._distance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShortestPath_WithInvalidFromNode_ShouldThrowException()
        {
             
            _pathFinder.ShotestPath("X", "D", _testGraph);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShortestPath_WithInvalidToNode_ShouldThrowException()
        {
            
            _pathFinder.ShotestPath("A", "Z", _testGraph);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShortestPath_WithNullGraph_ShouldThrowException()
        {
            
            _pathFinder.ShotestPath("A", "D", null);
        }

         
        private List<Node> CreateTestGraph()
        {
            // Create nodes
            Node nodeA = new Node("A");
            Node nodeB = new Node("B");
            Node nodeC = new Node("C");
            Node nodeD = new Node("D");
            Node nodeE = new Node("E");
            Node nodeF = new Node("F");

            // Create edges
            nodeA.edges.Add(new Edge(nodeA, nodeB, 4));
            nodeA.edges.Add(new Edge(nodeA, nodeC, 6));

            nodeB.edges.Add(new Edge(nodeB, nodeC, 1));
            nodeB.edges.Add(new Edge(nodeB, nodeD, 5));

            nodeC.edges.Add(new Edge(nodeC, nodeD, 8));
            nodeC.edges.Add(new Edge(nodeC, nodeE, 5));

            nodeD.edges.Add(new Edge(nodeD, nodeF, 6));
            nodeD.edges.Add(new Edge(nodeD, nodeE, 4));

            nodeE.edges.Add(new Edge(nodeE, nodeB, 3));
            nodeE.edges.Add(new Edge(nodeE, nodeD, 2));

            return new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF };
        }
    }
}
