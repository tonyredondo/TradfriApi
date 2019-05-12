using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradfriApi.Models;
using TradfriApi.Tradfri;

namespace TradfriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        public TradfriController _controller;

        public InfoController(TradfriController controller)
        {
            _controller = controller;
        }

        [HttpGet]
        public async Task<ApiGatewayInfo> GetAsync()
        {
            var info = await _controller.GatewayController.GetGatewayInfo();
            return MapModel.Map(info);
        }
    }
}
