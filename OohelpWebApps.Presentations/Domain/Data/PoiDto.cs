using OohelpWebApps.Presentations.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OohelpWebApps.Presentations.Domain.Data
{
    public class PoiDto
    {
        public Guid Id { get; set; }


        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [MaxLength(6)]
        [Column(TypeName = "varchar(6)")]
        public string IconColor { get; set; }
        public IconStyle IconStyle { get; set; }


        public Guid PresentationId { get; set; }
        public PresentationDto Presentation { get; set; }
    }
}
