namespace UniversityEventsAPI.Models
{
    public class AddUniversityEventRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }
    }
}
