using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly VacancyContext _context;

        public VacanciesController(VacancyContext context)
        {
            _context = context;
        }

        // GET: Vacancies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vacancy.ToListAsync());
        }

        [HttpPost]
        public IActionResult Index(string fio)
        {
            var vacancies = _context.SearchVacancies(fio);
            return View(vacancies);
        }

        // GET: Vacancies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .FirstOrDefaultAsync(m => m.id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // GET: Vacancies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vacancies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,staffing_item_parrent_full_ext_id,staffing_item_full_ext_id,Fio_vlad,Telefon_vlad,Fio_rec,Telefon_rec,Email_rec,id_candidate,last_name,first_name,middle_name,no_middle_name,dt_birthday,email,gender,Rec_Active")] Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _context.Database.ExecuteSqlRaw("EXEC Insert_data @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14",
                   new object[] { vacancy.staffing_item_parrent_full_ext_id, vacancy.staffing_item_full_ext_id, vacancy.Fio_vlad, vacancy.Telefon_vlad, vacancy.Fio_rec, vacancy.Telefon_rec, vacancy.Email_rec, vacancy.id_candidate, vacancy.last_name, vacancy.first_name, vacancy.middle_name, vacancy.no_middle_name, vacancy.dt_birthday, vacancy.email, vacancy.gender });
                //_context.Add(vacancy);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vacancy);
        }

        // GET: Vacancies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy.FindAsync(id);
            if (vacancy == null)
            {
                return NotFound();
            }
            return View(vacancy);
        }

        // POST: Vacancies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,staffing_item_parrent_full_ext_id,staffing_item_full_ext_id,Fio_vlad,Telefon_vlad,Fio_rec,Telefon_rec,Email_rec,id_candidate,last_name,first_name,middle_name,no_middle_name,dt_birthday,email,gender,Rec_Active")] Vacancy vacancy)
        {
            if (id != vacancy.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacancy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacancyExists(vacancy.id))
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
            return View(vacancy);
        }

        // GET: Vacancies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacancy = await _context.Vacancy
                .FirstOrDefaultAsync(m => m.id == id);
            if (vacancy == null)
            {
                return NotFound();
            }

            return View(vacancy);
        }

        // POST: Vacancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _context.Database.ExecuteSqlRaw("EXEC Delete_data @p0", id);

            //var vacancy = await _context.Vacancy.FindAsync(id);

            //vacancy.Rec_Active = 0;
            //_context.Update(vacancy);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacancyExists(int id)
        {
            return _context.Vacancy.Any(e => e.id == id);
        }
    }
}
