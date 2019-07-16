using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using System.Data;

namespace CapaNegocio
{
   public class NCategoria
    {
       //MEtodo Insertar que llama al metodo insertar de la clase Dcategoria de la capaDatos

       public static string Insertar(string nombre, string descripcion)
       {
           DCategoria Obj = new DCategoria();
           Obj.Nombre = nombre;
           Obj.Descripcion = descripcion;

           return Obj.Insertar(Obj);
       }

       //Metodo Editar que llama al metodo editar de la clase DCategoria

       public static string Editar(int idcategoria,string nombre, string descripcion)
       {
           DCategoria Obj = new DCategoria();
           Obj.Idcategoria = idcategoria;
           Obj.Nombre = nombre;
           Obj.Descripcion = descripcion;

           return Obj.Editar(Obj);
       }

       //Metodo eliminar que llama al metodo editar de la clase DCategoria

       public static string Eliminar(int idcategoria)
       {
           DCategoria Obj = new DCategoria();
           Obj.Idcategoria = idcategoria;

           return Obj.Eliminar(Obj);
       }

       //Metodo Mostrar que llama al metodo editar de la clase DCategoria

       public static DataTable Mostrar()
       {
           return new DCategoria().Mostrar();
        
       }

       //Metodo BuscarNombre que llama al metodo editar de la clase DCategoria

       public static DataTable BuscarNombre(string textobuscar)
       {
           DCategoria Obj = new DCategoria();
           Obj.TextoBuscar = textobuscar;

           return Obj.BuscarNombre(Obj);

          
       }




    }
}
