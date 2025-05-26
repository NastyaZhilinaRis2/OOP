using System;
using System.Collections.Generic;
using System.Text;

namespace ООП16
{
    public class MyCollection<TKey, TValue> : HashTableCollection<TKey, TValue>
    {
        //происходит при добавлении нового элемента или при удалении элемента из коллекции
        public event CollectionHandler<TKey, TValue> CollectionCountChanged;

        //объекту коллекции присваивается новое значение       
        public event CollectionHandler<TKey, TValue> CollectionReferenceChanged;

        public string NameCollection { get; set; }
        public MyCollection(string nameCollection) : base()
        {
            NameCollection = nameCollection;
        }
        public MyCollection(string nameCollection, int capacity) : base(capacity)
        {
            NameCollection = nameCollection;
        }
        public MyCollection(string nameCollection, HashTableCollection<TKey, TValue> collection) : base(collection)
        {
            NameCollection = nameCollection;
        }
        public override bool Remove(TKey key)
        {
            if (TryGetValue(key, out TValue value))
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TKey, TValue>(this.NameCollection, "delete", key, value));
            }
            return base.Remove(key);
        }
        public override void Add(TKey key, TValue value)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<TKey, TValue>(this.NameCollection, "add", key, value));
            base.Add(key, value);
        }
        public override TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<TKey, TValue>(this.NameCollection, "changed", key, value));
                base[key] = value;
            }
        }
        void OnCollectionCountChanged(object source, CollectionHandlerEventArgs<TKey, TValue> args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }
        void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs<TKey, TValue> args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }
    }
}
