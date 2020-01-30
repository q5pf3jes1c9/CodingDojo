using System.Collections.Generic;

namespace StackTest
{
    public class StackVisitor<TElement> : Stack.Stack<TElement>
    {
        public void SetElements(params TElement[] elements)
        {
            var firstNode = CreateNodes(elements);
            _first = firstNode;
        }

        private static Node<TElement> CreateNodes(TElement[] elemente)
        {
            Node<TElement> lastCreatedNode = null;
            foreach (var element in elemente)
            {
                var node = CreateNode(element, lastCreatedNode);
                lastCreatedNode = node;
            }

            return lastCreatedNode;
        }

        private static Node<TElement> CreateNode(TElement element, Node<TElement> firstNode)
        {
            var node = new Node<TElement>(element);
            node.Next = firstNode;
            return node;
        }

        public IEnumerable<TElement> GetElements()
        {
            var actualNode = _first;
            while (actualNode != null)
            {
                yield return actualNode.Value;
                actualNode = actualNode.Next;
            }
        }
    }
}