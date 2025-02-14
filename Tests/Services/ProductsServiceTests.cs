using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using ProductHub_API.Services;
using ProductHub_API.Repositories.Interfaces;
using ProductHub_API.Models;
using ProductHub_API.Dto.Products;

public class ProductsServiceTests
{
    private readonly ProductsService _productsService;
    private readonly Mock<IProductsRepository> _productsRepositoryMock;
    private readonly Mock<IMemoryCache> _cacheMock;

    public ProductsServiceTests()
    {
        _productsRepositoryMock = new Mock<IProductsRepository>();
        _cacheMock = new Mock<IMemoryCache>();
        _productsService = new ProductsService(_productsRepositoryMock.Object, _cacheMock.Object);
    }

    [Fact]
    public async Task CreateProduct_ShouldReturnSuccess()
    {
        var newProductDto = new ProductsDto { Name = "Energia Residencial Convencional", Description = "Fornecimento energia elétrica tradicional", Price = 99.99M };
        var newProduct = new ProductsModel { Id = 1, Name = "Energia Eólica Residencial", Description = "Fornecimento de 220 kWh/mês de energia eólica", Price = 99.99M };

        _productsRepositoryMock.Setup(r => r.Add(It.IsAny<ProductsModel>())).Returns(Task.CompletedTask);
        _productsRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(new List<ProductsModel> { newProduct });

        var result = await _productsService.CreateProduct(newProductDto);

        Assert.True(result.Status);
        Assert.Equal("Produto criado com sucesso!", result.Message);
        Assert.Single(result.Data);
        Assert.Equal(newProduct.Name, result.Data.First().Name);
    }

    [Fact]
    public async Task DeleteProduct_ShouldReturnSuccess()
    {
        
        int productId = 1;
        var existingProduct = new ProductsModel { Id = productId };

        _productsRepositoryMock.Setup(r => r.GetById(productId)).ReturnsAsync(existingProduct);
        _productsRepositoryMock.Setup(r => r.Delete(productId)).Returns(Task.CompletedTask);
        _productsRepositoryMock.Setup(r => r.GetAll()).ReturnsAsync(new List<ProductsModel>());

        var result = await _productsService.DeleteProduct(productId);

        Assert.True(result.Status);
    }
}
