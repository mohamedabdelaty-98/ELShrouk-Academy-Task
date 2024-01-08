using AutoMapper;
using BusinessAccessLayer.Interfaces;
using BusinessAccessLayer.Models;
using BusinessAccessLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELShrouk_Academy_Task.Controllers
{
    public class CashierController : Controller
    {
        private readonly IGenericRepository<Cashier> _Cashier;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Branch> _Bransh;

        public CashierController(IGenericRepository<Cashier> _Cashier,IMapper _mapper,
            IGenericRepository<Branch> _Bransh)
        {
            this._Cashier = _Cashier;
            this._mapper = _mapper;
            this._Bransh = _Bransh;
        }
        public IActionResult Index()
        {
            return View(_Cashier.GetAll());
        }
        public IActionResult Add()
        {
            List<Branch> branches = _Bransh.GetAll();
            CashierVM cashierVM = new CashierVM
            {
                Branches = _mapper.Map<List<Branch>>(branches),
            };
            return View(cashierVM);
        }
        [HttpPost]
        public IActionResult Add(CashierVM cashierVM)
        {
            if(ModelState.IsValid)
            {
                Cashier cashier = _mapper.Map<Cashier>(cashierVM);
                _Cashier.Insert(cashier);
                _Cashier.Save();
                return RedirectToAction(nameof(Index));
            }
           
            return View(cashierVM);
        }
        public IActionResult Update(int id)
        {
            
            List<Branch> branches = _Bransh.GetAll();
            Cashier cashier=_Cashier.GetById(id);
            CashierVM cashierVM = _mapper.Map<CashierVM>(cashier);
            cashierVM.Branches = _mapper.Map<List<Branch>>(branches);
            return View(cashierVM);
        }
        [HttpPost]
        public IActionResult Update(CashierVM cashierVM)
        {
            if(ModelState.IsValid)
            {
                Cashier cashier = _mapper.Map<Cashier>(cashierVM);
                _Cashier.Update(cashier);
                _Cashier.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cashierVM);
        }
        public IActionResult GetById(int id)
        {
            Cashier cashier = _Cashier.GetById(id);
            if(cashier == null)
                return NotFound();
            return View(cashier);
        }
        public IActionResult Delete(int id)
        {
            Cashier cashier = _Cashier.GetById(id);
            _Cashier.Delete(cashier);
            _Cashier.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}
