using OohelpWebApps.Presentations.Domain.Common.Enums;
using OohelpWebApps.Presentations.Domain.Data;
using System.Text;

namespace OohelpWebApps.Presentations.Mapping
{
    public static class DtoToViewMapper
    {
        const string ICON_OLD_DROP_BASE_LINK = @"https://www.gstatic.com/mapspro/images/stock/503-wht-blank_maps.png";
        const string ICON_OLD_CIRCLE_BASE_LINK = @"https://www.gstatic.com/mapspro/images/stock/959-wht-circle-blank.png";
        const string ICON_CIRCLE_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png&highlight=ff000000,{0}";
        const string ICON_DROP_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-pin-container-bg_4x.png,icons/onion/SHARED-mymaps-pin-container_4x.png,icons/onion/1899-blank-shape_pin_4x.png&highlight=ff000000,{0},ff000000";
        const string ICON_POINT_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-measle-container-bg_4x.png,icons/onion/SHARED-mymaps-measle-container_4x.png,icons/onion/1739-blank-measle_4x.png&highlight=ff000000,{0},ff000000";
        const string ICON_ROUNDED_BILLBOARD_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png,icons/onion/1612-japanese-post-office_4x.png&highlight=ff000000,{0},ff000000";
        const string ICON_ROUNDED_HOUSE_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png,icons/onion/1603-house_4x.png&highlight=ff000000,{0},ff000000";
        const string ICON_ARROW_PATH = "M -6,0 6,0 M 0,2 -2,6 0,4 2,6 Z ";
        public static Models.PresentationViewModel ToPresentationViewModel(this Domain.Data.PresentationDto dto)
        {
            return new Models.PresentationViewModel
            {
                Id = dto.Id,
                ClientName = dto.ClientName,
                Boards = dto.Boards.Select(a => a.ToBoardViewModel()).ToArray()
            };
        }
        public static Models.BoardViewModel ToBoardViewModel(this Domain.Data.BoardDto dto)
        {
            return new Models.BoardViewModel
            {
                Id = dto.Id,
                Address = dto.Address,
                City = dto.City,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                InfoHtml = GenerateHtmlInfo(dto),
                SupplierCode = dto.Code,
                TypeSize = dto.Type + ' ' + dto.Size,
                Icon = GenerateIcon(dto)
            };
        }

        private static object GenerateIcon(BoardDto dto)
        {
            return dto.IconStyle switch
            {
                IconStyle.OldDrop => CreateUri(dto.IconStyle, dto.IconColor),
                IconStyle.OldCircle => CreateUri(dto.IconStyle, dto.IconColor),
                IconStyle.Drop => CreateUri(dto.IconStyle, dto.IconColor),
                IconStyle.Circle => CreateUri(dto.IconStyle, dto.IconColor),
                IconStyle.Point => CreateUri(dto.IconStyle, dto.IconColor),
                IconStyle.Billboard => CreateUri(dto.IconStyle, dto.IconColor),
                IconStyle.House => CreateUri(dto.IconStyle, dto.IconColor),
                IconStyle.Arrow => new { path = ICON_ARROW_PATH, rotation = dto.Angle.GetValueOrDefault(), fillColor = HexToRgb(dto.IconColor), strokeColor = HexToRgb(dto.IconColor), scale = 2},
                _ => new { Icon = CreateUri(dto.IconStyle, dto.IconColor) },
            };
        }

        private static string GenerateHtmlInfo(Domain.Data.BoardDto dto)
        {
            StringBuilder sb = new StringBuilder("<div class=\"nosinf\"><strong>");
            sb.Append(dto.Code).Append(' ').Append(dto.Type).Append(' ').Append(dto.Size);
            if (dto.Ots.HasValue) sb.Append(" OTS = ").Append(dto.Ots.Value);
            sb.Append("<img src=\"").Append(dto.Photo).Append("\" width=\"490\" height=\"340\">");
            sb.Append("<br>").Append(dto.Address).Append("</strong><div>");
            return sb.ToString();
        }
        private static Uri CreateUri(this IconStyle style, string color)
        {            
            return style switch
            {
                IconStyle.Drop => new Uri(string.Format(ICON_DROP_BASE_LINK, color)),
                IconStyle.OldDrop => new Uri(ICON_OLD_DROP_BASE_LINK),
                IconStyle.Circle => new Uri(string.Format(ICON_CIRCLE_BASE_LINK, color)),
                IconStyle.OldCircle => new Uri(ICON_OLD_CIRCLE_BASE_LINK),
                IconStyle.Point => new Uri(string.Format(ICON_POINT_BASE_LINK, color)),
                IconStyle.Billboard => new Uri(string.Format(ICON_ROUNDED_BILLBOARD_BASE_LINK, color)),

                IconStyle.House => new Uri(string.Format(ICON_ROUNDED_HOUSE_BASE_LINK, color)),
                _ => throw new NotImplementedException(),
            };
        }
        private static string HexToRgb(string hexColor)
        {
            var rgb = Helpers.Colors.HexToColor(hexColor);
            return $"rgb({rgb.R}, {rgb.G}, {rgb.B})";
        }
    }
}
