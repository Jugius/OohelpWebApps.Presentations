
namespace OohelpWebApps.Presentations.Domain.Common.Entities;
public abstract class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
    public virtual DateTime Created { get; set; }

    public virtual Guid CreatedBy { get; set; }

    public virtual DateTime? LastModified { get; set; }

    public virtual Guid? LastModifiedBy { get; set; }
}

public interface IAuditableEntity
{
    DateTime Created { get; set; }

    Guid CreatedBy { get; set; }

    DateTime? LastModified { get; set; }

    Guid? LastModifiedBy { get; set; }
}
