﻿namespace Unimote.Server.API.Helpers
{
	public static class ListHelpers
	{
		public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
		{
			return listToClone.Select(item => (T)item.Clone()).ToList();
		}
	}
}
