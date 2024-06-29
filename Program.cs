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

    public class DynamicArray<Atype> {
        private Atype[] data;
        private int size;

        public DynamicArray() {
            data = new Atype[0];
        }

        public void Add(Atype item, int pos) {
            if (pos > size || pos < 0) {
                throw new IndexOutOfRangeException("Out of Range");
            }

            data[pos] = item;

            for (int i = pos; i < size - 1; i++) {
                data[i] = data[i + 1];
            }
            
            size++ ;

            if (pos == size) {
                int sizeNew = data.Length * 2;
                Array.Resize(ref data, sizeNew);
            }
        }

        public Atype Remove(int pos) {
            if (pos >= size || pos < 0) {
                throw new IndexOutOfRangeException("Out of Range");
            }

            Atype itemRemoved = data[pos];
            
            for (int i = pos; i < size - 1; i++) {
                data[i] = data[i + 1];
            }
            
            size-- ;

            return itemRemoved;
        }

        public Atype Get(int pos) {
            if (pos >= size || pos < 0) {
                throw new IndexOutOfRangeException("Out of Range");
            }
            
            return data[pos];
        }

        public Atype Set(Atype val, int pos) {
            if (pos >= size || pos < 0) {
                throw new IndexOutOfRangeException("Out of Range");
            }

            Atype valOld = data[pos];
            data[pos] = val;
            return valOld;
        }

        public int Size() {
            return size;
        }

    }

    public class LinkedList<Ltype> {
        internal class LListNode<T> : Node<T> {
            public LListNode<T>? next, prev;

            public LListNode(T val, LListNode<T>? next = null, LListNode<T>? prev = null) : base(val) {
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
                size++ ;
            }
            tail = node;
        }

        public void AddAt(Ltype item, int pos) {
            var node = head;
            
            for (int i = 0; i < pos - 1; i++) {
                node = node.next;
            }
            var nextnode = node.next;
            var newNode = new LListNode<Ltype>(item, next: nextnode);
            node.next = newNode;
        }

        public Ltype RemoveAt(int pos) {
            if (pos >= size || pos < 0) {
                throw new IndexOutOfRangeException("Out of Range");
            }

            var node = head;
            
            for (int i = 0; i < pos; i++) {
                if(node.next != null)
                {
                    node = node.next;
                }
                
            }

            if (node.prev != null) {
                node.prev.next = node.next;
            }
            else { 
                head = node.next; 
            }

            if (node.next != null) {
                node.next.prev = node.prev;
            }
            else {
                tail = node.prev;
            }
            size-- ;
            
            return node.Data;
        }

        public Ltype Get(int pos) {
            if (pos >= size || pos < 0) {
                throw new IndexOutOfRangeException("Out of Range");
            }
            
            var node = head;

            for (int i = 0; i < pos; i++) {
                node = node.next;
            }
            
            return node.Data;
        }

        public Ltype Set(Ltype val, int pos) {
            if (pos >= size || pos < 0) {
                throw new IndexOutOfRangeException("Out of Range");
            }
            Ltype valOld = Get(pos);
            AddAt(val, pos);
            return valOld;
        }
        
        private int Size() {
            return size;
        }
    }

    public class Stack<Stype> {
        private DynamicArray<Stype> stack;
        private int size = 0;
        public Stack () {
            stack = new DynamicArray<Stype>();
        }

        public void push(Stype item) {
            stack.Add(item, size);
            size++ ;
        }

        public Stype Pop() {
            if (size == 0) {
                throw new InvalidOperationException("Stack is empty");
            }

            Stype itemPopped = stack.Get(size - 1);
            stack.Remove(size - 1);
            size-- ;
            return itemPopped;
        }

        public Stype Peek() {
            return stack.Get(size -1);
        }

        public int Size() {
            return size;
        }
    }

    public class Queue<Qtype> {
        private DynamicArray<Qtype> queue;
        private int size = 0;
        public Queue () {
            queue = new DynamicArray<Qtype>();
        }

        public void Enqueue(Qtype item) {
            queue.Add(item, size);
            size++;
        }

        public Qtype Dequeue() {
            if (size == 0) {
                throw new InvalidOperationException("Queue is empty");
            }

            Qtype itemDequeued = queue.Get(0);
            queue.Remove(0);
            size-- ;
            return itemDequeued;
        }

        public Qtype Peek() {
            return queue.Get(0);
        }

        public int Size() {
            return size;
        }
    }

    public class InsertionSort {
        public static void Sort(int[] list) {
            int size = list.Length;
            if (size == 0) {
                throw new InvalidOperationException("List is empty");
            }
            for (int i = 1; i < size; i++) {
                int key = list[i];
                int j = list[i - 1];

                while (j >= 0 && list[j] > key) {
                    list[j + 1] = list[j];
                    j = j - 1;
                }
                list[j + 1] = key;
            }
        }
    }

    public class MergeSort {
        void merge (int [] list, int left, int mid, int right) {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] arrayLeft = new int[n1];
            int[] arrayRight = new int[n2];
            int i, j;

            for (i = 0; i < n1; i++) {
                arrayLeft[i] = list[1 + i];
            }
            for (j = 0; j < n2; j++) {
                arrayRight[j] = list[mid + 1 + j];
            }

            i = 0;
            j = 0;

            int k = left;

            while (i < n1 && j < n2) {
                if (arrayLeft[i] <= arrayRight[j]) {
                    list[k] = arrayLeft[i];
                    i++ ;
                }
                else {
                    list[k] = arrayRight[j];
                    j++ ;
                }
                k++ ;
            }
            while (i < n1) {
                list[k] = arrayLeft[i];
                i++ ;
                k++ ;
            }
            while (j < n2) {
                list[k] = arrayRight[j];
                j++ ;
                k++ ;
            }

        }
        public static void Sort(int[] list) {
            int size = list.Length;
            MergeSort Merge = new MergeSort();
            if (size == 0) {
                throw new InvalidOperationException("List is empty");
            }
            
            int left = 0;
            int right = list.Length - 1; 

            if (left < right) {
                int mid = left + (right - left) / 2;
                
                Sort(list);
                
                Merge.merge(list, left, mid, right);
            }
        }
    }

    public class BinaryTree {
        protected class TreeNode : Node<int> {
            public TreeNode? parent, right, left;

            public TreeNode(int val) : base(val) {
                parent = null;
                right = null;
                left = null;
            }
        }

        protected TreeNode? root;

        public BinaryTree() {
            root = null;
        }

        public bool Has(int val) {
            return FindNode(root, val) != null;
        }

        private TreeNode? FindNode(TreeNode? curr, int val) {
            if (curr.Data == val) {
                return curr;
            }
            else if (val > curr.Data) {
                return FindNode(curr.right, val);
            }
            else {
                return FindNode(curr.left, val);
            }
        }

        public void Add(int val) {
            root = TreeAdd(root, val);
        }

        virtual protected TreeNode? TreeAdd(TreeNode curr, int val) {
            if (val > curr.Data) {
                curr.right = TreeAdd(curr.right, val);
                if (curr.right == null) {
                    curr.right.parent = curr;
                }
            }
            else {
                curr.left = TreeAdd(curr.left, val);
                if (curr.left == null) {
                    curr.left.parent = curr;
                }
            }

            return curr;
        }

        public int? Remove(int val) {
            TreeNode? removal = FindNode(root, val);
            
            if (removal != null) {
                root = TreeRemove(removal);
                return val;
            }
            else {
                return null;
            }
        }

        virtual protected TreeNode? TreeRemove(TreeNode? removal) {
            TreeNode? right = removal.right;
            TreeNode? left = removal.left;
            
            if (removal == null) {
                return null;
            }
            //Case 1(0)
            else if (left == null && right == null) {
                removal = null;
            }
            //Case 2(1)
            else if (left == null || right == null) {
                if (left == null) {
                    TreeNode? child = right;
                    child.parent = removal.parent;
                    removal.parent.right = child;
                    
                }
                else {
                    TreeNode? child = left;
                    child.parent = removal.parent;
                    removal.parent.left = child;
                }
            }
            //Case 3(2)
            else {
                TreeNode successor = FindSuccessor(removal);
                removal.Data = successor.Data;
                TreeRemove(successor);
            }
            return removal;
        }

        private static TreeNode FindSuccessor(TreeNode DeadNode)
        {
            TreeNode successor = DeadNode.left;

            while (successor.right != null) {
                successor = successor.right;
            }
            return successor;
        }

        public int Height() {
            return FindHeight(root);
        }

        protected int FindHeight(TreeNode? node) {
            int leftHeight = FindHeight(node.left);
            int rightHeight = FindHeight(node.right);

            return 1 + Math.Max(leftHeight, rightHeight);
        }
    }

    public class AVL {
        public class TreeNode : Node<int> {
            public TreeNode? parent, right, left;
            
            public int height;

            public TreeNode(int val) : base(val) {
                parent = null;
                right = null;
                left = null;
                height = 1;
            }
        }

        protected TreeNode? root;

        public AVL () {
            root = null;
        }

        public bool Has(int val) {
            return FindNode(root, val) != null;
        }

        private TreeNode? FindNode(TreeNode? curr, int val) {
            if (curr.Data == val) {
                return curr;
            }
            else if (val > curr.Data) {
                return FindNode(curr.right, val);
            }
            else {
                return FindNode(curr.left, val);
            }
        }

        public void Add(int val) {
            root = TreeAdd(root, val);
        }

        virtual protected TreeNode? TreeAdd(TreeNode curr, int val) {
            if (val > curr.Data) {
                curr.right = TreeAdd(curr.right, val);
                if (curr.right == null) {
                    curr.right.parent = curr;
                }
            }
            else {
                curr.left = TreeAdd(curr.left, val);
                if (curr.left == null) {
                    curr.left.parent = curr;
                }
            }

            curr.height = 1 + Math.Max(Height(curr.left), Height(curr.right));

            int balance = Balance(curr);

            if (IsBalanced(curr)) {
                return curr;
            }
            else {
                Restructure(curr);
                return curr;
            }
        }

        public int? Remove(int val) {
            TreeNode? removal = FindNode(root, val);
            
            if (removal != null) {
                root = TreeRemove(removal, val);
                return val;
            }
            else {
                return null;
            }
        }

        virtual protected TreeNode? TreeRemove(TreeNode? removal, int val) {
            TreeNode? right = removal.right;
            TreeNode? left = removal.left;
            
            if (removal == null) {
                return null;
            }

            if (val > removal.Data) {
                right = TreeRemove(right, val);
            }
            else if (val < removal.Data) {  
                left = TreeRemove(left, val);
            }
            else {
                TreeNode? node = FindSuccessor(removal.right);
                removal.Data = node.Data;
                right = TreeRemove(right, node.Data);
            }

            removal.height = 1 + Math.Max(Height(left), Height(left));

            int balance = Balance(removal);

            if (IsBalanced(removal)) {
                return removal;
            }
            else {
                Restructure(removal);
                return removal;
            }
        }

        private static TreeNode FindSuccessor(TreeNode DeadNode)
        {
            TreeNode successor = DeadNode;

            while (successor.right != null) {
                successor = successor.right;
            }
            return successor;
        }

        public int Height(TreeNode? x) {
            return FindHeight(x);
        }

        protected int FindHeight(TreeNode? node) {
            return node.height;
        }

        public TreeNode? Restructure(TreeNode x) {
            TreeNode? parent = x.parent;
            TreeNode? grParent = parent.parent;

            if (parent == grParent.left) {
                // Left, left child
                if (x == parent.left) {
                    Rotate(grParent);
                    return grParent;
                }
                // Left, right child
                else {
                    Rotate(parent);
                    Rotate(parent);
                    return parent;
                }
            }
            else {
                // Right, right child
                if (x == parent.right) {
                    Rotate(grParent);
                    return grParent;
                }
                // Right, left child
                else {
                    Rotate(parent);
                    Rotate(parent);
                    return parent;
                }
            }
        }

        public void Rotate(TreeNode x) {
            TreeNode? parent = x.parent;
            TreeNode? grParent = parent.parent;

            if (parent == grParent.left) {
                if (x == parent.left) {
                    RotateRight(grParent);
                }
                else {
                    RotateLeft(parent);
                    RotateRight(grParent);
                }
            }
            else {
                if (x == parent.right) {
                    RotateLeft(grParent);
                }
                else {
                    RotateRight(parent);
                    RotateLeft(grParent);
                }
            }
        }

        private TreeNode RotateLeft (TreeNode? x) {
            TreeNode right = x.right;
            TreeNode niece = right.left;

            niece.left = x;
            x.right = niece;

            x.height = Math.Max(Height(x.left), Height(x.right));
            right.height = Math.Max(Height(right.left), Height(right.right));

            return right;
        }

        private TreeNode RotateRight (TreeNode? x) {
            TreeNode left = x.left;
            TreeNode niece = left.right;

            niece.right = x;
            x.left = niece;

            x.height = Math.Max(Height(x.left), Height(x.right));
            left.height = Math.Max(Height(left.left), Height(left.right));

            return left;
        }

        public void Relink(TreeNode parent, TreeNode child, bool left) {
            if (left) {
                parent.left = child;
            }
            else {
                parent.right = child;
            }
            
            if (child != null) {
                child.parent = parent;
            }
        }

        public int Balance (TreeNode? x) {
            return Height(x.left) - Height(x.right);
        }

        public bool IsBalanced(TreeNode x) {
            int balance = Balance(x);

            return Math.Abs(balance) <= 1;
        }
    }

    public class MaxHeap {
        private DynamicArray<int> heap;

        private int size;
        public MaxHeap() {
            heap = new DynamicArray<int>();
        }

        public void Add(int item) {
            heap.Add(item, (size -1));
            size++ ;

            Heapify(size -1);
        }

        public int Next() {
            int max = heap.Get(0);
            int min = heap.Get(size - 1);
            heap.Remove(0);
            heap.Add(min, 0);
            heap.Remove(min);
            Heapify(0);
            return max;

        }

        public void HeapSort(int[] arr) {
            MaxHeap temp = new MaxHeap();

            foreach (int item in arr) {
                temp.Add(item);
            }

            for (int i = 0; i < arr.Length; i++) {
                arr[i] = temp.Next();
            }
        }

        public IEnumerable<int> SortedVals() {
            while (heap.Size() != 0) {
                yield return Next();
            }
        }

        public void Heapify(int pos) {
            int parentPos = Parent(pos);

            if (pos > 0 && heap.Get(pos) > heap.Get(parentPos)) {
                while (pos > 0 && heap.Get(pos) > heap.Get(parentPos)) {
                    int temp = heap.Get(pos);
                    int tempParent = heap.Get(parentPos);
                    heap.Set(heap.Get(parentPos), heap.Get(pos));
                    heap.Set(temp, tempParent);
                }
            } else {
                while (pos < heap.Size()) {
                    int rightPos = Right(pos);
                    int leftPos = Left(pos);
                    int temp = pos;

                    if (leftPos < heap.Size() && heap.Get(leftPos) > heap.Get(temp)) {
                        temp = leftPos;
                    }
                    else if (rightPos < heap.Size() && heap.Get(rightPos) > heap.Get(temp)) {
                        temp = rightPos;
                    }
                    else {
                        break;
                    }
                }
            }
        }

        protected int Right(int pos) {
            return 2 * pos + 1;
        }

        protected int Left(int pos) {
            return 2 * pos + 2;
        }

        protected int Parent(int pos) {
            return (pos - 1) / 2;
        }
    }
}