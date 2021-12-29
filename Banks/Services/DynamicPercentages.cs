using System.Collections.Generic;
using Banks.Tools;

namespace Banks.Services
{
    public class DynamicPercentages
    {
        private List<(float, float)> _dynamicPercentages = new List<(float, float)>();

        public void AddPercent(float moneyValue, float percent)
        {
            for (int i = 0; i != _dynamicPercentages.Count; ++i)
            {
                if (_dynamicPercentages[i].Item1 == moneyValue)
                {
                    _dynamicPercentages[i] = (moneyValue, percent);
                    return;
                }
            }

            _dynamicPercentages.Add((moneyValue, percent));
            _dynamicPercentages.Sort();
        }

        public void DelPercent(float moneyValue)
        {
            for (int i = 0; i != _dynamicPercentages.Count; ++i)
            {
                if (_dynamicPercentages[i].Item1 == moneyValue)
                    _dynamicPercentages.RemoveAt(i);
            }
        }

        public float GetPercent(float moneyValue)
        {
            foreach ((float, float) el in _dynamicPercentages)
            {
                if (el.Item1 > moneyValue)
                    return el.Item2;
            }

            throw new PercentNotExistsBanksException("There isn`t same percentages");
        }
    }
}
