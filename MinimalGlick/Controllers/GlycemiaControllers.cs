using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalGlick.Models;
using MinimalGlick.Services;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace MinimalGlick.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GlycemiaControllers : ControllerBase
    {
        private readonly GlycemiaServices _glycemiaService;

        public GlycemiaControllers (GlycemiaServices glycemiaService) =>
            _glycemiaService = glycemiaService;

        
        [HttpGet("GetAll")]
        public async Task<List<Glycemia>> Get() =>
            await _glycemiaService.GetGlycemiasAsync();

        [HttpPost("Save")]
        public async Task<IActionResult> Post(Glycemia newMeasure)
        {
            await _glycemiaService.CreateMeasureAsync(newMeasure);

            return CreatedAtAction(nameof(Get), new { id = newMeasure.Id }, newMeasure);
        }
    }
}
