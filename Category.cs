using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Expense_Tracker.Models
{
	public class Category
	{
		[Key]
		public int CategoryId { get; set; }
		[Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Please enter a title")]
        public string Title { get; set; }
		[Column(TypeName = "nvarchar(5)")]
		[Required(ErrorMessage ="Please enter an icon")]
		public string Icon { get; set; } = "";
		[Column(TypeName = "nvarchar(10)")]
        [Required(ErrorMessage = "Please enter a type")]
        public string Type { get; set; } = "Expense";
		[NotMapped]
		public string TitleWithIcon
		{
			get
			{
				return this.Icon + " " + this.Title;
			}
		}
	}
}
