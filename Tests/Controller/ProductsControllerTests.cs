using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductHub_API.Controllers;
using ProductHub_API.Services.Interfaces;
using ProductHub_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductsControllerTests
{
    private readonly ProductsController _controller;
    private readonly Mock<IProductsService> _serviceMock;

    public ProductsControllerTests()
    {
        _serviceMock = new Mock<IProductsService>();
        _controller = new ProductsController(_serviceMock.Object);
    }

    [Fact]
    public async Task GetAll_ShouldReturnProducts()
    {
        
        var products = new List<ProductsModel>
        {
            new ProductsModel { Id = 1, Name = "Energia Residencial Convencional" },
            new ProductsModel { Id = 2, Name = "Energia Híbrida" }
        };

        _serviceMock.Setup(s => s.GetAllProducts()).ReturnsAsync(new ResponseModel<IEnumerable<ProductsModel>>
        {
            Data = products,
            Status = true
        });

        var result = await _controller.GetAllProducts();

        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var response = Assert.IsType<ResponseModel<IEnumerable<ProductsModel>>>(okResult.Value);

        Assert.True(response.Status);
        Assert.Equal(2, response.Data.Count());
    }
   


}
