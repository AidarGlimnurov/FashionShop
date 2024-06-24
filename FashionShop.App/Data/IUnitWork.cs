using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionShop.App.Data
{
	public interface IUnitWork
	{
		public Task Commit();
		public void Rollback();
	}
}
