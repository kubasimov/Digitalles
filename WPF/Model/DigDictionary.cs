using System;
using System.Collections;
using System.Collections.Generic;

namespace WPF.Model
{
    /// <summary>
    /// Słowink haseł
    /// pojedyńcze hasło składa się z klucza - hasła i wartości - listy elementów opisujących hasło
    /// </summary>
    public class DigDictionary:IDictionary
    {
        private Dictionary<string,Dictionary<string,string>> _descriptionArrayList;

        public DigDictionary(Dictionary<string, Dictionary<string, string>> descriptionArrayList)
        {
            _descriptionArrayList = descriptionArrayList;
        }


        public bool Contains(object key)
        {
            return ((IDictionary) _descriptionArrayList).Contains(key);
        }

        public void Add(object key, object value)
        {
            ((IDictionary) _descriptionArrayList).Add(key, value);
        }

        public void Clear()
        {
            _descriptionArrayList.Clear();
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            return ((IDictionary) _descriptionArrayList).GetEnumerator();
        }

        public void Remove(object key)
        {
            ((IDictionary) _descriptionArrayList).Remove(key);
        }

        public object this[object key]
        {
            get { return ((IDictionary) _descriptionArrayList)[key]; }
            set { ((IDictionary) _descriptionArrayList)[key] = value; }
        }

        public ICollection Keys
        {
            get { return ((IDictionary) _descriptionArrayList).Keys; }
        }

        public ICollection Values
        {
            get { return ((IDictionary) _descriptionArrayList).Values; }
        }

        public bool IsReadOnly
        {
            get { return ((IDictionary) _descriptionArrayList).IsReadOnly; }
        }

        public bool IsFixedSize
        {
            get { return ((IDictionary) _descriptionArrayList).IsFixedSize; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _descriptionArrayList).GetEnumerator();
        }

        public void CopyTo(Array array, int index)
        {
            ((ICollection) _descriptionArrayList).CopyTo(array, index);
        }

        public int Count
        {
            get { return _descriptionArrayList.Count; }
        }

        public object SyncRoot
        {
            get { return ((ICollection) _descriptionArrayList).SyncRoot; }
        }

        public bool IsSynchronized
        {
            get { return ((ICollection) _descriptionArrayList).IsSynchronized; }
        }
    }
}