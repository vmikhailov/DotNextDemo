using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DotNextRZD.PublicApi.Controllers
{
    public class ContentController : ApiController
    {
        //GET Menus
        //GET Menus/{menu}/Products

        //POST Orders - create order 
        //GETD Orders/Active - active orders 
        //DELETE Orders/{id} - remove order
        //GET Orders/{id}/items - items in order
        //POST Orders/{id}/items - add item to the order

        //POST Orders/{id}/Check - create
        //POST Orders/{id}/CheckCalculationRequest - make a request to POS to calculate  
        //POST Orders/{id}/CloseCheckRequests/

    }
}

namespace OldController
{
//    public interface IContentController
//    {
//        //Task<HttpResponseMessage> MenuList(MenuListRequest request);
//        //Task<HttpResponseMessage> MenuProducts(MenuProductsRequest request);
//        //Task<HttpResponseMessage> CreateCheck(CreateCheckRequest request); //wtf??
//        //Task<HttpResponseMessage> Order(OrderRequest request);
//        //Task<HttpResponseMessage> Calculate(CalculateRequest request);
//        Task<HttpResponseMessage> CalculateCheck(CalculateCheckRequest request);
//        Task<HttpResponseMessage> CloseCheck(CloseCheckRequest request);
//        Task<HttpResponseMessage> TakeOrdersByCheck(TakeOrdersByCheckRequest request);
//    }

//    public class ContentController
//    {
//        [HttpPost]
//        [ResponseType(typeof (MenuListResponse))]
//        [HttpPost]
//        [ResponseType(typeof (MenuProductsResponse))]
//        [HttpPost]
//        [ResponseType(typeof (CreateCheckResponse))]
//        [HttpPost]
//        [ResponseType(typeof (OrderResponse))]
//        [HttpPost]
//        [ResponseType(typeof (OrderResponse))]
//        [HttpPost]
//        [ResponseType(typeof (CalculateCheckResponse))]
//        [HttpPost]
//        [ResponseType(typeof (CloseCheckResponse))]
//        [HttpPost]
//        [ResponseType(typeof (TakeOrdersByCheckResponse))]
//        private
        
//    }
}