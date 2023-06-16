using System;
using System.Collections.Generic;

namespace NapilnikShop
{
    public class Warehouse
    {
        private List<Position> _positions = new List<Position>();

        public void Delive(Good good, int count)
        {
            TryAdd(new Position(good, count));
        }

        public void OutputRemnants()
        {
            foreach (var position in _positions)
            {
                Console.WriteLine($"{position.Good.Name}, {position.Count}");
            }
        }

        public bool CompareBalances(Position position)
        {
            Position tempPosition = CheckForMatches(position);

            if (tempPosition != null && tempPosition.Count >= position.Count)
            {
                return true;
            }
            else if (tempPosition != null && tempPosition.Count < position.Count)
            {
                Console.WriteLine("На складе недостаточно товара");
                return false;
            }

            return false;
        }

        public void TransferPositionToCart(Position position)
        {
            if (CheckForMatches(position) != null)
                CheckForMatches(position).DeleteCountGood(position.Count);
        }

        private void TryAdd(Position position)
        {
            if (position.Count > 0 && CheckForMatches(position) == null)
            {
                _positions.Add(position);
            }
            else if (position.Count > 0 && CheckForMatches(position) != null)
            {
                CheckForMatches(position).AddCountGood(position.Count);
            }
        }

        private Position CheckForMatches(Position position)
        {
            foreach (var tempPosition in _positions)
            {
                if (tempPosition.Good.Name == position.Good.Name)
                {
                    return tempPosition;
                }
            }

            return null;
        }
    }
}