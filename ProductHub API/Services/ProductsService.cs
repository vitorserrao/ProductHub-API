using Microsoft.Extensions.Caching.Memory;
using ProductHub_API.Dto.Products;
using ProductHub_API.Models;
using ProductHub_API.Repositories.Interfaces;
using ProductHub_API.Services.Interfaces;

namespace ProductHub_API.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IMemoryCache _cache;
        private readonly string cacheKey = "productsCache";

        public ProductsService(IProductsRepository productsRepository, IMemoryCache cache)
        {
            _productsRepository = productsRepository;
            _cache = cache;
        }

        public async Task<ResponseModel<IEnumerable<ProductsModel>>> CreateProduct(ProductsDto productsDto)
        {
            var response = new ResponseModel<IEnumerable<ProductsModel>>();
            try
            {
                var newProduct = new ProductsModel
                {
                    Name = productsDto.Name,
                    Description = productsDto.Description,
                    Price = productsDto.Price
                };

                await _productsRepository.Add(newProduct);
                _cache.Remove(cacheKey);

                response.Message = "Produto criado com sucesso!";
                response.Data = await _productsRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<IEnumerable<ProductsModel>>> DeleteProduct(int id)
        {
            var response = new ResponseModel<IEnumerable<ProductsModel>>();
            try
            {
                await _productsRepository.Delete(id);
                _cache.Remove(cacheKey);

                response.Message = "Produto deletado com sucesso!";
                response.Data = await _productsRepository.GetAll();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<IEnumerable<ProductsModel>>> GetAllProducts()
        {
            var response = new ResponseModel<IEnumerable<ProductsModel>>();
            try
            {
                if (!_cache.TryGetValue(cacheKey, out IEnumerable<ProductsModel> products))
                {
                    products = await _productsRepository.GetAll();
                    _cache.Set(cacheKey, products, TimeSpan.FromMinutes(10));
                }
                response.Data = products;
                response.Message = "Produtos listados com sucesso!";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<ProductsModel>> GetProductById(int id)
        {
            var response = new ResponseModel<ProductsModel>();
            try
            {
                var product = await _productsRepository.GetById(id);
                if (product == null)
                {
                    response.Status = false;
                    response.Message = "Produto não encontrado!";
                }
                else
                {
                    response.Data = product;
                    response.Message = "Produto encontrado!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }

        public async Task<ResponseModel<IEnumerable<ProductsModel>>> UpdateProduct(int id, ProductsDto productsDto)
        {
            var response = new ResponseModel<IEnumerable<ProductsModel>>();
            try
            {
                var existingProduct = await _productsRepository.GetById(id);
                if (existingProduct == null)
                {
                    response.Message = "Produto não encontrado.";
                    response.Status = false;
                }
                else
                {
                    existingProduct.Name = productsDto.Name;
                    existingProduct.Description = productsDto.Description;
                    existingProduct.Price = productsDto.Price;

                    await _productsRepository.Update(existingProduct);
                    _cache.Remove(cacheKey);

                    response.Message = "Produto atualizado com sucesso!";
                    response.Data = await _productsRepository.GetAll();
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
            }
            return response;
        }
    }
}
