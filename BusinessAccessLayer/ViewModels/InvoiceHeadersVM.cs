using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.ViewModels
{
    public class InvoiceHeadersVM
    {
        public long ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? Invoicedate { get; set; }

        public int? CashierID { get; set; }

        public int? BranchID { get; set; }
        public double? TotalPirce { get; set; }

        public Branch? Branch { get; set; }

        public Cashier? Cashier { get; set; }
        
        public List<InvoiceDetail>? InvoiceDetails { get; set; } = new List<InvoiceDetail>();
        public List<Branch>? Branches { get; set; }
        public List<Cashier>? Cashieres { get; set; }
    }
}
