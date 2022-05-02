namespace OohelpWebApps.Presentations.Models
{
    public class PresentationModel
    {
        public string ClientName { get; set; }
        public Guid Id { get; set; }
        public BoardModel[] Boards { get; set; }
                
    }

}
