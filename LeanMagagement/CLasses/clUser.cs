using LeanMagagement.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeanMagagement.CLasses
{
    public class clUser : PropertyChangedBase
    {

        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged(); }
        }
        private string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; OnPropertyChanged(); }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; OnPropertyChanged(); }
        }

        private DateTime? _DateOfBirth;
        public DateTime? DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; OnPropertyChanged(); }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; OnPropertyChanged(); }
        }

        private byte[] _Photo;

        public byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; OnPropertyChanged(); }
        }

    }
}
