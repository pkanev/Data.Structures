using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Q03ArrayStack.Tests
{
    [TestClass]
    public class UnitTestsArrayStack
    {
        [TestMethod]
        public void Push_EmptyArrayStack_ShouldAddElement()
        {
            // Arrange
            var arrStack = new ArrayStack<int>();

            // Act
            arrStack.Push(5);

            // Assert
            Assert.AreEqual(1, arrStack.Count);
        }

        [TestMethod]
        public void PushDeque_ShouldWorkCorrectly()
        {
            // Arrange
            var arrStack = new ArrayStack<string>();
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
        public void Pop_EmptyArrayStack_ThrowsException()
        {
            // Arrange
            var arrStack = new ArrayStack<int>();

            // Act
            arrStack.Pop();

            // Assert: expect and exception
        }

        [TestMethod]
        public void PushPop1000Elements_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>();
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
        public void ArrayStack_PushPopManyChunks_ShouldWorkCorrectly()
        {
            // Arrange
            var stack = new ArrayStack<int>();
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
            var stack = new ArrayStack<int>();

            // Act
            for (int i = array.Length - 1; i >= 0 ; i--)
            {
                stack.Push(array[i]);
            }
            var arrayFromQueue = stack.ToArray();

            // Assert
            CollectionAssert.AreEqual(array, arrayFromQueue);
        }

        [TestMethod]
        public void InitialCapacity1_PushPop20Elements_ShouldWorkCorrectly()
        {
            // Arrange
            int elementsCount = 20;
            int initialCapacity = 1;

            // Act
            var stack = new ArrayStack<int>(initialCapacity);
            for (int i = 0; i < elementsCount; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.AreEqual(elementsCount, stack.Count);
            for (int i = 0; i < elementsCount; i++)
            {
                var elementFromStack = stack.Pop();
                Assert.AreEqual(elementsCount - i - 1, elementFromStack);
            }
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]
        public void EmptyStackToArray()
        {
            // Arrange
            var stack = new ArrayStack<DateTime>();
            DateTime[] array = new DateTime[0];
            
            // Act
            var arrayFromStack = stack.ToArray();
            
            // Assert
            CollectionAssert.AreEqual(array, arrayFromStack);
        }
    }
}
