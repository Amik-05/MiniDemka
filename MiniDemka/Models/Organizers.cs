namespace MiniDemka.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Organizers
    {
        public int ID { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Patronymic { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        public string Email { get; set; }

        public DateTime? Birthday { get; set; }

        public int? Country { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }

        public string Photo { get; set; }

        public virtual Country Country1 { get; set; }

        public virtual Gender Gender1 { get; set; }
    }
}
