using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SplitSmart.Models;
using Microsoft.EntityFrameworkCore;
using SplitSmart.Data;
using SplitSmart.ReportBuilder;

namespace SplitSmart.Controllers;

public class ReportController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public ReportController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var CurrentUser = User.Identity?.Name;
        var ExpenseReportData = _context.ExpenseModels.Include(x => x.GroupModel).Where(x => x.GroupModel != null &&
                                ((x.GroupModel.Member1 != null && x.GroupModel.Member1 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member2 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member3 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member4 == CurrentUser) ||
                                (x.GroupModel.Member1 != null && x.GroupModel.Member5 == CurrentUser))).ToList();

        var PaymentReportData = _context.PaymentModels.Where(x => x.User == CurrentUser).ToList();

        // Construct Report using ReportBuilder
        ReportDirector Director = new ReportDirector();
        ConcreteReportBuilder ReportBuilder = new ConcreteReportBuilder();
        Director.Builder = ReportBuilder;
        Director.BuildStandardReport(ExpenseReportData, PaymentReportData, CurrentUser, _context);
        List<ReportViewModel> FinalReport = ReportBuilder.GetReport().ListParts();

        if(FinalReport.Count > 0)
            ViewData["balance"] = "Your balance is " + string.Format("{0:C2}", FinalReport.First().TotalBalance);

        return View(FinalReport);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

