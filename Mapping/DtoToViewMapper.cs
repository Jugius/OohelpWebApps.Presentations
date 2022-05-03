using System.Text;

namespace OohelpWebApps.Presentations.Mapping
{
    public static class DtoToViewMapper
    {
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
                Side = dto.Side,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                InfoHtml = GenerateHtmlInfo(dto),
                SupplierCode = dto.Code,
                TypeSize = dto.Type + ' ' + dto.Size
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
    }
}
