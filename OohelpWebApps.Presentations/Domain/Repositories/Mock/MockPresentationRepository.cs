using OohelpWebApps.Presentations.Domain.Data;

namespace OohelpWebApps.Presentations.Domain.Repositories.Mock
{
    public class MockPresentationRepository : Interfaces.IPresentationRepository
    {
        public IQueryable<PresentationDto> Presentations => throw new NotImplementedException();

        public Task<bool> CreateAsync(PresentationDto presentation)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PresentationDto>> GetAllAsync(Guid ownerId)
        {
            var presa = await GetAsync(Guid.NewGuid());
            presa.Owner = ownerId;
            return new [] { presa };
        }

        public Task<PresentationDto> GetAsync(Guid id)
        {
            var presa = new PresentationDto
            {
                Id = id,
                Boards = InitializeBoards().ToList(),
                Description = "Май-июль 2022, Арки на трассах",
                Name = "Большие форматы на весну!",
                Owner = Guid.NewGuid(),
                ShowOwner = true
            };
            return Task.FromResult(presa);
        }

        public Task<bool> UpdateAsync(PresentationDto presentation)
        {
            throw new NotImplementedException();
        }
        private static BoardDto[] InitializeBoards() => new BoardDto[]
        {
            new BoardDto {
                Id = Guid.NewGuid(),
                Supplier = "РТМ", Code ="M06TA0751B",
                Region = "Житомирская",
                City ="Житомир", Address ="Трасса M-06, Киев-Житомир, 75,100",
                Type = "Арка", Size = "3x18", Side = 'A',
                Latitude =50.3895462639, Longitude =29.4901639223, Angle = 75,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/0d01c3b4-18c7-4800-900c-ee61e215b28c.jpg",
                Condition = Common.Enums.BoardCondition.Free,
                IconStyle = Common.Enums.IconStyle.Billboard,
                IconColor = "eb17c4",
                Price = 20000,
            },
            new BoardDto {
                Id= Guid.NewGuid(),
                Supplier = "РТМ", Code ="M03TA0456B",
                Region = "Киевская",
                City ="Борисполь", Address ="Трасса M-03, Киев - Харьков, 45,650",
                Type = "Арка", Size = "3x18", Side = 'A',
                Latitude =50.3172779486, Longitude =31.0401856899, Angle = 290,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/ae9d515f-bd0b-429f-bb53-4b857bfbdc78.jpg",
                Condition = Common.Enums.BoardCondition.Free,
                IconStyle = Common.Enums.IconStyle.House,
                IconColor = "33eb17",
                Price = 20000,
            },
            new BoardDto {
                Id= Guid.NewGuid(),
                Supplier = "РТМ", Code ="M05TA0768A",
                Region = "Киевская",
                City ="Белая Церковь", Address ="Трасса M-05, Киев-Одесса, 76,800",
                Type = "Арка", Size = "3x18", Side = 'A',
                Latitude =49.8607770802, Longitude =30.1644122601, Angle = 200,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/c5251675-fda1-4916-92fd-7b52acfa579b.jpg",
                Condition = Common.Enums.BoardCondition.Free,
                IconStyle = Common.Enums.IconStyle.Arrow,
                IconColor = "f50521",
                Price = 20000,
            }
        };
    }
}
