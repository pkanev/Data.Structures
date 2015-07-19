using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Q05LinkedStack;
using System.Linq;

namespace Q06LinkedStackTests
{
    [TestClass]
    public class UnitTestsLinkedStack
    {
        [TestMethod]
        public void Push_EmptyLinkedStack_ShouldAddElement()
        {
            // Arrange
            var arrStack = new LinkedStack<int>();

            // Act
            arrStack.Push(5);

            // Assert
            Assert.AreEqual(1, arrStack.Count);
        }

        [TestMethod]
        public void PushDeque_ShouldWorkCorrectly()
        {
            // Arrange
            var arrStack = new LinkedStack<string>();
            var element = "some value";

            // Act
            arrStack.Push(element);
            var elementFromArrayStack = arrStack.Pop();

            // Assert
            Assert.AreEqual(0, arrStack.Count);
            Assert.AreEqual(element, elementFromArrayStack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_EmptyLinkedStack_ThrowsException()
        {
            // Arrange
            var arrStack = new LinkedStack<int>();

            // Act
            arrStack.Pop();

            // Assert: expect and exception
        }

        [TestMethod]
        public void PushPop1000Elements_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<int>();
            int numberOfElements = 1000;

            // Act
            for (int i = 0; i < numberOfElements; i++)
            {
                stack.Push(i);
            }

            // Assert
            for (int i = 0; i < numberOfElements; i++)
            {

                Assert.AreEqual(numberOfElements - i, stack.Count);
                var element = stack.Pop();
                Assert.AreEqual(numberOfElements - i - 1, element);
                Assert.AreEqual(numberOfElements - i - 1, stack.Count);
            }
        }

        [TestMethod]
        public void LinkedStack_PushPopManyChunks_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new LinkedStack<int>();
            int chunks = 100;

            // Act & Assert in a loop
            int value = 1;
            for (int i = 0; i < chunks; i++)
            {
                Assert.AreEqual(0, stack.Count);
                var chunkSize = i + 1;
                for (int counter = 0; counter < chunkSize; counter++)
                {
                    Assert.AreEqual(value - 1, stack.Count);
                    stack.Push(value);
                    Assert.AreEqual(value, stack.Count);
                    value++;
                }
                for (int counter = 0; counter < chunkSize; counter++)
                {
                    value--;
                    Assert.AreEqual(value, stack.Count);
                    stack.Pop();
                    Assert.AreEqual(value - 1, stack.Count);
                }
                Assert.AreEqual(0, stack.Count);
            }
        }

        [TestMethod]
        public void Push500Elements_ToArray_ShouldWorkCorrectly()
        {
            // Arrange
            var array = Enumerable.Range(1, 500).ToArray();
            var stack = new LinkedStack<int>();

            // Act
            for (int i = array.Length - 1; i >= 0; i--)
            {
                stack.Push(array[i]);
            }
            var arrayFromQueue = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromQueue);
        }

        [TestMethod]
        public void EmptyStackToArray()
        {
            // Arrange
            var stack = new LinkedStack<DateTime>();
            DateTime[] array = new DateTime[0];

            // Act
            var arrayFromStack = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromStack);
        }
    }
}
