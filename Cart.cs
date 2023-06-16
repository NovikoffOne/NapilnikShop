using System;
using System.Collections.Generic;

namespace NapilnikShop
{
    public class Cart
    {
        private List<Position> _goods = new List<Position>();
        private Warehouse _warehouse;

        public Cart(Warehouse warehouse)
        {
            _warehouse = warehouse;
        }

        public void Add(Good good, int count)
        {
            if(good != null && count > 0)
            {
                Position position = new Position(good, count);

                TryAdd(position);
            }
        }

        public string Order()
        {
            for (int i = 0; i < _goods.Count; i++)
            {
                _warehouse.TransferPositionToCart(_goods[i]);

                return $"Товар {_goods[i].Good.Name} в кол-во {_goods[i].Count} готов к оплате";
            }

            return $"Возникла ошибка, попробуйте позже";
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