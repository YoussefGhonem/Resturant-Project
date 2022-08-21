using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.Settings
{
    public class PrivateDininCoverDto
    {
        public IFormFile? PrivateDiningCover { get; set; }
    }
    public class ManuCoverDto
    {
        public IFormFile? ManuCover { get; set; }
    }
    public class AboutCoverDto
    {
        public IFormFile? AboutCover { get; set; }
    }
}
