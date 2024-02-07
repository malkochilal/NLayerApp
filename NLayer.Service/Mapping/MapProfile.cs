using AutoMapper;
using NLayer.core;
using NLayer.core.DTOs;
using NLayer.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
 {
        public MapProfile() {
         CreateMap<Product, ProductDto>().ReverseMap();//product'ı produsctdto'ya çavirebilirim ya da tam tersi
        CreateMap<Category,CategoryDto>().ReverseMap();
        CreateMap<ProductFeature, ProductFeatureDto>().ReverseMap();
        CreateMap<ProductUpdateDto, Product>(); //tersini almama gerek yok.
        CreateMap<Product, ProductWithCategoryDto>();
        CreateMap<Category,CategoryWithProductsDto>();
        }
    }
}
