using Dapper.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IProductRepository productRepository)
        {
            Products = productRepository;
        }
        public IProductRepository Products { get; }
    }
}
