namespace OpenHolidaysApi.Dtos
{
    public record HolidayDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public DateOnly Date { get; init; }
        public string Country { get; init; }
    }
}
