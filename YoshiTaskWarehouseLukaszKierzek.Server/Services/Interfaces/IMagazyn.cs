using Microsoft.AspNetCore.Mvc;
using YoshiTaskWarehouseLukaszKierzek.Server.Models;

namespace YoshiTaskWarehouseLukaszKierzek.Server.Services.Interfaces
{
    public interface IMagazyn
    {
        Task<IEnumerable<Magazyn>> GetAllMagazyn();
    }
}
