using NLayer.core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<List<ProductWithCategoryDto>> GetProductWithCategory();
        //Task<List<ProductWithCategoryDto>> GetProductWithCategory();
    }
}
