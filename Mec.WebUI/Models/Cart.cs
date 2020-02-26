using Mec.WebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mec.WebUI.Models
{
    public class Cart
    {
        private List<CartLine> _cartlines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get{return _cartlines;}
        }
        public void AddProduct(Product product,int quantity)
        {
            var line = _cartlines.FirstOrDefault(x => x.Product.Id == product.Id);
            if (line==null)
            {
                _cartlines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduct(Product product)
        {
            _cartlines.RemoveAll(x => x.Product.Id == product.Id);

        }

        public double Total()
        {
            return _cartlines.Sum(x => x.Product.Price * x.Quantity);
        }

        public void Clear()
        {
            _cartlines.Clear();
        }
    }
    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}