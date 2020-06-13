using System.Text;
using Microsoft.Extensions.Options;

namespace Common.Services
{
    public interface ISingletonService
    {
        string ChangeSettings();
    }

    public class SingletonService : ISingletonService
    {
        private readonly IOptions<TestGroupSettings> _testOptions;
        private readonly IOptionsSnapshot<TestGroupSettings> _testOptionsSnapshot;
        private readonly IOptionsMonitor<TestGroupSettings> _testOptionsMonitor;

        public SingletonService(IOptions<TestGroupSettings> testOptions, IOptionsSnapshot<TestGroupSettings> testOptionsSnapshot,
            IOptionsMonitor<TestGroupSettings> testOptionsMonitor)
        {
            _testOptions = testOptions;
            _testOptionsSnapshot = testOptionsSnapshot;
            _testOptionsMonitor = testOptionsMonitor;
        }

        public string ChangeSettings()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"SingletonService IOptions value: {_testOptions.Value.Test}");
            sb.AppendLine($"SingletonService IOptionsSnapshot value: {_testOptionsSnapshot.Value.Test}");
            sb.AppendLine($"SingletonService IOptionsMonitor value: {_testOptionsMonitor.CurrentValue.Test}");

            return sb.ToString();
        }
    }
}