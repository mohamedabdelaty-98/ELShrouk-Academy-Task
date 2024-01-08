using AutoMapper;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using BusinessAccessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ELShrouk_Academy_Task.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IGenericRepository<InvoiceHeader> _invoiceheader;
        private readonly IGenericRepository<Branch> _Branch;
        private readonly IGenericRepository<Cashier> _Cashier;
        private readonly IInvoiceRepository _invoice;
        private readonly IMapper _mapper;

        public InvoiceController(IGenericRepository<InvoiceHeader> _invoiceheader,
            IMapper _mapper,IInvoiceRepository _invoice,
            IGenericRepository<Branch> _Branch,IGenericRepository<Cashier> _Cashier)
        {
            this._invoiceheader = _invoiceheader;
            this._Branch = _Branch;
            this._Cashier = _Cashier;
            this._mapper = _mapper;
            this._invoice = _invoice;
        }
        public IActionResult Index()
        {
            List<InvoiceHeader> invoiceHeaders = _invoiceheader.GetAll();
            List<InvoiceHeadersVM> invoiceHeadersVM = new List<InvoiceHeadersVM>();
            foreach (var item in invoiceHeaders)
            {
                var invoiceHeaderVM = _mapper.Map<InvoiceHeadersVM>(item);
                invoiceHeaderVM.TotalPirce = _invoice.GetTotalPrice(item.ID);

                invoiceHeadersVM.Add(invoiceHeaderVM);
            }
            return View(invoiceHeadersVM);
        }
        public IActionResult Add()
        {
            List<Branch> branches = _Branch.GetAll();
            List<Cashier> cashier = _Cashier.GetAll();
            List<InvoiceDetail> invoiceDetails = _invoice.GetAll();
            InvoiceHeadersVM invoiceheadersVM = new InvoiceHeadersVM
            {
                Branches = _mapper.Map<List<Branch>>(branches),
                Cashieres = _mapper.Map<List<Cashier>>(cashier),
                InvoiceDetails = _mapper.Map<List<InvoiceDetail>>(invoiceDetails),
            };
            return View(invoiceheadersVM);

        }
        [HttpPost]
        public IActionResult Add(InvoiceHeadersVM headersVM)
        {
            if (ModelState.IsValid)
            {
                InvoiceHeader invoiceheader = _mapper.Map<InvoiceHeader>(headersVM);
                _invoiceheader.Insert(invoiceheader);
                foreach (var detail in invoiceheader.InvoiceDetails)
                {
                    detail.InvoiceHeaderID = invoiceheader.ID;
                    _invoice.Insert(detail);
                }
                _invoiceheader.Save();
                _invoice.Save();
                return RedirectToAction(nameof(Index));
            }
            var branches = _Branch.GetAll();
            var cashiers = _Cashier.GetAll();
            var invoiceDetails = _invoice.GetAll();

            headersVM.Branches = _mapper.Map<List<Branch>>(branches);
            headersVM.Cashieres = _mapper.Map<List<Cashier>>(cashiers);
            headersVM.InvoiceDetails = _mapper.Map<List<InvoiceDetail>>(invoiceDetails);
            return View(headersVM);
        }
    }
}
