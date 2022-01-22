using MstNetCoreAPI.Filter;

namespace MstNetCoreAPI.Interface
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
