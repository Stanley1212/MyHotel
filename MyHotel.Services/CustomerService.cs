using AutoMapper;
using MyHotel.Domain;
using MyHotel.Repository.Interfaces;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Services
{
    public class CustomerService : ICustomerService
    {
        private ICustomerRepository _Repository;
        private IMapper _Mapper;

        public CustomerService(ICustomerRepository customerRepository,IMapper mapper)
        {
            _Repository = customerRepository;
            _Mapper = mapper;
        }

        public IEnumerable<CustomerViewModel> GetAll()
        {

            var List = _Mapper.Map<IEnumerable<CustomerViewModel>>(_Repository.GetAll());

            return List;
        }

        public CustomerViewModel GetById(int id)
        {
            return _Mapper.Map<CustomerViewModel>(_Repository.GetById(id));
        }

        public Task<int> Insert(CustomerViewModel model)
        {
            var modelToSave = _Mapper.Map<Customer>(model);
            modelToSave.CreateDate = DateTime.UtcNow;
            modelToSave.CreateUser = CommonExtension.Currentuser;

            return _Repository.Insert(modelToSave);
        }

        public Task<int> Update(CustomerViewModel model)
        {
            var Room = _Mapper.Map<Customer>(model);
            Room.UpdateDate = DateTime.UtcNow;
            Room.UpdateUser = CommonExtension.Currentuser;


            return _Repository.Update(Room);
        }
    }
}
