using Expense_Tracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Expense_Tracker.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            //Last 7 days
            DateTime startDate = DateTime.Today.AddDays(-6);
            DateTime endDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transaction.
                Include(x => x.Category).Where(y => y.Date >= startDate && y.Date <= endDate).ToListAsync();

            //Total Income 
            int TotalIncome = SelectedTransactions.Where(w => w.Category.Type == "Income").Sum(v => v.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");

            //Total Expense
            int TotalExpense = SelectedTransactions.Where(w => w.Category.Type == "Expense").Sum(v => v.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            //Balance
            int Balance = TotalIncome - TotalExpense;
            ViewBag.Balance = Balance.ToString("C0");

            return View();
        }
    }
}
