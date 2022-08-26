using Resturant.Core.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Resturant.Data.DbModels.BusinessSchema
{
    [Table("SiteLocations", Schema = "Business")]
    public class SiteLocation : BaseEntity
    {
        public Guid Id { get; set; }
        public string Adress { get; set; }
        public string WorkDays { get; set; }
        public string GoogleMapLink { get; set; }
    }
}
