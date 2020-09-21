using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class ManagerUsuarios
    {
        private SqlConnection _conn;
        protected SqlConnection Conn
        {
            get { return _conn; }
            set { _conn = value; }
        }
        public ManagerUsuarios()
        {
            this.Conn = new SqlConnection(
             "Data Source=localhost;Initial Catalog=academia;Integrated Security=true;");
            
        }

        public List<Usuario> GetAll()
        {
            //Creo la lista en la que le voy a ir agregando los usuarios
            List<Usuario> listaUsuarios = new List<Usuario>();
            //Defino una variable de tipo Usuario
            Usuario usuarioActual;

            //Creo el comando para ejecutar la sentencia SQL, le asocio la Conexión también
            SqlCommand cmdGetUsuarios = new SqlCommand("select * from usuarios", this.Conn);

            //Abro la conexión
            this.Conn.Open();

            //Ejecuto la consulta, me devuelve un objeto SqlDataReader
            SqlDataReader rdrUsuarios = cmdGetUsuarios.ExecuteReader();

            //Recorro el SqlDataReader, transformo el registro a objeto y 
            //agrego ese objeto a la lista de usuarios
            while (rdrUsuarios.Read())
            {
                usuarioActual = new Usuario();
                usuarioActual.Id = (int)rdrUsuarios["id"];
                usuarioActual.TipoDoc = (Nullable<int>)rdrUsuarios["tipo_doc"];
                usuarioActual.NroDoc = (Nullable<int>)rdrUsuarios["nro_doc"];
                usuarioActual.FechaDateTime = (DateTime) rdrUsuarios["fecha_nac"];
                usuarioActual.Apellido = rdrUsuarios["apellido"].ToString();
                usuarioActual.Nombre = rdrUsuarios["nombre"].ToString();
                usuarioActual.Direccion = rdrUsuarios["direccion"].ToString();
                usuarioActual.Telefono = rdrUsuarios["telefono"].ToString();
                usuarioActual.Email = rdrUsuarios["email"].ToString();
                usuarioActual.Celular = rdrUsuarios["celular"].ToString();
                usuarioActual.NombreUsuario = rdrUsuarios["usuario"].ToString();
                usuarioActual.Clave = rdrUsuarios["clave"].ToString();

                //Agrego el objeto a la lista de usuarios
                listaUsuarios.Add(usuarioActual);

            }

            //Cierro la conexión
            this.Conn.Close();

            //Devuelvo la Lista de Usuarios
            return listaUsuarios;
        }

        public void BorrarUsuario(Usuario usuarioActual)
        {
            //Creo el comando para ejecutar la sentencia SQL de DELETE, 
            //le asocio la Conexión también
            SqlCommand cmdDeleteUsuario = new SqlCommand(" DELETE FROM usuarios WHERE id=@id ", this.Conn);

            //Le agrego los parámetros necesarios
            cmdDeleteUsuario.Parameters.Add(new SqlParameter("@id", usuarioActual.Id.ToString()));

            //Abro la Conexión
            this.Conn.Open();
            //Ejecuto la instrucción SQL de DELETE
            cmdDeleteUsuario.ExecuteNonQuery();

            //Cierro la Conexión
            this.Conn.Close();
        }

        public void ActualizarUsuario(Usuario usuarioActual)
        {
            //Creo el comando para ejecutar la sentencia SQL de UPDATE, 
            //le asocio la Conexión también
                SqlCommand cmdActualizarUsuario = new SqlCommand(" UPDATE usuarios " +
                                               " SET tipo_doc = @tipo_doc, nro_doc = @nro_doc, fecha_nac = @fecha_nac, " +
                                               " apellido = @apellido, nombre = @nombre, direccion = @direccion, " +
                                               " telefono = @telefono, email = @email, celular = @celular, usuario = @usuario, " +
                                               " clave = @clave WHERE id=@id ", this.Conn);

            //Le agrego los parámetros necesarios
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@tipo_doc", usuarioActual.TipoDoc));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@nro_doc", usuarioActual.NroDoc));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@fecha_nac", usuarioActual.FechaDateTime));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@apellido", usuarioActual.Apellido));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@nombre", usuarioActual.Nombre));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@direccion", usuarioActual.Direccion));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@telefono", usuarioActual.Telefono));
             cmdActualizarUsuario.Parameters.Add(new SqlParameter("@email", usuarioActual.Email));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@celular", usuarioActual.Celular));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@usuario", usuarioActual.NombreUsuario));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@clave", usuarioActual.Clave));
            cmdActualizarUsuario.Parameters.Add(new SqlParameter("@id", usuarioActual.Id));

            //Abro la Conexión
            this.Conn.Open();
            //Ejecuto la instrucción SQL de UPDATE
            cmdActualizarUsuario.ExecuteNonQuery();
            //Cierro la Conexión
            this.Conn.Close();
        }

        public void AgregarUsuario(Usuario usuarioActual)
        {
            //Creo el comando para ejecutar la sentencia SQL de INSERT, 
            //le asocio la Conexión también
            SqlCommand cmdInsertarUsuario = new SqlCommand(" INSERT INTO usuarios(tipo_doc,nro_doc,fecha_nac,apellido, " +
                                               " nombre,direccion,telefono,email,celular,usuario,clave) " +
                                               " VALUES (@tipo_doc,@nro_doc,@fecha_nac,@apellido,@nombre,@direccion, " +
                                               " @telefono,@email,@celular, @usuario, @clave  )", this.Conn);

            //Le agrego los parámetros necesarios
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@tipo_doc", usuarioActual.TipoDoc.ToString()));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@nro_doc", usuarioActual.NroDoc.ToString()));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@fecha_nac", usuarioActual.FechaDateTime));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@apellido", usuarioActual.Apellido));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@nombre", usuarioActual.Nombre));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@direccion", usuarioActual.Direccion));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@telefono", usuarioActual.Telefono));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@email", usuarioActual.Email));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@celular", usuarioActual.Celular));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@usuario", usuarioActual.NombreUsuario));
            cmdInsertarUsuario.Parameters.Add(new SqlParameter("@clave", usuarioActual.Clave));

            //Abro la Conexión
            this.Conn.Open();
            //Ejecuto la instrucción SQL de INSERT
            cmdInsertarUsuario.ExecuteNonQuery();
            //Cierro la Conexión
            this.Conn.Close();
        }
        public Usuario GetUsuario(int idUsuario)
        {
            //Basarse en el método GetAll pero obtener únicamente el usuario que viene
            //como párametro

            Usuario usuarioActual = new Usuario();

            //Creo el comando para ejecutar la sentencia SQL, le asocio la Conexión también
            SqlCommand cmdGetUsuarios = new SqlCommand("SELECT * FROM usuarios WHERE id = @id", this.Conn);

            //Abro la conexión
            this.Conn.Open();

            cmdGetUsuarios.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
            //Ejecuto la consulta, me devuelve un objeto SqlDataReader
            SqlDataReader rdrUsuarios = cmdGetUsuarios.ExecuteReader();
            if (rdrUsuarios.Read())
            {
                usuarioActual.Id = idUsuario;
                usuarioActual.TipoDoc = (Nullable<int>)rdrUsuarios["tipo_doc"];
                usuarioActual.NroDoc = (Nullable<int>)rdrUsuarios["nro_doc"];
                usuarioActual.FechaDateTime = (DateTime) rdrUsuarios["fecha_nac"];
                usuarioActual.Apellido = rdrUsuarios["apellido"].ToString();
                usuarioActual.Nombre = rdrUsuarios["nombre"].ToString();
                usuarioActual.Direccion = rdrUsuarios["direccion"].ToString();
                usuarioActual.Telefono = rdrUsuarios["telefono"].ToString();
                usuarioActual.Email = rdrUsuarios["email"].ToString();
                usuarioActual.Celular = rdrUsuarios["celular"].ToString();
                usuarioActual.NombreUsuario = rdrUsuarios["usuario"].ToString();
                usuarioActual.Clave = rdrUsuarios["clave"].ToString();
            }
            rdrUsuarios.Close();
            this.Conn.Close();
            return usuarioActual;           
                
        }
       

    }
}
