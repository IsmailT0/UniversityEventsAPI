namespace UniversityEventsAPI.Models
{
    public class UpdateUniversityEventRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string Location { get; set; }
    }
}
