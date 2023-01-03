using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HumanResourcesWpfApp.Models
{
    public class Login : IDataErrorInfo
    {
        public string login { get; set; }
        public string password { get; set; }



        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(login):

                        if (string.IsNullOrWhiteSpace(login))
                        {
                            Error = "Pole login jest wymagane.";

                        }
                        else
                        {
                            Error = string.Empty;
                        }
                        break;

                    default:
                        break;

                }
                return Error;

            }

        }

        public string Error { get; set; }
    }
}
