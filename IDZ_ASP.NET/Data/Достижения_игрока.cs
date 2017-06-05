namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Достижения игрока")]
    public partial class Достижения_игрока
    {
        [Key]
        [Column("ID достижения", Order = 0)]
        public Guid ID_достижения { get; set; }

        [Required]
        [StringLength(50)]
        public string Название { get; set; }

        [Column("ID сезона")]
        public Guid ID_сезона { get; set; }

        [Key]
        [Column("ID персоны", Order = 1)]
        public Guid ID_персоны { get; set; }

        public virtual Игроки Игроки { get; set; }

        public virtual Сезоны Сезоны { get; set; }
    }
}
