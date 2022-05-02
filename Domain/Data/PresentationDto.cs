using System.ComponentModel.DataAnnotations;


namespace OohelpWebApps.Presentations.Domain.Data
{
    public class PresentationDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }


        [MaxLength(32)]
        public string ClientName { get; set; }

        public bool ShowLogo { get; set; }


        [MaxLength(256)]
        public string Description { get; set; }

        public List<BoardDto> Boards { get; set; }
    }
}
