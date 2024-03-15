using System.Threading.Tasks;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Services.Interfaces
{
    public interface IDostawca
    {
        Task<IEnumerable<Dostawca>> GetAllDostawca();
        Task<Dostawca> GetDostawcaById(int id);
        Task<Dostawca> PostDostawca(Dostawca dostawca);
        Task<Dostawca> PutDostawca(Dostawca dostawca);
        Task<Dostawca> FindDostawcaToDelete(int id);
        Task<Dostawca> DeleteDostawca(Dostawca dostawca);
        bool AnyDostawca(int id);
    }
}
