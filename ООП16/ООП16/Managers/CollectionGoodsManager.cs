using MyCollectionLibrary;

namespace ООП16
{
    public static class CollectionGoodsManager
    {
        public static List<Goods> SortedByField(MyCollection<string, Goods> collection, string field)
        {
            List<Goods>? sortedList = new List<Goods>();

            switch (field)
            {
                case "Название":
                    {
                        foreach (var item in collection.OrderBy(kv => kv.Value, new SortByName()))
                        {
                            sortedList.Add(item.Value);
                        }

                        break;
                    }
                case "Цена":
                    {
                        foreach (var item in collection.OrderBy(kv => kv.Value, new SortByPrice()))
                        {
                            sortedList.Add(item.Value);
                        }
                        break;
                    }
                case "Количество":
                    {
                        foreach (var item in collection.OrderBy(kv => kv.Value, new SortByAmountGoods()))
                        {
                            sortedList.Add(item.Value);
                        }
                        break;
                    }
            }
            return sortedList;
        }
        public static List<Goods> FilteringByField(MyCollection<string, Goods> collection, string filter, string field)
        {
            List<Goods>? filterList = new List<Goods>();

            switch (field)
            {
                case "Название":
                    {
                        filterList = collection.Select(kv => kv.Value).Where(g => g.Name == filter).ToList();
                        break;
                    }
                case "Цена":
                    {
                        if (int.TryParse(filter, out int price))
                        {
                            filterList = collection.Select(kv => kv.Value).Where(g => g.Price == price).ToList();
                        }
                        else MessageBox.Show("Введен неверный формат данных фильтрации. Введите число!");
                        break;
                    }
                case "Количество":
                    {
                        if (int.TryParse(filter, out int amountGoods))
                        {
                            filterList = collection.Select(kv => kv.Value).Where(g => g.AmountGoods == amountGoods).ToList();
                        }
                        else MessageBox.Show("Введен неверный формат данных фильтрации. Введите число!");
                        break;
                    }
            }
            return filterList;
        }
        public static MyCollection<string, Goods> ConvertGoodsData(List<string> data)
        {
            MyCollection<string, Goods> convertData = new MyCollection<string, Goods>("Коллекция");
            foreach (string item in data)
            {
                var strArray = item.Split(new string[]
                { "[", "]", ", ",
                "Название: ", "Цена: ", "Количество: ", "Изготовитель: ", "Возрастное ограничение: " , "Состав: " , "До конца срока годности: ", "Без лактозы: ", "БМЖ: " ,
                " руб.", " шт.", "+", " дня(ей)" },
                StringSplitOptions.RemoveEmptyEntries);

                switch (strArray[2])
                {
                    case "Goods":
                        {
                            convertData.Add(strArray[0], new Goods(strArray[3], int.Parse(strArray[4]), int.Parse(strArray[5])));
                            break;
                        }
                    case "Toy":
                        {
                            convertData.Add(strArray[0], new Toy(strArray[3], int.Parse(strArray[4]), int.Parse(strArray[5]), strArray[6], int.Parse(strArray[7])));
                            break;
                        }
                    case "Product":
                        {
                            convertData.Add(strArray[0], new Product(strArray[3], int.Parse(strArray[4]), int.Parse(strArray[5]), strArray[6], int.Parse(strArray[7])));
                            break;
                        }
                    case "MilkProduct":
                        {
                            convertData.Add(strArray[0], new MilkProduct(strArray[3], int.Parse(strArray[4]), int.Parse(strArray[5]), strArray[6], int.Parse(strArray[7]), bool.Parse(strArray[8]), bool.Parse(strArray[9])));
                            break;
                        }
                    default:
                        {
                            throw new ArgumentException("Неверные данные для конвертации!");
                        }
                }
            }
            return convertData;
        }
    }
}
