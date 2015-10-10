namespace Sortable_Collection.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Sorters;

    [TestClass]
    public class InterpolationSearchTests
    {
        private static readonly Random Random = new Random();

        [TestMethod]
        public void TestWithEmptyCollectionShouldReturnMissingElement()
        {
            var collection = new SortableCollection<int>();
            var sorter = new Quicksorter<int>();
            collection.Sort(sorter);
            var result = collection.InterpolationSearch(collection.ToArray(), 0);
            var expected = Array.BinarySearch(collection.ToArray(), 0);

            Assert.AreEqual(expected, result, "No elements are present in an empty collection; method should return -1.");
        }

        [TestMethod]
        public void TestWithMissingElement()
        {
            var collection = new SortableCollection<int>(-1, 1, 5, 12, 50);

            var sorter = new Quicksorter<int>();
            collection.Sort(sorter);
            var result = collection.InterpolationSearch(collection.ToArray(), 0);
            var expected = -1;

            Assert.AreEqual(expected, result, "Missing element should return -1.");
        }

        [TestMethod]
        public void TestWithItemAtMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

            var sorter = new Quicksorter<int>();
            collection.Sort(sorter);
            var result = collection.InterpolationSearch(collection.ToArray(), 3);
            var expected = Array.BinarySearch(collection.ToArray(), 3);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheLeftOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

            var sorter = new Quicksorter<int>();
            collection.Sort(sorter);
            var result = collection.InterpolationSearch(collection.ToArray(), 2);
            var expected = Array.BinarySearch(collection.ToArray(), 2);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithItemToTheRightOfMidpoint()
        {
            var collection = new SortableCollection<int>(1, 2, 3, 4, 5);

            var sorter = new Quicksorter<int>();
            collection.Sort(sorter);
            var result = collection.InterpolationSearch(collection.ToArray(), 4);
            var expected = Array.BinarySearch(collection.ToArray(), 4);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysSmallerThanMinimum()
        {
            const int NumberOfChecks = 10000;
            const int NumberOfElements = 1000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);
            
            var collection = new SortableCollection<int>(elements);
            var sorter = new Quicksorter<int>();
            collection.Sort(sorter);
            var sortedArray = collection.ToArray();

            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(int.MinValue, collection.Items[0]);

                var result = collection.InterpolationSearch(sortedArray, item);

                Assert.AreEqual(-1, result);
            }
        }

        [TestMethod]
        public void TestWithMultipleMissingKeysLargerThanMaximum()
        {
            const int NumberOfChecks = 10000;
            const int NumberOfElements = 1000;

            var elements = new int[NumberOfElements];

            for (int i = 0; i < NumberOfElements; i++)
            {
                elements[i] = Random.Next(int.MinValue / 2, int.MaxValue / 2);
            }

            Array.Sort(elements);

            var collection = new SortableCollection<int>(elements);
            var sorter = new Quicksorter<int>();
            collection.Sort(sorter);
            var sortedArray = collection.ToArray();

            for (int i = 0; i < NumberOfChecks; i++)
            {
                var item = Random.Next(collection.Items[collection.Count - 1], int.MaxValue);
                
                var result = collection.InterpolationSearch(sortedArray, item);

                Assert.AreEqual(-1, result);
            }
        }
        
        [TestMethod]
        public void TestWithRepeatingItemShouldReturnFirstDiscoveredIndex()
        {
            var collection = new SortableCollection<int>(0, 3, 3, 3, 3, 7, 7, 7, 7, 7, 7);
            var sorter = new InsertionSorter<int>();
            collection.Sort(sorter);
            var sortedArray = collection.ToArray(); 
            var result = collection.InterpolationSearch(sortedArray, 3);

            Assert.AreEqual(4, result);
        }
    }
}
