namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Клубы
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Клубы()
        {
            Аренда_игрока = new HashSet<Аренда_игрока>();
            Достижения_клуба = new HashSet<Достижения_клуба>();
            Контракт_игрока_с_клубом = new HashSet<Контракт_игрока_с_клубом>();
            Контракт_тренера_с_клубом = new HashSet<Контракт_тренера_с_клубом>();
        }

        [Key]
        [Column("ID клуба")]
        public Guid ID_клуба { get; set; }

        [Required]
        [StringLength(50)]
        public string Название { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Аренда_игрока> Аренда_игрока { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Достижения_клуба> Достижения_клуба { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Контракт_игрока_с_клубом> Контракт_игрока_с_клубом { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Контракт_тренера_с_клубом> Контракт_тренера_с_клубом { get; set; }
    }
}
