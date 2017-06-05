namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Чемпионат в сезоне")]
    public partial class Чемпионат_в_сезоне
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Чемпионат_в_сезоне()
        {
            Достижения_клуба = new HashSet<Достижения_клуба>();
            Статистика_игрока = new HashSet<Статистика_игрока>();
        }

        [Key]
        [Column("ID чемпионата в сезоне")]
        public Guid ID_чемпионата_в_сезоне { get; set; }

        [Column("ID чемпионата")]
        public Guid ID_чемпионата { get; set; }

        [Column("ID сезона")]
        public Guid ID_сезона { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Достижения_клуба> Достижения_клуба { get; set; }

        public virtual Сезоны Сезоны { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Статистика_игрока> Статистика_игрока { get; set; }

        public virtual Чемпионат Чемпионат { get; set; }
    }
}
