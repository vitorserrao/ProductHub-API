using ProductHub_API.Dto.Products;
using ProductHub_API.Models;

namespace ProductHub_API.Services.Interfaces
{
    public interface IProductsService
    {
        Task<ResponseModel<IEnumerable<ProductsModel>>> GetAllProducts();
        Task<ResponseModel<ProductsModel>> GetProductById(int id);
        Task<ResponseModel<IEnumerable<ProductsModel>>> CreateProduct(ProductsDto productsDto);
        Task<ResponseModel<IEnumerable<ProductsModel>>> UpdateProduct(int id, ProductsDto productDto);
        Task<ResponseModel<IEnumerable<ProductsModel>>> DeleteProduct(int id);
    }
}
