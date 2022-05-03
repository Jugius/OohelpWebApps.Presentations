using System.Text;
using System.Text.Json.Serialization;

namespace OohelpWebApps.Presentations.Models
{
    public class BoardViewModel
    {
        public Guid Id { get; set; }

        public string SupplierCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string TypeSize { get; set; }
        public char Side { get; set; }
        //public string Size { get; set; }
        //public string Type { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        //[JsonIgnore]
        //public int? DoorsDix { get; set; }

        //[JsonIgnore]
        //public int? Ots { get; set; }

        //[JsonIgnore]
        //public decimal? Grp { get; set; }


        //[JsonIgnore]
        //public string Photo { get; set; }

        public string InfoHtml { get; init; }
        public string IconLink => ICON_ROUNDED_BILLBOARD_BASE_LINK + "eb17c4";
        const string ICON_CIRCLE_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png&highlight=ff000000,";
        const string ICON_ROUNDED_BILLBOARD_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png,icons/onion/1612-japanese-post-office_4x.png&highlight=ff000000,";


        public string CheckBoxId() => "chcode" + this.Id.ToString();
        

    }
}
