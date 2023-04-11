using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SplitSmart.Models
{
	public class ReportViewModel
	{
        public int UserExpenseId { get; set; }
        // Expense Type of Expense or Payment
        [DisplayName("Expense Type")]
        public string? ExpenseType { get; set; }
        [DisplayName("Group Name")]
        public string? GroupName { get; set; }
        [DisplayName("Description")]
        public string? ExpenseDescription { get; set; }
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        public decimal TotalBalance { get; set; }
    }
}

