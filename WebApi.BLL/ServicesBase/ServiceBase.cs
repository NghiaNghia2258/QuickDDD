using AutoMapper;
using WebApi.BLL.ServicesBase.Interface;
using WebApi.Domain.Abstractions;

namespace WebApi.BLL.ServicesBase
{
    public abstract class ServiceBase: IServiceBase
	{
		protected readonly IUnitOfWork _unitOfWork;
		protected readonly IMapper _mapper;

		protected ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
	}
}
