using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
        }
        public EntityBase(Guid createdBy)
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            CreatedBy = createdBy;
        }
        public EntityBase(Guid? createdBy, string? createdByName, string? createdByEmail)
        {
            Id = Guid.NewGuid();
            CreatedOn = DateTime.UtcNow;
            CreatedBy = createdBy;
            CreatedByName = createdByName;
            CreatedByEmail = createdByEmail;
        }

        [Key]
        public Guid Id { get; set; }
        public Guid? CreatedBy { get; set; }
        public string? CreatedByName { get; set; }
        public string? CreatedByEmail { get; set; }
        public Guid? Tenant { get; set; }
        public DateTime CreatedOn { get; set; }
        public Guid? LastUpdatedBy { get; set; }
        public string? LastUpdatedByName { get; set; }
        public string? LastUpdatedByEmail { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
