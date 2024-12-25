using Microsoft.AspNetCore.Mvc;
using OpenHolidaysApi.Dtos;
using OpenHolidaysApi.Helpers;
using OpenHolidaysApi.Models;
using OpenHolidaysApi.Repositories;

namespace OpenHolidaysApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolidaysController : ControllerBase
    {
        private readonly ILogger<HolidaysController> _logger;
        private readonly IHolidaysRepository _holidaysRepository;

        public HolidaysController(ILogger<HolidaysController> logger, IHolidaysRepository holidaysRepository)
        {
            _logger = logger;
            _holidaysRepository = holidaysRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<HolidayDto>> GetHolidaysAsync()
        {
            var holidays =
                (await _holidaysRepository.GetHolidaysAsync())
                .Select(holiday => holiday.ToDto());

            return holidays;
        }

        [HttpGet]
        public async Task<IEnumerable<HolidayDto>> GetHolidaysAsync(string country)
        {
            var holidays =
                (await _holidaysRepository.GetHolidaysAsync(country))
                .Select(holiday => holiday.ToDto());

            return holidays;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolidayDto>> GetHolidayAsync(Guid id)
        {
            var holiday = await _holidaysRepository.GetHolidayAsync(id);

            if (holiday is null)
            {
                return NotFound();
            }

            return holiday.ToDto();
        }

        [HttpPost]
        public async Task<ActionResult<HolidayDto>> AddHolidayAsync(HolidayDto holidayDto)
        {
            Holiday holiday = new()
            {
                Id = Guid.NewGuid(),
                Title = holidayDto.Title,
                Date = holidayDto.Date,
                Country = holidayDto.Country
            };

            await _holidaysRepository.AddHolidayAsync(holiday);

            return CreatedAtAction(nameof(GetHolidayAsync), new { id = holiday.Id }, holiday.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateHolidayAsync(Guid id, UpdateHolidayDto holidayDto)
        {
            var holiday = await _holidaysRepository.GetHolidayAsync(id);

            if (holiday is null)
            {
                return NotFound();
            }
            Holiday updatedHoliday = holiday with
            {
                Title = holidayDto.Title,
                Date = holidayDto.Date,
                Country = holidayDto.Country
            };

            await _holidaysRepository.UpdateHolidayAsync(updatedHoliday);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHolidayAsync(Guid id)
        {
            var holiday = await _holidaysRepository.GetHolidayAsync(id);

            if (holiday is null)
            {
                return NotFound();
            }

            await _holidaysRepository.DeleteHolidayAsync(id);
            return NoContent();
        }
    }
}
