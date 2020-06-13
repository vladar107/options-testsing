using System.Text;
using System.Threading.Tasks;
using Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace SettingsTest
{
    [Route("settings")]
    public class SettingsController : Controller
    {
        private readonly ISingletonService _singletonService;
        private readonly IScopedService _scopedService;
        private readonly ITransientService _transientService;

        public SettingsController(ISingletonService singletonService, IScopedService scopedService,
            ITransientService transientService)
        {
            _singletonService = singletonService;
            _scopedService = scopedService;
            _transientService = transientService;
        }

        [HttpGet]
        public string Get()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine(_singletonService.ChangeSettings());
            sb.AppendLine(_scopedService.ChangeSettings());
            sb.AppendLine(_transientService.ChangeSettings());

            return sb.ToString();
        }
    }
}