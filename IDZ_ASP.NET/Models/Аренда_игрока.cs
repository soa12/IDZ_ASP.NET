namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Аренда игрока")]
    public partial class Аренда_игрока
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Аренда_игрока()
        {
            Статистика_игрока = new HashSet<Статистика_игрока>();
        }

        [Key]
        [Column("ID аренды")]
        public Guid ID_аренды { get; set; }

        [Column("Дата начала", TypeName = "date")]
        public DateTime Дата_начала { get; set; }

        [Column("Дата окончания", TypeName = "date")]
        public DateTime Дата_окончания { get; set; }

        [Column("Номер на поле")]
        public int Номер_на_поле { get; set; }

        [Column("ID клуба")]
        public Guid ID_клуба { get; set; }

        [Column("ID контракта")]
        public Guid ID_контракта { get; set; }

        [Column("ID позиции")]
        public int ID_позиции { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Статистика_игрока> Статистика_игрока { get; set; }

        public virtual Клубы Клубы { get; set; }

        public virtual Контракт_игрока_с_клубом Контракт_игрока_с_клубом { get; set; }

        public virtual Позиции_игроков Позиции_игроков { get; set; }
    }
}
