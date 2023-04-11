using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SplitSmart.Models
{
    public class ExpenseModel
    {
        [Key]
        public int ExpenseId { get; set; }
        [DisplayName("Group Name")]
        public string? ExpenseGroupName {get;set;}
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }
        [DisplayName("Expense Date")]
        [DataType(DataType.Date)]
        public DateTime ExpenseDate { get; set; }
        public string? Description { get; set; }
        [DisplayName("Member 1 Percentage")]
        public decimal User1Percentage { get; set; }
        [DisplayName("Member 2 Percentage")]
        public decimal User2Percentage { get; set; }
        [DisplayName("Member 3 Percentage")]
        public decimal User3Percentage { get; set; }
        [DisplayName("Member 4 Percentage")]
        public decimal User4Percentage { get; set; }
        [DisplayName("Member 5 Percentage")]
        public decimal User5Percentage { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Member 1 Balance")]
        public decimal User1Balance { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Member 2 Balance")]
        public decimal User2Balance { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Member 3 Balance")]
        public decimal User3Balance { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Member 4 Balance")]
        public decimal User4Balance { get; set; }
        [DataType(DataType.Currency)]
        [DisplayName("Member 5 Balance")]
        public decimal User5Balance { get; set; }
        public GroupModel? GroupModel { get; set; }
    }
}