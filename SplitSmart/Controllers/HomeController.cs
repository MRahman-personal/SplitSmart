using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SplitSmart.Models;
using Microsoft.EntityFrameworkCore;
using SplitSmart.Data;
using SQLitePCL;
using SplitSmart.PaymentProcessorTemplate;

namespace SplitSmart.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var CurrentUser = User.Identity?.Name;
        var UserExpenses = await _context.ExpenseModels.Include(x => x.GroupModel).Where(x => x.GroupModel != null &&
                                ((x.GroupModel.Member1 != null && x.GroupModel.Member1 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member2 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member3 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member4 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member5 == CurrentUser))).ToListAsync();

        List<UserExpenseViewModel> list = new List<UserExpenseViewModel>();
        decimal TotalBalance = 0m;

        foreach (var Expense in UserExpenses)
        {       
            var ExpenseGroup = Expense.GroupModel;
            decimal UserAmount = 0;

            if (ExpenseGroup.Member1 == CurrentUser)
            {
                UserAmount = Expense.User1Balance;
            }
            else if (ExpenseGroup.Member2 == CurrentUser)
            {
                UserAmount = Expense.User2Balance;
            }
            else if (ExpenseGroup.Member3 == CurrentUser)
            {
                UserAmount = Expense.User3Balance;
            }
            else if (ExpenseGroup.Member4 == CurrentUser)
            {
                UserAmount = Expense.User4Balance;
            }
            else if (ExpenseGroup.Member5 == CurrentUser)
            {
                UserAmount = Expense.User5Balance;
            }

            TotalBalance += UserAmount;

            list.Add(new UserExpenseViewModel() { UserExpenseId = Expense.ExpenseId, GroupName = Expense.ExpenseGroupName, ExpenseDate = Expense.ExpenseDate, ExpenseDescription = Expense.Description, Amount = UserAmount });
        }

        // Show 5 most recent notifications on dashboard
        if (UserExpenses.Count >= 5)
            ViewData["notification1"] = "New Expense " + UserExpenses[UserExpenses.Count - 5].Description + " Created for Group " + UserExpenses[UserExpenses.Count - 5].GroupModel.GroupName + " on " + UserExpenses[UserExpenses.Count - 5].ExpenseDate.ToString("MM/dd/yyyy");
        if (UserExpenses.Count >= 4)
            ViewData["notification2"] = "New Expense " + UserExpenses[UserExpenses.Count - 4].Description + " Created for Group " + UserExpenses[UserExpenses.Count - 4].GroupModel.GroupName + " on " + UserExpenses[UserExpenses.Count - 4].ExpenseDate.ToString("MM/dd/yyyy");
        if (UserExpenses.Count >= 3)
            ViewData["notification3"] = "New Expense " + UserExpenses[UserExpenses.Count - 3].Description + " Created for Group " + UserExpenses[UserExpenses.Count - 3].GroupModel.GroupName + " on " + UserExpenses[UserExpenses.Count - 3].ExpenseDate.ToString("MM/dd/yyyy");
        if (UserExpenses.Count >= 2)
            ViewData["notification4"] = "New Expense " + UserExpenses[UserExpenses.Count - 2].Description + " Created for Group " + UserExpenses[UserExpenses.Count - 2].GroupModel.GroupName + " on " + UserExpenses[UserExpenses.Count - 2].ExpenseDate.ToString("MM/dd/yyyy");
        if(UserExpenses.Count >= 1)
            ViewData["notification5"] = "New Expense " + UserExpenses[UserExpenses.Count - 1].Description + " Created for Group " + UserExpenses[UserExpenses.Count - 1].GroupModel.GroupName + " on " + UserExpenses[UserExpenses.Count - 1].ExpenseDate.ToString("MM/dd/yyyy");
        ViewData["balance"] = "Your balance is " + string.Format("{0:C2}", TotalBalance);
        return View(list);
    }

    public IActionResult MakePayment(int? id)
    {
        TempData["PaymentExpenseId"] = id;
        return View(new PaymentModel());
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> MakePayment([Bind("PaymentId,ExpenseId,Amount,User,Date")] PaymentModel paymentModel)
    {
        var CurrentUser = User.Identity?.Name;

        if (ModelState.IsValid)
        {
            // Use Payment Processor Template to Process Payments
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            paymentProcessor.ProcessPayment(CurrentUser, (int)TempData["PaymentExpenseId"], _context, paymentModel);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(paymentModel);
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}

