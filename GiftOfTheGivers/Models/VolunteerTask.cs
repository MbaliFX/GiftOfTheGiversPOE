namespace GiftOfTheGivers.Models
{
    public class VolunteerTask
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public string AssignedVolunteer { get; set; }
    }
}
