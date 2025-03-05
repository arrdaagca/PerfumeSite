using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.AbstractServices
{
    public interface IEmailService
    {
        void SendResetPasswordEmail(string toEmail, int userId);
    }
}
