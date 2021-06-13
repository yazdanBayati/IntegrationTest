using System;
using Core;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class EntityFrameworkFactory : IUnitOfWorkFactory
    {
       private DbConfig _config;
       public EntityFrameworkFactory(DbConfig config)
       {
           this._config = config;
       }
        public IUintOfWork Create()
        {
            return new FileSharingContext(this._config);
        }

        public IUintOfWork Create(string connStr)
        {
            throw new NotImplementedException();
        }
    }
}
