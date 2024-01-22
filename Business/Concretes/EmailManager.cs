// EmailManager.cs
using Business.Abstracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

public class EmailManager : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailManager(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ForgetPassword(string toEmail)
    {
        try
        {
            var emailConfig = _configuration.GetSection("MailSettings");
            string smtpServer = emailConfig["Server"];
            int port = int.Parse(emailConfig["Port"]);
            string senderEmail = emailConfig["SenderEmail"];
            string senderPassword = emailConfig["Password"];

            using (SmtpClient client = new SmtpClient(smtpServer))
            {
                client.Port = port;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.EnableSsl = true;

                using (MailMessage message = new MailMessage(senderEmail, toEmail))
                {
                    client.Send(message);
                }
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"E-posta gönderme hatası: {ex.Message}");
        }
    }

    public void SendEmail(string fromEmail, string fullName, string subject, string body)
    {
        try
        {
            var emailConfig = _configuration.GetSection("MailSettings");
            string smtpServer = emailConfig["Server"];
            int port = int.Parse(emailConfig["Port"]);
            string senderEmail = emailConfig["SenderEmail"];
            string senderPassword = emailConfig["Password"];

            using (SmtpClient client = new SmtpClient(smtpServer))
            {
                client.Port = port;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                client.EnableSsl = true;

                using (MailMessage message = new MailMessage(fromEmail, senderEmail, subject, body))
                {
                    client.Send(message);
                }
            }
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"E-posta gönderme hatası: {ex.Message}");
        }
    }
}