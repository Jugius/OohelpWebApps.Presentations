
using OohelpWebApps.Presentations.Domain.Common.Entities;

namespace OohelpWebApps.Presentations.Domain.Entities;
public class PresentationDesignBoardsListingColumns : BaseEntity
{
    public bool Supplier { get; set; }
    public bool SupplierCode { get; set; }

    public bool City { get; set; }
    public bool Address { get; set; }

    public bool TypeSize { get; set; }
    public bool Grp { get; set; }

    public bool Price { get; set; }
    public bool Condition { get; set; }
}
