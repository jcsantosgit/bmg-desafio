using BmgMultipleNumber.Api.Models;
using BmgMultipleNumber.Api.Utils;
using BmgMultipleNumber.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BmgMultipleNumber.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MultipleNumberController : ControllerBase
{
    private readonly ILogger<MultipleNumberController> _logger;
    private readonly IMultipleNumberService _service;

    public MultipleNumberController(ILogger<MultipleNumberController> logger, IMultipleNumberService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpPut("calc-multiple-number")]
    public async Task<IActionResult> CalcMultipleNumber(MultipleNumberRequest request)
    {
        try
        {
            request.AreValidNumbers();
            var entities = _service.CalcMultipleNumber(request.Numbers, 11);
            var models = MultipleNumberModelView.ParseToModels(entities);
            return Ok(new MultipleNumberResponse(models));
        }
        catch(EmptyListException ex)
        {
            _logger.LogInformation(ex.Message);
            return BadRequest(ex.Message);            
        }
        catch(NegativeNumberException ex)
        {
            _logger.LogInformation(ex.Message);
            return BadRequest(ex.Message);            
        }        
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

