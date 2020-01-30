using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stack;

namespace StackTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PopTest()
        {
            var sut = new StackVisitor<int>();
            sut.SetElements(7, 9, 1);

            PopAndAssert(sut, 1);
            PopAndAssert(sut, 9);
            PopAndAssert(sut, 7);
        }

        [TestMethod]
        public void PushTest()
        {
            var sut = new StackVisitor<int>();

            sut.Push(7);
            sut.Push(9);
            sut.Push(1);

            var elements = sut.GetElements();
            var expected = new List<int>
            {
                1,9,7
            };

            elements.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
        }
        [TestMethod]
        public void MainTest()
        {
            var sut = new Stack.Stack<int>();

            sut.Push(5);

            PopAndAssert(sut, 5);

            Assert.ThrowsException<InvalidOperationException>(() => sut.Pop());

            sut.Push(7);
            sut.Push(9);
            sut.Push(1);

            PopAndAssert(sut, 1);
            PopAndAssert(sut, 9);
            PopAndAssert(sut, 7);
        }

        private static void PopAndAssert(IStack<int> sut, int expected)
        {
            var result = sut.Pop();
            result.Should().Be(expected);
        }
    }
}
