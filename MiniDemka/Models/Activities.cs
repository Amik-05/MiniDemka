namespace MiniDemka.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Activities
    {
        public int ID { get; set; }

        public string Activity { get; set; }

        public DateTime? DateStart { get; set; }

        public TimeSpan? TimeStart { get; set; }

        public int? Days { get; set; }

        public int? EventID { get; set; }

        public int? ModeratorID { get; set; }

        public int? JuryID { get; set; }

        public virtual Events Events { get; set; }

        public virtual Jury Jury { get; set; }

        public virtual Moderators Moderators { get; set; }
    }
}
