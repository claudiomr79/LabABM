using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Usuario
    {
        private int _id;
        private Nullable<int> _tipoDoc;
        private Nullable<int> _nroDoc;
        private string _apellido;
        private string _nombre;
        private string _direccion;
        private string _telefono;
        private string _email;
        private string _celular;
        private string _usuario;
        private string _clave;
        private DateTime _fechaDatetime;


        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public Nullable<int> TipoDoc
        {
            get { return _tipoDoc; }
            set { _tipoDoc = value; }
        }
        public Nullable<int> NroDoc
        {
            get { return _nroDoc; }
            set { _nroDoc = value; }
        }
        
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public string Telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Celular
        {
            get { return _celular; }
            set { _celular = value; }
        }
        public string NombreUsuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        public string Clave
        {
            get { return _clave; }
            set { _clave = value; }
        }

        public DateTime FechaDateTime
        {
            get { return _fechaDatetime; }
            set { _fechaDatetime= value; }
        }

        public int Dia
        {
            get { return FechaDateTime.Day; }
        }

        public int Mes 
        {
            get { return FechaDateTime.Month; }
        }

        public int Anio
        {
            get { return FechaDateTime.Year; }
        }

        //public string FechaFormateada
        //{
        //    get { return FechaDateTime.ToString("dd/MM/yyyy"); }
        //}

    }
}
