using System;

namespace MyCollectionLibrary
{
    public class NodeHash<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public NodeHash<TKey, TValue> Next { get; set; }
        public NodeHash()
        {
            Key = default(TKey);
            Value = default(TValue);
            Next = null;
        }
        public NodeHash(TKey key, TValue data)
        {
            Key = key;
            Value = data;
            Next = null;
        }
        public override string ToString()
        {
            return Value + " ";
        }
    }
}
