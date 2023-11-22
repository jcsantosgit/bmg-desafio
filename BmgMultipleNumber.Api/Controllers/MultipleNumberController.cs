using BmgMultipleNumber.Api.Models;
using BmgMultipleNumber.Api.Utils;
using BmgMultipleNumber.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BmgMultipleNumber.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MultipleNumberController : ControllerBase
{
    private readonly IMultipleNumberService _service;

    public MultipleNumberController(IMultipleNumberService service)
    {
        _service = service;
    }

    [HttpPut("calc-multiple-number")]
    public async Task<IActionResult> CalcMultipleNumber(MultipleNumberRequest request)
    {
        try
        {
            if(request == null) throw new Exception("Parâmetro nulo");

            request.AreValidNumbers();
            
            var entities = _service.CalcMultipleNumber(request.Numbers, 11);
            var models = MultipleNumberModelView.ParseToModels(entities);
            return Ok(new MultipleNumberResponse(models));
        }
        catch(EmptyListException ex)
        {
            return BadRequest(ex.Message);            
        }
        catch(NegativeNumberException ex)
        {
            return BadRequest(ex.Message);            
        }        
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}

