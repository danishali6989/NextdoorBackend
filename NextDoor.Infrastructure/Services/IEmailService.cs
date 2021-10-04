using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NextDoor.Infrastructure.Services
{
    public interface IEmailService
    {
        // Task SendAsync(string email, string subject, string mailBody);
        // Task SendEmail(string receiver, string subject, string message);
        Task SendAsync(string receiver, string senderName, string senderEmail, string subject, string mailBody);

        Task SendWithAttachmentAsync(string email, string subject, string mailBody, string path);

        //  Task<UserManagement.Dtos.UserLogin.UserDetailDto>GeneratePasswordResetTokenAsync(string email);


    }
}
