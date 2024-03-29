using System;

namespace CoreEscuela.Entidades
{
    public class Evaluacion
    {
        public string UniqueId { get; set; }
        public string Nombre    { get; set; }
        public Alumno Alumno { get; set; }
        public Asignaturas Asignatura { get; set; }
        public float Nota { get; set; }
        public Evaluacion() => UniqueId = Guid.NewGuid().ToString();
    }
}