using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILastFiveProductsRepository
    {
        Task<List<ResultLastFiveProductWithCategoryDto>> GetLastFiveProductAsync(int id);

    }
}
