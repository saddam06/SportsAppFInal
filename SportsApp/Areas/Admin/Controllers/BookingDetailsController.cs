using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsApp.Data;
using SportsApp.Models;

namespace SportsApp.Areas.Admin.Controllers
{
    [Area("Admin")]
  

    public class BookingDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/BookingDetails
        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BookingDetail.Include(b => b.Product);
            return View(await applicationDbContext.ToListAsync());
        }
          public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.BookingDetail.Include(b => b.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Admin/BookingDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetail
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            return View(bookingDetail);
        }

        // GET: Admin/BookingDetails/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName");
            return View();
        }

        // POST: Admin/BookingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,UserName,Quantity,MoibileNumber,UserAddress")] BookingDetail bookingDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details",new{id=bookingDetail.OrderId});
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProuductName", bookingDetail.ProductId);
            return View(bookingDetail);
        }

        // GET: Admin/BookingDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetail.FindAsync(id);
            if (bookingDetail == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", bookingDetail.ProductId);
            return View(bookingDetail);
        }

        // POST: Admin/BookingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,UserName,Quantity,MoibileNumber,UserAddress")] BookingDetail bookingDetail)
        {
            if (id != bookingDetail.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingDetailExists(bookingDetail.OrderId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "ProductName", bookingDetail.ProductId);
            return View(bookingDetail);
        }

        // GET: Admin/BookingDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingDetail = await _context.BookingDetail
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (bookingDetail == null)
            {
                return NotFound();
            }

            return View(bookingDetail);
        }

        // POST: Admin/BookingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingDetail = await _context.BookingDetail.FindAsync(id);
            _context.BookingDetail.Remove(bookingDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingDetailExists(int id)
        {
            return _context.BookingDetail.Any(e => e.OrderId == id);
        }
    }
}
