namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Игроки
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Игроки()
        {
            Достижения_игрока = new HashSet<Достижения_игрока>();
            Контракт_игрока_с_клубом = new HashSet<Контракт_игрока_с_клубом>();
        }

        [Key]
        [Column("ID персоны")]
        public Guid ID_персоны { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Достижения_игрока> Достижения_игрока { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Контракт_игрока_с_клубом> Контракт_игрока_с_клубом { get; set; }

        public virtual Персоны Персоны { get; set; }
    }
}
