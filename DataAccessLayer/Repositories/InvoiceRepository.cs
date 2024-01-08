using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class InvoiceRepository : GenericRepository<InvoiceDetail>,IInvoiceRepository
    {
        private readonly ShaTaskContext _context;

        public InvoiceRepository(ShaTaskContext _context) : base(_context)
        {
            this._context = _context;
        }

        public double GetTotalPrice(long InvoiceheaderId)
        {
            return _context.InvoiceDetails
                   .Where(detail => detail.InvoiceHeaderID == InvoiceheaderId)
                   .Sum(detail => detail.ItemCount * detail.ItemPrice);
        }
    }
}
