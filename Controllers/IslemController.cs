using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crud.Models;
using Newtonsoft.Json;

namespace crud.Controllers
{
    public class IslemController : Controller
    {
        private readonly IslemDbModel _context;
        
        //List<BankName> BankIsımler = JsonConvert.DeserializeObject<BankName>(jsonData);
        public List<string> ReturnBankName()
        {
            List<string> bankalar = new List<string>();

            using (StreamReader R = new StreamReader("C:\\Users\\ahmet\\OneDrive\\Masaüstü\\Projeler\\Asp.net core\\Asp.netCore6.0\\crud\\Datas\\BankaIsımleri.json"))
            {
                string jsonFile = R.ReadToEnd();
                bankalar  = JsonConvert.DeserializeObject<List<string>>(jsonFile);
            }
            return bankalar;


        }
        public IslemController(IslemDbModel context)
        {
            _context = context;
        }

        // GET: Islem
        public async Task<IActionResult> Index()
        {
           

            return _context.Islemler != null ? 
                          View(await _context.Islemler.ToListAsync()) :
                          Problem("Entity set 'IslemDbModel.Islemler'  is null.");
        }

        // GET: Islem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Islemler == null)
            {
                return NotFound();
            }

            var islem = await _context.Islemler
                .FirstOrDefaultAsync(m => m.islemId == id);
            if (islem == null)
            {
                return NotFound();
            }

            return View(islem);
        }

        // GET: Islem/Create
        public IActionResult Create()
        {
            var a = ReturnBankName();
            ViewBag.bankaIsımleri = a;
            return View();
        }

        // POST: Islem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("islemId,HesapNumarasi,AliciIsim,BankaIsim,SwiftCode,Miktar,Tarih")] Islem islem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(islem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(islem);
        }

        // GET: Islem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Islemler == null)
            {
                return NotFound();
            }

            var islem = await _context.Islemler.FindAsync(id);
            if (islem == null)
            {
                return NotFound();
            }
            return View(islem);
        }

        // POST: Islem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("islemId,HesapNumarasi,AliciIsim,BankaIsim,SwiftCode,Miktar,Tarih")] Islem islem)
        {
            if (id != islem.islemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(islem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IslemExists(islem.islemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(islem);
        }

        // GET: Islem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Islemler == null)
            {
                return NotFound();
            }

            var islem = await _context.Islemler
                .FirstOrDefaultAsync(m => m.islemId == id);
            if (islem == null)
            {
                return NotFound();
            }

            return View(islem);
        }

        // POST: Islem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Islemler == null)
            {
                return Problem("Entity set 'IslemDbModel.Islemler'  is null.");
            }
            var islem = await _context.Islemler.FindAsync(id);
            if (islem != null)
            {
                _context.Islemler.Remove(islem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        List<string> liste = new List<string>();
        
        private bool IslemExists(int id)
        {
          return (_context.Islemler.Any(e => e.islemId == id));
           
        }
    }
}
