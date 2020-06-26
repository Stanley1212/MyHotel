using AutoMapper;
using MyHotel.Repository.Interfaces;
using MyHotel.Services.Interfaces;
using MyHotel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.Services
{
    public class ReceptionsService : IReceptionsService
    {
        private IReceptionsRepository _ReceptionsRepository;
        private IMapper _Mapper;

        public ReceptionsService(IReceptionsRepository receptionsRepository,IMapper mapper)
        {
            _ReceptionsRepository = receptionsRepository;
            _Mapper = mapper;
        }
        public IEnumerable<ReceptionsViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ReceptionsViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(ReceptionsViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ReceptionsViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
