using System;
using System.Diagnostics;

namespace ModelObjectPicker
{
	public class Program
	{
		public static void Main(string[] args)
		{
			try
			{
				new PickerExample().Run();
			}
			catch (Exception ex)
			{
				Trace.WriteLine(ex.InnerException + ex.Message + ex.StackTrace);
			}
		}
	}
}
