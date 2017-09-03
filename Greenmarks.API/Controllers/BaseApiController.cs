using System.Web.Http;

namespace Greenmarks.API.Controllers
{
    public class BaseApiController<T> : ApiController where T : class, new()
    {
        public BLL.BaseService<T> BllService { get; set; }

        public int Edit(T entity)
        {
            return BllService.Edit(entity);
        }

        public T Add(T entity)
        {
            return BllService.Add(entity);
        }

        public bool Delete(T entity)
        {
            return BllService.Delete(entity);
        }
    }
}
