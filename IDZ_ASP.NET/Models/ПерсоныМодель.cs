namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ПерсоныМодель
    {
        public Guid ID_персоны { get; set; }

        [Required]
        [StringLength(50)]
        public string Фамилия { get; set; }

        [Required]
        [StringLength(50)]
        public string Имя { get; set; }

        [StringLength(50)]
        public string Отчество { get; set; }

        [DataType(DataType.Date)]
        public DateTime Дата_рождения { get; set; }


        public int Рост { get; set; }

        public decimal Вес { get; set; }

        public Guid? Гражданство { get; set; }

        public string Страна { get; set; }
    }
}
