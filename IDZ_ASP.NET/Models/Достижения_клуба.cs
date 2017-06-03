namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Достижения клуба")]
    public partial class Достижения_клуба
    {
        [Key]
        [Column("ID достижения", Order = 0)]
        public Guid ID_достижения { get; set; }

        [Required]
        [StringLength(50)]
        public string Наименование { get; set; }

        [Column("ID чемпионата в сезоне")]
        public Guid ID_чемпионата_в_сезоне { get; set; }

        [Key]
        [Column("ID клуба", Order = 1)]
        public Guid ID_клуба { get; set; }

        public virtual Клубы Клубы { get; set; }

        public virtual Чемпионат_в_сезоне Чемпионат_в_сезоне { get; set; }
    }
}
