using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHotel.ViewModel.Users
{
    public class UserListViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string FullName { get; set; }
    }
}
