namespace OohelpWebApps.Presentations.ModelViews
{
    public class PresentationViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool ColumnSupplier { get; set; }
        public bool ColumnSupplierCode { get; set; }

        public bool ColumnCity { get; set; }
        public bool ColumnAddress { get; set; }

        public bool ColumnTypeSize { get; set; }
        public bool ColumnGrp { get; set; }

        public bool ColumnPrice { get; set; }
        public bool ColumnCondition { get; set; }

        public ClientInfoViewModel ClientInfo { get; set; }
        public BoardViewModel[] Boards { get; set; }

        public string GoogleMapApiKey { get; set; }
    }

}
