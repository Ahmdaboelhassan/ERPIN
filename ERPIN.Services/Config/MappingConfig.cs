using ERPIN.Domain.Entities.PR;
using ERPIN.Domain.Entities.SL;
using ERPIN.Services.DTOs.Bases;
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
        config.NewConfig<SLReturn, SLReturnResponse>();
        config.NewConfig<PRInvoice, PRInvoiceResponse>();
        config.NewConfig<PRReturn, PRReturnResponse>();
 
        config.NewConfig<SLInvoiceDetail, InvoiceDetailResponseBase>()
            .Map(dest => dest.BarCode, src => src.Item.BarCode)
            .Map(dest => dest.itemName, src => src.Item.Name)
            .Map(dest => dest.itemNameEn, src => src.Item.NameEn)
            .Map(dest => dest.BarCode, src => src.Item.BarCode)
            .Map(dest => dest.Code, src =>  src.Item.Code);

        config.NewConfig<SLReturnDetail, InvoiceDetailResponseBase>()
            .Map(dest => dest.BarCode, src => src.Item.BarCode)
            .Map(dest => dest.itemName, src => src.Item.Name)
            .Map(dest => dest.itemNameEn, src => src.Item.NameEn)
            .Map(dest => dest.Code, src => src.Item.Code);

        config.NewConfig<PRInvoiceDetail, InvoiceDetailResponseBase>()
            .Map(dest => dest.BarCode, src => src.Item.BarCode)
            .Map(dest => dest.itemName, src => src.Item.Name)
            .Map(dest => dest.itemNameEn, src => src.Item.NameEn)
            .Map(dest => dest.Code, src => src.Item.Code);

        config.NewConfig<PRReturnDetail, InvoiceDetailResponseBase>()
            .Map(dest => dest.BarCode, src => src.Item.BarCode)
            .Map(dest => dest.itemName, src => src.Item.Name)
            .Map(dest => dest.itemNameEn, src => src.Item.NameEn)
            .Map(dest => dest.Code, src => src.Item.Code);
            

        // Request 
        config.NewConfig<CreateSLInvoice, SLInvoice>();
        config.NewConfig<CreateSLReturn, SLReturn>();
        config.NewConfig<CreatePRInvoice, PRInvoice>();
        config.NewConfig<CreatePRReturn, PRReturn>()
            .Map(dest => dest.ReturnDetails , src => src.InvoiceDetails);

        config.NewConfig<CreateInvoiceDetailsBase, SLInvoiceDetail>();
        config.NewConfig<CreateInvoiceDetailsBase, SLReturnDetail>();
        config.NewConfig<CreateInvoiceDetailsBase, PRInvoiceDetail>();
        config.NewConfig<CreateInvoiceDetailsBase, PRReturnDetail>();
            

    }
}
