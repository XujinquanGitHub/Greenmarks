using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Web.Http.Results;
using System.Web.Mvc;
using Greenmarks.Model;

namespace Greenmarks.API.Controllers
{
    public class ValuesController : BaseApiController<Model.bma_brands>
    {

        ValuesController()
        {
            BllService = new BLL.bma_brandsService();
        }

        // GET api/values
        public JsonResult<List<bma_brands>> Get()
        {
            var listData = BllService.LoadEntities(u => true).ToList();
            return Json(listData);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
