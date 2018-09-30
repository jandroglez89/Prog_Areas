using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace Prog_Areas.Excepciones
{
    public static class Excepciones
    {
        const string _USERNAME = "ja.gonzalez";
        const string _PASSWORD = "Bouygues1";
        const string _DOMAIN = "HAVANADMN";
        const string _EMAILS = "ja.gonzalez@bouygues.cu";

        public static void EnviarCorreo(Exception e)
        {
            SmtpClient _client = new SmtpClient();
            NetworkCredential _networkCredential = new NetworkCredential(_USERNAME, _PASSWORD, _DOMAIN);
            MailMessage _message = new MailMessage();
            MailAddress _from = new MailAddress(_EMAILS);
            MailAddress _to = new MailAddress(_EMAILS);

            _client.Host = "HAVVCAS001.havana.intl.local";
            _client.UseDefaultCredentials = false;
            _client.Credentials = _networkCredential;
            _client.Timeout = (6 * 5 * 1000);

            _message.To.Add(_to);
            _message.From = _from;
            _message.Priority = MailPriority.High;
            _message.Subject = "Error Log: " + Program._autenticatedUser.username + " _ " + e.Source;
            _message.IsBodyHtml = true;
            _message.Body = e.Source + "<br>";
            _message.Body += "----------Message-----------<br>";
            _message.Body += e.Message.Replace("\r\n", "<br>") + "<br>";
            //_message.Body += "-------Inner Exception------<br>";
            //_message.Body += e.InnerException.ToString().Replace("\r\n", "<br>");
            _message.Body += "---------Stacktrace---------<br>";
            _message.Body += e.StackTrace.Replace("\r\n", "<br>");
            _message.Body += e.TargetSite + "<br>";
            _message.Body += "---------Extra---------<br>";
            _message.Body += "Usuario: " + Program._autenticatedUser.username + "<br>";
            _message.Body += "Fecha: " + DateTime.Now.ToString("yyyy/MM/dd") + "<br>";
            _message.Body += "Hora: " + DateTime.Now.ToString("hh:mm:ss") + "<br>";

            _client.Send(_message);
            System.Windows.Forms.MessageBox.Show("Ha ocurrido un error, se ha enviado un correo con los detalles al equipo BIM", "Error en la aplicación", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
