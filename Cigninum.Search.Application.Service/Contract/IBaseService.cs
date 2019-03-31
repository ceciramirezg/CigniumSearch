using System.Threading.Tasks;

namespace Cigninum.Search.Application.Service
{
    public interface IBaseService
    {
        Task<long> GetTotal(string text, string searcherName);
    }
}
