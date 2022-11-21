using AutoMapper;
using PruebaTecnicaDotNet.Server.Models;
using PruebaTecnicaDotNet.Shared;

namespace PruebaTecnicaDotNet.Server.Profiles
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<Customers, CustomerViewModel>().ReverseMap();

            CreateMap<CustomerViewModel, Customers>().ReverseMap()
                .ForMember(x => x.CustomerPhones, b => b.MapFrom(s => s.CustomersPhones));
        }
    }
}
