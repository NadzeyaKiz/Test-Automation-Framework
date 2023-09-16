using RestSharp;
using System.Threading.Tasks;
using TestAutomation.Epam.API.Models.RequestModels;

namespace TestAutomation.Epam.API.Controllers
{
    public class TechController : BaseController
    {
        public TechController(CustomRestClient client) : base(client, Service.Tech)
        {
        }

        private const string TechResource = "/objects";

        private const string SingleTechResource = "/objects/{0}";

        /// <summary>
        /// Request that receive all list of phones
        /// </summary>
        /// <typeparam name="T"><see cref="TechItemSingleResponseModel"/></typeparam>
        /// <returns>response typeof <see cref="RestResponse"/> and List of <see cref="TechItemSingleResponseModel"/></returns>
        public (RestResponse Response, T? TechModel) GetTechItems<T>()
        {
            return Get<T>(TechResource);
        }

        /// <summary>
        /// Request that receive single tech object by id
        /// </summary>
        /// <typeparam name="T"><see cref="TechItemSingleResponseModel"/></typeparam>
        /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemSingleResponseModel"/></returns>
        public (RestResponse Response, T? TechModel) GetSingleTechItem<T>(string techId)
        {
            return Get<T>(string.Format(SingleTechResource, techId));
        }

        /// <summary>
        /// Request that posts new tech object
        /// </summary>
        /// <typeparam name="T"><see cref="TechItemSingleResponseModel"/></typeparam>
        /// <returns>response typeof <see cref="RestResponse"/> and <see cref="TechItemSingleResponseModel"/></returns>
        public (RestResponse Response, T? TechModel) AddTechItem<T>(TechItemRequestModel model)
        {
            return Post<T, TechItemRequestModel>(TechResource, model);
        }

        /// <summary>
        /// Request that delete single tech object by id
        /// </summary>
        /// <param name="techId"><see cref="TechItemSingleResponseModel"/></param>
        /// <returns>response typeof <see cref="RestResponse"/></returns>
        public RestResponse  DeleteSingleCreatedItem (string techId)
        {
            return Delete(string.Format(SingleTechResource, techId));            
        }

        /// <summary>
        /// Request that partially update object by id
        /// </summary>
        /// <typeparam name="T"><see cref="TechItemSingleResponseModel"/></typeparam>        
        /// <returns>response typeof <see cref="RestResponse"/></returns>
        public (RestResponse Response, T? TechModel) UpdateTechItem<T>(object model, string techId)
        {
            return Patch<T, TechItemRequestModel>(string.Format(SingleTechResource, techId), model);
        }
    }
}





