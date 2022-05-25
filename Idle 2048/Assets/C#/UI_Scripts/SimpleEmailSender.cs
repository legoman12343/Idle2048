using System.Collections;
using System.ComponentModel;
using System.IO;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class SimpleEmailSender : MonoBehaviour
{
    public static EmailSettings emailSettings = new EmailSettings { SMTPClient = "", SMTPPort = 0, UserName = "", UserPass = "" };
    public struct EmailSettings
    {
        public string SMTPClient;
        public int SMTPPort;
        public string UserName;
        public string UserPass;
    }

    public static void Send(string to, string subject, string body, string attatchFile, Action<object, AsyncCompletedEventArgs> callback)
    {
        try
        {
            SmtpClient mailServer = new SmtpClient(emailSettings.SMTPClient, emailSettings.SMTPPort);
            mailServer.EnableSsl = true;
            mailServer.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.UserPass) as ICredentialsByHost;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
                return true;
            };
            MailMessage msg = new MailMessage(emailSettings.UserName, to);
            msg.Subject = subject;
            msg.Body = body;
            if (attatchFile != null && !attatchFile.Equals(""))
                if (File.Exists(attatchFile))
                    msg.Attachments.Add(new Attachment(attatchFile));
            mailServer.SendCompleted += new SendCompletedEventHandler(callback);
            mailServer.SendAsync(msg, "");

            Debug.Log("SimpleEmail: Sending Email.");
        }
        catch (Exception ex)
        {
            Debug.LogWarning("SimpleEmail: " + ex);
            callback("", new AsyncCompletedEventArgs(ex, true, ""));
        }
    }

}
