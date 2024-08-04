using System.ComponentModel.DataAnnotations;

namespace UniversalRemote.Server.API.Models.Chrome
{
	public class ClickOnWebPageInput
	{
		[Required]
		public string TargetBrowser { get; set; }
		[Required]
		public string TargetTab { get; set; }
		[Required]
		public string XPath { get; set; }
	}
}
