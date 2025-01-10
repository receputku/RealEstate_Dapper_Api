using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly ILastFiveProductsRepository _lastFiveProductsRepository;

        public EstateAgentLastProductsController(ILastFiveProductsRepository lastFiveProductsRepository)
        {
            _lastFiveProductsRepository = lastFiveProductsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLastFiveProductAsync(int id) 
        {
            var values = await _lastFiveProductsRepository.GetLastFiveProductAsync(id);
            return Ok(values);
        }
    }
}
