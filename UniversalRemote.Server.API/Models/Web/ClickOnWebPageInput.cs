using System.ComponentModel.DataAnnotations;

namespace UniversalRemote.Server.API.Models.Chrome
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
