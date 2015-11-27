using System;
using System.Collections.Generic;
using System.Linq;
using SystranHorizonte.Models;
using SystranHorizonte.Repository.Ventas.Interfaces;
using System.Data.Entity;

namespace SystranHorizonte.Repository.Ventas.Datos
{
    public class CuentasReporsitory : MasterRepository, ICuentasReporsitory
    {
        public string EliminarCuentaUsuario(int idUser)
        {
            try
            {
                var elim = ObtenerCuentaPorId(idUser);

                Context.Accounts.Remove(elim);
                Context.SaveChanges();

                return "Eliminado Correctamente";
            }
            catch (Exception e)
            {
                return "No se puede eliminar. Error:" + e.Message;
            }
            
        }

        public string EliminarRol(int idrol)
        {
            try
            {
                var elim = ObtenerRolPorId(idrol);

                Context.Roless.Remove(elim);
                Context.SaveChanges();

                return "Eliminado Correctamente";
            }
            catch (Exception e)
            {
                return "No se puede eliminar. Error:" + e.Message;
            }
        }

        public string ModificarCuentaUsuario(Account user)
        {
            try
            {
                

                return "Modificado Correctamente";
            }
            catch (Exception e)
            {
                return "No puede ser modificar. Error:" + e.Message;
            }
        }

        public string ModificarRol(Roles rol)
        {
            try
            {
                Context.Entry(rol).State = EntityState.Modified;
                Context.SaveChanges();

                return "Modificado Correctamente";
            }
            catch (Exception e)
            {
                return "No puede ser modificar. Error:" + e.Message;
            }
        }

        public string NuevaCuentaUsuario(Account user)
        {
            try
            {
                Context.Accounts.Add(user);

                Context.SaveChanges();

                return "Guardado Correctamente";
            }
            catch (Exception e)
            {
                return "No puede ser guardado. Error:" + e.Message;
            }
        }

        public string NuevoRol(Roles rol)
        {
            try
            {
                Context.Roless.Add(rol);

                Context.SaveChanges();

                return "Guardado Correctamente";
            }
            catch (Exception e)
            {
                return "No puede ser guardado. Error:" + e.Message;
            }
        }

        public Account ObtenerCuentaPorCriterio(string criterio)
        {
            try
            {
                //Falta definir que va
                return new Account();
            }
            catch (Exception e)
            {
                return new Account();
            }
        }

        public Account ObtenerCuentaPorId(int iduser)
        {
            try
            {
                return Context.Accounts.Find(iduser);
            }
            catch (Exception e)
            {
                return new Account();
            }
        }

        public IEnumerable<Account> ObtenerCuentasPorRol(int rol)
        {
            try
            {
                var query = from p in Context.DetalleUsuarios
                            .Include("Account")
                            .Include("Roles")
                            where p.Roles.Id.Equals(rol)
                            select p;

                List<Account> cuentas = new List<Account>();

                var idcuenta = 0;

                foreach (var item in query)
                {
                    if (idcuenta != item.Account.Id)
                    {
                        cuentas.Add(item.Account);
                    }
                    
                    idcuenta = item.Account.Id;
                }
                
                return cuentas;
            }
            catch (Exception e)
            {
                return new List<Account>();
            }
        }

        public IEnumerable<Roles> ObtenerRolesPorCriterio(string criterio)
        {
            try
            {
                var query = from p in Context.Roless
                            where p.Nombre.ToUpper().Contains(criterio.ToUpper()) || p.Comentario.ToUpper().Contains(criterio.ToUpper())
                            select p;
                
                return query;
            }
            catch (Exception e)
            {
                return new List<Roles>();
            }
        }

        public Roles ObtenerRolPorId(int idrol)
        {
            try
            {
                return Context.Roless.Find(idrol);
            }
            catch (Exception e)
            {
                return new Roles();
            }
        }
    }
}
