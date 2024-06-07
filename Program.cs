    // public static void Main(string[] args) {
    //     Console.WriteLine("Helloey");
    // }

namespace DataStructures {
    public class Node<T> {
        private T data;

        public Node() {
            data = default;
        }
        public Node(T val) {
            data = val;
        }

        public T Data {
            get { 
                return data; 
            }
            set { 
                data = value; 
            }
        }
    }

    public class DyanamicArray<Atype> {
        public void Add(Atype item, int pos) {

        }

        public Atype Remove(int pos) {

        }

        public Atype Get(int pos) {

        }

        public Atype Set(int pos) {

        }

        public int Size() {
            return 0;
        }

    }

    public class LinkedList<Ltype> {
        internal class LListNode<T> : Node<T> {
            public LListNode<T>? next, prev;

            public LListNode(T val, LListNode<T>? next = null, LListNode<T>? prev = null) : base(val)
            {
                this.next = next;
                this.prev = prev;
            }

        }

        private LListNode<Ltype>? head, tail;
        private int size;
        
        public LinkedList() {
            head = null;
            tail = null;
            size = 0;
        }

        public LinkedList(Ltype startval) {
            head = new LListNode<Ltype>(startval);
            tail = head;
            size = 1;
        }

        public LinkedList(IEnumerable<Ltype> vals) {
            bool first = true;
            LListNode<Ltype>? node = null;
            
            foreach (var val in vals) {
                if (first) {
                    first = false;
                    head = new LListNode<Ltype>(val);
                    node = head;
                }
                else {
                    node.next = new LListNode<Ltype>(val);
                    node = node.next;
                }
                size++;
            }
            tail = node;
        }

        public void AddAt(Ltype item, int pos) {
            // if (pos >= size) {
            //     throw new IndexOutOfRangeException("");
            // }

            var node = head;
            
            for (int i = 0; i < pos - 1; i++) {
                node = node.next;
            }
            var nextnode = node.next;
            var newNode = new LListNode<Ltype>(item, next: nextnode);
            node.next = newNode;
        }

        public Ltype RemoveAt(int pos) {
            // if(pos >= size) {
            //     throw new ArgumentException();
            // }
            // if(head == null) {
            //     throw new ArgumentException();
            // }

            var node = head;
            
            for (int i = 0; i < pos; i++)
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

        public Ltype this[int i] {
            get => Get(i);
            set => AddAt(value, i);
        }

        public Ltype Get(int pos) {
            // if (pos >= size) {
            //     throw new IndexOutOfRangeException();
            // }
            var node = head;

            for (int i = 0; i < pos; i++) {
                node = node.next;
            }
            // if(node == null) {
            //     throw new ArgumentException("Null Node found");
            // }

            return node.Data;
        }
        
        private int Size() {
            return size;
        }
    }
}