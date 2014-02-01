using Algorithm_Heap;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    
    
    /// <summary>
    ///This is a test class for HeapTest and is intended
    ///to contain all HeapTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HeapTest
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
        ///A test for HeapSort
        ///</summary>
        public void HeapSortTestHelper<T>()
            where T : IComparable<T>
        {
            Heap<int> target = new Heap<int>(); // TODO: Initialize to an appropriate value
            int[] array = { 4, 1, 3, 2, 16, 9, 10, 14, 8, 7 };
            target.HeapSort(ref array);
        }

        [TestMethod()]
        public void HeapSortTest()
        {
            HeapSortTestHelper<int>();
        }
    }
}
