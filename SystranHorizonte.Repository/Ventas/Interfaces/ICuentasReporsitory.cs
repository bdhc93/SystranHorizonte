using System;
using System.Collections.Generic;
using SystranHorizonte.Models;

namespace SystranHorizonte.Repository.Ventas.Interfaces
{
    public interface ICuentasReporsitory
    {
        String NuevaCuentaUsuario(Account user);
        String ModificarCuentaUsuario(Account user);
        String EliminarCuentaUsuario(Int32 idUser);

        IEnumerable<Account> ObtenerCuentasPorRol(Int32 rol);
        Account ObtenerCuentaPorId(Int32 iduser);
        Account ObtenerCuentaPorCriterio(String criterio);


        String NuevoRol(Roles rol);
        String ModificarRol(Roles rol);
        String EliminarRol(Int32 idrol);

        IEnumerable<Roles> ObtenerRolesPorCriterio(String criterio);
        Roles ObtenerRolPorId(Int32 idrol);
    }
}
