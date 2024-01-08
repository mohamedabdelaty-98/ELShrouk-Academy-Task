using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.ViewModels
{
    public class InvoiceDetailsVM
    {
        public long ID { get; set; }

        public long InvoiceHeaderID { get; set; }
        public string ItemName { get; set; }

        public double ItemCount { get; set; }

        public double ItemPrice { get; set; }

        public InvoiceHeadersVM InvoiceHeader { get; set; }
    }
}
