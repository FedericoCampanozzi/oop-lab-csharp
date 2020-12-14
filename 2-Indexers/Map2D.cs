namespace Indexers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <inheritdoc cref="IMap2D{TKey1,TKey2,TValue}" />
    public class Map2D<TKey1, TKey2, TValue> : IMap2D<TKey1, TKey2, TValue>
    {
        public IDictionary<Tuple<TKey1, TKey2>, TValue> Map { get; set; }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.NumberOfElements" />
        public int NumberOfElements
        {
            get => Map.Count;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.this" />
        public TValue this[TKey1 key1, TKey2 key2]
        {
            get => Map[new Tuple<TKey1, TKey2>(key1, key2)];
            set => Map[new Tuple<TKey1, TKey2>(key1, key2)] = value;
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetRow(TKey1)" />
        public IList<Tuple<TKey2, TValue>> GetRow(TKey1 key1)
        {
            return Map.Where(tuple => tuple.Key.Item1.Equals(key1)).Select(tuple => new Tuple<TKey2, TValue>(tuple.Key.Item2, tuple.Value)).ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetColumn(TKey2)" />
        public IList<Tuple<TKey1, TValue>> GetColumn(TKey2 key2)
        {
            return Map.Where(tuple => tuple.Key.Item2.Equals(key2)).Select(tuple => new Tuple<TKey1, TValue>(tuple.Key.Item1, tuple.Value)).ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.GetElements" />
        public IList<Tuple<TKey1, TKey2, TValue>> GetElements()
        {
            return Map.Select(tuple => new Tuple<TKey1, TKey2, TValue>(tuple.Key.Item1, tuple.Key.Item2, tuple.Value)).ToList();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.Fill(IEnumerable{TKey1}, IEnumerable{TKey2}, Func{TKey1, TKey2, TValue})" />
        public void Fill(IEnumerable<TKey1> keys1, IEnumerable<TKey2> keys2, Func<TKey1, TKey2, TValue> generator)
        {
            IList<TKey1> listKey1 = new List<TKey1>(keys1);
            IList<TKey2> listKey2 = new List<TKey2>(keys2);

            Map = new Dictionary<Tuple<TKey1, TKey2>, TValue>();

            for (int i = 0; i < listKey1.Count; i++)
            {
                for (int j = 0; j < listKey2.Count; j++)
                {
                    Map.Add(new Tuple<TKey1, TKey2>(listKey1[i], listKey2[j]), generator(listKey1[i], listKey2[j]));
                }
            }
        }

        /// <inheritdoc cref="IEquatable{T}.Equals(T)" />
        public bool Equals(IMap2D<TKey1, TKey2, TValue> other)
        {
            return other.NumberOfElements == this.NumberOfElements;
        }

        /// <inheritdoc cref="object.Equals(object?)" />
        public override bool Equals(object obj)
        {
            // TODO: improve
            return base.Equals(obj);
        }

        /// <inheritdoc cref="object.GetHashCode"/>
        public override int GetHashCode()
        {
            // TODO: improve
            return base.GetHashCode();
        }

        /// <inheritdoc cref="IMap2D{TKey1, TKey2, TValue}.ToString"/>
        public override string ToString()
        {
            // TODO: improve
            return base.ToString();
        }
    }
}
