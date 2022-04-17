namespace IncidentManager.Shared
{
    using System.ComponentModel.DataAnnotations;

    public class ProgramBranch
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name has to be 3-50 characters long", MinimumLength =3)]
        public string Name { get; set; }
        public string Abr { get; set; }

    }
}
