namespace IncidentManager.Shared
{
    using System.ComponentModel.DataAnnotations;

    public class Profile
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "I'm sure your first name isn't THAT long!")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "I'm sure your last name isn't THAT long!")]
        public string LastName { get; set; }
        public string ProgramBranchName { get; set; }
        public string Role { get; set; }
        public string Location { get; set; }
        public string LogonSite { get; set; }
        public string Language { get; set; }
        public bool RemoteWork { get; set; }

    }
}
