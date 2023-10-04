using BODEGA_SOLORZANO.Datos;
using BODEGA_SOLORZANO.Models.BoSolor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;//Validaciones
using System.Text.RegularExpressions;



namespace BODEGA_SOLORZANO.LogicaNegocio
{
    public class logUsuario 
    {
        private string errorMessage = string.Empty;
        
        private static readonly logUsuario _instancia = new logUsuario();
        public static logUsuario Instancia
        {
            get { return _instancia; }
        }

        #region CRUD
        public bool CrearUsuario(entUsuario user, out List<string> lsErrores)
        {
            try
            {
                bool isValid = Validation.TryValidateEntityMsj(user, out lsErrores);
                if (!isValid)
                    return false;

                user.Pass = Recursos.GetSHA256(user.Pass);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return datUsuario.Instancia.CrearUsuario(user);
        }

        public List<entUsuario> ListarUsuarios()
        {
            return datUsuario.Instancia.ListarUsuarios();
        }
        public List<entUsuario> ListarAdministradores(string dato, string orden)
        {
            if (!string.IsNullOrEmpty(dato))
            {
                return datUsuario.Instancia.BuscarAdministrador(dato);
            }
            switch (orden)
            {
                case "asc":
                    return datUsuario.Instancia.OrdenarAdministradores(1);
                case "desc":
                    return datUsuario.Instancia.OrdenarAdministradores(0);
                default:
                    return datUsuario.Instancia.ListarAdministradores();
            }
        }

        // Método que devuelve una lista de entidades "Usuario" (clientes).
        // El parámetro "dato" se utiliza para buscar clientes por su nombre o correo electrónico.
        // El parámetro "orden" se utiliza para especificar la dirección de ordenamiento: "asc" para ascendente y "desc" para descendente.      

        public bool DeshabilitarUsuario(int id)
        {
            return datUsuario.Instancia.DeshabilitarUsuario(id);
        }
        public bool HabilitarUsuario(int id)
        {
            return datUsuario.Instancia.HabilitarUsuario(id);
        }
        #endregion

        #region Acceso Sistema
        public bool CrearSesionUsuario(string usuario, string correo, string password, out List<string> errores)
        {
            errores = new List<string>();

            if (ValidateUsuario(usuario) != string.Empty)
            {
                errores.Add(errorMessage);
            }

            if (ValidateCorreo(correo) != string.Empty)
            {
                errores.Add(errorMessage);
            }

            if (ValidatePassword(password) != string.Empty)
            {
                errores.Add(errorMessage);
            }

            if (errores.Count > 0)
            {
                return false;
            }

            try
            {
                entRoll r = new entRoll
                {
                    IdRoll = 2,
                };
                entUsuario u = new entUsuario
                {
                    UserName = usuario,
                    Correo = correo,
                    Pass = password,
                    Roll = r,
                };
                 
                // Encriptar clave e intentar crear el usuario
                u.Pass = Recursos.GetSHA256(u.Pass);
                return datUsuario.Instancia.CrearSesionUsuario(u);
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public entUsuario IniciarSesion(string dato, string contra)
        {
            entUsuario u = null;
            try
            {
                if (!(string.IsNullOrEmpty(dato) || string.IsNullOrEmpty(contra)))
                {
                    if (DateTime.Now.Hour > 24)
                    {
                        throw new Exception("No se puede ingresar despues de las 22:00 horas");
                    }
                    else
                    {
                        contra = Recursos.GetSHA256(contra);
                        u = datUsuario.Instancia.IniciarSesion(dato, contra);
                        if (u != null)// El usuario existe
                        { 
                            if (!u.Activo)
                            {
                                u = null;
                                throw new Exception("Usted ya no puede ingresar al sistema");
                            }

                        }
                        else
                        {
                            throw new Exception("´No tienes una cuenta con ese nombre");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
            return u;
        }

        private static string correoDestino = string.Empty;
        private static string codigoGenerado = string.Empty;

        #endregion

        #region Otros
        public List<entUsuario> BuscarUsuario(string dato)
        {
            return datUsuario.Instancia.BuscarUsuario(dato);
        }


        public List<entUsuario> BuscarAdministrador(string dato)
        {
            return datUsuario.Instancia.BuscarAdministrador(dato);
        }
        #endregion

        #region Validaciones
        public string ValidateUsuario(string usuario)
        {
            if (!Regex.IsMatch(usuario, @"^[a-zA-ZñÑ]{5,20}$"))
            {
                return errorMessage = "El nombre de usuario no es válido (Solo se aceptan de 5 a 20 letras).";
            }
            return string.Empty;
        }

        public string ValidateCorreo(string correo)
        {
            if (!Regex.IsMatch(correo, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                return errorMessage = "El correo electrónico no es válido (Solo se aceptan correos gmail).";
            }
            return string.Empty;

        }

        public string ValidatePassword(string password)
        {
            if (!Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-zA-Z])(?=.*[@#$%^&+=]).{8,}$"))
            {
                return errorMessage = "La contraseña no es válida (Debe contener al menos un número, una letra, un carácter especial y como mínimo 8 caracteres).";
            }
            return string.Empty;
        }
        #endregion
    }
}
