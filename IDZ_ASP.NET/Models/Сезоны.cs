namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Сезоны
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Сезоны()
        {
            Достижения_игрока = new HashSet<Достижения_игрока>();
            Чемпионат_в_сезоне = new HashSet<Чемпионат_в_сезоне>();
        }

        [Key]
        [Column("ID сезона")]
        public Guid ID_сезона { get; set; }

        [Column("Начало сезона", TypeName = "date")]
        public DateTime Начало_сезона { get; set; }

        [Column("Конец сезона", TypeName = "date")]
        public DateTime Конец_сезона { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Достижения_игрока> Достижения_игрока { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Чемпионат_в_сезоне> Чемпионат_в_сезоне { get; set; }
    }
}
