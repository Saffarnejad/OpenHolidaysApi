namespace OpenHolidaysApi.Models
{
    public record Holiday
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public DateOnly Date { get; init; }
        public string Country { get; init; }
    }
}
