using CQRS.WebApi.Application.Features.Product.ViewModels;
using CQRS.WebApi.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WebApi.Application.Features.Product.Queries
{
    public class GetProductByIdQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
        {
            private readonly IApplicationContext _context;
            public GetProductByIdQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<ProductViewModel> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product =  _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
                if (product == null) return null;
                var thisProduct = new ProductViewModel();
                thisProduct.Id = product.Id;
                thisProduct.Barcode = product.Barcode;
                thisProduct.Name = product.Name;
                thisProduct.Description = product.Description;
                thisProduct.Rate = product.Rate;
                return thisProduct;
            }
        }
    }
}
