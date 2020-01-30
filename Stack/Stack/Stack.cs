using System;

namespace Stack
{
    public class Stack<TElement> : IStack<TElement>
    {
        protected Node<TElement> _first;

        protected class Node<TElement>
        {
            public readonly TElement Value;

            public Node<TElement> Next;

            public Node(TElement value)
            {
                Value = value;
            }
        }

        public void Push(TElement element)
        {
            var newNode = new Node<TElement>(element);
            newNode.Next = _first;
            _first = newNode;
        }

        public TElement Pop()
        {
            ThrowExceptionIfStackIsEmpty();
            var node = _first;
            RemoveFirstNode();
            return ValueOf(node);
        }

        private void ThrowExceptionIfStackIsEmpty()
        {
            if (_first == null)
            {
                throw new InvalidOperationException();
            }
        }

        private void RemoveFirstNode()
        {
            _first = _first.Next;
        }

        private static TElement ValueOf(Node<TElement> node)
        {
            return node.Value;
        }
    }
}