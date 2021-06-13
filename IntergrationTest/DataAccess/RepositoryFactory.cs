using System;
using Core;
using IntergrationTest.Core.Repositories;

namespace DataAccess
{
    public class RepositoryFactory : IRepositoryFactory
    {
        public T Create<T>(IUintOfWork unitOfWork) where T : class
        {
             if (typeof(T) == typeof(IFileRepository))
            {
                return new FileRepository(unitOfWork as FileSharingContext) as T;
            }
            throw new Exception("respository not support");
        }
    }
}