using System;
using System.Collections.Generic;

namespace NapilnikShop
{
    public class Cart
    {
        private List<Position> _goods = new List<Position>();
        private Warehouse _warehouse;
        private Shop _shop;

        public Cart(Warehouse warehouse, Shop shop)
        {
            _warehouse = warehouse;
            _shop = shop;
        }

        public void Add(Good good, int count)
        {
            if(good != null && count > 0)
            {
                Position position = new Position(good, count);

                TryAdd(position);
            }
        }

        public Shop Order()
        {
            for (int i = 0; i < _goods.Count; i++)
            {
                _warehouse.TransferPositionToCart(_goods[i]);

                return _shop;
            }

            Console.WriteLine($"Возникла ошибка, попробуйте позже");

            return null;
        }

        public void ShowPosition()
        {
            foreach (var good in _goods)
            {
                Console.WriteLine($"{good.Good.Name}, {good.Count}");
            }
        }

        private void TryAdd(Position position)
        {
            if(_warehouse.CompareBalances(position) == true)
            {
                _goods.Add(position);
            }
        }
    }
}