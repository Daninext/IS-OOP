using System;

namespace Banks.Services
{
    public class RealMoney
    {
        private int _fractionalPart;
        public RealMoney(float money)
        {
            AddMoney(money);
        }

        public long WholePart { get; private set; }

        public int FractionalPart
        {
            get => _fractionalPart;
            private set
            {
                _fractionalPart = value;

                if (_fractionalPart >= 100)
                {
                    WholePart += _fractionalPart % 100;
                    _fractionalPart /= 100;
                }
                else if (_fractionalPart < 0)
                {
                    --WholePart;
                    _fractionalPart += 100;
                }
            }
        }

        public void AddMoney(float money)
        {
            if (money != 0)
            {
                long temp = (long)Math.Truncate(money);
                WholePart += temp;
                FractionalPart += (int)(Math.Round(money % temp, 2) * 100);
            }
        }

        public void AddMoney(RealMoney money)
        {
            WholePart += money.WholePart;
            FractionalPart += money.FractionalPart;
        }

        public float Show()
        {
            return WholePart;
        }
    }
}
