namespace Q02ImplementBiDictionary
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class BiDictionary<TKey1, TKey2, T>
    {
        private Dictionary<TKey1, Set<T>> collectionByKey1 = new Dictionary<TKey1, Set<T>>();
        private Dictionary<TKey2, Set<T>> collectionByKey2 = new Dictionary<TKey2, Set<T>>();
        private Dictionary<Tuple<TKey1, TKey2>, Set<T>> collectionByKey1AndKey2 = new Dictionary<Tuple<TKey1, TKey2>, Set<T>>();

        public bool Add(TKey1 key1, TKey2 key2, T element)
        {
            this.collectionByKey1.AppendValueToKey(key1, element);
            this.collectionByKey2.AppendValueToKey(key2, element);

            var combinedKeys = new Tuple<TKey1, TKey2>(key1, key2);
            this.collectionByKey1AndKey2.AppendValueToKey(combinedKeys, element);

            return true;
        }

        public ICollection<T> FindElementsByKey1(TKey1 key)
        {
            return this.collectionByKey1.GetValuesForKey(key);
        }

        public ICollection<T> FindElementsByKey2(TKey2 key)
        {
            return this.collectionByKey2.GetValuesForKey(key);
        }

        public ICollection<T> FindElementsByKey1AndKey2(TKey1 key1, TKey2 key2)
        {
            var combinedKeys = new Tuple<TKey1, TKey2>(key1, key2);
            return this.collectionByKey1AndKey2.GetValuesForKey(combinedKeys);
        }

    }
}