using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.ViewModels
{
    public class BranchVM
    {
        public int ID { get; set; }
        public string BranchName { get; set; }
        public int CityID { get; set; }

        public City City { get; set; }

        public ICollection<Cashier> Cashiers { get; set; } = new List<Cashier>();

        public ICollection<InvoiceHeader> InvoiceHeaders { get; set; } = new List<InvoiceHeader>();
    }
}
