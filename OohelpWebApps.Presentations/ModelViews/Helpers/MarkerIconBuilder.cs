using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Common.Enums;


namespace OohelpWebApps.Presentations.ModelViews.Helpers;
public class MarkerIconBuilder
{
    const string ICON_OLD_DROP_BASE_LINK = @"https://www.gstatic.com/mapspro/images/stock/503-wht-blank_maps.png";
    const string ICON_CIRCLE_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png&highlight=ff000000,{0}";
    const string ICON_DROP_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-pin-container-bg_4x.png,icons/onion/SHARED-mymaps-pin-container_4x.png,icons/onion/1899-blank-shape_pin_4x.png&highlight=ff000000,{0},ff000000";
    const string ICON_POINT_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-measle-container-bg_4x.png,icons/onion/SHARED-mymaps-measle-container_4x.png,icons/onion/1739-blank-measle_4x.png&highlight=ff000000,{0},ff000000";
    const string ICON_ROUNDED_BILLBOARD_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png,icons/onion/1612-japanese-post-office_4x.png&highlight=ff000000,{0},ff000000";
    const string ICON_ROUNDED_HOUSE_BASE_LINK = @"https://mt.google.com/vt/icon/name=icons/onion/SHARED-mymaps-container-bg_4x.png,icons/onion/SHARED-mymaps-container_4x.png,icons/onion/1603-house_4x.png&highlight=ff000000,{0},ff000000";
    const string ICON_ARROW_PATH = "M -6,0 6,0 M 0,2 -2,6 0,4 2,6 Z ";


    public static object BuildIcon(Board dto) => dto.IconStyle switch
    {
        IconStyle.OldCircle => new 
        {
            path = 0, 
            fillColor = ColorsConverter.HexToRgb(dto.IconColor), 
            fillOpacity = 1,
            strokeWeight = 1,
            strokeOpacity = 0.7,
            scale = 6 
        },

        IconStyle.Arrow => new
        {
            path = ICON_ARROW_PATH, 
            rotation = dto.Angle.GetValueOrDefault(),
            fillColor = ColorsConverter.HexToRgb(dto.IconColor),
            strokeColor = ColorsConverter.HexToRgb(dto.IconColor),
            scale = 2
        },

        _ => CreateUri(dto.IconStyle, dto.IconColor)
    };

    private static Uri CreateUri(IconStyle style, string color) => style switch
    {
        IconStyle.Drop => new Uri(string.Format(ICON_DROP_BASE_LINK, color)),
        IconStyle.OldDrop => new Uri(ICON_OLD_DROP_BASE_LINK),
        IconStyle.Circle => new Uri(string.Format(ICON_CIRCLE_BASE_LINK, color)),
        IconStyle.Point => new Uri(string.Format(ICON_POINT_BASE_LINK, color)),
        IconStyle.Billboard => new Uri(string.Format(ICON_ROUNDED_BILLBOARD_BASE_LINK, color)),

        IconStyle.House => new Uri(string.Format(ICON_ROUNDED_HOUSE_BASE_LINK, color)),
        _ => throw new NotImplementedException(),
    };
}
