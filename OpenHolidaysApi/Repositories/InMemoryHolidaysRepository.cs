using OpenHolidaysApi.Models;

namespace OpenHolidaysApi.Repositories
{
    public class InMemoryHolidaysRepository : IHolidaysRepository
    {
        private readonly List<Holiday> _holidays =
        [
            new() { Title = "Iranian New Year's Day", Date = new DateOnly(2021, 3, 21), Country = "IR" },
            new() { Title = "Islamic Republic Day", Date = new DateOnly(2021, 4, 1), Country = "IR" },
            new() { Title = "Nature's Day", Date = new DateOnly(2021, 4, 2), Country = "IR" },
            new() { Title = "New Year's Day", Date = new DateOnly(2021, 1, 1), Country = "US" },
            new() { Title = "Independence Day", Date = new DateOnly(2021, 7, 4), Country = "US" },
            new() { Title = "Christmas Day", Date = new DateOnly(2021, 12, 25), Country = "US" }
        ];

        public async Task AddHolidayAsync(Holiday holiday)
        {
            _holidays.Add(holiday);
            await Task.CompletedTask;
        }

        public async Task DeleteHolidayAsync(Guid id)
        {
            var index = _holidays.FindIndex(h => h.Id == id);
            _holidays.RemoveAt(index);
            await Task.CompletedTask;
        }

        public async Task<Holiday> GetHolidayAsync(Guid id)
        {
            var holiday = _holidays.SingleOrDefault(h => h.Id == id);
            return await Task.FromResult(holiday);
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync()
        {
            return await Task.FromResult(_holidays);
        }

        public async Task<IEnumerable<Holiday>> GetHolidaysAsync(string country)
        {
            var holidays = _holidays.Where(h => h.Country.Equals(country, StringComparison.CurrentCultureIgnoreCase));
            return await Task.FromResult(holidays);

        }

        public async Task UpdateHolidayAsync(Holiday holiday)
        {
            var index = _holidays.FindIndex(h => h.Id == holiday.Id);
            _holidays[index] = holiday;
            await Task.CompletedTask;
        }
    }
}
