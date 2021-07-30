using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModel
{
    public class SCRN0001ViewModel
    {

        //暫定的にｊ

        ErrorMessageModel j = new ErrorMessageModel();

        public string Message
        {
            set { this.Message = j.errorMessage[1]; }
            get { return this.Message; }
        }

    }
}

