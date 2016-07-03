using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FRM.Web.Data;
using FRM.Web.Models;
using FRM.Web.ViewModels;
using FRM.Web.Contracts;

namespace FRM.Web.Controllers
{
    public class FamiliesController : Controller
    {
        //private readonly ApplicationDbContext _context;
        IRepositoryBase<Family> families;

        public FamiliesController(IRepositoryBase<Family> _families)
        {
            families = _families;
        }

        // GET: Families
        public IActionResult Index()
        {
            var model = families.GetAll();
            return View(model);
            //return View(await _context.Families.ToListAsync());
        }

        // GET: Families/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = families.GetById(id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // Below this line => before Repository Implementation

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var family = await _context.Families.SingleOrDefaultAsync(m => m.Id == id);
        //    if (family == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(family);
        //}

        // GET: Families/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Families/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FamilyViewModel model)
        {
            var family = new Family
            {
                FamilyName = model.FamilyName
            };
            if (ModelState.IsValid)
            {
                families.Insert(family);
                families.Commit();
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Families/Edit/5

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = families.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        //POST: Families/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Family family)
        {
            families.Update(family);
            families.Commit();

            return RedirectToAction("Index");
            
        }


        //// POST: Families/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        ////[HttpPost]
        ////[ValidateAntiForgeryToken]
        ////public async Task<IActionResult> Create([Bind("Id,FamilyName")] Family family)
        ////{
        ////    if (ModelState.IsValid)
        ////    {
        ////        _context.Add(family);
        ////        await _context.SaveChangesAsync();
        ////        return RedirectToAction("Index");
        ////    }
        ////    return View(family);
        ////}

        //[HttpPost]
        //public async Task<IActionResult> Create(FamilyViewModel model)
        //{
        //    var family = new Family();
        //    if (ModelState.IsValid)
        //    {
        //        family.FamilyName = model.FamilyName;
        //        _context.Add(family);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //// GET: Families/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var family = await _context.Families.SingleOrDefaultAsync(m => m.Id == id);
        //    if (family == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(family);
        //}

        //// POST: Families/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,FamilyName")] Family family)
        //{
        //    if (id != family.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(family);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!FamilyExists(family.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction("Index");
        //    }
        //    return View(family);
        //}

        //// GET: Families/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var family = await _context.Families.SingleOrDefaultAsync(m => m.Id == id);
        //    if (family == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(family);
        //}

        //// POST: Families/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var family = await _context.Families.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.Families.Remove(family);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //private bool FamilyExists(int id)
        //{
        //    return _context.Families.Any(e => e.Id == id);
        //}
    }
}
