using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace ООП12Library
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
    public class HashTableCollection<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private NodeHash<TKey, TValue>[] hashTable; // массив указателей на головы цепочек

        // индексатор, например hashTable["apple"] = 1;
        public virtual TValue this[TKey key]
        {
            get
            {
                // пытаемся получить значение по ключу
                if (TryGetValue(key, out TValue value))
                {
                    return value;// ключ найден
                }
                throw new KeyNotFoundException("Ключ не найден.");// ключ не найден
            }
            set
            {
                // устанавливаем значение по ключу, добавляя его в хеш-таблицу
                Update(key, value);
            }
        }

        // свойство возвращает коллекцию ключей
        public ICollection<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();// создаем новый список для хранения ключей
                foreach (var node in hashTable)// проходим по всем ведрам хеш-таблицы
                {
                    NodeHash<TKey, TValue> current = node;
                    while (current != null)// проходим по цепочке узлов
                    {
                        keys.Add(current.Key);
                        current = current.Next;
                    }
                }
                return keys;
            }
        }

        // свойство возвращает коллекцию значений
        public ICollection<TValue> Values
        {
            get
            {
                List<TValue> values = new List<TValue>();// создаем новый список для хранения значений
                foreach (var node in hashTable)
                {
                    NodeHash<TKey, TValue> current = node;
                    while (current != null)
                    {
                        values.Add(current.Value);
                        current = current.Next;
                    }
                }
                return values;
            }
        }
        public int Count
        {
            get
            {
                int count = 0;
                foreach (var node in hashTable)
                {
                    NodeHash<TKey, TValue> current = node;
                    while (current != null)
                    {
                        count++;
                        current = current.Next;
                    }
                }
                return count;
            }
        }

        public bool IsReadOnly => false;
        public HashTableCollection()
        {
            hashTable = new NodeHash<TKey, TValue>[30];
        }
        public HashTableCollection(int capacity)
        {
            hashTable = new NodeHash<TKey, TValue>[capacity];
        }
        public HashTableCollection(HashTableCollection<TKey, TValue> collection)
        {
            hashTable = collection.hashTable;
        }
        private void Update(TKey key, TValue value)
        {
            var node = FindNode(key);
            if (node != null)
                node.Value = value;
            else
                Add(key, value);
        }
        private NodeHash<TKey, TValue> FindNode(TKey key)
        {
            int index = GetHeshIndex(key);
            NodeHash<TKey, TValue> current = hashTable[index];
            while (current != null)
            {
                if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
                    return current;
                current = current.Next;
            }
            return null;
        }
        // метод добавляет переданные ключ и значение в хеш-таблицу
        public virtual void Add(TKey key, TValue value)
        {
            if (hashTable == null)
            {
                throw new ArgumentNullException("Хеш таблица равна null");
            }
            int index = GetHeshIndex(key);

            // проверка на наличие дубликата ключа
            if (ContainsKey(key))
                throw new ArgumentException("Дублирование записи.");

            // если ведро пустое, создаем новый узел
            if (hashTable[index] == null)
                hashTable[index] = new NodeHash<TKey, TValue>(key, value);
            else
            {
                // если ведро не пустое, проходим по цепочке узлов
                NodeHash<TKey, TValue> current = hashTable[index];
                while (current.Next != null)
                {
                    current = current.Next;
                }
                // добавляем новый узел в конец цепочки
                NodeHash<TKey, TValue> newNode = new NodeHash<TKey, TValue>(key, value);
                current.Next = newNode;
            }
        }
        // метод добавляет переданный массив ключ и значение в хеш-таблицу
        public void AddRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }
        // метод добавляет пару ключ-значение в хеш-таблицу
        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        // метод очищает хеш-таблицу, устанавливая все ведра в null
        public void Clear()
        {
            Array.Clear(hashTable, 0, hashTable.Length);
        }

        // метод проверяет, содержит ли хеш-таблица указанный ключ
        public bool ContainsKey(TKey key)
        {
            int index = GetHeshIndex(key);

            if (hashTable[index] != null)// проверяем, не пусто ли ведро по этому индексу
            {
                NodeHash<TKey, TValue> current = hashTable[index];// первый узел в ведре

                // проходим по цепочке узлов в текущем ведре
                while (current != null)
                {
                    // сравниваем текущий ключ с заданным ключом
                    if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
                    {
                        return true;// ключ найден
                    }
                    current = current.Next;// переходим к следующему узлу в цепочке
                }
            }
            return false;// ключ не найден
        }
        // метод проверяет, содержится ли указанная пара ключ-значение в хеш-таблице
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return ContainsKey(item.Key);
        }

        // метод копирует все элементы хеш-таблицы в указанный массив
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            // проверяем, не является ли массив null
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            // проверяем, корректен ли индекс для вставки
            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            // проверяем, достаточно ли места в массиве для копирования всех элементов
            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Недостаточно места в массиве.");
            }
            int numNew = 0;// переменная для отслеживания количества скопированных элементов

            // проходим по всем ведрам хеш-таблицы
            for (int i = 0; i < hashTable.Length; i++)
            {
                // если ведро не пустое
                if (hashTable[i] != null)
                {
                    NodeHash<TKey, TValue> current = hashTable[i];// первый узел в ведре

                    // проходим по цепочке узлов в текущем ведре
                    while (current != null)
                    {
                        // копируем текущую пару в массив
                        array[arrayIndex + numNew] = new KeyValuePair<TKey, TValue>(current.Key, current.Value);
                        numNew++;// увеличиваем счетчик скопированных элементов
                        current = current.Next;// переходим к следующему узлу в цепочке
                    }
                }
            }
        }

        // реализация IEnumerable 
        // метод для получения перечислителя, который позволяет перебирать элементы хеш-таблицы
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            // создаем и возвращаем новый экземпляр HashTableEnumerator
            return new HashTableEnumerator<TKey, TValue>(this.hashTable);
        }
        // неявная реализация интерфейса IEnumerable для поддержки не обобщенных перечислителей
        IEnumerator IEnumerable.GetEnumerator()
        {
            // вызываем обобщенный метод GetEnumerator, чтобы вернуть перечислитель
            return GetEnumerator();
        }
        public class HashTableEnumerator<TKey, TValue> : IEnumerator<KeyValuePair<TKey, TValue>>
        {
            private readonly NodeHash<TKey, TValue>[] hashTable;// массив ведер
            private int currentBucket;// индекс текущего ведра
            private NodeHash<TKey, TValue> currentNode;// текущий узел в цепочке
            private bool started; // флаг, чтобы отслеживать, был ли начат перебор

            // свойство для получения текущей пары типа KeyValuePair
            public KeyValuePair<TKey, TValue> Current
            {
                get
                {
                    if (currentNode == null)
                        throw new InvalidOperationException("Текущий node = null");
                    return new KeyValuePair<TKey, TValue>(currentNode.Key, currentNode.Value);
                }
            }
            object IEnumerator.Current => Current;
            public HashTableEnumerator(NodeHash<TKey, TValue>[] hashTable)
            {
                this.hashTable = hashTable;
                currentBucket = -1;
                currentNode = null;
                started = false;
            }
            public void Dispose() { }

            // метод для перемещения к следующему элементу
            public bool MoveNext()
            {
                // двигаемся по цепочкам >
                if (currentNode != null)
                {
                    currentNode = currentNode.Next;// переход к следующему узлу
                }
                // двигаемся по ведрам v
                while (currentNode == null && currentBucket < hashTable.Length - 1)
                {
                    currentBucket++;// переход к следующему ведру
                    if (currentBucket < hashTable.Length)
                    {
                        currentNode = hashTable[currentBucket];// получаем первый элемент в новом ведре
                    }
                }

                return currentNode != null;// возвращаем true, если нашли следующий элемент
            }

            // метод для сброса состояния перечислителя
            public void Reset()
            {
                currentBucket = -1;
                currentNode = null;
                started = false;
            }
        }

        // метод для удаления узла по ключу из хеш-таблицы
        public virtual bool Remove(TKey key)
        {
            int index = GetHeshIndex(key);

            if (hashTable[index] != null) // проверяем, есть ли элементы в ведре
            {
                NodeHash<TKey, TValue> current = hashTable[index];// начинаем с головы цепочки
                NodeHash<TKey, TValue> previous = null;// предыдущий узел
                while (current != null)// проходим по цепочке
                {
                    // проверяем, совпадает ли ключ с искомым
                    if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
                    {
                        // Если удаляемый узел — это голова цепочки
                        if (previous == null)
                            hashTable[index] = current.Next; // обновляем голову цепочки
                        else
                            previous.Next = current.Next; // удаляем узел из цепочки
                        return true;// успешно удалено
                    }
                    // Переходим к следующему узлу
                    previous = current;
                    current = current.Next;
                }
            }
            return false;// не найдено для удаления
        }
        // метод удаляет переданный массив ключи и значения из хеш-таблицы
        public void RemoveRange(IEnumerable<KeyValuePair<TKey, TValue>> items)
        {
            foreach (var item in items)
            {
                Remove(item);
            }
        }
        // метод для удаления пары ключ-значение из хеш-таблицы
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        // метод для поиска значения по ключу
        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            int index = GetHeshIndex(key);

            NodeHash<TKey, TValue> current = hashTable[index];// начинаем с узла в этом ведре
            // проходим по цепочке узлов
            while (current != null)
            {
                // сравниваем текущий ключ с заданным ключом
                if (EqualityComparer<TKey>.Default.Equals(current.Key, key))
                {
                    value = current.Value;// ключ найден
                    return true;// успешный поиск
                }
                current = current.Next;// переходим к следующему узлу в цепочке
            }

            value = default; // ключ не найден
            return false;// неуспешный поиск
        }
        // метод для поиска элемента по значению
        public bool TryGetKey(TValue value, [MaybeNullWhen(false)] out TKey key)
        {
            // проверяем, что хеш-таблица не равна null
            if (hashTable == null)
            {
                key = default;
                return false; // хеш-таблица не инициализирована
            }

            foreach (var current in hashTable)
            {
                // проверяем, что текущее значение не равно null
                if (current != null && EqualityComparer<TValue>.Default.Equals(current.Value, value))
                {
                    key = current.Key; // значение найдено
                    return true; // успешный поиск
                }
            }

            key = default; // Значение не найдено
            return false; // Неуспешный поиск
        }
        // метод для получения хеш-индекса по ключу
        private int GetHeshIndex(TKey key)
        {
            return Math.Abs(HashCode.Combine(key)) % hashTable.Length;
        }
        // удаление коллекции из памяти
        public void Dispose()
        {
            Clear();
            hashTable = null;
        }
        // глубокое клонирование коллекции
        public HashTableCollection<TKey, TValue> DeepClone()
        {
            HashTableCollection<TKey, TValue> clone = new HashTableCollection<TKey, TValue>(hashTable.Length);
            foreach (var item in this)
            {
                clone.Add(CloneKey(item.Key), CloneValue(item.Value));// Создаем новую пару
            }
            return clone;
        }
        private TKey CloneKey(TKey key)
        {
            if (key is ICloneable cloneable)
            {
                return (TKey)cloneable.Clone(); // Если TKey реализует ICloneable, используем его метод Clone
            }
            // Если TKey - это структура или примитивный тип, можно просто вернуть значение
            return key; // В случае, если клонирование не требуется
        }
        private TValue CloneValue(TValue value)
        {
            if (value is ICloneable cloneable)
            {
                return (TValue)cloneable.Clone(); // Если TValue реализует ICloneable, используем его метод Clone
            }
            // Если TValue - это структура или примитивный тип, можно просто вернуть значение
            return value; // В случае, если клонирование не требуется
        }
        // поверхностное копирование
        public HashTableCollection<TKey, TValue> ShallowCopy()
        {
            return new HashTableCollection<TKey, TValue>(this);
        }
        public void Print()
        {
            if (hashTable == null)
                throw new ArgumentException("Массив null.");
            foreach (var item in this)
            {
                Console.WriteLine(item);
            }
        }
    }
    public static class HashTableCollectionExtensions
    {
        // a) Выборка по условию
        public static IEnumerable<T> GetProducts<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        // b) Агрегация
        public static decimal SumPriceProduct<T>(this IEnumerable<T> source, Func<T, bool> nameProduct, Func<T, decimal> Price, Func<T, int> AmountGoods)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            List<decimal> sumList = new List<decimal>();
            foreach (var item in source)
            {
                if (nameProduct(item))
                {
                    sumList.Add((decimal)(Price(item) * AmountGoods(item)));
                }
            }
            decimal sum = 0;
            foreach (var item in sumList)
            {
                sum += item;
            }
            return sum;
        }
        // c) Сортировка
        public static IEnumerable<KeyValuePair<TKey, TValue>> SortProductOrderBy<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> source) where TValue : IComparable
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            var items = source.ToList();

            for (int i = 0; i < items.Count - 1; i++)
            {
                for (int j = 0; j < items.Count - i - 1; j++)
                {
                    if (items[j].Value.CompareTo(items[j + 1].Value) > 0)
                    {
                        var temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }

            return items;
        }
    }
}


