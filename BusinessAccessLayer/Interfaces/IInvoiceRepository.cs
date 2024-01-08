using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Interfaces
{
    public interface IInvoiceRepository:IGenericRepository<InvoiceDetail>
    {
        double GetTotalPrice(long InvoiceheaderId);
    }
}
