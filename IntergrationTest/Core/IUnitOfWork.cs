using System;
using System.Threading.Tasks;

namespace Core
{
    public interface IUintOfWork: IDisposable
    {
       void Start();
       Task StartAsync();
       // void SaveChanges();
        int Commit();

        Task<int> CommitAsync();
        int Commit(int userId);
        Task<int> CommitAsync(int userId);

      //  void Rollback();
    }
}