using CQRS.WebApi.Infrastructure.Context;
using CQRS.WebApi.Infrastructure.Features.Product.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.WebApi.Infrastructure.Features.Product.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductViewModel>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery,IEnumerable<ProductViewModel>>
        {
            private readonly IApplicationContext _context;
            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<ProductViewModel>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                var data = new List<ProductViewModel>();
                foreach(Domain.Models.Product product in productList)
                {
                    var thisProduct = new ProductViewModel();
                    thisProduct.Id = product.Id;
                    thisProduct.Barcode = product.Barcode;
                    thisProduct.Name = product.Name;
                    thisProduct.Description = product.Description;
                    thisProduct.Rate = product.Rate;
                    data.Add(thisProduct);
                }
                if (productList == null)
                {
                    return null;
                }
                return data.AsReadOnly();
            }
        }
    }
}
