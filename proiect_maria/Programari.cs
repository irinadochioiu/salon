namespace proiect_maria
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Programari")]
    public partial class Programari
    {
        public int Id { get; set; }

        public int? ClientId { get; set; }

        public int? ServId { get; set; }

        public virtual Clienti Clienti { get; set; }

        public virtual Servicii Servicii { get; set; }
    }
}
