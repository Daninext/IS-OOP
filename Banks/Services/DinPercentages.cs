using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Services
{
    public class DinPercentages
    {
        private List<(float, float)> _dinPer = new List<(float, float)>();

        public void AddPercent(float moneyValue, float percent)
        {
            for (int i = 0; i != _dinPer.Count; ++i)
            {
                if (_dinPer[i].Item1 == moneyValue)
                {
                    _dinPer[i] = (moneyValue, percent);
                    return;
                }
            }

            _dinPer.Add((moneyValue, percent));
            _dinPer.Sort();
        }

        public void DelPercent(float moneyValue)
        {
            for (int i = 0; i != _dinPer.Count; ++i)
            {
                if (_dinPer[i].Item1 == moneyValue)
                    _dinPer.RemoveAt(i);
            }
        }

        public float GetPercent(float moneyValue)
        {
            foreach ((float, float) el in _dinPer)
            {
                if (el.Item1 > moneyValue)
                    return el.Item2;
            }

            throw new PercentNotExistsBanksException("There isn`t same pers");
        }
    }
}
