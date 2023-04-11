using System;
using System.Collections.Generic;
using SplitSmart.Data;
using SplitSmart.Models;

namespace SplitSmart.ReportBuilder
{
	public class ReportDirector
	{
		private IReportBuilder _builder;
		public IReportBuilder Builder
		{
			set { _builder = value; }
		}

		public void BuildStandardReport(List<ExpenseModel> ExpenseReportData, List<PaymentModel> PaymentReportData, string CurrentUser, ApplicationDbContext _context)
		{
			this._builder.BuildExpenses(ExpenseReportData, CurrentUser);
			this._builder.BuildPayments(PaymentReportData, CurrentUser, _context);
			this._builder.BuildPostProcess();
		}
	}
}

