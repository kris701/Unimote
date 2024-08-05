﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Unimote.Server.WPF.Helpers
{
	public static class StringHelpers
	{
		public static string ToSentenceCase(this string str)
		{
			return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
		}
	}
}