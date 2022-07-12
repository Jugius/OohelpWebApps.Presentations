namespace OohelpWebApps.Presentations.ApiClient.Entities.Common;

public class Presentation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool ShowOwnerInfo { get; set; }
    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; init; }


    public bool ColumnSupplier { get; set; }
    public bool ColumnSupplierCode { get; set; }

    public bool ColumnCity { get; set; }
    public bool ColumnAddress { get; set; }

    public bool ColumnTypeSize { get; set; }
    public bool ColumnGrp { get; set; }

    public bool ColumnPrice { get; set; }
    public bool ColumnCondition { get; set; }


    public bool CardType { get; set; } = true;
    public bool CardSide { get; set; } = true;
    public bool CardPrice { get; set; }
    public bool CardMedia { get; set; } = true;
    public bool CardSupplier { get; set; }
    public bool CardCode { get; set; }

    public Board[] Boards { get; set; }
    public Poi[] Pois { get; set; }

}
