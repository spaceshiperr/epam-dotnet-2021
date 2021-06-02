using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;


namespace GenericsLibrary.Tests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void Stack_DefaultConstructor_CreatesEmptyStack()
        {
            var expected = 0;

            var stack = new Stack<object>();
            var result = stack.Count;

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Stack_OneItemPassedToConstructor_CreatesOneItemStack()
        {
            var item = "something";
            var expected = 1;

            var stack = new Stack<string>(item);
            var result = stack.Count;

            Assert.That(result, Is.EqualTo(expected));
            Assert.That(stack.Contains(item));
        }

        [Test]
        public void Stack_CollectionPassedIntoConstructor_CreatesStackFromCollection()
        {
            var list = new List<int> { 1, 2, 3 };
            var expected = list.ToArray<int>();

            var stack = new Stack<int>(list);

            var result = stack.ToArray();

            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void Clear_StackIsEmpty_CountIsStillZero()
        {
            var stack = new Stack<int>();
            var expected = 0;
            
            stack.Clear();

            var result = stack.Count;

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Clear_StackHasItems_CountReturnsZero()
        {
            var stack = new Stack<double>(new List<double> { 2.3, 4.5, 7.0 });
            var expected = 0;

            stack.Clear();
            var result = stack.Count;

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Push_StackIsEmpty_ToArrayReturnsAnArrayOfPushedItems()
        {
            var stack = new Stack<string>();
            var items = new string[] { "some", "days", "are", "magical" };

            foreach (var item in items)
                stack.Push(item);

            var result = stack.ToArray();

            Assert.That(result, Is.EquivalentTo(items));
        }

        [Test]
        public void Pop_StackIsEmpty_ThrowsInvalidOperationException()
        {
            var stack = new Stack<object>();

            Assert.That(() => stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_StackHasItems_ReturnsRemovedItem()
        {
            var list = new List<string> { "baby", "it's", "a", "wild", "world" };
            var stack = new Stack<string>(list);

            var removed = stack.Pop();

            Assert.That(removed, Is.EqualTo(list.Last()));
        }

        [Test]
        public void Pop_StackHasItems_ToArrayReturnsArrayWithoutLastItem()
        {
            var list = new List<int> { 1, 2, 3 };
            var stack = new Stack<int>(list);

            stack.Pop();
            list.RemoveAt(list.Count - 1);

            Assert.That(stack.ToArray(), Is.EquivalentTo(list));
        }

        [Test]
        public void Peek_StackIsEmpty_ThrowsInvalidOperationException()
        {
            var stack = new Stack<bool>();

            Assert.That(() => stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackHasItems_ReturnsLastAddedItem()
        {
            var stack = new Stack<double>();
            var items = new double[] { 0.242, 0.121, 1.2342, 4.212 };

            foreach (var item in items)
                stack.Push(item);

            var lastItem = stack.Peek();

            Assert.That(lastItem, Is.EqualTo(items[items.Length - 1]));
        }

        [Test]
        public void Contains_StackDoesContainItem_ReturnsFalse()
        {
            var item = 1;
            var stack = new Stack<int>(0);
            var expected = false;

            var result = stack.Contains(item);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Contains_StackContainsItem_ReturnsTrue()
        {
            var items = new char[] { 'a', 'b', 'c' };
            var stack = new Stack<char>(items);
            var expected = true;

            var result = stack.Contains(items[0]);

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void ToArray_StackIsEmpty_ReturnsEmptyArray()
        {
            var stack = new Stack<bool>();

            var array = stack.ToArray();

            Assert.That(array.Length == 0);
        }

        [Test]
        public void ToArray_StackHasItems_ReturnsSameArrayOfItems()
        {
            var items = new bool[] { true, true, false, true };
            var stack = new Stack<bool>(items);

            var array = stack.ToArray();

            Assert.That(array, Is.EquivalentTo(items));
        }
    }
}
