using ERPIN.Domain.Entities.SL;
using ERPIN.Services.DTOs.Request;
using ERPIN.Services.DTOs.Response;
using Mapster;
using Microsoft.AspNet.Identity;

namespace ERPIN.Services.Config;
public class MappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<SlInvoice, SLInvoiceResponse>();
        config.NewConfig<SlInvoiceDetail, SLInvoiceDetailResponse>();

        config.NewConfig<CreateSLInvoice, SlInvoice>();
        config.NewConfig<CreateSLInvoiceDetail, SlInvoiceDetail>();

    }
}
