namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class КонтрактИгрокаМодель
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        /*
        public Контракт_игрока_с_клубом()
        {
            Аренда_игрока = new HashSet<Аренда_игрока>();
            Статистика_игрока = new HashSet<Статистика_игрока>();
        }*/

        public Guid ID_контракта { get; set; }

        public Guid ID_игрока { get; set; }


        public Guid ID_персоны { get; set; }
        public string Игрок { get; set; }

        public Guid ID_клуба { get; set; }
        public string Клуб { get; set; }

        public int ID_позиции { get; set; }
        public string Позиция { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата начала")]
        public DateTime Дата_начала { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата окончания")]
        public DateTime Дата_окончания { get; set; }

        [Display(Name = "Номер на поле")]
        public int Номер_на_поле { get; set; }

        
        


        

        /*//[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Аренда_игрока> Аренда_игрока { get; set; }

        public virtual Игроки Игроки { get; set; }

        public virtual Клубы Клубы { get; set; }

        public virtual Позиции_игроков Позиции_игроков { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Статистика_игрока> Статистика_игрока { get; set; }*/
    }
}
