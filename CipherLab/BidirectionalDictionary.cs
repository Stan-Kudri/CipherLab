using System.Collections;

namespace CipherLab
{
    public class BidirectionalDictionary<TFirst, TSecond> : IEnumerable<KeyValuePair<TFirst, TSecond>>
    {
        private readonly Dictionary<TFirst, TSecond> _forward = new Dictionary<TFirst, TSecond>();
        private readonly Dictionary<TSecond, TFirst> _reverse = new Dictionary<TSecond, TFirst>();

        public BidirectionalDictionary()
        {
            Forward = new Indexer<TFirst, TSecond>(_forward);
            Reverse = new Indexer<TSecond, TFirst>(_reverse);
        }

        public Indexer<TFirst, TSecond> Forward { get; private set; }
        public Indexer<TSecond, TFirst> Reverse { get; private set; }

        public void Add(TFirst t1, TSecond t2)
        {
            if (!_forward.ContainsKey(t1) && !_reverse.ContainsKey(t2))
            {
                _forward.Add(t1, t2);
                _reverse.Add(t2, t1);
            }
        }

        public void Remove(TFirst t1)
        {
            if (_forward.TryGetValue(t1, out var t2))
            {
                _forward.Remove(t1);
                _reverse.Remove(t2);
            }
        }

        public void Remove(TSecond t2)
        {
            if (_reverse.TryGetValue(t2, out var t1))
            {
                _reverse.Remove(t2);
                _forward.Remove(t1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TFirst, TSecond>> GetEnumerator()
        {
            return _forward.GetEnumerator();
        }

        public class Indexer<T2, T1>
        {
            private readonly Dictionary<T2, T1> _dictionary;

            public Indexer(Dictionary<T2, T1> dictionary)
            {
                _dictionary = dictionary;
            }

            public T1 this[T2 index]
            {
                get { return _dictionary[index]; }
                set { _dictionary[index] = value; }
            }

            public bool Contains(T2 key)
            {
                return _dictionary.ContainsKey(key);
            }
        }

        public bool TryGetValue(TFirst key, out TSecond value)
        {
            if (_forward.TryGetValue(key, out var second))
            {
                value = second;
                return true;
            }
            value = default(TSecond);
            return false;
        }

        public bool TryGetValue(TSecond key, out TFirst value)
        {
            if (_reverse.TryGetValue(key, out var first))
            {
                value = first;
                return true;
            }
            value = default(TFirst);
            return false;
        }
    }
}
