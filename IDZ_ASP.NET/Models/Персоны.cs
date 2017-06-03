using System.Net.Cache;

namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Персоны
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Персоны()
        {
            Государство = new HashSet<Государство>();
        }

        [Key]
        [Column("ID персоны")]
        public Guid ID_персоны { get; set; }

        [Required]
        [StringLength(50)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(50)]
        public string Имя { get; set; }

        [StringLength(50)]
        public string Отчество { get; set; }

        [Required]
        [Column("Дата рождения", TypeName = "date")]
        public DateTime Дата_рождения { get; set; }

        [Required]
        public int Рост { get; set; }

        [Required]
        public decimal Вес { get; set; }

        [Required]
        public virtual Игроки Игроки { get; set; }

        [Required]
        public virtual Тренеры Тренеры { get; set; }

        [Required]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Государство> Государство { get; set; }
    }
}
