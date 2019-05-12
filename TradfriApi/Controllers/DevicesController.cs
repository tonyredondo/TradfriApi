using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradfriApi.Models;
using TradfriApi.Tradfri;

namespace TradfriApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        public TradfriController _controller;

        public DevicesController(TradfriController controller)
        {
            _controller = controller;
        }

        [HttpGet]
        public async Task<List<ApiTradfriDevice>> GetAsync()
        {
            var devicesObject = await _controller.GatewayController.GetDeviceObjects();
            var lstDevices = new List<ApiTradfriDevice>();
            foreach (var device in devicesObject)
                lstDevices.Add(MapModel.Map(device));
            return lstDevices;
        }

        [HttpGet("{id}")]
        public async Task<ApiTradfriDevice> GetByIdAsync(long id)
        {
            var value = await _controller.DeviceController.GetTradfriDevice(id);
            return MapModel.Map(value);
        }

        [HttpGet("{id}/color/{value}")]
        public async Task<ApiTradfriDevice> SetColor(long id, string value)
        {
            await _controller.DeviceController.SetColor(id, value);
            return await GetByIdAsync(id);
        }

        [HttpGet("{id}/dimmer/{value}")]
        public async Task<ApiTradfriDevice> SetDimmer(long id, int value)
        {
            await _controller.DeviceController.SetDimmer(id, value);
            return await GetByIdAsync(id);
        }

        [HttpGet("{id}/on")]
        public async Task<ApiTradfriDevice> TurnOn(long id)
        {
            await _controller.DeviceController.SetLight(id, true);
            return await GetByIdAsync(id);
        }

        [HttpGet("{id}/off")]
        public async Task<ApiTradfriDevice> TurnOff(long id)
        {
            await _controller.DeviceController.SetLight(id, false);
            return await GetByIdAsync(id);
        }
    }
}
