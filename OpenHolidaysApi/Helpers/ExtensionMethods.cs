using OpenHolidaysApi.Dtos;
using OpenHolidaysApi.Models;

namespace OpenHolidaysApi.Helpers
{
    public static class ExtensionMethods
    {
        public static HolidayDto ToDto(this Holiday holiday)
        {
            return new HolidayDto
            {
                Id = holiday.Id,
                Title = holiday.Title,
                Date = holiday.Date,
                Country = holiday.Country
            };
        }
    }
}
