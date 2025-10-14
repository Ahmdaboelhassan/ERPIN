using ERPIN.Domain.Entities.SH;
using ERPIN.Domain.IRepositories;
using ERPIN.Services.Extinctions;
using ERPIN.Services.IServices.Shared;
using ERPIN.Services.Models;
using Microsoft.AspNetCore.Http;


namespace ERPIN.Services.Services.Shared;
public class UserLogService : IUserLogService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IHttpContextAccessor _httpContext;

    public UserLogService(IUnitOfWork unitOfWork, IHttpContextAccessor httpContext)
    {
        _unitOfWork = unitOfWork;
        _httpContext = httpContext;
    }

    public async Task LogUserActivityAsync(CreateUserLog userlog)
    {
        var userId = _httpContext.HttpContext.GetUserId();

        var newLog = new UserLog
        {
            Action = userlog.Action,
            Notes = userlog.Notes,
            Code = userlog.Code,
            Process = userlog.Process,
            Time = DateTime.UtcNow,
            UserId = userId,
        };

        await _unitOfWork.UserLogs.AddAsync(newLog);
        await _unitOfWork.SaveChangesAsync();
    }
}
