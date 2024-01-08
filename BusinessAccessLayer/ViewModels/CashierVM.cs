using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace BusinessAccessLayer.ViewModels
{
    public class CashierVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "CashierName is required")]
        [StringLength(200, ErrorMessage = "CashierName must be at most 200 characters")]
        public string CashierName { get; set; }
        [Required(ErrorMessage = "BranchID is required")]
        public int BranchID { get; set; }
        public Branch? Branch { get; set; }
        public List<Branch>? Branches { get; set; }
       // public List<SelectListItem> selectlist { get; set; }
        public ICollection<InvoiceHeader>? InvoiceHeaders { get; set; }
    }
}
