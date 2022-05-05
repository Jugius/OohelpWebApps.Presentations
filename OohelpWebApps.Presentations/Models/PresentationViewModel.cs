namespace OohelpWebApps.Presentations.Models
{
    public class PresentationViewModel
    {
        public ClientInfoViewModel ClientInfo { get; set; }
        public BoardViewModel[] Boards { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
