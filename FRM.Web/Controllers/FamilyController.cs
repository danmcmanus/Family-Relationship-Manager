using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FRM.Web.Data;
using FRM.Web.Models;
using FRM.Web.Contracts;

namespace FRM.Web.Controllers
{
    public class FamilyController : Controller
    {
        private readonly ApplicationDbContext _context;
        IRepositoryBase<Family> _repository;

        public FamilyController(IRepositoryBase<Family> repository, ApplicationDbContext context)
        {
            _context = context;
            _repository = repository;
        }

        // GET: Family
        public async Task<IActionResult> Index()
        {
            return View(await _context.Families.Where(f => f.Username == User.Identity.Name).ToListAsync());
        }

        // GET: Family/Details/5
        public IActionResult Details(int? id)
        {
            var model = _repository.GetDistinctFamilyWithMembers(id);
            if (model != null)
            {
                return View(model);
            }

            else
            {
                return RedirectToAction("Index");
            }
        }


        // GET: Family/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Family/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Family family)
        {
            if (ModelState.IsValid)
            {
                family.Username = User.Identity.Name;
                family.FamilyMembers = new List<FamilyMember>();
                _repository.Insert(family);
                _repository.Commit();
                return RedirectToAction("Index");
            }

            return View(family);
        }

        // GET: Family/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var family = await _context.Families.SingleOrDefaultAsync(m => m.Id == id);
            if (family == null)
            {
                return NotFound();
            }
            return View(family);
        }

        // POST: Family/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FamilyName")] Family family)
        {
            if (id != family.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.Update(family);
                    _repository.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FamilyExists(family.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(family);
        }

        // GET: Family/Delete/5
        public IActionResult Delete(int id)
        {
            _repository.DeleteFamily(id);
            return RedirectToAction("Index");
        }

        // POST: Family/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var family = await _context.Families.SingleOrDefaultAsync(m => m.Id == id);
            _context.Families.Remove(family);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FamilyExists(int id)
        {
            return _context.Families.Any(e => e.Id == id);
        }
    }
}
