using System.Text.Json.Serialization;

namespace OohelpWebApps.Presentations.ModelViews;

public class BoardViewModel
{
    public Guid Id { get; set; }

    [JsonIgnore]
    public string SupplierCode { get; set; }

    [JsonIgnore]
    public string Supplier { get; set; }

    [JsonIgnore]
    public string City { get; set; }

    public string Address { get; set; }

    [JsonIgnore]
    public string TypeSize { get; set; }

    [JsonIgnore]
    public decimal? Grp { get; set; }

    [JsonIgnore]
    public decimal? Price { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public object Icon { get; set; }
    public string InfoHtml { get; init; }

    public string CheckBoxId() => "chcode" + Id.ToString();


}
