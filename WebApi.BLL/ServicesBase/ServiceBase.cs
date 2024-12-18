using AutoMapper;
using Microsoft.Extensions.Configuration;
using WebApi.BLL.ServicesBase.Interface;
using WebApi.Domain.Abstractions;

namespace WebApi.BLL.ServicesBase
{
	public abstract class ServiceBase: IServiceBase
	{
		protected readonly IUnitOfWork _unitOfWork;
		protected readonly IMapper _mapper;
		protected readonly IConfiguration _config;

		protected ServiceBase(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration config)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_config = config;
		}
	}
}
