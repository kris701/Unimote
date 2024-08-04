using System.ComponentModel.DataAnnotations;

namespace Unimote.Server.API.Models.Web
{
	public class ClickOnWebPageInput
	{
		public enum BrowserTypes { Chrome }

		[Required]
		public BrowserTypes Browser { get; set; }
		[Required]
		public string TargetTab { get; set; }
		[Required]
		public string XPath { get; set; }
	}
}
