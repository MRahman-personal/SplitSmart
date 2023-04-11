using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SplitSmart.Data;
using SplitSmart.Models;

namespace SplitSmart.Views
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Expense
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ExpenseModels.Include(e => e.GroupModel);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Expense/Create
        public IActionResult Create()
        {
            ViewData["ExpenseGroupName"] = new SelectList(_context.GroupModels, "GroupName", "GroupName");
            return View();
        }

        // POST: Expense/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpenseId,ExpenseGroupName,Amount,ExpenseDate,Description,User1Percentage,User2Percentage,User3Percentage,User4Percentage,User5Percentage,User1Balance,User2Balance,User3Balance,User4Balance,User5Balance,User1Payments,User2Payments,User3Payments,User4Payments,User5Payments,Receipt")] ExpenseModel expenseModel)
        {
            if (ModelState.IsValid)
            {
                // Set balances using percentage
                expenseModel.User1Balance = expenseModel.User1Percentage * .01m * expenseModel.Amount;
                expenseModel.User2Balance = expenseModel.User2Percentage * .01m * expenseModel.Amount;
                expenseModel.User3Balance = expenseModel.User3Percentage * .01m * expenseModel.Amount;
                expenseModel.User4Balance = expenseModel.User4Percentage * .01m * expenseModel.Amount;
                expenseModel.User5Balance = expenseModel.User5Percentage * .01m * expenseModel.Amount;

                _context.Add(expenseModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ExpenseGroupName"] = new SelectList(_context.GroupModels, "GroupName", "GroupName", expenseModel.ExpenseGroupName);
            
            return View(expenseModel);
        }

        // GET: Expense/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ExpenseModels == null)
            {
                return NotFound();
            }

            var expenseModel = await _context.ExpenseModels.FindAsync(id);
            if (expenseModel == null)
            {
                return NotFound();
            }
            ViewData["ExpenseGroupName"] = new SelectList(_context.GroupModels, "GroupName", "GroupName", expenseModel.ExpenseGroupName);
            return View(expenseModel);
        }

        // POST: Expense/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpenseId,ExpenseGroupName,Amount,ExpenseDate,Description,User1Percentage,User2Percentage,User3Percentage,User4Percentage,User5Percentage,User1Balance,User2Balance,User3Balance,User4Balance,User5Balance,User1Payments,User2Payments,User3Payments,User4Payments,User5Payments,Receipt")] ExpenseModel expenseModel)
        {
            if (id != expenseModel.ExpenseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Set balances using percentage
                    expenseModel.User1Balance = expenseModel.User1Percentage * .01m * expenseModel.Amount;
                    expenseModel.User2Balance = expenseModel.User2Percentage * .01m * expenseModel.Amount;
                    expenseModel.User3Balance = expenseModel.User3Percentage * .01m * expenseModel.Amount;
                    expenseModel.User4Balance = expenseModel.User4Percentage * .01m * expenseModel.Amount;
                    expenseModel.User5Balance = expenseModel.User5Percentage * .01m * expenseModel.Amount;

                    _context.Update(expenseModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseModelExists(expenseModel.ExpenseId))
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
            ViewData["ExpenseGroupName"] = new SelectList(_context.GroupModels, "GroupName", "GroupName", expenseModel.ExpenseGroupName);
            return View(expenseModel);
        }

        // GET: Expense/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ExpenseModels == null)
            {
                return NotFound();
            }

            var expenseModel = await _context.ExpenseModels
                .Include(e => e.GroupModel)
                .FirstOrDefaultAsync(m => m.ExpenseId == id);
            if (expenseModel == null)
            {
                return NotFound();
            }

            return View(expenseModel);
        }

        // POST: Expense/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ExpenseModels == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ExpenseModels'  is null.");
            }
            var expenseModel = await _context.ExpenseModels.FindAsync(id);
            if (expenseModel != null)
            {
                _context.ExpenseModels.Remove(expenseModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseModelExists(int id)
        {
          return (_context.ExpenseModels?.Any(e => e.ExpenseId == id)).GetValueOrDefault();
        }
    }
}
