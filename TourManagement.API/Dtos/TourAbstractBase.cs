using System;
using System.ComponentModel.DataAnnotations;

namespace TourManagement.API.Dtos
{
    public abstract class TourAbstractBase
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required.")]
        [MaxLength(200, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }

        [MaxLength(2000, ErrorMessage = "Description is too long.")]
        public virtual string Description { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The start date is required.")]
        public DateTimeOffset StartDate { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The end date is required.")]
        public DateTimeOffset EndDate { get; set; }
    }
}
