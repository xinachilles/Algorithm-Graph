using Algorithm_Graph;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GraphTestProject
{
    
    
    /// <summary>
    ///This is a test class for GraphTest and is intended
    ///to contain all GraphTest Unit Tests
    ///</summary>
    [TestClass()]
    public class GraphTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Dijkstra
        ///</summary>
        public void DijkstraTestHelper<T>()
            where T : IComparable<T>
        {
            Graph<int> target = new Graph<int>(); // TODO: Initialize to an appropriate value
            for (int i = 0; i < 5; i++)
            {
                target.AddNode(new GraphNode<int>());
            }

            target.AddDirectedEdge(target.Nodes[0], target.Nodes[1], 10);
            target.AddDirectedEdge(target.Nodes[0], target.Nodes[2], 5);
            target.AddDirectedEdge(target.Nodes[1], target.Nodes[3], 1);
            target.AddDirectedEdge(target.Nodes[1], target.Nodes[2], 2);
            target.AddDirectedEdge(target.Nodes[2], target.Nodes[1], 3);
            target.AddDirectedEdge(target.Nodes[2], target.Nodes[3], 9);
            target.AddDirectedEdge(target.Nodes[2], target.Nodes[4], 2);
            target.AddDirectedEdge(target.Nodes[4], target.Nodes[1], 7);
            target.AddDirectedEdge(target.Nodes[3], target.Nodes[4], 4);
            target.AddDirectedEdge(target.Nodes[4], target.Nodes[3], 6);

            target.Dijkstra(target.Nodes[0]);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        [TestMethod()]
        public void DijkstraTest()
        {
            DijkstraTestHelper<int>();
        }
    }
}
