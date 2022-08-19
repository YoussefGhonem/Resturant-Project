using Resturant.Data.DbModels.BusinessSchema.manue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.Manue
{
    public class CreateAndUpdateSubcategory
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? price { get; set; }
        public string? value { get; set; }
        public Guid? categoryId { get; set; }
    }
}
