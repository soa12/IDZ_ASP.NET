namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Контракт тренера с клубом")]
    public partial class Контракт_тренера_с_клубом
    {
        [Key]
        [Column("ID контракта")]
        public Guid ID_контракта { get; set; }

        [Column("Дата начала", TypeName = "date")]
        public DateTime Дата_начала { get; set; }

        [Column("Дата окончания", TypeName = "date")]
        public DateTime Дата_окончания { get; set; }

        [Column("ID клуба")]
        public Guid ID_клуба { get; set; }

        [Column("ID персоны")]
        public Guid ID_персоны { get; set; }

        public virtual Клубы Клубы { get; set; }

        public virtual Тренеры Тренеры { get; set; }
    }
}
