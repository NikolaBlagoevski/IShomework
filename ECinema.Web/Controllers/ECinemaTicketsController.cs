using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ECinema.Web.Data;
using ECinema.Web.Models.Domain;

namespace ECinema.Web.Controllers
{
    public class ECinemaTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ECinemaTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ECinemaTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.tickets.ToListAsync());
        }

        // GET: ECinemaTickets/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCinemaTicket = await _context.tickets
                .FirstOrDefaultAsync(m => m.id == id);
            if (eCinemaTicket == null)
            {
                return NotFound();
            }

            return View(eCinemaTicket);
        }

        // GET: ECinemaTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ECinemaTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,idMovie,priceOfTicket,dateValid")] ECinemaTicket eCinemaTicket)
        {
            if (ModelState.IsValid)
            {
                eCinemaTicket.id = Guid.NewGuid();
                _context.Add(eCinemaTicket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eCinemaTicket);
        }

        // GET: ECinemaTickets/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCinemaTicket = await _context.tickets.FindAsync(id);
            if (eCinemaTicket == null)
            {
                return NotFound();
            }
            return View(eCinemaTicket);
        }

        // POST: ECinemaTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,idMovie,priceOfTicket,dateValid")] ECinemaTicket eCinemaTicket)
        {
            if (id != eCinemaTicket.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eCinemaTicket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ECinemaTicketExists(eCinemaTicket.id))
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
            return View(eCinemaTicket);
        }

        // GET: ECinemaTickets/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eCinemaTicket = await _context.tickets
                .FirstOrDefaultAsync(m => m.id == id);
            if (eCinemaTicket == null)
            {
                return NotFound();
            }

            return View(eCinemaTicket);
        }

        // POST: ECinemaTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var eCinemaTicket = await _context.tickets.FindAsync(id);
            _context.tickets.Remove(eCinemaTicket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ECinemaTicketExists(Guid id)
        {
            return _context.tickets.Any(e => e.id == id);
        }
    }
}
