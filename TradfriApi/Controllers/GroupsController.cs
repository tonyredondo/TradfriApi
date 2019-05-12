using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradfriApi.Models;
using TradfriApi.Tradfri;
using TradfriApi.Tradfri.Models;

namespace TradfriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        public TradfriController _controller;

        public GroupsController(TradfriController controller)
        {
            _controller = controller;
        }

        [HttpGet]
        public async Task<List<ApiTradfriGroup>> GetAsync()
        {
            var groupObject = await _controller.GatewayController.GetGroupObjects();
            var lstGroup = new List<ApiTradfriGroup>();
            foreach (var group in groupObject)
                lstGroup.Add(MapModel.Map(group));
            return lstGroup;
        }

        [HttpGet("{id}")]
        public async Task<ApiTradfriGroup> GetByIdAsync(long id)
        {
            var value = await _controller.GroupController.GetTradfriGroup(id);
            return MapModel.Map(value);
        }

        [HttpGet("{id}/dimmer/{value}")]
        public async Task<ApiTradfriGroup> SetDimmer(long id, int value)
        {
            await _controller.GroupController.SetDimmer(id, value);
            return await GetByIdAsync(id);
        }

        [HttpGet("{id}/on")]
        public async Task<ApiTradfriGroup> TurnOn(long id)
        {
            await _controller.GroupController.SetLight(id, true);
            return await GetByIdAsync(id);
        }

        [HttpGet("{id}/off")]
        public async Task<ApiTradfriGroup> TurnOff(long id)
        {
            await _controller.GroupController.SetLight(id, false);
            return await GetByIdAsync(id);
        }

        [HttpPost("{id}/mood")]
        public async Task<ApiTradfriGroup> SetMood(long id, [FromBody] ApiTradfriMood value)
        {
            if (value != null)
            {
                var mood = new TradfriMood
                {
                    CreatedAt = value.CreatedAt,
                    GroupID = value.GroupID,
                    ID = value.ID,
                    Name = value.Name,
                    The9057 = value.The9057,
                    The9068 = value.The9068,
                    MoodProperties = value.MoodProperties?.Select(m => new TradfriMoodProperties
                    {
                        ColorHex = m.ColorHex,
                        ColorHue = m.ColorHue,
                        ColorSaturation = m.ColorSaturation,
                        ColorX = m.ColorX,
                        ColorY = m.ColorY,
                        Dimmer = m.Dimmer,
                        ID = m.ID,
                        LightState = m.LightState,
                        Mireds = m.Mireds
                    }).ToArray()
                };
                await _controller.GroupController.SetMood(id, mood);
            }
            return await GetByIdAsync(id);
        }

    }
}
