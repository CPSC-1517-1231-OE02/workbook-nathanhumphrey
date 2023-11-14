using Microsoft.AspNetCore.Components;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WestWindWebApp.Pages
{
	public partial class ProductsPage
	{
		[Inject]
		CategoryServices CategoryServices { get; set; }
		[Inject]
		ProductServices ProductServices { get; set; }
		[Inject]
		NavigationManager NavigationManager { get; set; }

		public List<Category>? Categories { get; set; } = null;
		public List<Product>? Products { get; set; } = null;

		[Parameter]
		public int CategoryId { get; set; }

		public string PartialSearch { get; set; }

		protected override void OnInitialized()
		{
			Categories = CategoryServices.GetAllCategories();

			if (CategoryId != 0)
			{
				Products = ProductServices.GetProductsByCategoryId(CategoryId);
				PartialSearch = null;
			}

			base.OnInitialized();
		}

		private void HandleCategorySelected()
		{
			if (CategoryId != 0)
			{
				Products = ProductServices.GetProductsByCategoryId(CategoryId);
				PartialSearch = null;
				NavigationManager.NavigateTo($"/products/{CategoryId}");
			}
		}

		private void HandlePartialSearch()
		{
			if (!string.IsNullOrWhiteSpace(PartialSearch))
			{
				Products = ProductServices.GetProductsByNameOrCategoryName(PartialSearch);
				CategoryId = 0;
				NavigationManager.NavigateTo("/products");
			}
		}
	}
}
