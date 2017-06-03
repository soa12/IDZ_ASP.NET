namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Чемпионат
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Чемпионат()
        {
            Чемпионат_в_сезоне = new HashSet<Чемпионат_в_сезоне>();
        }

        [Key]
        [Column("ID чемпионата")]
        public Guid ID_чемпионата { get; set; }

        [Required]
        [StringLength(100)]
        public string Название { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Чемпионат_в_сезоне> Чемпионат_в_сезоне { get; set; }
    }
}
