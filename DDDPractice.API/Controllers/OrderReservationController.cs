using DDDPractice.Application.Shared;
using Microsoft.AspNetCore.Mvc;

namespace DDDPractice.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderReservationController: ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = Result.Success("",200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            return BadRequest(e.Message);
        } 
    }

    [HttpDelete]
    public async Task<IActionResult> Delete()
    {
        try
        {
            var result = Result.Success("",200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            return BadRequest(e.Message);
        } 
    }
    
    [HttpPost]
    public async Task<IActionResult> Create()
    {
        try
        {
            var result = Result.Success("",200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            return BadRequest(e.Message);
        } 
    }
    
    [HttpPut]
    public async Task<IActionResult> Update()
    {
        try
        {
            var result = Result.Success("",200);
            return StatusCode(result.StatusCode, result);
        }
        catch (Exception e)
        {   
            return BadRequest(e.Message);
        } 
    } 
}