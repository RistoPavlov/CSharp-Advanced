using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Helpers
{
    public static class PrintHelper
    {
		public static void PrintSimple<T>(this List<T> list)
		{
			Console.WriteLine("------------------------------");
			foreach (T item in list)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("------------------------------");
		}
		public static void PrintEntities<T>(this List<T> list) where T : BaseEntity
		{
			Console.WriteLine("------------------------------");
			foreach (T item in list)
			{
				Console.WriteLine(item.Info());
			}
			Console.WriteLine("------------------------------");
		}
    }
}
