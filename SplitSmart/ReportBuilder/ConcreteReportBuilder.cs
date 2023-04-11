using System;
using Microsoft.EntityFrameworkCore;
using SplitSmart.Models;
using SplitSmart.Data;

namespace SplitSmart.ReportBuilder
{
	public class ConcreteReportBuilder : IReportBuilder
	{
        private Report _report = new Report();
		public ConcreteReportBuilder()
		{
            this.Reset();
		}

        public void Reset()
        {
            this._report = new Report();
        }

        public void BuildExpenses(List<ExpenseModel> ExpenseReportData, string CurrentUser)
        {

            List<ReportViewModel> list = new List<ReportViewModel>();
            decimal TotalExpenseBalance = 0;

            foreach (var Row in ExpenseReportData)
            {
                var ExpenseGroup = Row.GroupModel;
                decimal UserAmount = 0;

                if (ExpenseGroup.Member1 == CurrentUser)
                {
                    UserAmount = Row.User1Balance;
                }
                else if (ExpenseGroup.Member2 == CurrentUser)
                {
                    UserAmount = Row.User2Balance;
                }
                else if (ExpenseGroup.Member3 == CurrentUser)
                {
                    UserAmount = Row.User3Balance;
                }
                else if (ExpenseGroup.Member4 == CurrentUser)
                {
                    UserAmount = Row.User4Balance;
                }
                else if (ExpenseGroup.Member5 == CurrentUser)
                {
                    UserAmount = Row.User5Balance;
                }

                TotalExpenseBalance += UserAmount;
                list.Add(new ReportViewModel() { UserExpenseId = Row.ExpenseId, ExpenseType="Expense", GroupName = Row.ExpenseGroupName, ExpenseDate = Row.ExpenseDate, ExpenseDescription = Row.Description, Amount = UserAmount, TotalBalance=TotalExpenseBalance });
            }

            this._report.Add(list);
        }

        public void BuildPayments(List<PaymentModel> PaymentReportData, string CurrentUser, ApplicationDbContext _context)
        {
            List<ReportViewModel> list = new List<ReportViewModel>();

            foreach (var Row in PaymentReportData)
            {
                ExpenseModel ExpenseRow = _context.ExpenseModels.FirstOrDefault(x => x.ExpenseId == Row.ExpenseId);
                list.Add(new ReportViewModel() { UserExpenseId = Row.ExpenseId, ExpenseType="Payment" ,GroupName = ExpenseRow.ExpenseGroupName, ExpenseDate = ExpenseRow.ExpenseDate, ExpenseDescription = ExpenseRow.Description, Amount = Decimal.Negate(Row.Amount) });
            }

            this._report.Add(list);
        }

        public void BuildPostProcess()
        {
            List<ReportViewModel> list = this._report.ListParts();
            list.OrderByDescending(x => x.ExpenseDate);
            this._report.SetProcessedList(list);
        }

        public Report GetReport()
        {
            Report report = this._report;
            this.Reset();
            return report;
        }
    }
}

