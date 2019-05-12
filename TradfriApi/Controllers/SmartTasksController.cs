using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradfriApi.Models;
using TradfriApi.Tradfri;

namespace TradfriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartTasksController : ControllerBase
    {
        public TradfriController _controller;

        public SmartTasksController(TradfriController controller)
        {
            _controller = controller;
        }

        [HttpGet]
        public async Task<List<ApiTradfriSmartTask>> GetAsync()
        {
            var smartTasks = await _controller.GatewayController.GetSmartTaskObjects();
            var lstApiTradfriSmartTask = new List<ApiTradfriSmartTask>();
            foreach(var sTask in smartTasks)
                lstApiTradfriSmartTask.Add(MapModel.Map(sTask));
            return lstApiTradfriSmartTask;
        }

        [HttpGet("{id}")]
        public async Task<ApiTradfriSmartTask> GetByIdAsync(long id)
        {
            var value = await _controller.SmartTasksController.GetTradfriSmartTask(id);
            return MapModel.Map(value);
        }
    }
}
