using System;
using System.Collections.Generic;
using ООП12Library;

namespace ООП13Library
{
    public delegate void CollectionHandler<TKey, TValue>(object source, CollectionHandlerEventArgs<TKey, TValue> args);
    public class CollectionHandlerEventArgs<TKey, TValue> : EventArgs
    {
        public string NameCollection { get; set; }
        public string Operation { get; set; }
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public CollectionHandlerEventArgs(string nameCollection, string operation, TKey key, TValue value)
        {
            this.NameCollection = nameCollection;
            this.Operation = operation;
            this.Key = key;
            this.Value = value;
        }
        public override string ToString()
        {
            return NameCollection + " " + Operation + " " + Key + " " + Value;
        }
    }
    public class MyNewCollection<TKey, TValue> : HashTableCollection<TKey, TValue>
    {
        //происходит при добавлении нового элемента или при удалении элемента из коллекции
        public event CollectionHandler<TKey, TValue> CollectionCountChanged;

        //объекту коллекции присваивается новое значение       
        public event CollectionHandler<TKey, TValue> CollectionReferenceChanged;

        public string NameCollection { get; set; }
        public MyNewCollection(string nameCollection) : base()
        {
            NameCollection = nameCollection;
        }
        public MyNewCollection(string nameCollection, int capacity) : base(capacity)
        {
            NameCollection = nameCollection;
        }
        public MyNewCollection(string nameCollection, HashTableCollection<TKey, TValue> collection) : base(collection)
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
    public class JournalEntry<TKey, TValue>
    {
        public string NameCollection { get; set; }
        public string Operation { get; set; }
        public TKey Key { get; set; }
        public TValue Value { get; set; }

        public JournalEntry(string nameCollection, string operation, TKey key, TValue value)
        {
            this.NameCollection = nameCollection;
            this.Operation = operation;
            this.Key = key;
            this.Value = value;
        }
        public override string ToString()
        {
            return $"Название коллекции: [{ NameCollection}], Операция: [{Operation}], Объект: ключ [{Key}], значение [{Value}]";
        }
    }
    public class Journal<TKey, TValue>
    {
        public List<string> journal = new List<string>();
        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs<TKey, TValue> e)
        {
            JournalEntry<TKey, TValue> je = new JournalEntry<TKey, TValue>(e.NameCollection, e.Operation, e.Key, e.Value);
            journal.Add(je.ToString());

        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs<TKey, TValue> e)
        {
            JournalEntry<TKey, TValue> je = new JournalEntry<TKey, TValue>(e.NameCollection, e.Operation, e.Key, e.Value);
            journal.Add(je.ToString());
        }
        public void PrintJournal()
        {
            if (journal.Count == 0)
            {
                Console.WriteLine("Журнал пуст");
                return;
            }
            foreach (string record in journal)
            {
                Console.WriteLine(record);
            }
        }
    }
}
