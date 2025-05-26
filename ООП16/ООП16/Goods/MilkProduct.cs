using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml.Linq;

namespace ООП16
{
    public class MilkProduct : Product, ICloneable, IComparable
    {
        public bool IsNoLactose { get; set; }
        public bool IsNoMilkFat { get; set; }
        public MilkProduct() : base()
        {
            IsNoLactose = false;
            IsNoMilkFat = false;
        }
        public MilkProduct(string name, int price, int amountGoods, string composition, int expirationDate, bool isNoLactose, bool isNoMilkFat) : base(name, price, amountGoods, composition, expirationDate)
        {
            IsNoLactose = isNoLactose;
            IsNoMilkFat = isNoMilkFat;
        }
        public MilkProduct(MilkProduct milkProduct) : base(milkProduct)
        {
            IsNoLactose = milkProduct.IsNoLactose;
            IsNoMilkFat = milkProduct.IsNoMilkFat;
        }
        public override object ShallowCopy()
        {
            return (MilkProduct)this.MemberwiseClone();
        }
        public override object Clone()
        {
            return new MilkProduct(Name, Price, AmountGoods, Composition, ExpirationDate, IsNoLactose, IsNoMilkFat);
        }
        public override string ToString()
        {
            return base.ToString() + $", Без лактозы: {IsNoLactose}, БМЖ: {IsNoMilkFat}";
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Без лактозы: {IsNoLactose}\nБМЖ: {IsNoMilkFat}");
        }
        public new void ShowNotVirtual()
        {
            base.Show();
            Console.WriteLine($"Без лактозы: {IsNoLactose}\nБМЖ: {IsNoMilkFat}");
        }
        public override void Init()
        {
            base.Init();
            Console.Write("Без лактозы введите 0: ");
            IsNoLactose = UserInput.InputNumber<int>(int.Parse) == 0;

            Console.Write("БМЖ введите 0: ");
            IsNoMilkFat = UserInput.InputNumber<int>(int.Parse) == 0;

        }
        public override void RandomInit()
        {
            base.RandomInit();
            Random random = new Random();

            IsNoLactose = random.Next(2) == 0;
            IsNoMilkFat = random.Next(2) == 0;
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

                var other = (MilkProduct)obj;

                if (IsNoLactose && !other.IsNoLactose)
                    return 1;
                else if (IsNoLactose != other.IsNoLactose)
                    return -1;
                if (IsNoMilkFat && !other.IsNoMilkFat)
                    return 1;
                else if (IsNoMilkFat != other.IsNoMilkFat)
                    return -1;
                return 0;
            }
        }
    }
}
