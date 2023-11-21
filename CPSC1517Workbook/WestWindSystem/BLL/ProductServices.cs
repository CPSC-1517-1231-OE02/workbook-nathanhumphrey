using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
	public class ProductServices
	{
		private readonly WestWindContext _context;

		internal ProductServices(WestWindContext context)
		{
			_context = context;
		}

		public List<Product> GetProductsByCategoryId(int id)
		{
			return _context.Products.Where(p => p.CategoryId == id)
				.Include(p => p.Supplier)
				.ToList<Product>();
		}

		public List<Product> GetProductsByNameOrCategoryName(string partial)
		{
			if (partial == null)
			{
				throw new ArgumentNullException("Partial argument cannot be null.", new ArgumentException());
			}

			partial = partial.ToLower();
			return _context.Products.Where(p => p.ProductName.ToLower().Contains(partial) || p.Category.CategoryName.ToLower().Contains(partial))
				.Include(p => p.Supplier)
				.ToList<Product>();
		}

		public Product? GetProductById(int id)
		{
			return _context.Products.Where(p => p.ProductId == id).FirstOrDefault();
		}

		public void AddProduct(Product product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("Product argument cannot be null.", new ArgumentException());
			}

			_context.Products.Add(product);
			_context.SaveChanges();
		}

		public void UpdateProduct(Product product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("Product argument cannot be null.", new ArgumentException());
			}

			_context.Products.Update(product);
			_context.SaveChanges();
		}

		public void DiscontinueProduct(Product product)
		{
			if (product == null)
			{
				throw new ArgumentNullException("Product argument cannot be null.", new ArgumentException());
			}

			product.Discontinued = true;
			UpdateProduct(product);
		}
	}
}
