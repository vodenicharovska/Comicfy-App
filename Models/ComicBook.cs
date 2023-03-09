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
    public class ComicBook:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Слика")]
        public string Image { get; set; }
        [Display(Name = "Наслов")]
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Published { get; set; }
        public string Language { get; set; }
        public float Price { get; set; }
        public SellingCategory SellingCategory { get; set; }

        //Relationships
        public List<MCharacter_ComicBook> Characters_ComicBooks { get; set; }

        //Writer
        public int WriterId { get; set; }
        [ForeignKey("WriterId")]
        public Writer Writer { get; set; }

        //Penciler
        public int PencilerId { get; set; }
        [ForeignKey("PencilerId")]
        public Penciler Penciler { get; set; }

        //Cover Artist
        public int CoverArtistId { get; set; }
        [ForeignKey("CoverArtistId")]
        public CoverArtist CoverArtist { get; set; }
    }
}
