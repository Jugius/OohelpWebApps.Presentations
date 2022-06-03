using OohelpWebApps.Presentations.Domain.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OohelpWebApps.Presentations.Domain.Data;

public class BoardDto
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(64)]
    public string Supplier { get; set; }        
    
    [MaxLength(32)]
    public string Code { get; set; }

    [Required]
    [MaxLength(32)]
    public string Region { get; set; }

    [Required]
    [MaxLength(64)]
    public string City { get; set; }

    [Required]
    [MaxLength(256)]
    public string Address { get; set; }

    [Required]
    [MaxLength(1)]
    [Column(TypeName = "varchar(1)")]
    public char Side { get; set; }

    [Required]
    [MaxLength(16)]
    public string Size { get; set; }

    [Required]
    [MaxLength(24)]
    public string Type { get; set; }

    public bool Lighting { get; set; }

    public decimal? Price { get; set; }

    [Required]
    public double Latitude { get; set; }

    [Required]
    public double Longitude { get; set; }

    public int? Angle { get; set; }

    public int? DoorsDix { get; set; }

    public int? Ots { get; set; }

    public decimal? Grp { get; set; }

    public string Photo { get; set; }    
    public BoardCondition Condition { get; set; }

    [MaxLength(256)]
    public string? Description { get; set; }

    [MaxLength(6)]
    [Column(TypeName = "varchar(6)")]
    public string IconColor { get; set; }
    public IconStyle IconStyle { get; set; }


    public Guid PresentationId { get; set; }
    public PresentationDto Presentation { get; set; }
}
