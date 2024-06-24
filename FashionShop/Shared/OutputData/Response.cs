using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.Shared.OutputData
{
	public class Response
	{
		public bool IsSuccess { get; set; }
		public string? ErrorMessage { get; set; } = string.Empty;
		public string? ErrorInfo { get; set; } = string.Empty;
        // for additional information
        public string? Info { get; set; } = string.Empty;
    }

	public class Response<T> : Response
	{
		public T? Value { get; set; }
	}
}
