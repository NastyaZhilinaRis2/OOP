using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ООП10Library
{
    public class Toy : Goods, IInit, ICloneable, IComparable
    {
        int ageLimit;
        
        public string Maker { get; set; }
        public int AgeLimit
        {
            get => ageLimit;
            set
            {
                int[] validValues = { 0, 3, 6, 12, 16, 18 };
                    if (value < 0)
                    throw new ArgumentOutOfRangeException("Возраст не может быть < 0");
                else if (value > 18)
                    throw new ArgumentOutOfRangeException("Возрастное ограничение не может быть > 18");
                else if (!validValues.Contains(value))
                    throw new ArgumentOutOfRangeException("Возрастное ограничение: 0, 3, 6, 12, 16 или 18 ");
                ageLimit = value;
            }
        }

        public Toy() : base()
        {
            Maker = "";
            AgeLimit = 0;
        }
        public Toy(string name, decimal price, int amountGoods, string maker, int ageLimit) : base(name, price, amountGoods)
        {
            Maker = maker;
            AgeLimit = ageLimit;
        }
        public Toy(Toy toy) : base(toy)
        {
            Maker = toy.Maker;
            AgeLimit = toy.AgeLimit;
        }
        public override object ShallowCopy()
        {
            return (Toy)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new Toy(Name, Price, AmountGoods, Maker, AgeLimit);
        }
        public override string ToString()
        {
            return base.ToString() + $", {Maker}, {AgeLimit,-2}+";
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Изготовитель: {Maker}\nВозрастное ограничение: {AgeLimit}+");
        }
        public new void ShowNotVirtual()
        {
            base.Show();
            Console.WriteLine($"Изготовитель: {Maker}\nВозрастное ограничение: {AgeLimit}+");
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Введите изготовителя: ");
            Maker = UserInput.InputString();

            do
            {
                try
                {
                    Console.Write("Введите возрастное ограничение: ");
                    AgeLimit = UserInput.InputNumber(int.Parse);
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
                    Maker = "Изготовитель_" + random.Next(0, 100000);
                    break;
                }
                catch (ArgumentOutOfRangeException) { }
            } while (true);
            do
            {
                try
                {
                    AgeLimit = random.Next(0, 19);
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

                var other = (Toy)obj;

                if (String.Compare(Maker, other.Maker) > 0)
                    return 1;
                else if (String.Compare(Maker, other.Maker) < 0)
                    return -1;
                if (AgeLimit > other.AgeLimit)
                    return 1;
                else if (AgeLimit < other.AgeLimit)
                    return -1;
                return 0;
            }
        }
    }
}
