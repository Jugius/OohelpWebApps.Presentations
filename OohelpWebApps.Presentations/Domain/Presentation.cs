﻿
using OohelpWebApps.Presentations.Domain.Authentication;

namespace OohelpWebApps.Presentations.Domain;

public class Presentation
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }    
    public bool ShowOwnerInfo { get; set; }
    public DateTime CreatedAt { get; set; }

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
    
    public List<Board> Boards { get; set; }
    public List<Poi> Pois { get; set; }
    public User Owner { get; set; }

}
