using System;
using System.Collections.Generic;
using System.Text;

namespace HashTable
{
    class MyMapNode<K, V>
    {
        //defining variable
        public readonly int size;
        public readonly LinkedList<keyValue<K, V>>[] items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MyMapNode{K, V}"/> class.
        /// </summary>
        /// <param name="size">The size.</param>
        //default constructor of class
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<keyValue<K, V>>[size];
        }

        /// <summary>
        /// Gets and sets the values.
        /// </summary>
        /// <typeparam name="k"></typeparam>
        /// <typeparam name="v"></typeparam>
        public struct keyValue<k, v>
        {
            public k key { get; set; }
            public v value { get; set; }
            public int Frequency { get; set; }
        }

        /// <summary>
        /// Gets the linkedlist.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        // Creating a GetLinkedList Method with return type as KeyValue Pair
        // Gets the linked list present at the entered position in the items[] array
        protected LinkedList<keyValue<K, V>> GetLinkedlist(int position)
        {
            //key value pair will be retrieved at index position
            LinkedList<keyValue<K, V>> linkedlist = items[position];
            //checks if list is empty
            if (linkedlist == null)
            {
                //linked list is created and updates the array items[]
                linkedlist = new LinkedList<keyValue<K, V>>();
                items[position] = linkedlist;
            }
            return linkedlist;
        }

        /// <summary>
        /// Gets the array postion.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        //To Find the Array Position with key as the parameter
        protected int GetArrayPostion(K key)
        {
            //gets hashcode gives position value using inbuilt function
            int position = key.GetHashCode() % size;
            //returning absolute position
            return Math.Abs(position);
        }

        /// <summary>
        /// Gets the value provided by key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        // Gets the value at the specified key.
        // Generic method to find the key value pair at the particular position
        public V Get(K key)
        {
            int position = GetArrayPostion(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            //iterates through loop so that values is keys are equal
            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    return item.value;
                }
            }
            return default;
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        //Adds the specified key, value pair at the end of the linked list present at the position corresponding to the key.
        public void Add(K key, V value)
        {
            //gets the position of key
            int position = GetArrayPostion(key);
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            keyValue<K, V> item = new keyValue<K, V>() { key = key, value = value };
            //adds the key to the list 
            linkedlist.AddLast(item);
        }

        /// <summary>
        /// Removes the value provided by key.
        /// </summary>
        /// <param name="key">The key.</param>
        //Method to Remove a particular item from the Hash Table
        public void Remove(K key)
        {
            //gets the array position at key
            int position = GetArrayPostion(key);
            //gets the key value pair at given position
            LinkedList<keyValue<K, V>> linkedlist = GetLinkedlist(position);
            bool itemFound = false;
            keyValue<K, V> foundItem = default(keyValue<K, V>);
            // Iterating through the for each loop to find the key value pair 
            foreach (keyValue<K, V> item in linkedlist)
            {
                if (item.key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedlist.Remove(foundItem);
            }
        }

        /// <summary>
        ///Gives the count the of word provided.
        /// </summary>
        //Method to find the frequency of the words appearing in the hash table
        public int GetFrequency(V value)
        {
            int frequency = 0;
            // Iterating using foreach loop to get the key value pair in the list
            foreach (LinkedList<keyValue<K, V>> list in items)
            {
                if (list == null)
                {
                    continue;
                }
                // iterating using for each loop to get each object in the list
                foreach (keyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                    {
                        continue;
                    }
                    // if the object matches the value then increasing the frequency count 
                    if (obj.value.Equals(value))
                    {
                        frequency++;
                    }
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Word '{0}' appears {1} times", value, frequency);
            return frequency;
        }

        /// UC 3
        /// <summary>
        /// Removes the given value.
        /// </summary>
        /// <param name="value">The value.</param>
        //Method to Remove a particular word from the hash table
        public void RemoveValue(V value)
        {
            // Iterating through foreach loop to get the key value pair in the list
            foreach (LinkedList<keyValue<K, V>> list in items)
            { 
                if (list == null)
                    continue;
                // iterating through loop to get each object in the list
                foreach (keyValue<K, V> obj in list)
                {
                    if (obj.Equals(null))
                        continue;
                    // if the object matches the value then it will be removed
                    if (obj.value.Equals(value))
                    {
                        Remove(obj.key);
                        break;
                    }
                }
            }
        }
    }
}
