using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ООП16
{
    [JsonDerivedType(typeof(Toy), typeDiscriminator: "Toy")]
    [JsonDerivedType(typeof(Product), typeDiscriminator: "Product")]
    [JsonDerivedType(typeof(MilkProduct), typeDiscriminator: "MilkProduct")]
    [XmlInclude(typeof(Toy))]
    [XmlInclude(typeof(Product))]
    [XmlInclude(typeof(MilkProduct))]
    [Serializable]
    public class Goods : IInit, ICloneable, IComparable
    {
        private string name;
        private int price;
        private int amountGoods;

        [JsonIgnore]
        [XmlIgnore]
        public int[] ReferenceType { get; set; } // Ссылочный тип (для демонстрации поверхностного копирования)

        //свойства
        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }
        public int Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Стоимость не может быть меньше 0");
                else if (value > 100000)
                    throw new ArgumentOutOfRangeException("Стоимость не может быть больше 100000");
                price = value;
            }
        }
        public int AmountGoods
        {
            get => amountGoods;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество товаров не может быть < 0");
                else if (value > 100000)
                    throw new ArgumentOutOfRangeException("Количество товаров не может быть > 100000");
                amountGoods = value;
            }
        }
        //конструктор без параметров
        public Goods()
        {
            Name = "";
            Price = 0;
            AmountGoods = 0;
            CreateReferenceType();
        }
        //конструктор с параметрами
        public Goods(string name, int price, int amountGoods)
        {
            Name = name;
            Price = price;
            AmountGoods = amountGoods;
            CreateReferenceType();
        }
        //конструктор копирования
        public Goods(Goods goods)
        {
            Name = goods.Name;
            Price = goods.Price;
            AmountGoods = goods.AmountGoods;
            ReferenceType = (int[])goods.ReferenceType.Clone();
        }
        void CreateReferenceType()
        {
            Random random = new Random();
            ReferenceType = new int[3];
            ReferenceType[0] = random.Next(0, 10);
            ReferenceType[1] = random.Next(0, 10);
            ReferenceType[2] = random.Next(0, 10);
        }
        //метод для поверхностного копирования
        public virtual object ShallowCopy()
        {
            return (Goods)this.MemberwiseClone();
        }
        //метод для глубокого копирования
        public virtual object Clone()
        {
            Goods clone = new Goods(Name, Price, AmountGoods);
            clone.ReferenceType = (int[])ReferenceType.Clone();
            return clone;
        }
        //вывод строки со сылочным типом
        public string StringWithReferenceType()
        {
            return $"Название: {Name}, Цена: {Price} руб., {AmountGoods} шт.";
        }
        public override string ToString()
        {
            return $"Тип объекта: [{this.GetType().Name}], Название: {Name}, Цена: {Price} руб., Количество: {AmountGoods} шт.";
        }
        //вывод информации об экземпляре (виртуальный метод)
        public virtual void Show()
        {
            Console.WriteLine($"Название: {Name}\nЦена: {Price} руб.\nКоличество: {AmountGoods} шт.");
        }
        //вывод информации об экземпляре (не виртуальный метод)
        public void ShowNotVirtual()
        {
            Console.WriteLine($"Название: {Name}\nЦена: {Price} руб.\nКоличество: {AmountGoods} шт.");
        }
        //РУЧНОЙ ввод информации об экземпляре (виртуальный метод) 
        public virtual void Init()
        {
            Console.Write("Введите название товара: ");
            Name = UserInput.InputString();

            do
            {
                try
                {
                    Console.Write("Введите цену товара: ");
                    Price = UserInput.InputNumber(int.Parse);
                    break;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }

            } while (true);
            do
            {
                try
                {
                    Console.Write("Введите количество товара: ");
                    AmountGoods = UserInput.InputNumber(int.Parse);
                    break;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }

            } while (true);
        }
        //АВТО ввод информации об экземпляре (виртуальный метод) 
        public virtual void RandomInit()
        {
            Random random = new Random();
            do
            {
                try
                {
                    Name = "Товар_" + random.Next(0, 100000);
                    break;
                }
                catch (Exception) { }
            } while (true);
            do
            {
                try
                {
                    Price = random.Next(0, 100000);
                    break;
                }
                catch (Exception) { }
            } while (true);
            do
            {
                try
                {
                    AmountGoods = random.Next(0, 100000);
                    break;
                }
                catch (Exception) { }
            } while (true);
        }
        //проверка на равенство объектов
        public override bool Equals(object obj)
        {
            if (obj is Goods goods2)
                return Name == goods2.Name && Price == goods2.Price && AmountGoods == goods2.AmountGoods;
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Price, AmountGoods);
        }
        //реализация интерфейса
        public virtual int CompareTo(object obj)
        {
            if (this is null && obj is null)
                return 0;
            if (this is null)
                return -1;
            if (obj is null)
                return 1;
            else
            {
                var other = (Goods)obj;

                if (String.Compare(Name, other.Name) > 0)
                    return 1;
                else if (String.Compare(Name, other.Name) < 0)
                    return -1;
                if (Price > other.Price)
                    return 1;
                else if (Price < other.Price)
                    return -1;
                if (AmountGoods > other.AmountGoods)
                    return 1;
                if (AmountGoods < other.AmountGoods)
                    return -1;
                return 0;
            }
        }
    }

    public class SortByName : IComparer<Goods>
    {
        public int Compare(Goods x, Goods y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }

    public class SortByPrice : IComparer<Goods>
    {
        public int Compare(Goods x, Goods y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x.Price.CompareTo(y.Price);
        }
    }

    public class SortByAmountGoods : IComparer<Goods>
    {
        public int Compare(Goods x, Goods y)
        {
            if (x is null && y is null) return 0;
            if (x is null) return -1;
            if (y is null) return 1;
            return x.AmountGoods.CompareTo(y.AmountGoods);
        }
    }
}
