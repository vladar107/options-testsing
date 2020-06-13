using System.Text;
using Microsoft.Extensions.Options;

namespace Common.Services
{
    public interface IScopedService
    {
        string ChangeSettings();
    }

    public class ScopedService : IScopedService
    {
        private readonly IOptions<TestGroupSettings> _testOptions;
        private readonly IOptionsSnapshot<TestGroupSettings> _testOptionsSnapshot;
        private readonly IOptionsMonitor<TestGroupSettings> _testOptionsMonitor;

        public ScopedService(IOptions<TestGroupSettings> testOptions, IOptionsSnapshot<TestGroupSettings> testOptionsSnapshot,
            IOptionsMonitor<TestGroupSettings> testOptionsMonitor)
        {
            _testOptions = testOptions;
            _testOptionsSnapshot = testOptionsSnapshot;
            _testOptionsMonitor = testOptionsMonitor;
        }

        public string ChangeSettings()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"ScopedService IOptions value: {_testOptions.Value.Test}");
            sb.AppendLine($"ScopedService IOptionsSnapshot value: {_testOptionsSnapshot.Value.Test}");
            sb.AppendLine($"ScopedService IOptionsMonitor value: {_testOptionsMonitor.CurrentValue.Test}");

            return sb.ToString();
        }
    }
}