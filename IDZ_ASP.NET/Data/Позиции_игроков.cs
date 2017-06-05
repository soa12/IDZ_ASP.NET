namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Позиции игроков")]
    public partial class Позиции_игроков
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Позиции_игроков()
        {
            Аренда_игрока = new HashSet<Аренда_игрока>();
            Контракт_игрока_с_клубом = new HashSet<Контракт_игрока_с_клубом>();
        }

        [Key]
        [Column("ID позиции")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_позиции { get; set; }

        [Required]
        [StringLength(50)]
        public string Название { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Аренда_игрока> Аренда_игрока { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Контракт_игрока_с_клубом> Контракт_игрока_с_клубом { get; set; }
    }
}
