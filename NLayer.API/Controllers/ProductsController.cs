using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.core;
using NLayer.core.DTOs;
using NLayer.core.Services;

namespace NLayer.API.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
       // private readonly IService<Product> _service;
        private readonly IProductService _service;

        public ProductsController(IService<Product> service, IMapper mapper, IProductService productService)
        {
           
            _mapper = mapper;
            _service = productService;

        }
            [HttpGet("[action]")]
            public async Task<IActionResult> GetProductWithCategory()
            {
                return CreateActionResult(await _service.GetProductsWithCategory());
            //return CreateActionResult(await productService.GetProductsWithCategory());
        }



            //GET api/products


            [HttpGet]
            public async Task<IActionResult> All()
            {
                var products = await _service.GetAllAsync();
                var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
                // return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDtos));
                return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
            }
        [ServiceFilter(typeof(NotFoundFilter<Product>))]
            // GET/api/products/5
            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productsDto));
            //}

                //var productsDto = _mapper.Map<ProductDto>(product);
                // return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDtos));
               
            }

            [HttpPost]
            public async Task<IActionResult> Save(ProductDto productDto)
            {
                var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
                var productsDto = _mapper.Map<ProductDto>(product);
                // return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDtos));
                return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
            }

            [HttpPut]
            public async Task<IActionResult> Update(ProductUpdateDto productDto)
            {
                await _service.UpdateAsync(_mapper.Map<Product>(productDto));

                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
                // return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDtos));

            }
            //DELETE api/products/5
            [HttpDelete("{id}")]
            public async Task<IActionResult> Remove(int id)
            {
                var product = await _service.GetByIdAsync(id);

                await _service.RemoveAsync(product);

                // return Ok(CustomResponseDto<List<ProductDto>>.Success(200,productsDtos));
                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
            }

           // this.IproductService = productService;
        }
    }
