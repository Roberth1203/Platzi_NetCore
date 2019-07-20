using System;
using System.Collections.Generic;

namespace CoreEscuela.Entidades
{
    public class Escuela
    {
        public string UniqueId { get; private set; } = Guid.NewGuid().ToString();
        string nombre;
        public string Nombre { 
            get { return "Copia:" + nombre; } 
            set { nombre = value.ToUpper(); } 
        }
        public int AñoDeCreacion { get; set; }
        public string País { get; set; }
        public string Ciudad { get; set; }

        public TiposDeEscuela Tipo { get; set; }
        public List<Curso> Cursos { get; set; }
        public Escuela(string Nombre, int año) => (nombre,AñoDeCreacion) = (Nombre, año);

        public override string ToString() {
            return $"Nombre: {Nombre}, Tipo: {Tipo} \n País: {País}, Ciudad: {Ciudad}";
        }
    }
}