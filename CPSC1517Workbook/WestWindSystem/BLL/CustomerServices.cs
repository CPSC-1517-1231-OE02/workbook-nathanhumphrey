using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Requried namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
	public class CustomerServices
	{
		private readonly WestWindContext _context;

		internal CustomerServices(WestWindContext context)
		{
			_context = context;
		}

		public Customer GetCustomerById(string id)
		{
			Customer? customer = _context.Customers.Where(c => c.CustomerId == id)
				.FirstOrDefault();

			return customer;
		}
	}
}
