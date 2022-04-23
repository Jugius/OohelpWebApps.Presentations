using System.Text;
using System.Text.Json.Serialization;

namespace OohelpWebApps.Presentations.Models
{
    public class BoardModel
    {
        public Guid Id { get; set; }


        [JsonIgnore]
        public string Supplier { get; set; }
        public string SupplierCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public string Side { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public bool Lighting { get; set; }
        public decimal Price { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [JsonIgnore]
        public int? Angle { get; set; }

        [JsonIgnore]
        public int? DoorsDix { get; set; }

        [JsonIgnore]
        public int? Ots { get; set; }

        [JsonIgnore]
        public decimal? Grp { get; set; }

        [JsonIgnore]
        public string Photo { get; set; }


        public string InfoHtml {
            get {
                StringBuilder sb = new StringBuilder("<div class=\"nosinf\"><strong>");
                sb.Append(this.SupplierCode).Append(' ').Append(this.TypeSize());
                if(this.Ots.HasValue) sb.Append(" OTS = ").Append(this.Ots.Value);
                sb.Append("<img src=\"").Append(this.Photo).Append("\" width=\"490\" height=\"340\">");
                sb.Append("<br>").Append(this.Address).Append("</strong><div>");
                return sb.ToString();
            }
        }
        public string IconLink => ICON_CIRCLE_BASE_LINK + "eb17c4";
        const string ICON_CIRCLE_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png&highlight=ff000000,";


        public string RowId() => this.Id.ToString();
        public string CheckBoxId() => "chcode" + this.Id.ToString();
        public string TypeSize() => this.Type + " " + this.Size;
    }
}
