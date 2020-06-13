using System.Text;
using Microsoft.Extensions.Options;

namespace Common.Services
{
    public interface ITransientService
    {
        string ChangeSettings();
    }

    public class TransientService : ITransientService
    {
        private readonly IOptions<TestGroupSettings> _testOptions;
        private readonly IOptionsSnapshot<TestGroupSettings> _testOptionsSnapshot;
        private readonly IOptionsMonitor<TestGroupSettings> _testOptionsMonitor;

        public TransientService(IOptions<TestGroupSettings> testOptions, IOptionsSnapshot<TestGroupSettings> testOptionsSnapshot,
            IOptionsMonitor<TestGroupSettings> testOptionsMonitor)
        {
            _testOptions = testOptions;
            _testOptionsSnapshot = testOptionsSnapshot;
            _testOptionsMonitor = testOptionsMonitor;
        }

        public string ChangeSettings()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"TransientService IOptions value: {_testOptions.Value.Test}");
            sb.AppendLine($"TransientService IOptionsSnapshot value: {_testOptionsSnapshot.Value.Test}");
            sb.AppendLine($"TransientService IOptionsMonitor value: {_testOptionsMonitor.CurrentValue.Test}");

            return sb.ToString();
        }
    }
}