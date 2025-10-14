using ERPIN.Domain.Entities.SH;
using ERPIN.Domain.IRepositories;
using ERPIN.Infrastructure.Context;

namespace ERPIN.Infrastructure.Repositories;
public class UserLogRepository : Repository<UserLog> ,IUserLogRepository
{
    public UserLogRepository(AppDbContext context) : base(context)
    {
    }
}
