using System;
using System.Collections.Generic;
using SystranHorizonte.Repository.Ventas.Interfaces;
using SystranHorizonte.Services.Ventas.Interfaces;
using SystranHorizonte.Models;

namespace SystranHorizonte.Services.Ventas.Services
{
    public class CuentasService : ICuentasService
    {
        public ICuentasReporsitory cuentasReporsitory { get; set; }

        public CuentasService(ICuentasReporsitory cuentasReporsitory)
        {
            this.cuentasReporsitory = cuentasReporsitory;
        }

        public string EliminarCuentaUsuario(int idUser)
        {
            return cuentasReporsitory.EliminarCuentaUsuario(idUser);
        }

        public string EliminarRol(int idrol)
        {
            return cuentasReporsitory.EliminarRol(idrol);
        }

        public string ModificarCuentaUsuario(Account user)
        {
            return cuentasReporsitory.ModificarCuentaUsuario(user);
        }

        public string ModificarRol(Roles rol)
        {
            return cuentasReporsitory.ModificarRol(rol);
        }

        public string NuevaCuentaUsuario(Account user)
        {
            return cuentasReporsitory.NuevaCuentaUsuario(user);
        }

        public string NuevoRol(Roles rol)
        {
            return cuentasReporsitory.NuevoRol(rol);
        }

        public Account ObtenerCuentaPorCriterio(string criterio)
        {
            return cuentasReporsitory.ObtenerCuentaPorCriterio(criterio);
        }

        public Account ObtenerCuentaPorId(int iduser)
        {
            return cuentasReporsitory.ObtenerCuentaPorId(iduser);
        }

        public IEnumerable<Account> ObtenerCuentasPorRol(int rol)
        {
            return cuentasReporsitory.ObtenerCuentasPorRol(rol);
        }

        public IEnumerable<Roles> ObtenerRolesPorCriterio(string criterio)
        {
            return cuentasReporsitory.ObtenerRolesPorCriterio(criterio);
        }

        public Roles ObtenerRolPorId(int idrol)
        {
            return cuentasReporsitory.ObtenerRolPorId(idrol);
        }
    }
}
