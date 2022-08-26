using OohelpWebApps.Presentations.Domain;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.ModelViews;

namespace OohelpWebApps.Presentations.Mapping
{
    public static class DomainToModelView
    {
        public static PresentationViewModel ToViewModel(this Presentation pr)
        {
            var htmlBuilder = ModelViews.Helpers.BoardCardHtmlBuilder.Create(pr);
            var viewModel = new PresentationViewModel
            {
                Name = pr.Name,
                Description = pr.Description,

                ColumnGrp = pr.ColumnGrp,
                ColumnPrice = pr.ColumnPrice,
                ColumnSupplier = pr.ColumnSupplier,
                ColumnCondition = pr.ColumnCondition,
                ColumnAddress = pr.ColumnAddress,
                ColumnCity = pr.ColumnCity,
                ColumnSupplierCode = pr.ColumnSupplierCode,
                ColumnTypeSize = pr.ColumnTypeSize,

                Boards = pr.Boards.Select(a => a.ToViewModel(htmlBuilder)).ToArray(),
                Pois = pr.Pois.Select(a => a.ToViewModel()).ToArray(),

                ClientInfo = pr.ShowOwnerInfo ? pr.Owner.ToViewModel() : null,
            };
            return viewModel;
        }
        public static BoardViewModel ToViewModel(this Board dto, ModelViews.Helpers.BoardCardHtmlBuilder htmlBuilder) =>
            new BoardViewModel
            {
                Id = dto.Id,
                Address = dto.Address,
                City = dto.City,
                Grp = dto.Grp,
                Price = dto.Price,
                Supplier = dto.Supplier,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                InfoHtml = htmlBuilder.BuildHtmlCard(dto),
                SupplierCode = dto.Code,
                TypeSize = dto.Type + ' ' + dto.Size,
                Icon = ModelViews.Helpers.MarkerIconBuilder.BuildIcon(dto)
            };

        public static ClientInfoViewModel ToViewModel(this User user) =>
            new ClientInfoViewModel
            {
                Name = user.Company?.Name ?? user.Username,
                Logo = user.Company == null ? null : (user.Company.Id + ".png"),
                Site = user.Company?.SiteUri ?? null
            };

        public static PoiViewModel ToViewModel(this Poi poi) =>
            new PoiViewModel
            {
                Address = poi.Name,
                Description = poi.Description,
                Latitude = poi.Latitude,
                Longitude = poi.Longitude,
                Icon = ModelViews.Helpers.MarkerIconBuilder.BuildIcon(poi)
            };
    }
}