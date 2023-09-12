using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Epam.API.Controllers
{
    public class TechController : BaseController
    {
        public TechController(CustomRestClient client) : base(client, Service.Tech)
        {
        }

        private const string AllTechResourse = "/objects";

        /// <summary>
        /// Gets list of Bibles from API
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// 
        public (RestResponse responce, T? Tech) GetTech<T>()
        {
            return Get<T>(AllTechResourse);
        }
    }
}
