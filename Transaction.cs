using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
	public class Transaction
	{
		[Key]
		public int TransactionId { get; set; }
		//[Required(ErrorMessage = "Please enter a category")]
		[Range(1, int.MaxValue, ErrorMessage ="Please select a category")]
        public int CategoryId { get; set; }
		public Category Category { get; set; }
        //[Required(ErrorMessage = "Please enter an amount")]
		[Range(1, int.MaxValue, ErrorMessage ="Please enter an amount")]
        public int Amount { get; set; }
		[Column(TypeName = "nvarchar(75)")]
		public string? Note { get; set; } 
		public DateTime Date { get; set; } = DateTime.Now;

		[NotMapped]
		public string CategoryTitleWithIcon
		{
			get
			{
				return Category == null ? "" : Category.Icon + " " + Category.Title;
			}
		}

		[NotMapped]
        public string FormattedAmount
        {
            get
            {
                return ((Category == null || Category.Type == "Expense" ? "- " + Amount.ToString("C0") : "+ " + Amount.ToString("C0")));
            }
        }
    }
}
