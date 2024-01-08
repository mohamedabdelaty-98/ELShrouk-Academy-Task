using AutoMapper;
using BusinessAccessLayer.Models;
using BusinessAccessLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.AutoMapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BranchVM, Branch>();
            CreateMap<Branch, BranchVM>();

            CreateMap<Cashier, CashierVM>();
            CreateMap<CashierVM, Cashier>();
            
            CreateMap<InvoiceHeader, InvoiceHeadersVM>();
            CreateMap<InvoiceHeadersVM, InvoiceHeader>();

  
        }
    }
}
