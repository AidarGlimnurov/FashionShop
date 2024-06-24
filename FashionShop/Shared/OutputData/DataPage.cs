using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.OutputData
{
	public class DataPage<T>
	{
		public int Start { get; set; }
		public int Count => Data.Length;

		public T[] Data { get; set; } = Array.Empty<T>();
	}
}
