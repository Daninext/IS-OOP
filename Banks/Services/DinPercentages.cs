using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Services
{
    public class DinPercentages
    {
        private List<(long, float)> _dinPer = new List<(long, float)>();

        public void AddPercent(int monValue, float percent)
        {
            for (int i = 0; i != _dinPer.Count; ++i)
            {
                if (_dinPer[i].Item1 == monValue)
                {
                    _dinPer[i] = (monValue, percent);
                    return;
                }
            }

            _dinPer.Add((monValue, percent));
            _dinPer.Sort();
        }

        public void DelPercent(int monValue)
        {
            for (int i = 0; i != _dinPer.Count; ++i)
            {
                if (_dinPer[i].Item1 == monValue)
                    _dinPer.RemoveAt(i);
            }
        }

        public float GetPercent(long monValue)
        {
            foreach ((int, float) el in _dinPer)
            {
                if (el.Item1 > monValue)
                    return el.Item2;
            }

            throw new PercentNotExistsBanksException("There isn`t same pers");
        }
    }
}
