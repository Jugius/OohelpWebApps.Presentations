using OohelpWebApps.Presentations.Api.Contracts.Common;
using OohelpWebApps.Presentations.Domain.Authentication;
using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Api.Mappers
{
    public static class ContractDto
    {
        public static PresentationDto ToDto(this PresentationContract pr, User createdByUser)
        {            
            return new PresentationDto
            {
                Id = pr.Id.GetValueOrDefault(Guid.Empty),
                Name = pr.Name,
                Description = pr.Description,
                CreatedAt = pr.CreatedAt.GetValueOrDefault(DateTime.Now),
                OwnerId = createdByUser.Id,
                ShowOwner = pr.ShowOwnerInfo,
                Boards = pr.Boards?.Select(a => a.ToDto()).ToList() ?? new List<BoardDto>(),
            };
        }
        public static PresentationContract ToContract(this PresentationDto dto, User createdByUser)
        {
            return new PresentationContract
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = dto.CreatedAt,
                CreatedBy = createdByUser.Username,
                ShowOwnerInfo = dto.ShowOwner,
                Boards = dto.Boards == null || dto.Boards.Count == 0 ? null : dto.Boards.Select(a=>a.ToContract()).ToArray()
            };
        }
        public static BoardDto ToDto(this BoardContract br)
        {
            return new BoardDto
            {
                Id = br.Id.GetValueOrDefault(Guid.Empty),
                Address = br.Address,
                Angle = br.Angle,
                City = br.City,
                Code = br.Code,
                Condition = br.Condition,
                Description = br.Description,
                DoorsDix = br.DoorsDix,
                Grp = br.Grp,
                IconColor = br.IconColor,
                IconStyle = br.IconStyle,
                Latitude = br.Latitude,
                Longitude = br.Longitude,
                Lighting = br.Lighting,
                Ots = br.Ots,
                Photo = br.Photo,
                Price = br.Price,
                Region = br.Region,
                Side = br.Side,
                Size = br.Size,
                Supplier = br.Supplier,
                Type = br.Type,
                
                PresentationId = br.PresentationId.GetValueOrDefault(Guid.Empty),                
            };
        }
        public static BoardContract ToContract(this Domain.Data.BoardDto dto)
        {
            return new BoardContract
            {
                Id = dto.Id,
                Region = dto.Region,
                City = dto.City,
                Address = dto.Address,
                Code = dto.Code,
                Supplier = dto.Supplier,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Angle = dto.Angle,
                Condition = dto.Condition,
                Description = dto.Description,
                DoorsDix = dto.DoorsDix,
                Grp = dto.Grp,
                IconColor = dto.IconColor,
                IconStyle = dto.IconStyle,
                Lighting = dto.Lighting,
                Ots = dto.Ots,
                Photo = dto.Photo,
                Price = dto.Price,
                Side = dto.Side,
                Size = dto.Size,
                Type = dto.Type
            };
        }
    }
}
