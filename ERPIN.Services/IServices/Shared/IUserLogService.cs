using ERPIN.Services.Models;

namespace ERPIN.Services.IServices.Shared;
public interface IUserLogService
{
    Task LogUserActivityAsync(CreateUserLog userlog);

}
