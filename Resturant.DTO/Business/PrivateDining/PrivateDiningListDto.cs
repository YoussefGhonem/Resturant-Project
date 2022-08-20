namespace Resturant.DTO.Business.PrivateDining
{
    public class PrivateDiningListDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Company { get; set; }
        public DateTimeOffset EventDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public string NumberOfPeople { get; set; }
        public string AdditionalInformation { get; set; }
        public string Email { get; set; }
    }
}
