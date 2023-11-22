using BmgMultipleNumber.Api.Controllers;
using BmgMultipleNumber.Api.Models;
using BmgMultipleNumber.Application.Interfaces;
using BmgMultipleNumber.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Moq;

namespace BmgMultipleNumber.Tests;

public class MultipleNumberTests
{
    [Fact]
    public void MultipleNumber_ListaVazia_BadRequestReturn()
    {
        // Arrange
        var numbers = new List<long>();
        var request = new MultipleNumberRequest();
        request.Numbers = numbers;

        var mockService = new Mock<IMultipleNumberService>();

        var controller = new MultipleNumberController(mockService.Object);

        mockService
            .Setup(service => service.CalcMultipleNumber(numbers, 11))
            .Returns(CalcMultipleNumberEmpty(numbers, 11));

        // Act
        var result = controller.CalcMultipleNumber(request).Result;
        var viewResult = Assert.IsType<BadRequestObjectResult>(result);

        // Assert
        Assert.Equal("Lista vazia", viewResult.Value);

    }

    [Fact]
    public void MultipleNumber_ValorNegativo_BadRequestReturn()
    {
        // Arrange
        var numbers = new List<long>() { 11, 13, 10, -1, -9 };
        var request = new MultipleNumberRequest();
        request.Numbers = numbers;

        var mockService = new Mock<IMultipleNumberService>();

        var controller = new MultipleNumberController(mockService.Object);

        mockService
            .Setup(service => service.CalcMultipleNumber(numbers, 11))
            .Returns(CalcMultipleNumberEmpty(numbers, 11));

        // Act
        var result = controller.CalcMultipleNumber(request).Result;
        var viewResult = Assert.IsType<BadRequestObjectResult>(result);

        // Assert
        Assert.Equal("A lista não pode conter número negativo", viewResult.Value);
    }

    [Fact]
    public void MultipleNumber_ListaCalculada_Success()
    {
        // Arrange
        var numbers = new List<long>() { 11, 13, 10, 33};
        var request = new MultipleNumberRequest();
        request.Numbers = numbers;

        var mockService = new Mock<IMultipleNumberService>();

        var controller = new MultipleNumberController(mockService.Object);

        mockService
            .Setup(service => service.CalcMultipleNumber(numbers, 11))
            .Returns(CalcMultipleNumberEmpty(numbers, 11));

        // Act
        var result = controller.CalcMultipleNumber(request).Result;
        var viewResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<MultipleNumberResponse>(viewResult.Value);

        // Assert
        Assert.Equal(numbers.Count, model.Result.Count);

    }

    public List<MultipleNumberEntity> CalcMultipleNumberEmpty(List<long> numbers, long number)
    {
        List<MultipleNumberEntity> list = new List<MultipleNumberEntity>();
        list.Add(new MultipleNumberEntity() { Number = 11, IsMultiple = true });
        list.Add(new MultipleNumberEntity() { Number = 13, IsMultiple = false });
        list.Add(new MultipleNumberEntity() { Number = 10, IsMultiple = false });
        list.Add(new MultipleNumberEntity() { Number = 33, IsMultiple = true });

        return list;
    }
}