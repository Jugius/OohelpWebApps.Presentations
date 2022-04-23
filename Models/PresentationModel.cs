namespace OohelpWebApps.Presentations.Models
{
    public class PresentationModel
    {
        public string ClientName { get; set; }
        public Guid Id { get; set; }
        public BoardModel[] Boards { get; set; }

        internal static PresentationModel Default =>
            new PresentationModel {
            ClientName = "Ad Strategy",
            Id = Guid.NewGuid(),
            Boards = InitializeBoards()
            };

        private static BoardModel[] InitializeBoards() => new BoardModel[]
        {
            new BoardModel {
                Id = Guid.NewGuid(),
                Supplier = "РТМ", SupplierCode ="M06TA0751B",
                City ="Житомир", Address ="Трасса M-06, Киев-Житомир, 75,100",
                Type = "Арка", Size = "3x18", Side = "А",
                Latitude =50.3895462639, Longitude =29.4901639223, Angle = 75,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/0d01c3b4-18c7-4800-900c-ee61e215b28c.jpg"
            },
            new BoardModel {
                Id= Guid.NewGuid(),
                Supplier = "РТМ", SupplierCode ="M03TA0456B",
                City ="Борисполь", Address ="Трасса M-03, Киев - Харьков, 45,650",
                Type = "Арка", Size = "3x18", Side = "А",
                Latitude =50.3172779486, Longitude =31.0401856899, Angle = 290,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/ae9d515f-bd0b-429f-bb53-4b857bfbdc78.jpg"
            },
            new BoardModel {
                Id= Guid.NewGuid(),
                Supplier = "РТМ", SupplierCode ="M05TA0768A",
                City ="Белая Церковь", Address ="Трасса M-05, Киев-Одесса, 76,800",
                Type = "Арка", Size = "3x18", Side = "А",
                Latitude =49.8607770802, Longitude =30.1644122601, Angle = 200,
                Photo = @"https://photoreports.com.ua/photo/pictures/a040d310-3621-45ac-b72d-840c9134f3ad/c5251675-fda1-4916-92fd-7b52acfa579b.jpg"
            }
        };
    }

}
