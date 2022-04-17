namespace IncidentManager.Shared
{
    using System.ComponentModel.DataAnnotations;

    public class Incident
    {

        // meta
        public string importance { get; set; }
        public string Status { get; set; }
        public int Id { get; set; }


        // Who / Where
        public Profile Profile { get; set; } = new Profile();

        // What
        public string Application { get; set; }
        public string Description { get; set; }

        // When
        public string DateStarted { get; set; }
        public string DataEnded { get; set; }

    }
}
