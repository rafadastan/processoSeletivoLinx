using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLinx.Domain.Contracts.Repositories;
using ProjetoLinx.Domain.Contracts.Services;
using ProjetoLinx.Domain.Entities;

namespace ProjetoLinx.Domain.Services
{
    public class AddressDomainService : BaseDomainService<Address, Guid>,
        IAddressDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.AddressRepository)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
