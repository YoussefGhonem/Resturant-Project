using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.AboutAndCommuniry
{
    public class CreateAndUpdateCommunity
    {
        public string? name { get; set; }
        public string? Desciption { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
