using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class NPresentacion
    {

        //MEtodo Insertar que llama al metodo insertar de la clase DPresentacion de la capaDatos

        public static string Insertar(string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Insertar(Obj);
        }

        //Metodo Editar que llama al metodo editar de la clase DPresentacion

        public static string Editar(int idpresentacion, string nombre, string descripcion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;
            Obj.Nombre = nombre;
            Obj.Descripcion = descripcion;

            return Obj.Editar(Obj);
        }

        //Metodo eliminar que llama al metodo editar de la clase DPresentacion

        public static string Eliminar(int idpresentacion)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.Idpresentacion = idpresentacion;

            return Obj.Eliminar(Obj);
        }

        //Metodo Mostrar que llama al metodo editar de la clase DPresentacion

        public static DataTable Mostrar()
        {
            return new DPresentacion().Mostrar();

        }

        //Metodo BuscarNombre que llama al metodo editar de la clase DPresentacion

        public static DataTable BuscarNombre(string textobuscar)
        {
            DPresentacion Obj = new DPresentacion();
            Obj.TextoBuscar = textobuscar;

            return Obj.BuscarNombre(Obj);


        }


    }
}
