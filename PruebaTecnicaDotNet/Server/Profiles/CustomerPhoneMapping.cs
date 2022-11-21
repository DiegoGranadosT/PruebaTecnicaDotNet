using AutoMapper;
using PruebaTecnicaDotNet.Server.Models;
using PruebaTecnicaDotNet.Shared;

namespace PruebaTecnicaDotNet.Server.Profiles
{
    public class CustomerPhoneMapping : Profile
    {
        public CustomerPhoneMapping()
        {
            CreateMap<CustomersPhones, CustomerPhoneViewModel>().ReverseMap();

            CreateMap<CustomerPhoneViewModel, CustomersPhones>().ReverseMap();
        }
    }
}
