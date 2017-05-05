using System.Collections;
using System.Collections.Generic;

namespace WPF.Model
{
    public class DictionaryModel:IDictionary<string,string>
    {
        private readonly IDictionary<string, string> _dictionaryImplementation;


        public DictionaryModel(IDictionary<string, string> dictionaryImplementation)
        {
            _dictionaryImplementation = dictionaryImplementation;
        }

        public DictionaryModel()
        {
            _dictionaryImplementation = new Dictionary<string, string>();
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _dictionaryImplementation.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) _dictionaryImplementation).GetEnumerator();
        }

        public void Add(KeyValuePair<string, string> item)
        {
            _dictionaryImplementation.Add(item);
        }

        public void Clear()
        {
            _dictionaryImplementation.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return _dictionaryImplementation.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            _dictionaryImplementation.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return _dictionaryImplementation.Remove(item);
        }

        public int Count
        {
            get { return _dictionaryImplementation.Count; }
        }

        public bool IsReadOnly
        {
            get { return _dictionaryImplementation.IsReadOnly; }
        }

        public bool ContainsKey(string key)
        {
            return _dictionaryImplementation.ContainsKey(key);
        }

        public void Add(string key, string value)
        {
            _dictionaryImplementation.Add(key, value);
        }

        public bool Remove(string key)
        {
            return _dictionaryImplementation.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            return _dictionaryImplementation.TryGetValue(key, out value);
        }

        public string this[string key]
        {
            get { return _dictionaryImplementation[key]; }
            set { _dictionaryImplementation[key] = value; }
        }

        public ICollection<string> Keys
        {
            get { return _dictionaryImplementation.Keys; }
        }

        public ICollection<string> Values
        {
            get { return _dictionaryImplementation.Values; }
        }
    }
}