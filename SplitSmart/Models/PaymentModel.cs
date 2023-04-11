using System;
using System.ComponentModel.DataAnnotations;

namespace SplitSmart.Models
{
	public class PaymentModel
	{
		[Key]
		public int PaymentId { get; set; }
		public int ExpenseId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
		public string? User { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
	}
}

