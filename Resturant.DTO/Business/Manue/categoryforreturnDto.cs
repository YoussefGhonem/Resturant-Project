using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.Manue
{
    public class categoryforreturnDto
    {
        public string? Name { get; set; }
        public Guid? manueId { get; set; }
        public IEnumerable<SubcategoryforreturnDto>? Subcategory { get; set; }
    }
}
