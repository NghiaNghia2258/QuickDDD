using WebApi.Domain.Models;

namespace WebApi.Domain.Abstractions.Repository;

public interface ITeacherRepository
{
    Task<bool> Create(Teacher model);
    Task<int> GetOrdinalNumberOfCurrentYear();
}
