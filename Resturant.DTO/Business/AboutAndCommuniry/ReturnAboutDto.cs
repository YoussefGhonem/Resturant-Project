using Resturant.DTO.Business.Manue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.AboutAndCommuniry
{
    public class ReturnAboutDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public IEnumerable<ReturnTeamForAboutDto>? Teams { get; set; }
    }
}
