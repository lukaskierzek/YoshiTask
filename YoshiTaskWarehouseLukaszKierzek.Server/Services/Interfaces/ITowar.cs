using System.Threading.Tasks;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Services.Interfaces
{
    public interface ITowar
    {
        Task<IEnumerable<Towar>> GetAllTowar();
        Task<Towar> GetTowarById(int id);
        Task<Towar> PostTowar(Towar towar);
        Task<Towar> PutTowar(Towar towar);
        Task<Towar> FindTowarToDelete(int id);
        Task<Towar> DeleteTowar(Towar towar);
        bool AnyTowar(int id);
    }
}
