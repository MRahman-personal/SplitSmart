using System;
using SplitSmart.Data;
using SplitSmart.Models;

namespace SplitSmart.PaymentProcessorTemplate
{
	public abstract class PaymentProcessorTemplate
	{
		public abstract bool ValidatePayment();
		public abstract void CreatePaymentRecord(string CurrentUser, int ExpenseId, ApplicationDbContext _context, PaymentModel _paymentModel);
		public abstract void UpdateExpenseRecord(string CurrentUser, int ExpenseId,decimal Amount, ApplicationDbContext _context);
		public abstract void ExternalPaymentProcessor();

		public void ProcessPayment(string CurrentUser, int ExpenseId, ApplicationDbContext _context, PaymentModel _paymentModel)
		{
			if (ValidatePayment() == true)
			{
				CreatePaymentRecord(CurrentUser, ExpenseId, _context, _paymentModel);
				UpdateExpenseRecord(CurrentUser, ExpenseId, _paymentModel.Amount, _context);
				ExternalPaymentProcessor();
			}
		}
	}
}

