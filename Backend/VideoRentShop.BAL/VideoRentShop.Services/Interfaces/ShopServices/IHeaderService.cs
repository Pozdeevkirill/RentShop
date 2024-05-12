using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Public;
using VideoRentShop.HttpModels.Responses;
using VideoRentShop.HttpModels.ViewObjects;
using VideoRentShop.HttpModels.ViewObjects.Shop;

namespace VideoRentShop.Services.Interfaces.ShopServices
{
	public interface IHeaderService : IService
	{
		IdWithNameVo CreateHeader(CreateHeaderRequest request);

		HeaderVo GetActiveHeader();

		PaginationResponse<HeaderVo> GetHeaders(PaginationRequest request);

		void Remove(Guid id);

		void SetActive(Guid id);
	}
}
