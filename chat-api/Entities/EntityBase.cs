using System.ComponentModel.DataAnnotations;

namespace ChatApi.Entities
{
    public abstract class EntityBase
    {
        [MinLength(36), MaxLength(36)]
        public Guid Id { get; set; }
        public DateTime RecordCreated { get; set; } = DateTime.Now;
        [MaxLength(128)]
        public string RecordCreatedBy { get; set; }
        public DateTime RecordUpdated { get; set; }
        [MaxLength(128)]
        public string RecordUpdatedBy { get; set; }

        public void Created(string recordBy)
        {
            Id = Guid.NewGuid();
            RecordUpdated = DateTime.Now;
            RecordCreatedBy = recordBy;
            RecordUpdatedBy = recordBy;
        }

        public void Updated(string recordBy)
        {
            RecordUpdated = DateTime.Now;
            RecordUpdatedBy = recordBy;
        }
    }
}
