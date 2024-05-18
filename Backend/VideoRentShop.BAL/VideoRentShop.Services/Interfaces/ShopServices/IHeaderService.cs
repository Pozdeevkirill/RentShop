using VideoRentShop.HttpModels.Requests;
using VideoRentShop.HttpModels.Requests.Admin;
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

		HeaderVo GetHeader(Guid id);

		void Remove(Guid id);

		void SetActive(Guid id);

		void EditHeader(EditHeaderRequest request);
	}
}
