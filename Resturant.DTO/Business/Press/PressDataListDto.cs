namespace Resturant.DTO.Business.Press
{
    public class PressDataListDto
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? HyperLink { get; set; }
        public DateTime? CreatedOn { get; set; }
        // file info
        public string? AttachmentName { get; set; }
        public string? AttachmentPath { get; set; }
        public string? AttachmentExtension { get; set; }
    }
}
