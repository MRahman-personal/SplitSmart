using System;
using Microsoft.EntityFrameworkCore;
using SplitSmart.Models;
using SplitSmart.Data;

namespace SplitSmart.PaymentProcessorTemplate
{
    public class PaymentProcessor : PaymentProcessorTemplate
    {
        public override void CreatePaymentRecord(string CurrentUser, int ExpenseId, ApplicationDbContext _context, PaymentModel _paymentModel)
        {
            PaymentModel paymentModel = _paymentModel;
            paymentModel.User = CurrentUser;
            paymentModel.ExpenseId = ExpenseId;
            paymentModel.Date = DateTime.Now;

            _context.Add(paymentModel);
        }
        // Interface with external payment processor to process payments
        public override void ExternalPaymentProcessor()
        {
        }

        public override void UpdateExpenseRecord(string CurrentUser, int ExpenseId, decimal Amount, ApplicationDbContext _context)
        {
            var ExpenseRow = _context.ExpenseModels.Include(x => x.GroupModel).FirstOrDefault(x => x.ExpenseId == ExpenseId);
            var ExpenseGroup = _context.GroupModels.FirstOrDefault(x => x.GroupId == ExpenseRow.GroupModel.GroupId);

            if (ExpenseGroup.Member1 == CurrentUser)
            {
                ExpenseRow.User1Balance -= Amount;
            }
            else if (ExpenseGroup.Member2 == CurrentUser)
            {
                ExpenseRow.User2Balance -= Amount;
            }
            else if (ExpenseGroup.Member3 == CurrentUser)
            {
                ExpenseRow.User3Balance -= Amount;
            }
            else if (ExpenseGroup.Member4 == CurrentUser)
            {
                ExpenseRow.User4Balance -= Amount;
            }
            else if (ExpenseGroup.Member5 == CurrentUser)
            {
                ExpenseRow.User5Balance -= Amount;
            }

            _context.Update(ExpenseRow);
        }
        // Validate Payment
        public override bool ValidatePayment()
        {
            return true;
        }
    }
}

