using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private ListNode first;
        private ListNode last;

        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                first = last = new ListNode(element);
            }
            else
            {
                var newFirst = new ListNode(element);
                newFirst.NextNode = first;
                first.PreviousNode = newFirst;
                first = newFirst;
            }
            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                first = last = new ListNode(element);
            }
            else
            {
                var newLast = new ListNode(element);
                newLast.PreviousNode = last;
                last.NextNode = newLast;
                last = newLast;
            }
            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = first.Value;
            first = first.NextNode;
            if (first != null)
            {
                first.PreviousNode = null;
            }
            else
            {
                last = null;
            }
            Count--;
            return firstElement;
        }

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = last.Value;
            last = last.PreviousNode;

            if (last != null)
            {
                last.NextNode = null;
            }
            else
            {
                first = null;
            }
            Count--;
            return lastElement;
        }

        public void ForEach(Action<int> action)
        {
            var currNode = first;
            while (currNode != null)
            {
                action(currNode.Value);
                currNode = currNode.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            int index = 0;
            var currNode = first;
            while (currNode != null)
            {
                array[index] = currNode.Value;
                currNode = currNode.NextNode;
                index++;
            }
            return array;
        }
    }
}
