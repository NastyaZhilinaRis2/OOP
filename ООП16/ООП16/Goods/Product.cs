using System;
using System.Collections.Generic;
using System.Text;

namespace ООП16
{
    public class Product : Goods, ICloneable, IComparable
    {
        int expirationDate;

        public string Composition { get; set; }
        public int ExpirationDate
        {
            get => expirationDate;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Количество дней не может быть меньше 0");
                else if (value > 365)
                    throw new ArgumentOutOfRangeException("Количество дней не может быть больше 365");
                expirationDate = value;
            }
        }

        public Goods BaseGoods
        {
            get
            {
                return new Goods(Name, Price, AmountGoods);//возвращает объект базового класса
            }
        }
        public Product() : base()
        {
            Composition = "";
            ExpirationDate = 0;
        }
        public Product(string name, int price, int amountGoods, string composition, int expirationDate) : base(name, price, amountGoods)
        {
            Composition = composition;
            ExpirationDate = expirationDate;
        }
        public Product(Product product) : base(product)
        {
            Composition = product.Composition;
            ExpirationDate = product.ExpirationDate;
        }
        public override object ShallowCopy()
        {
            return (Product)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new Product(Name, Price, AmountGoods, Composition, ExpirationDate);
        }
        public override string ToString()
        {
            return base.ToString() + $", Состав: {Composition}, До конца срока годности: {ExpirationDate} дня(ей)";
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Состав: {Composition}\nДо конца срока годности: {ExpirationDate} дня(ей)");
        }
        public new void ShowNotVirtual()
        {
            base.Show();
            Console.WriteLine($"Состав: {Composition}\nДо конца срока годности: {ExpirationDate} дня(ей)");
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Введите состав: ");
            Composition = UserInput.InputString();

            do
            {
                try
                {
                    Console.Write("Введите количество дней до конца срока годности: ");
                    ExpirationDate = UserInput.InputNumber(int.Parse);
                    break;
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }

            } while (true);

        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();
            do
            {
                try
                {
                    Composition = "Состав_" + random.Next(0, 100000);
                    break;
                }
                catch (ArgumentOutOfRangeException) { }
            } while (true);
            do
            {
                try
                {
                    ExpirationDate = random.Next(0, 366);
                    break;
                }
                catch (ArgumentOutOfRangeException) { }
            } while (true);
        }
        public override int CompareTo(object obj)
        {
            if (this is null && obj is null)
                return 0;
            if (this is null)
                return -1;
            if (this is null)
                return 1;
            else
            {
                int baseComparison = base.CompareTo(obj);

                if (baseComparison != 0)
                    return baseComparison;

                var other = (Product)obj;

                if (String.Compare(Composition, other.Composition) > 0)
                    return 1;
                else if (String.Compare(Composition, other.Composition) < 0)
                    return -1;
                if (ExpirationDate > other.ExpirationDate)
                    return 1;
                else if (ExpirationDate < other.ExpirationDate)
                    return -1;
                return 0;
            }
        }
    }
}
