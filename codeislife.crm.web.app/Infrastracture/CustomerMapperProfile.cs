using AutoMapper;
using codeislife.crm.data.domain;
using codeislife.crm.web.app.Models;

namespace codeislife.crm.web.app.Infrastracture;

public class CustomerMapperProfile : Profile
{
    public CustomerMapperProfile()
    {
        CreateMap<Customer, CustomerModel>()
            .ForMember(p => p.LeadCount, o => o.MapFrom(m => m.Leads.Count))
            .ForMember(p => p.ContactCount, o => o.MapFrom(m => m.CustomerContacts.Count));

        CreateMap<CustomerModel, Customer>();

        CreateMap<CustomerCreateModel, Customer>();

        CreateMap<Customer, CustomerUpdateModel>().ReverseMap();
            //.ForMember(m=> m.CreatedDate, o=> o.MapFrom(e=> e.CreatedDateUtc))
            //.ReverseMap()
            //.ForMember(p => p.CreatedDateUtc, o => o.MapFrom(m => m.CreatedDate));
    }
}
