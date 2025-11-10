using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Model
{
    public class BookModel
    {
        public int Id { get; set; } // Auto-generated ID

        [Required(ErrorMessage = "Title is required")]
        [StringLength(200)]
        public string Title { get; set; }


        [Required(ErrorMessage = "Author is required")]
        [StringLength(150)]
        public string Author { get; set; }


        [Required(ErrorMessage = "ISBN is required")]
        [StringLength(20)]
        public string ISBN { get; set; }

        [Range(1, 3000, ErrorMessage = "Enter a valid publication year")]
        public int PublicationYear { get; set; }

        public bool Active { get; set; } = true;
    }
}
