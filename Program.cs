﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private Atype[] data;
        private int size;

        public DyanamicArray() {
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

            AddAt(val, pos);
        }
        
        private int Size() {
            return size;
        }
    }

    public class Stack<Stype> {
        private DyanamicArray<Stype> stack;
        private int size;
        public Stack () {
            stack = new DyanamicArray<Stype>();
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
        private DyanamicArray<Qtype> queue;
        private int size;
        public Queue () {
            
        }

        public void Enqueue(Qtype item) {

        }

        public Qtype Peek() {
            
        }

        public int Size() {
            return size;
        }
    }

    public class InsertionSort {
        public static void Sort(int[] list) {
            
        }
    }

    public class MergeSort {
        public static void Sort(int[] list) {

        }
    }
}