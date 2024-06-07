using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrucures
{
    /*
     * Generic Node Class
     * Can be extended to add additional references depending on the data structure
     * Using the generic type <T> allows us to create nodes of ANY type!
     */
    public class Node<T>
    {
        private T data;
        public Node()
        {
            data = default;
        }
        /*
         * Constructor
         * Node example = new Node<String>; this will create a node of type String, so every instance of T would be the same as if it were a String data tyoe
         * 
         */
        public Node(T val)
        {
            data = val;

        }
        
        /**
         * Shorthand to create a Getter and Setter method for Data
         */
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        /*
         * override of the .Equals method to properly allow comparisons between Nodes
         */
        public override bool Equals(object? obj)
        {
            //Check for null input, different objects, and null data
            if (obj == null || obj.GetType() != this.GetType() || this.data == null)
            {
                return false;
            }
            else
            {
                return data.Equals(((Node<T>)obj).Data);
            }
        }
        /*
         * We're not making our own hash code, so leave as is :)
         */
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        
    }
}
