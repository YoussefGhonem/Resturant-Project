using Microsoft.AspNetCore.Http;
using Resturant.Data.DbModels.BusinessSchema.About;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.AboutAndCommuniry
{
    public class CreateAndUpdateTeams
    {
        public string? Name { get; set; }
        public string? JopTitle { get; set; }
        public string? Description { get; set; }
        public List<IFormFile>? Images { get; set; }
        //public Guid? AboutId { get; set; }
    }
}
