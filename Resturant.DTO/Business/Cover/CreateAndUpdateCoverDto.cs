using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.Cover
{
    public class CreateAndUpdateCoverDto
    {
        public List<IFormFile>? Images { get; set; }
    }
}
