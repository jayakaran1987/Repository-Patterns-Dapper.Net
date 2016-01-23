using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQuery.Web.Service.Interface
{
    public interface INotificationService
    {
        void SendEmailToSalesTeam(string body);
        void SendEmail(string to, string from, string host, string body, string subject);
    }
}
