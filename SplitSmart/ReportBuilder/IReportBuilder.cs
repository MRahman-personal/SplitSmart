using System;
using SplitSmart.Data;
using SplitSmart.Models;

namespace SplitSmart.ReportBuilder
{
	public interface IReportBuilder
	{
		void BuildExpenses(List<ExpenseModel> ExpenseReportData, string CurrentUser);
		void BuildPayments(List<PaymentModel> PaymentReportData, string CurrentUser, ApplicationDbContext _context);
		void BuildPostProcess();
	}
}

