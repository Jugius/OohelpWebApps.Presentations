namespace OohelpWebApps.Presentations.Models
{
    public class PresentationViewModel
    {
        public ClientInfoViewModel ClientInfo { get; set; }
        public BoardViewModel[] Boards { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool ColumnPrice { get; set; }
        public bool ColumnSupplier { get; set; }
        public bool ColumnGrp { get; set; }
        public bool ColumnCondition { get; set; }
    }

}
