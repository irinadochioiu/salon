namespace proiect_maria
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Servicii")]
    public partial class Servicii
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicii()
        {
            Programari = new HashSet<Programari>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string Denumire { get; set; }

        [StringLength(50)]
        public string Durata { get; set; }

        [StringLength(50)]
        public string NumeAng { get; set; }

        public int? Pret { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Data { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Programari> Programari { get; set; }
    }
}
