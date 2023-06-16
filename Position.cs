using System.Xml.Serialization;

namespace NapilnikShop
{
    public class Position
    {
        private Good _good;
        private int _goodCount;

        public int Count => _goodCount;
        public Good Good => _good;

        public Position (Good good, int count)
        {
            _good = good;
            _goodCount = count;
        }

        public void AddCountGood(int count)
        {
            if(count > 0)
            {
                _goodCount += count;
            }
        }

        public void DeleteCountGood(int count)
        {
            if(count > 0)
            {
                _goodCount -= count;
            }
        }
    }
}