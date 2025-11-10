using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class CustomerModel
    {
    

        public int CustomerID { get; set; }
        [Required(ErrorMessage = "Customer Name is required")]
        [StringLength(255)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Customer Email is required")]
        [StringLength(255)]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; } = true;
    }
}
