using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SplitSmart.Models
{
	public class UserExpenseViewModel
	{
		public int UserExpenseId { get; set; }
        [DisplayName("Group Name")]
        public string? GroupName { get; set; }
        [DisplayName("Description")]
        public string? ExpenseDescription { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Expense Date")]
        public DateTime ExpenseDate { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
		public decimal Balance { get; set; }
	}
}

