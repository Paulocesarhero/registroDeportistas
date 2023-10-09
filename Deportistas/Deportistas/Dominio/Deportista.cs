using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deportistas.Dominio
{
    public class Deportista
    {
        public Deportista(
            string apellidoPaterno = "",
            string apellidoMaterno = "",
            string nombres = "",
            DateTime fechaNacimiento = default(DateTime),
            string sexo = "",
            int edad = 0,
            string curp = "",
            string telefono = "",
            string numInterior = "",
            string numExterior = "",
            string estado = "",
            string correo = "",
            string institucion = "",
            string semestre = "",
            string deporte = "",
            string matricula = "",
            string grado = "",
            string nombreDeGrado = "",
            string facultad = "",
            string region = "",
            string planDeEstudios = "",
            DateTime fechaIngresoIes = default(DateTime),
            string noSeguro = "",
            string colonia = "",
            string delegacion = "",
            decimal pesoKg = 0,
            int estaturaCm = 0,
            string tallaInt = "",
            string tallaExt = "",
            string noCalzado = "")
        {
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Nombres = nombres;
            FechaNacimiento = fechaNacimiento;
            Sexo = sexo;
            Edad = edad;
            Curp = curp;
            Telefono = telefono;
            NumInterior = numInterior;
            NumExterior = numExterior;
            Estado = estado;
            Correo = correo;
            Institucion = institucion;
            Semestre = semestre;
            Deporte = deporte;
            Matricula = matricula;
            Grado = grado;
            NombreDeGrado = nombreDeGrado;
            Facultad = facultad;
            Region = region;
            PlanDeEstudios = planDeEstudios;
            FechaIngresoIES = fechaIngresoIes;
            NoSeguro = noSeguro;
            Colonia = colonia;
            Delegacion = delegacion;
            PesoKg = pesoKg;
            EstaturaCm = estaturaCm;
            TallaInt = tallaInt;
            TallaExt = tallaExt;
            NoCalzado = noCalzado;
        }

        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Sexo { get; set; }
        public int Edad { get; set; }
        public string Curp { get; set; }
        public string Telefono { get; set; }
        public string NumInterior { get; set; }
        public string NumExterior { get; set; }
        public string Estado { get; set; }
        public string Correo { get; set; }
        public string Institucion { get; set; }
        public string Semestre { get; set; }
        public string Deporte { get; set; }
        public string Matricula { get; set; }
        public string Grado { get; set; }
        public string NombreDeGrado { get; set; }
        public string Facultad { get; set; }
        public string Region { get; set; }
        public string PlanDeEstudios { get; set; }
        public DateTime FechaIngresoIES { get; set; }
        public string NoSeguro { get; set; }
        public string Colonia { get; set; }
        public string Delegacion { get; set; }
        public decimal PesoKg { get; set; }
        public decimal EstaturaCm { get; set; }
        public string TallaInt { get; set; }
        public string TallaExt { get; set; }
        public string NoCalzado { get; set; }
    }
}