using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductApp.Entities
{
    [Table("Employee")]
    public class EmployeeModel
    {
        [Key]
        [Display(Name = "Id")]
        public int EmpId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
    }
}
