using BasicECommerce.DAL.Entities.Abstract;

namespace BasicECommerce.DAL.Response
{
    public class ListDataResponse<T> : BaseResponse where T : class, IEntity ,new()
    {
        public IEnumerable<T> Data { get; set; }
    }
}
