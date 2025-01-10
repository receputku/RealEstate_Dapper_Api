using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgentDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLastFiveProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentLastFiveProductComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44356/api/EstateAgentLastProducts?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultLastFiveProductWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
