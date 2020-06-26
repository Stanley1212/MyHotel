using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.ViewModel.Customer
{
    public class CustomerViewModel
    {
        public int CustomerID { get; set; }
        [Display(Name ="Nombres"), Required]
        public string Name { get; set; }
        [Display(Name ="Tipo de Documento")]
        public string DocumentType { get; set; }
        [Display(Name ="Numero de Documento"),Required]
        public string DocumentNumber { get; set; }
        [Display(Name = "Teléfono"),Phone]
        public string PhoneNumber { get; set; }
        [Display(Name = "Correo Electrónico"),EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Dirección")]
        public string Address { get; set; }
    }
}
