using System.ComponentModel.DataAnnotations;

namespace Portal.Base.Entities;

public abstract class BaseEntity
{
    [Key]
    public long Id { get; set; }

    public DateTime? CreatedOn { get; private set; }
    public string? CreatedBy { get; private set; }

    public DateTime? DeletedOn { get; private set; }
    public string? DeletedBy { get; private set; }
    public bool IsDeleted { get; private set; } = false;

    public DateTime? UpdateOn { get; private set; }
    public string? UpdateBy { get; private set; }

    public void Create(string createdBy)
    {
        if(string.IsNullOrEmpty(createdBy))
            throw new ArgumentNullException(nameof(createdBy));
        CreatedBy = createdBy;
        CreatedOn = DateTime.Now;
    }

    public void Update(string updateBy)
    {
        if (string.IsNullOrEmpty(updateBy))
            throw new ArgumentNullException(nameof(updateBy));
        UpdateBy = updateBy;
        UpdateOn = DateTime.Now;
    }

    public void SoftDelete(string deletedBy)
    {
        if (string.IsNullOrEmpty(deletedBy))
            throw new ArgumentNullException(nameof(deletedBy));
        DeletedBy = deletedBy;
        DeletedOn = DateTime.Now;
        IsDeleted = true;
    }
}
