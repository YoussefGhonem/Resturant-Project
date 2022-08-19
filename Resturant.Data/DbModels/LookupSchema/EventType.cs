using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resturant.Data.DbModels.LookupSchema
{
    [Table("EventTypes", Schema = "Lookup")]
    public class EventType : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

    }
}
