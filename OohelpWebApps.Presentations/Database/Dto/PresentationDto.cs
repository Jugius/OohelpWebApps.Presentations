using System.ComponentModel.DataAnnotations;


namespace OohelpWebApps.Presentations.Database.Dto
{
    public class PresentationDto
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        public bool ShowOwner { get; set; }

        public bool ColumnSupplier { get; set; }
        public bool ColumnSupplierCode { get; set; }

        public bool ColumnCity { get; set; }
        public bool ColumnAddress { get; set; }

        public bool ColumnTypeSize { get; set; }
        public bool ColumnGrp { get; set; }

        public bool ColumnPrice { get; set; }
        public bool ColumnCondition { get; set; }


        public bool CardType { get; set; }
        public bool CardSide { get; set; }
        public bool CardPrice { get; set; }
        public bool CardMedia { get; set; }
        public bool CardSupplier { get; set; }
        public bool CardCode { get; set; }

        public List<BoardDto> Boards { get; set; }
        public List<PoiDto> Pois { get; set; }
        
    }
}
