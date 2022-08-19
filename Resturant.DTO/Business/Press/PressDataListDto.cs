using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.DTO.Business.Press
{
    public class PressDataListDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? HyperLink { get; set; }
        // file info
        public string? AttachmentName { get; set; }
        public string? AttachmentPath { get; set; }
        public string? AttachmentExtension { get; set; }
    }
}
