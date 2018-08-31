using System.Collections.Generic;
using System.Linq;
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Plantilla.Controllers;

namespace Prog_Areas_Plantilla.Controllers
{
    public static class Usuario_Controller
    {
        public static Usuario FindUsuario(string username)
        {
            using (var db = new DB_PLANTILLA())
            {
                return db.GetSingleRecord<Usuario>(u => u.username == username);
            }
        }

        public static List<Usuario> GetAllUsuarios()
        {
            using (var db = new DB_PLANTILLA())
            {
                return db.GetAllRecords<Usuario>();
            }
        }

        public static Usuario InsertUsuario(string username, string password)
        {
            using (var db = new DB_PLANTILLA())
            { 
                if (!GetAllUsuarios().Any())
                {
                    var _newUser = new Usuario() { username = "ja.gonzalez", password = "noAccess", access_Level = 3 };
                    db.AddElemento(_newUser.GetType(), _newUser);
                }
                
                if (FindUsuario(username) == null)
                {
                    var _newUser = new Usuario() { username = username, password=password, access_Level = 0 };
                    db.AddElemento(_newUser.GetType(), _newUser);
                    return _newUser;
                }
                else
                {
                    return FindUsuario(username);
                }
            }
        }

        public static Usuario UpdateUser(Usuario user)
        {
            using (var db = new DB_PLANTILLA())
            {
                var result = db.Usuario.FirstOrDefault(u => u.username == user.username);
                if (result != null)
                {
                    result.access_Level = user.access_Level;
                    db.SaveChanges();
                    return result;
                }
                else
                {
                    return result;
                }
            }
        }

        public static Usuario Autenticate(string username, string password)
        {
            using (var db = new DB_PLANTILLA())
            {
                if (!db.GetAllRecords<Usuario>().Any())
                {
                    var _newUser = new Usuario() { username = "ja.gonzalez", password = "noAccess", access_Level = 3 };
                    db.AddElemento(_newUser.GetType(), _newUser);
                }

                var result = db.GetSingleRecord<Usuario>(u => u.username == username && u.password == password);
                return result;
            }
        }

        
    }
}
