using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradfriApi.Models;
using TradfriApi.Tradfri;

namespace TradfriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodsController : ControllerBase
    {
        public TradfriController _controller;

        public MoodsController(TradfriController controller)
        {
            _controller = controller;
        }

        [HttpGet]
        public async Task<List<ApiTradfriMood>> GetAsync()
        {
            var moods = await _controller.GatewayController.GetMoods();
            var lstMoods = new List<ApiTradfriMood>();
            foreach(var mood in moods)
                lstMoods.Add(MapModel.Map(mood));
            return lstMoods;
        }
    }
}
