using Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace Services.Controllers
{
    public abstract class BaseDMSController : ControllerBase
    {
        public BaseDMSController(IUnitOfWorkFactory unitOfWorkFactory, IRepositoryFactory repoFactory)
        {
            this._unitOfWorkFactory = unitOfWorkFactory;
            this._repoFactory = repoFactory;
        }
        protected IUnitOfWorkFactory _unitOfWorkFactory;
        protected IRepositoryFactory _repoFactory;
}
}