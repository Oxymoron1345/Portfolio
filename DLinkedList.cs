using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucures
{
    /*
     * Implementation of a Doubly Linked List
     */
    public class DLinkedList<LType>
    {
        /*
         * We extend our generic Node class to also contain references to the next and previous nodes
         */
        internal class LListNode<T> : Node<T>
        {
            public LListNode<T>? next, prev;

            public LListNode(T val, LListNode<T>? next = null, LListNode<T>? prev = null) : base(val)
            {
                this.next = next;
                this.prev = prev;
            }
        }
       
        private LListNode<LType>? head, tail; //We keep a reference to both the first (head) and last (tail) nodes
        private int size; // Keep track of the number of elements in our list
        public int Size()
        {
            return size;
        }
        /*
         * Default constructor
         */
        public DLinkedList()
        {
            head = null;
            tail = null;
            size = 0;
        }
        public DLinkedList(LType startval)
        {
            head = new LListNode<LType>(startval);
            tail = head;
            size = 1;
        }
        public DLinkedList(IEnumerable<LType> vals)
        {
            bool first = true;
            LListNode<LType>? node = null;
            foreach (var val in vals)
            {
                if (first)
                {
                    first = false;
                    head = new LListNode<LType>(val);
                    node = head;
                }
                else
                {
                    node.next = new LListNode<LType>(val);
                    node.next.prev = node;
                    node = node.next;
                }
                size++;
            }
            tail = node;
        }
        /*
         * Goes through each node and yields them one by one
         * Yielding allows the function to return one item at a time while maintaining its current state
         * See the following link for more:
         * https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield
         */
        public IEnumerable<LType> Iterate()
        {
            var node = head;
            while (node != null)
            {
                yield return node.Data;
                node = node.next;
            }
        }
        /*
         * This neat trick allows the Linked List to be indexed similar to arrays
         * If we have:
         * DLinkedList example;
         * example[3] -> same thing as example.Get(3)
         * example[2] = 30 -> same thing as example.AddAt(30,2)
         */
        public LType this[int i]
        {
            get => Get(i);
            set => AddAt(value, i);
        }
        /*
         * Get -> returns the element at a given position in the linked list
         * @param position - the 0-based index to get the value of
         */
        public LType Get(int position)
        {
            if (position >= size)
            {
                throw new IndexOutOfRangeException();
            }
            var node = head;
            for (int i = 0; i < position; i++)
            {
                node = node.next;
            }
            if(node == null)
            {
                throw new ArgumentException("Null Node found");
            }
            return node.Data;
        }
        /*
         * AddAt -> Inserts a value at a position
         * @param val - the value to add
         * @param position - the 0 based index to insert at
         */
        public void AddAt(LType val, int position)
        {
            if (position >= size)
            {
                throw new IndexOutOfRangeException();
            }
            if (position == 0)
            {
                AddHead(val);
                return;
            }
            var node = head;
            for (int i = 0; i < position - 1; i++)
            {
                node = node.next;
            }
            var nextnode = node.next;
            var newNode = new LListNode<LType>(val, next: nextnode, prev: node);
            node.next = newNode;
            if (nextnode != null) nextnode.prev = newNode;
            size++;
        }
        /*
         * AddTail - Adds a value to the end of the list
         * @param val - the value to add
         */
        public void AddTail(LType val)
        {
            var newNode = new LListNode<LType>(val, prev: tail);
            if (newNode.prev != null)
            {
                newNode.prev.next = newNode;
            }
            size++;
            tail = newNode;
            if(head == null)
            {
                head = newNode;
            }
        }
        /*
         * AddHead - Adds a value to the beginning of the list
         * @param val - the value to add
         */
        public void AddHead(LType val)
        {
            var newNode = new LListNode<LType>(val, next: head);
            if (newNode.next != null)
            {
                newNode.next.prev = newNode;
            }
            size++;
            head = newNode;
            if(tail == null)
            {
                tail = newNode;
            }
        }
        /*
         * RemoveAt -> removes an element at a specific position
         * @param position - The 0 based index to remove
         */
        public LType RemoveAt(int position)
        {
            if(position >= size)
            {
                throw new ArgumentException();
            }
            if(head == null)
            {
                throw new ArgumentException();
            }

            var node = head;
            for (int i = 0; i < position; i++)
            {
                if(node.next != null)
                {
                    node = node.next;
                }
                
            }

            if (node.prev != null)
            {
                node.prev.next = node.next;
            }
            else
            { head = node.next; }

            if (node.next != null)
            {
                node.next.prev = node.prev;
            }
            else
            {
                tail = node.prev;
            }
            size--;
            return node.Data;
        }
        /*
         * RemoveHead -> Removes the node at the head
         */
        public LType RemoveHead()
        {
            if(head == null)
            {
                throw new ArgumentException();
            }

            return RemoveAt(0);
        }
        /*
         * RemoveTail -> Removes the node at the Tail
         */
        public LType RemoveTail()
        {
            if (head == null)
            {
                throw new ArgumentException();
            }
            return RemoveAt(size - 1);
        }
        /*
         * Pretty prints the Linked List to a string
         */
        public override string ToString()
        {
            string retVal = "[";
            foreach (var val in this.Iterate())
            {
                retVal += val.ToString() + " <-> ";
            }
            retVal = retVal.Remove(retVal.Length - 5);
            retVal += "]";
            return retVal;
        }


    }
}
