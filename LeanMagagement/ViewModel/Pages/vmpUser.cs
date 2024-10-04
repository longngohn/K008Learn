using LeanMagagement.CLasses;
using LeanMagagement.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanMagagement.ViewModel.Pages
{
    public class vmpUser :PropertyChangedBase
    {
        private ObservableRangeCollection<clUser> _userList = new ObservableRangeCollection<clUser>();

        public ObservableRangeCollection<clUser> UserList
        {
            get { return _userList; }
            set { _userList = value; OnPropertyChanged(); }
        }



    }
}
