using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapilnikShop
{
    public class Shop
    {
        private Warehouse _warehouse;
        private Cart _templateCart;

        public object Paylink => new Random().Next(100000000).ToString();

        public Shop(Warehouse warehouse) => _warehouse = warehouse;

        public Cart Cart()
        {
            _templateCart = new Cart(_warehouse, this);

            return _templateCart;
        }
    }
}
