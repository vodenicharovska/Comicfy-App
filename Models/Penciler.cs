using Comicfy.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Comicfy.Models
{
    public class Penciler:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Име")]
        [Required(ErrorMessage = "Мора се се прикачи име на писателот")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Името мора да е помеѓу 3 и 50 букви")]
        public string Name { get; set; }

        //Relationships
        public List<ComicBook> ComicBooks { get; set; }
    }
}
