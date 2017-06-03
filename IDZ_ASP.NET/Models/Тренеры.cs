namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Тренеры
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Тренеры()
        {
            Контракт_тренера_с_клубом = new HashSet<Контракт_тренера_с_клубом>();
        }

        [Key]
        [Column("ID персоны")]
        public Guid ID_персоны { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Контракт_тренера_с_клубом> Контракт_тренера_с_клубом { get; set; }

        public virtual Персоны Персоны { get; set; }
    }
}
