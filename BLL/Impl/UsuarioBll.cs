using BLL.Interface;
using DAL;
using DAL.Interface;
using Model;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Util;

namespace BLL
{
    public class UsuarioBll : IUsuarioBll
    {
        private IUsuarioDal _usuarioDal;

        public UsuarioBll()
        {
            _usuarioDal = new UsuarioDal();
        }

        #region CRUD

        public void Atualizar(Users usuario)
        {
            if (null != usuario)
            {
                _usuarioDal.Update(usuario);
                _usuarioDal.SaveChanges();
            }
        }

        public void Excluir(Users usuario)
        {
            if (null != usuario)
            {
                _usuarioDal.Update(usuario);
                _usuarioDal.SaveChanges();
            }
        }

        public IQueryable<Users> Listar()
        {
            return _usuarioDal.GetAll();
        }
        
        public Users Obter(string id)
        {
            return _usuarioDal.Find(u => u.Id == id);
        }

        public void Salvar(Users usuario)
        {
            if (null != usuario)
            {
                _usuarioDal.Update(usuario);
                _usuarioDal.SaveChanges();
            }
        }

        #endregion

        #region ROTINA DE AUTENTICACAO

        public bool Autenticar(Users usuario)
        {
            return true; // _usuarioDal.Autenticar(usuario);
        }

        public bool RecuperarSenhaPorEmail(Users usuario)
        {
            bool retorno = false;

            usuario = _usuarioDal.Find(u => u.Email.ToLower().Equals(usuario.Email.ToLower()));

            if (usuario != null)
            {
                retorno = EnviarSenha(usuario);
            }

            return retorno;
        }


        private bool EnviarSenha(Users usuario)
        {
            bool retorno = false;

            try
            {
                MailMessage mailMessage = new MailMessage();
                MailAddress mailAddress = new MailAddress(usuario.Email + " <email@mainsoftware.com.br>");

                mailMessage.To.Add(usuario.Email);
                mailMessage.Bcc.Add("ericosouza87@outlook.com");

                mailMessage.Subject = "Recuperação de senha" + DateTime.Now.ToString(" - dd/MM/yyyy - HH:mm");
                mailMessage.From = mailAddress;
                mailMessage.ReplyToList.Add(usuario.Email);
                mailMessage.Priority = MailPriority.High;
                mailMessage.IsBodyHtml = true;


                StringBuilder mensagem = new StringBuilder();
                mensagem.Append("<h3> Solicitação de envio de senha </h3>").Append(Environment.NewLine);
                mensagem.Append("<hr/>").Append(Environment.NewLine);
                mensagem.Append("<p><strong>Nome: </strong>" + usuario.UserName + "</p>").Append(Environment.NewLine);
                mensagem.Append("<p><strong>E-mail: </strong>" + usuario.Email + "</p>").Append(Environment.NewLine);
                mensagem.Append("<p><strong>Segue abaixo a sua senha:</strong></p>").Append(Environment.NewLine);
                mensagem.Append("<p><strong>Senha: </strong>" + usuario.PasswordHash + "</p>").Append(Environment.NewLine);

                mailMessage.Body = mensagem.ToString();

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Port = 587;
                smtpClient.Host = "smtp.mainsoftware.com.br";
                smtpClient.Credentials = new System.Net.NetworkCredential("email@mainsoftware.com.br", "Mvtmjsunp@87");
                smtpClient.Send(mailMessage);
                mailMessage.Dispose();
                retorno = true;
            }
            catch (Exception e)
            {
                //Log.Error("Erro ao enviar e-mail de recuperação de senha: " + e.Message);
                //Log.Error(e);
                System.Diagnostics.Debug.Write(e);
                retorno = false;
            }

            return retorno;
        }

        #endregion
    }
}
