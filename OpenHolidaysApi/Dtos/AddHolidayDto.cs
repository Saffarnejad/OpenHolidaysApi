﻿using System.ComponentModel.DataAnnotations;

namespace OpenHolidaysApi.Dtos
{
    public record AddHolidayDto
    {
        [Required]
        public string Title { get; init; }

        [Required]
        public DateOnly Date { get; init; }

        [Required]
        public string Country { get; init; }
    }
}
