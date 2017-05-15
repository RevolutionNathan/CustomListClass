using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomListCLass
{
    public class CustomList<T> : IEnumerable
    {
        private int length;
        T[] items;

        public CustomList()
        {
            length = 0;
            items = new T[length];
        }

      

        
        public IEnumerator GetEnumerator()
        {
           for (int i =0; i < length; i++)
            {
                yield return items[i];
            }
        }
        public T this [int i]
        {
            get 
            {
                return items[i];
            }
            set
            {
                items[i] = value;
            }
        }

        public void CheckTheIndex()
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator(); 
        }
        public int Counter()
        {
            length = 0;
            foreach (T t in items)
            {
                length++;
            }
            return length;
        }

        public int Count
        {
            get
            {
                return length;
            }

        }

        public void Add(T itemAdded)
        {
            T[] temporaryItems = new T[length + 1];
            for (int i = 0; i < length; i++)
                {
                    temporaryItems[i] = items[i];
                }
            temporaryItems[length] = itemAdded;
            items = temporaryItems;
            length++;
        }

        public bool Remove(T itemRemoved)
        {
            Counter();
            T[] temporaryItems = new T[length - 1];
            T[] trash = new T[1];
            int fillCounter = 0;
            for (int i = 0; i < length; i++)
            {
                if (i < items.Length)
                {
                    if (items[i].Equals(itemRemoved))
                    {
                        trash[0] = items[i];
                    }
                    else
                    {
                        temporaryItems[fillCounter] = items[i];
                        fillCounter++;
                    }
                }
                   
            }
            if (trash[0].Equals(itemRemoved))
            {
                items = temporaryItems;
                return true;
            }
            else
            {
                return false;
            }

        }
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(items[i]);
                builder.Append(",");
            }
            builder.Length -= 1;
            string itemsAsString = builder.ToString();
           
            return itemsAsString;
        }

        public static CustomList<T> operator+ (CustomList<T> itemsA, CustomList<T> itemsB)
        {
          
            CustomList<T> temporaryItems = new CustomList<T>();

            for (int i = 0; i < itemsA.length; i++)
            {
                temporaryItems.Add(itemsA[i]);
            }
            for (int i = 0; i < itemsA.length; i++)
            {
                temporaryItems.Add(itemsB[i]);
            }
            return temporaryItems;
        }

        public static CustomList<T> operator- (CustomList<T> items, CustomList<T> itemsSubtracted)
        {
            for (int i = 0; i < itemsSubtracted.length; i++)
            {
                items.Remove(itemsSubtracted[i]);
            }
            return items;
        }
        
          public CustomList<T> Zip(CustomList<T> itemsAdded)
        {
            CustomList<T> temporaryItems = new CustomList<T>();
            int counter = (length <= itemsAdded.length) ? length : itemsAdded.length;
            for (int i = 0; i < counter; i++)
            {
                temporaryItems.Add(items[i]);
                temporaryItems.Add(itemsAdded[i]);
            }
            return temporaryItems;
        }
        public int? GiveValueGetIndex(T valueWhoseIndexSought)
        {
            int i = 0;
            for (i = 0; i < length; i++)
            {
                if (valueWhoseIndexSought.Equals(items[i]))
                {
                    return i;
                }
            }
            return null;
        }
        public T GiveIndexGetValue(int indexWhoseValueSought)
        {
            for (int i = 0; i < length; i++)
            {
                if (indexWhoseValueSought.Equals(i))
                {
                    return items[i];
                }
            }
            return default(T);
        }




    }
}
