using System;
using System.Collections.Generic;
using System.Text;
using ООП10Library;

namespace ООП11
{
    public class TestCollections
    {
        public LinkedList<Product> listProduct;
        public LinkedList<string> listStr;
        public Dictionary<Goods, Product> dictionaryKeyGoods;
        public Dictionary<string, Product> dictionaryKeyStr;
        public int Count 
        { 
            get 
            {
                if (listProduct == null)
                    return 0;
                return listProduct.Count; 
            } 
        }
        private const int NumberOfElements = 1000;
        public TestCollections()
        {
            Random random = new Random();
            listProduct = new LinkedList<Product>();
            listStr = new LinkedList<string>();
            dictionaryKeyGoods = new Dictionary<Goods, Product>();
            dictionaryKeyStr = new Dictionary<string, Product>();

            for (int i = 0; i < NumberOfElements; i++)
            {
                Product product = new Product();
                product.RandomInit();
                Add(product);
            }
        }
        public bool Add(Product product)
        {
            listProduct.AddLast(product);
            listStr.AddLast(product.ToString());
            dictionaryKeyGoods.Add(product.BaseGoods, product);
            dictionaryKeyStr.Add(product.BaseGoods.ToString(), product);
            return true;
        }

        public bool Delete(Product product)
        {
            bool isProductRemoved = listProduct.Remove(product);
            listStr.Remove(product.ToString());
            dictionaryKeyGoods.Remove(product.BaseGoods);
            dictionaryKeyStr.Remove(product.BaseGoods.ToString());
            return isProductRemoved;

        }
    }
}

