namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Контракт игрока с клубом")]
    public partial class Контракт_игрока_с_клубом
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Контракт_игрока_с_клубом()
        {
            Аренда_игрока = new HashSet<Аренда_игрока>();
            Статистика_игрока = new HashSet<Статистика_игрока>();
        }

        [Key]
        [Column("ID контракта")]
        public Guid ID_контракта { get; set; }

        //[NotMapped]
        [DataType(DataType.Date)]
        [Column("Дата начала", TypeName = "date")]
        public DateTime Дата_начала { get; set; }

        [DataType(DataType.Date)]
        [Column("Дата окончания", TypeName = "date")]
        public DateTime Дата_окончания { get; set; }

        [Column("Номер на поле")]
        public int Номер_на_поле { get; set; }

        [Column("ID персоны")]
        public Guid ID_персоны { get; set; }
        //public string Игрок { get; set; }

        [Column("ID клуба")]
        public Guid ID_клуба { get; set; }

        [Column("ID позиции")]
        public int ID_позиции { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Аренда_игрока> Аренда_игрока { get; set; }

        public virtual Игроки Игроки { get; set; }

        public virtual Клубы Клубы { get; set; }

        public virtual Позиции_игроков Позиции_игроков { get; set; }

        public virtual Персоны Персоны { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Статистика_игрока> Статистика_игрока { get; set; }
    }
}
