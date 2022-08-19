using Resturant.Data.DbModels.BusinessSchema.manue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.Manue
{
    public class manuetoreturnDto
    {
        public new Guid Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<categoryforreturnDto>? Categorys { get; set; }
    }
}
