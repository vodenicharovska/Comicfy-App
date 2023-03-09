using Comicfy.Data;
using Comicfy.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Models
{
    public class NewComicBookVM
    {
        public int Id { get; set; }
        [Display(Name = "Слика")]
        [Required(ErrorMessage ="Мора да внесете слика на стрипот")]
        public string Image { get; set; }
        [Display(Name = "Наслов")]
        [Required(ErrorMessage = "Мора да внесете наслов на стрипот")]
        public string Title { get; set; }
        [Display(Name = "Краток опис")]
        [Required(ErrorMessage = "Мора да внесете краток опис на стрипот")]
        public string ShortDescription { get; set; }
        [Display(Name = "Објавен на")]
        [Required(ErrorMessage = "Мора да внесете кога е објавен стрипот")]
        public string Published { get; set; }
        [Display(Name = "Јазик")]
        [Required(ErrorMessage = "Мора да внесете јазик на кој е напишан стрипот")]
        public string Language { get; set; }
        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Мора да внесете цена на стрипот")]
        public float Price { get; set; }
        [Display(Name = "Категорија на продажба")]
        [Required(ErrorMessage = "Мора да внесете катеогорија на продажна на стрипот")]
        public SellingCategory SellingCategory { get; set; }

        //Relationships
        [Display(Name = "Главни карактери")]
        [Required(ErrorMessage = "Мора да одберете главни карактери на стрипот")]
        public List<int> CharacterIds { get; set; }
        [Display(Name = "Писател")]
        [Required(ErrorMessage = "Мора да одберете писател на стрипот")]
        public int WriterId { get; set; }
        [Display(Name = "Илустратор")]
        [Required(ErrorMessage = "Мора да одберете илустратор на стрипот")]
        public int PencilerId { get; set; }
        [Display(Name = "Сликар на корица")]
        [Required(ErrorMessage = "Мора да одберете сликар на корица на стрипот")]
        public int CoverArtistId { get; set; }
    }
}
