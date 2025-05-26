using System;
using System.Collections.Generic;
using System.Text;

namespace MyCollectionLibrary
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
            return $"Название коллекции: [{NameCollection}], Операция: [{Operation}], Объект: ключ [{Key}], значение [{Value}]";
        }
    }
    public class Journal<TKey, TValue>
    {
        public string Path { get; set; }

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
