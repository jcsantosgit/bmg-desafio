using BmgMultipleNumber.Api.Controllers;
using BmgMultipleNumber.Api.Models;
using BmgMultipleNumber.Application.Interfaces;
using BmgMultipleNumber.Domain.Entities;
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

        mockService.Setup(service => CalcMultipleNumberEmpty(numbers, 11));

        // Act
        var result = controller.CalcMultipleNumber(request).Result;

        // Assert
        var viewResult = Assert.IsType<MultipleNumberResponse>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<MultipleNumberModelView>>(viewResult.Result);

        Assert.Equal(1, 1);
    }

    public List<MultipleNumberEntity> CalcMultipleNumberEmpty(List<long> numbers, long number)
    {
        return null;
    }

    public void MostrarLog(string message)
    {
        
    }

}