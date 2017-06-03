namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Статистика игрока")]
    public partial class Статистика_игрока
    {
        [Key]
        [Column("ID контракта", Order = 0)]
        public Guid ID_контракта { get; set; }

        [Key]
        [Column("ID чемпионата в сезоне", Order = 1)]
        public Guid ID_чемпионата_в_сезоне { get; set; }

        [Column("Кол-во игр")]
        public int Кол_во_игр { get; set; }

        [Column("Кол-во голов")]
        public int Кол_во_голов { get; set; }

        [Column("ID аренды")]
        public Guid? ID_аренды { get; set; }

        public virtual Аренда_игрока Аренда_игрока { get; set; }

        public virtual Контракт_игрока_с_клубом Контракт_игрока_с_клубом { get; set; }

        public virtual Чемпионат_в_сезоне Чемпионат_в_сезоне { get; set; }
    }
}
