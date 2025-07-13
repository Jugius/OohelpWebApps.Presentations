
namespace OohelpWebApps.Presentations.Domain.Common.Entities;
public abstract class BaseEntity : IEntity<int>
{
    public virtual int Id { get; set; }
}
