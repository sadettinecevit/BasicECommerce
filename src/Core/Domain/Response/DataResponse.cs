using BasicECommerce.DAL.Entities.Abstract;

namespace BasicECommerce.DAL.Response
{
    public class DataResponse<T> : BaseResponse where T : class, IEntity ,new()
    {
        public T Data { get; set; }
    }
}
