using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.Happining
{
    public class CreateAndUpdateHappiningDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<IFormFile>? Images { get; set; }
    }
}
