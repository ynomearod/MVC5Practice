using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC5.Models
{   
	public  class ProductRepository : EFRepository<Product>, IProductRepository
	{

	}

	public  interface IProductRepository : IRepository<Product>
	{

	}
}