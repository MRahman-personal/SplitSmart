using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SplitSmart.Models
{
	public class GroupModel
	{
        [Key]
        public int GroupId { get; set; }
        [DisplayName("Group Name")]
        public string? GroupName { get; set; }
        [Required(ErrorMessage = "At least one member required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Member 1 Email")]
        public string? Member1 { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Member 2 Email")]
        public string? Member2 { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Member 3 Email")]
        public string? Member3 { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Member 4 Email")]
        public string? Member4 { get; set; }
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("Member 5 Email")]
        public string? Member5 { get; set; }
        public List<ExpenseModel>? ExpenseModels { get; set; }
    }
}

