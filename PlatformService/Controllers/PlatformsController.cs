using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using PlatformService.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace PlatformsController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepository;
        private readonly IMapper _mapper;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformsController(
            IPlatformRepo repository,
            IMapper mapper,
            ICommandDataClient commandDataClient)
        {
            _platformRepository = repository;
            _mapper = mapper;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformReadDto>> GetAllPlatforms()
        {
            Console.WriteLine("--> Getting Platforms from PlatformService");

            var platformItem = _platformRepository.GetAllPlatforms();

            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItem));
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(int id)
        {
            var platformItem = _platformRepository.GetPlatformById(id);

            if (platformItem == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<PlatformReadDto>(platformItem));
        }

        [HttpPost]
        public async Task<ActionResult<PlatformReadDto>> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
                var platformModel = _mapper.Map<Platform>(platformCreateDto);
                 _platformRepository.CreatePlatform(platformModel);
                 _platformRepository.SaveChanges();
                
                var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);

                try
                {
                    await _commandDataClient.SendPlatformToCommand(platformReadDto);
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
                }

                return CreatedAtRoute(nameof(GetPlatformById), new {Id = platformReadDto.Id}, platformReadDto);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutPlatform(int id, Platform platform)
        // {
        //     if (id != platform.Id)
        //     {
        //         return BadRequest();
        //     }

        //     await _platformRepository.UpdatePlatform(platform);

        //     return NoContent();
        // }

        // [HttpPost]
        // public async Task<ActionResult<Platform>> PostPlatform(Platform platform)
        // {
        //     await _platformRepository.AddPlatform(platform);

        //     return CreatedAtAction("GetPlatform", new { id = platform.Id }, platform);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeletePlatform(int id)
        // {
        //     var platform = await _platformRepository.GetPlatform(id);
        //     if (platform == null)
        //     {
        //         return NotFound();
        //     }

        //     await _platformRepository.DeletePlatform(platform);

        //     return NoContent();
        // }
    }
}