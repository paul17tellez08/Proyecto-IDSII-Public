﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using CapaDatos;
namespace CapaNegocio
{
    public class NTrabajador
    {

        public static string Insertar(string nombre, string apellido, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email,string acceso, string usuario,string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;


            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llama al metodo editar de la clase DCliente

        public static string Editar(int idtrabajador, string nombre, string apellido, string sexo, DateTime fecha_nacimiento,
            string num_documento, string direccion, string telefono, string email, string acceso, string usuario, string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;
            Obj.Nombre = nombre;
            Obj.Apellido = apellido;
            Obj.Sexo = sexo;
            Obj.Fecha_Nacimiento = fecha_nacimiento;
            Obj.Num_Documento = num_documento;
            Obj.Direccion = direccion;
            Obj.Telefono = telefono;
            Obj.Email = email;
            Obj.Acceso = acceso;
            Obj.Usuario = usuario;
            Obj.Password = password;


            return Obj.Editar(Obj);
        }

        //Metodo eliminar que llama al metodo editar de la clase DCliente

        public static string Eliminar(int idtrabajador)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Idtrabajador = idtrabajador;

            return Obj.Eliminar(Obj);
        }

        //Metodo Mostrar que llama al metodo editar de la clase DCliente

        public static DataTable Mostrar()
        {
            return new DTrabajador().Mostrar();

        }

        //Metodo BuscarApellidos que llama al metodo editar de la clase DCliente de la capa datos

        public static DataTable BuscarApellidos(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarApellidos(Obj);


        }

        //Metodo buscarnum_documento que llama al metodo editar de la clase DCliente de la capa datos

        public static DataTable BuscarNum_Documento(string textobuscar)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNum_Documento(Obj);


        }

        public static DataTable Login(string usuario,string password)
        {
            DTrabajador Obj = new DTrabajador();
            Obj.Usuario = usuario;
            Obj.Password = password;

            return Obj.Login(Obj);


        }


    }
}
