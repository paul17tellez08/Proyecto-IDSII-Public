﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class DTrabajador
    {

       //variables
        private int _Idtrabajador;
        private string _Nombre;
        private string _Apellido;
        private string _Sexo;
        private DateTime _Fecha_Nacimiento;
        private string _Num_Documento;
        private string _Direccion;
        private string _Telefono;
        private string _Email;
        private string _TextoBuscar;
        private string _Acceso;
        private string _Usuario;
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Usuario
        {
            get { return _Usuario; }
            set { _Usuario = value; }
        }

        public string Acceso
        {
            get { return _Acceso; }
            set { _Acceso = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public string TextoBuscar
        {
            get { return _TextoBuscar; }
            set { _TextoBuscar = value; }
        }


        public string Num_Documento
        {
            get { return _Num_Documento; }
            set { _Num_Documento = value; }
        }

        public DateTime Fecha_Nacimiento
        {
            get { return _Fecha_Nacimiento; }
            set { _Fecha_Nacimiento = value; }
        }

        public string Sexo
        {
            get { return _Sexo; }
            set { _Sexo = value; }
        }

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }


        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public int Idtrabajador
        {
            get { return _Idtrabajador; }
            set { _Idtrabajador = value; }
        }


         //Constructor
        public DTrabajador()
        {
        
        }
        public DTrabajador(int idrabajador,string nombre,string apellido,string sexo,
            DateTime fecha_nacimiento,string num_documento,string direccion,
            string telefono,string email, string acceso,string usuario,
            string password,string textobuscar)
        {
            this.Idtrabajador = Idtrabajador;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Sexo = sexo;
            this.Fecha_Nacimiento = fecha_nacimiento;
            this.Num_Documento=num_documento;
            this.Direccion=direccion;
            this.Telefono=telefono;
            this.Email=email;
            this.Acceso = acceso;
            this.Usuario = usuario;
            this.Password = password;
            this.TextoBuscar=textobuscar;
        }

        ////METODOS

        //Metodo Insertar
        public string Insertar(DTrabajador Trabajador)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spinsertar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(ParIdtrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Trabajador.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellido";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 40;
                ParApellidos.Value = Trabajador.Apellido;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Trabajador.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_Nacimiento.Size = 50;
                ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParNum_Documeto = new SqlParameter();
                ParNum_Documeto.ParameterName = "@num_documento";
                ParNum_Documeto.SqlDbType = SqlDbType.VarChar;
                ParNum_Documeto.Size = 11;
                ParNum_Documeto.Value = Trabajador.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documeto);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Trabajador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 50;
                ParAcceso.Value = Trabajador.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(ParPassword);

                //Ejecutart nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Editar
        public string Editar(DTrabajador Trabajador)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speditar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter PaiIdtrabajador = new SqlParameter();
                PaiIdtrabajador.ParameterName = "@idtrabajador";
                PaiIdtrabajador.SqlDbType = SqlDbType.Int;
                PaiIdtrabajador.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(PaiIdtrabajador);

                SqlParameter ParNombre = new SqlParameter();
                ParNombre.ParameterName = "@nombre";
                ParNombre.SqlDbType = SqlDbType.VarChar;
                ParNombre.Size = 50;
                ParNombre.Value = Trabajador.Nombre;
                SqlCmd.Parameters.Add(ParNombre);

                SqlParameter ParApellidos = new SqlParameter();
                ParApellidos.ParameterName = "@apellido";
                ParApellidos.SqlDbType = SqlDbType.VarChar;
                ParApellidos.Size = 40;
                ParApellidos.Value = Trabajador.Apellido;
                SqlCmd.Parameters.Add(ParApellidos);

                SqlParameter ParSexo = new SqlParameter();
                ParSexo.ParameterName = "@sexo";
                ParSexo.SqlDbType = SqlDbType.VarChar;
                ParSexo.Size = 1;
                ParSexo.Value = Trabajador.Sexo;
                SqlCmd.Parameters.Add(ParSexo);

                SqlParameter ParFecha_Nacimiento = new SqlParameter();
                ParFecha_Nacimiento.ParameterName = "@fecha_nacimiento";
                ParFecha_Nacimiento.SqlDbType = SqlDbType.VarChar;
                ParFecha_Nacimiento.Size = 50;
                ParFecha_Nacimiento.Value = Trabajador.Fecha_Nacimiento;
                SqlCmd.Parameters.Add(ParFecha_Nacimiento);

                SqlParameter ParNum_Documeto = new SqlParameter();
                ParNum_Documeto.ParameterName = "@num_documento";
                ParNum_Documeto.SqlDbType = SqlDbType.VarChar;
                ParNum_Documeto.Size = 11;
                ParNum_Documeto.Value = Trabajador.Num_Documento;
                SqlCmd.Parameters.Add(ParNum_Documeto);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@direccion";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = Trabajador.Direccion;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 11;
                ParTelefono.Value = Trabajador.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter ParEmail = new SqlParameter();
                ParEmail.ParameterName = "@email";
                ParEmail.SqlDbType = SqlDbType.VarChar;
                ParEmail.Size = 50;
                ParEmail.Value = Trabajador.Email;
                SqlCmd.Parameters.Add(ParEmail);

                SqlParameter ParAcceso = new SqlParameter();
                ParAcceso.ParameterName = "@acceso";
                ParAcceso.SqlDbType = SqlDbType.VarChar;
                ParAcceso.Size = 50;
                ParAcceso.Value = Trabajador.Acceso;
                SqlCmd.Parameters.Add(ParAcceso);

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 50;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter ParPassword = new SqlParameter();
                ParPassword.ParameterName = "@password";
                ParPassword.SqlDbType = SqlDbType.VarChar;
                ParPassword.Size = 50;
                ParPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(ParPassword);



                //Ejecutart nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }
        //Metodo Eliminar
        public string Eliminar(DTrabajador Trabajador)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Codigo
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCon.Open();

                //Establecer el comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_trabajador";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idtrabajador";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = Trabajador.Idtrabajador;
                SqlCmd.Parameters.Add(ParIdtrabajador);


                //Ejecutart nuestro comando
                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return rpta;
        }

        //Metodo Mostrar
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_trabajador";

                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        //Metodo Buscar Apellidos
        public DataTable BuscarApellidos(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_apellido";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable BuscarNum_Documento(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spbuscar_trabajador_num_documento";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@textobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Trabajador.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }

        public DataTable Login(DTrabajador Trabajador)
        {
            DataTable DtResultado = new DataTable("trabajador");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "splogin";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParUsuario = new SqlParameter();
                ParUsuario.ParameterName = "@usuario";
                ParUsuario.SqlDbType = SqlDbType.VarChar;
                ParUsuario.Size = 20;
                ParUsuario.Value = Trabajador.Usuario;
                SqlCmd.Parameters.Add(ParUsuario);

                SqlParameter PasPassword = new SqlParameter();
                PasPassword.ParameterName = "@password";
                PasPassword.SqlDbType = SqlDbType.VarChar;
                PasPassword.Size = 20;
                PasPassword.Value = Trabajador.Password;
                SqlCmd.Parameters.Add(PasPassword);


                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception ex)
            {
                DtResultado = null;
            }
            return DtResultado;
        }



    }
}
