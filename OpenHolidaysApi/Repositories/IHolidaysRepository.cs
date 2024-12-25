using OpenHolidaysApi.Models;

namespace OpenHolidaysApi.Repositories
{
    public interface IHolidaysRepository
    {
        Task AddHolidayAsync(Holiday holiday);
        Task DeleteHolidayAsync(Guid id);
        Task<Holiday> GetHolidayAsync(Guid id);
        Task<IEnumerable<Holiday>> GetHolidaysAsync();
        Task<IEnumerable<Holiday>> GetHolidaysAsync(string country);
        Task UpdateHolidayAsync(Holiday holiday);

    }
}