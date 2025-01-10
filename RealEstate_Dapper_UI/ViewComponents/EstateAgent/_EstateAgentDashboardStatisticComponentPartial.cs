using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginService.GetUserId;
            #region İstatistik1 - Toplam İlan Sayısı
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44356/api/EstateAgentDashboardStatistic/AllProductCount");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData1;
            #endregion
            #region İstatistik2 - Emlakçının Toplam İlan Sayısı
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44356/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id=" + id);
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.employeeByProductCount = jsonData2;
            #endregion
            #region İstatistik3 - Aktif İlan Sayısı
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44356/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id=" + id);
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusTrue = jsonData3;
            #endregion
            #region İstatistik4 - Pasif İlan Sayısı
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44356/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id=" + id);
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.productCountByEmployeeByStatusFalse = jsonData4;
            #endregion           
            return View();
        }
    }
}
