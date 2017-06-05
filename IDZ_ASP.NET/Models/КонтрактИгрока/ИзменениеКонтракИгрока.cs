using System.Web.Mvc;

namespace IDZ_ASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ИзменениеКонтрактИгрока
    {
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

        public List<SelectListItem> СписокПозиций { get; set; }
        public List<SelectListItem> СписокКлубов { get; set; }
        public List<SelectListItem> СписокИгроков { get; set; }
    }
}
