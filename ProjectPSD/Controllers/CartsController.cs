using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectPSD.Data;
using ProjectPSD.Models;

namespace ProjectPSD.Controllers
{
    public class CartsController : Controller
    {
        private readonly ProjectPSDContext _context;

        public CartsController(ProjectPSDContext context)
        {
            _context = context;
        }

        // GET: Carts
        public async Task<IActionResult> Index()
        {
              return _context.Cart != null ? 
                          View(await _context.Cart.ToListAsync()) :
                          Problem("Entity set 'ProjectPSDContext.Cart'  is null.");
        }

        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // GET: Carts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductName,Quantity,Price,CartID,DeffaultPrice")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cart);
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductName,Quantity,Price,CartID,DeffaultPrice")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
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
            return View(cart);
        }

        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cart == null)
            {
                return Problem("Entity set 'ProjectPSDContext.Cart'  is null.");
            }
            var cart = await _context.Cart.FindAsync(id);
            if (cart != null)
            {
                _context.Cart.Remove(cart);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Purchase()
        {
            var cart = _context.Cart
                .Where(m => m.CartID == 1)
                .ToList();
            if (cart == null)
            {
                return NotFound();
            }else if (cart != null)
            {
                _context.Cart.RemoveRange(cart);
            }

            await _context.SaveChangesAsync();
            return Redirect("../Home/PurchaseSuccess");
        }

        public async Task<IActionResult> addToCart()
        {
            String name = (string)TempData["name"];
            int price = (int)TempData["price"];

            Cart cart = new Cart()
            {
                ProductName = name, Quantity = 1, Price = price, CartID = 1, DeffaultPrice = price
            };

            if (cart == null)
            {
                return NotFound();
            }
            else if (cart != null)
            {
                _context.Add(cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Menu", "Products", new { id = (int)TempData["catID"] });
        }

        public async Task<IActionResult> plus(int? id)
        {
            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);

            cart.Quantity = (cart.Quantity + 1);
            cart.Price = (cart.Price + cart.DeffaultPrice);

            if (cart == null)
            {
                return NotFound();
            }
            else if (cart != null)
            {
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> minus(int? id)
        {
            var cart = await _context.Cart
                .FirstOrDefaultAsync(m => m.Id == id);

            cart.Quantity = (cart.Quantity - 1);
            cart.Price = (cart.Price - cart.DeffaultPrice);

            if (cart == null)
            {
                return NotFound();
            }
            else if (cart != null)
            {
                _context.Update(cart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CartExists(int id)
        {
          return (_context.Cart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
