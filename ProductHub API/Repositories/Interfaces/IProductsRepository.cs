using ProductHub_API.Models;

namespace ProductHub_API.Repositories.Interfaces
{
    public interface IProductsRepository
    {
        Task<IEnumerable<ProductsModel>> GetAll();
        Task<ProductsModel?> GetById(int id);
        Task Add(ProductsModel product);
        Task Update(ProductsModel product);
        Task Delete(int id);
    }
}
