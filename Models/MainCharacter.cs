using Comicfy.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Models
{
    public class MainCharacter:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Слика")]
        [Required(ErrorMessage = "Мора да се прикачи слика на карактерот")]
        public string Picture { get; set; }
        [Display(Name = "Име")]
        [Required(ErrorMessage = "Мора се се прикачи име на карактерот")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името мора да е помеѓу 3 и 50 букви")]
        public string Name { get; set; }
        [Display(Name = "Кратка биографија")]
        [Required(ErrorMessage = "Мора се се прикачи кратка биографија за карактерот")]
        public string Bio { get; set; }

        //Relationships
        public List<MCharacter_ComicBook> Characters_ComicBooks { get; set; }
    }
}
