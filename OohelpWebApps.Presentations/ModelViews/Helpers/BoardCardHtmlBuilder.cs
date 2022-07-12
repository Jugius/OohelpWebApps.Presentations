using OohelpWebApps.Presentations.Domain;
using System.Text;


namespace OohelpWebApps.Presentations.ModelViews.Helpers;
public class BoardCardHtmlBuilder
{
    public bool CardTypeSize { get; set; }
    public bool CardSide { get; set; }
    public bool CardPrice { get; set; }
    public bool CardMedia { get; set; }
    public bool CardSupplier { get; set; }
    public bool CardCode { get; set; }


    public string BuildHtmlCard(Board dto)
    {
        StringBuilder sb = new StringBuilder("<div class=\"informWindow\"><strong>");

        if (CardCode && !string.IsNullOrEmpty(dto.Code))
            sb.Append(dto.Code).Append(' ');

        if(CardTypeSize)        
            sb.Append(dto.Type).Append(' ').Append(dto.Size).Append(' ');
        
        if (CardMedia && dto.Ots.HasValue)
            sb.Append("OTS = ").Append(dto.Ots.Value);
        
        sb.Append("<img src=\"").Append(dto.Photo).Append('"');//.Append("\" width=\"490\" height=\"340\">");
        
        sb.Append("<br>").Append(dto.Address);

        if(CardSupplier && !string.IsNullOrEmpty(dto.Supplier))
            sb.Append("<br>").Append(dto.Supplier);
        
        sb.Append("</strong><div>");

        return sb.ToString();
    }
    public static BoardCardHtmlBuilder Create(Presentation pr) =>
        new BoardCardHtmlBuilder
        {
            CardSupplier = pr.CardSupplier,
            CardCode = pr.CardCode,
            CardTypeSize = pr.CardType,
            CardSide = pr.CardSide,
            CardPrice = pr.CardPrice,
            CardMedia = pr.CardMedia
        };

    
    
}
