using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystranHorizonte.Web.Models;

namespace SystranHorizonte.Web.Domain
{
    public class Data
    {
        public IEnumerable<Navbar> navbarItems()
        {
            var menu = new List<Navbar>();
            menu.Add(new Navbar { Id = 1, nameOption = "Inicio", controller = "Home", action = "Index", imageClass = "fa fa-share-square-o", status = true, isParent = false, parentId = 0 });
            menu.Add(new Navbar { Id = 2, nameOption = "Ventas", imageClass = "fa fa-shopping-cart", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 3, nameOption = "Listar Ventas", controller = "Venta", action = "ListarVentas", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 4, nameOption = "Nueva Venta", controller = "Venta", action = "AgregarVenta", status = true, isParent = false, parentId = 2 });
            menu.Add(new Navbar { Id = 5, nameOption = "Reservas", imageClass = "fa fa-shopping-cart", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 6, nameOption = "Listar Reservas", controller = "Reserva", action = "ListarReservas", status = true, isParent = false, parentId = 5 });
            menu.Add(new Navbar { Id = 7, nameOption = "Nueva Reserva", controller = "Reserva", action = "AgregarReserva", status = true, isParent = false, parentId = 5 });
            menu.Add(new Navbar { Id = 8, nameOption = "Encomiendas", imageClass = "fa fa-shopping-cart", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 9, nameOption = "Listar Encimiendas", controller = "Encomienta", action = "ListarEncomiendas", status = true, isParent = false, parentId = 8 });
            menu.Add(new Navbar { Id = 10, nameOption = "Nueva Encimienda", controller = "Encomienta", action = "AgregarEncomienda", status = true, isParent = false, parentId = 8 });
            menu.Add(new Navbar { Id = 11, nameOption = "Sistemas", imageClass = "fa fa-file", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 12, nameOption = "Listar Cargas", controller = "Cargas", action = "ListCargas", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 13, nameOption = "Nueva Carga", controller = "Cargas", action = "AddCarga", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 14, nameOption = "Listar Clientes", controller = "Cliente", action = "Listar", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 15, nameOption = "Nuevo Cliente", controller = "Cliente", action = "Agregar", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 16, nameOption = "Listar Empleados", controller = "Empleado", action = "ListarEmpleado", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 17, nameOption = "Nuevo Empleado", controller = "Empleado", action = "AgregarEmpleado", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 18, nameOption = "ReporteEmpleado", controller = "Empleado", action = "ReporteEmpleado", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 19, nameOption = "Listar Estaciones", controller = "Estacion", action = "ListarEstacion", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 20, nameOption = "Nueva Estacion", controller = "Estacion", action = "AgregarEstacion", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 21, nameOption = "Listar Horarios", controller = "Horario", action = "ListHorarios", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 22, nameOption = "Nuevo Horario", controller = "Horario", action = "AddHorario", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 23, nameOption = "Listar Vehículos", controller = "Vehiculo", action = "ListarVehiculo", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 24, nameOption = "Nuevo Vehículos", controller = "Vehiculo", action = "AgregarVehiculo", status = true, isParent = false, parentId = 11 });
            menu.Add(new Navbar { Id = 25, nameOption = "La Empresa", imageClass = "fa fa-hospital-o", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 26, nameOption = "Quienes Somos", controller = "Home", action = "Forms", status = true, isParent = false, parentId = 25 });
            menu.Add(new Navbar { Id = 27, nameOption = "Contatos", controller = "Home", action = "Forms", status = true, isParent = false, parentId = 25 });
            menu.Add(new Navbar { Id = 28, nameOption = "Usuarios", imageClass = "fa fa-user", status = true, isParent = true, parentId = 0 });
            menu.Add(new Navbar { Id = 29, nameOption = "Registrar Usuario", controller = "Cuenta", action = "Registrar", status = true, isParent = false, parentId = 28 });

            return menu.ToList();
        }
    }
}