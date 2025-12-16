using CleanArchMVC.Domain.Entities;
using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchMVC.Application.Products.Commands
{
    public class ProductCommand: IRequest<Product>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string Image { get; set; }
        public int CategoryId { get; set; }
    }
}
