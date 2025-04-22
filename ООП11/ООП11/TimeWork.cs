using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ООП11
{
    public class TimeWork
    {
        // с помощью метода Contains находим, есть элемент или нет
        public static string TimeOfWorkList<TValue>(LinkedList<TValue> list, TValue obj)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var flag = list.Contains(obj);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }
        // с помощью метода ContainsKey (по ключу) находим, есть элемент или нет
        public static string TimeOfWorkDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key) where TKey : notnull
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var flag = dictionary.ContainsKey(key);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }
        // с помощью метода ContainsValue (по значению) находим, есть элемент или нет
        public static string TimeOfWorkDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TValue value) where TKey : notnull
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var flag = dictionary.ContainsValue(value);
            stopWatch.Stop();
            return stopWatch.Elapsed.TotalMilliseconds.ToString() + $" Найден: {flag}";
        }
    }
}
