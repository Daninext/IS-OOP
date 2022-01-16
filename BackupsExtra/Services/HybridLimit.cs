using System.Collections.Generic;
using Backups.Services;

namespace BackupsExtra.Services
{
    public class HybridLimit : IClearLimit
    {
        private List<IClearLimit> _limits = new List<IClearLimit>();
        private ILimitStrategy _strategy = new HybridAnyLimitStrategy();

        public HybridLimit(IClearLimit limit, params IClearLimit[] limits)
        {
            _limits.Add(limit);
            _limits.AddRange(limits);
        }

        public IReadOnlyList<IClearLimit> Limits => _limits;

        public IReadOnlyList<RestorePoint> ChooseToClear(BackupJob job)
        {
            return _strategy.Choose(_limits, job);
        }

        public void SwitchMode(ILimitStrategy newStrategy)
        {
            _strategy = newStrategy;
        }
    }
}
