using ERPIN.Domain.Entities.PR;
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
        // Response 
        config.NewConfig<SLInvoice, SLInvoiceResponse>();
        config.NewConfig<SLInvoiceDetail, SLInvoiceDetailResponse>();
        config.NewConfig<SLReturn, SLReturnResponse>();
        config.NewConfig<SLReturnDetail, SLReturnDetailResponse>();
        config.NewConfig<PRInvoice, PRInvoiceResponse>();
        config.NewConfig<PRInvoiceDetail, PRInvoiceDetailResponse>();
        config.NewConfig<PRReturn, PRReturnResponse>();
        config.NewConfig<PRReturnDetail, PRReturnDetailResponse>();

        // Request 
        config.NewConfig<CreateSLInvoice, SLInvoice>();
        config.NewConfig<CreateSLInvoiceDetail, SLInvoiceDetail>();
        config.NewConfig<CreateSLReturn, SLReturn>();
        config.NewConfig<CreateSLReturnDetail, SLReturnDetail>();
        config.NewConfig<CreatePRInvoice, PRInvoice>();
        config.NewConfig<CreatePRInvoiceDetail, PRInvoiceDetail>();
        config.NewConfig<CreatePRReturn, PRReturn>();
        config.NewConfig<CreatePRReturnDetail, PRReturnDetail>();

    }
}
