namespace OohelpWebApps.Presentations.Models
{
    public class PresentationViewModel
    {
        public string ClientName { get; set; }
        public Guid Id { get; set; }
        public BoardViewModel[] Boards { get; set; }
                
    }

}
