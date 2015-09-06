﻿namespace Q02ImplementBiDictionary
{
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public static class DictionaryExtensions
    {
        /// <summary>
        /// Appends a new value to the collection of values mapped to the specified
        /// dictionary key. If the collection does not exists for the specified key,
        /// a new empty collection is first created and mapped to this key.
        /// </summary>
        /// <param name="key">The key that holds a collection of values</param>
        /// <param name="value">The value to be added to the collection for this key</param>
        public static void AppendValueToKey<TKey, TCollection, TValue>(
            this IDictionary<TKey, TCollection> dict, TKey key, TValue value)
            where TCollection : ICollection<TValue>, new()
        {
            TCollection collection;
            if (!dict.TryGetValue(key, out collection))
            {
                collection = new TCollection();
                dict.Add(key, collection);
            }
            collection.Add(value);
        }

        /// <summary>
        /// Get a sequence of values assigned to the specified dictionary key.
        /// If the key is missng, an empty sequence is returned.
        /// </summary>
        public static ICollection<TValue> GetValuesForKey<TKey, TValue>(
            this IDictionary<TKey, Set<TValue>> dict, TKey key)
        {
            Set<TValue> collection;
            if (dict.TryGetValue(key, out collection))
            {
                return collection;
            }
            return null;
        }
    }
}