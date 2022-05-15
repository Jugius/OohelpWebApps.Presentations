using System.ComponentModel.DataAnnotations;


namespace OohelpWebApps.Presentations.Domain.Data
{
    public class PresentationDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public bool ShowOwner { get; set; }        

        public List<BoardDto> Boards { get; set; }
        public List<PoiDto> Pois { get; set; }
    }
}
