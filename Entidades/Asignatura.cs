using System;

namespace CoreEscuela.Entidades
{
    public class Asignaturas
    {
        public string UniqueId { get; set; }
        public string Nombre    { get; set; }
        public Asignaturas() => UniqueId = Guid.NewGuid().ToString();
    }
}