using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class NCliente
    {

        public static string Insertar(string nombre, string apellido,string sexo,DateTime fecha_nacimiento, string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo=sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            

            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llama al metodo editar de la clase DCliente

        public static string Editar(int idcliente,string nombre, string apellido,string sexo,DateTime fecha_nacimiento, string tipo_documento, string num_documento, string direccion, string telefono, string email)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Tipo_Documento = tipo_documento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            

            return Obj.Editar(Obj);
        }

        //Metodo eliminar que llama al metodo editar de la clase DCliente

        public static string Eliminar(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.Idcliente = idcliente;

            return Obj.Eliminar(Obj);
        }

        //Metodo Mostrar que llama al metodo editar de la clase DCliente

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();

        }

        //Metodo BuscarApellidos que llama al metodo editar de la clase DCliente de la capa datos

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarApellidos(Obj);


        }

        //Metodo buscarnum_documento que llama al metodo editar de la clase DCliente de la capa datos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DCliente Obj = new DCliente();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNum_Documento(Obj);


        }


    }
}
