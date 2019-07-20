using System;
using System.Collections.Generic;
using System.Linq;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    public class EscuelaEngine
    {
        public Escuela Escuela { get; set; }

        public EscuelaEngine() {
            Inicializar();
        }

        public void Inicializar()
        {
            Escuela = new Escuela("Platzi", 2019);
            Escuela.País = "México";
            Escuela.Ciudad = "Zamora";

            CargarCursos();
            CargarAsignaturas();
            
            // foreach (var cursos in Escuela.Cursos) {
            //     cursos.Alumnos.AddRange(GenerarAlumnosRandom());
            // }
            CargarEvaluaciones();
        }

        private void CargarEvaluaciones()
        {
            /*
                ************ RETO *************
                Carga aleatoria de evaluciones
                5 evaluaciones x asignatura
                Por cada alumno de cada curso
                Notas al azar entre 0.0 y 5.0
                *******************************
             */

            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var r = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var e = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Evaluación: {i + 1}",
                                Nota = (float)(5 * r.NextDouble()),
                                Alumno = alumno
                            };

                            alumno.Evaluaciones.Add(e);
                            
                        }
                    }   
                }
            }
            
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos) {
                List<Asignaturas> listaAsignaturas = new List<Asignaturas>(){
                    new Asignaturas{Nombre="Matemáticas"},
                    new Asignaturas{Nombre="Educación física"},
                    new Asignaturas{Nombre="Español"},
                    new Asignaturas{Nombre="Ciencias Naturales"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenerarAlumnosRandom(int cantidad)
        {
            string[] nombre1   = {"José", "Sara", "Isabel", "Isabel", "José", "Roberto", "Alejandro", "David", "María", "Isabel", "María", "José María", "José María", "José", "María", "Ana María", "Maite", "Miguel", "Juan", "Montserrat", "Josefa", "David", "Jesús", "Pedro", "Roberto", "David", "Carmen", "Pilar", "Alejandro", "Manuel", "María Dolores", "Ana María", "Jaime", "María", "Laura", "Mercedes", "Ángel", "Manuel", "Rosa", "Francisca", "Juan Antonio"};
            string[] apellido1 = {"Márquez", "Torres", "Pérez", "González", "Fernández", "Marín", "Machado", "Cuadrado", "Herrero", "Ruiz", "Santana", "Marín", "Fernández", "Marín", "Gómez", "Martínez", "Rodríguez", "Zafra", "Marco", "Osorio", "Ramírez", "Martínez", "Barranco", "Molero", "Martin", "García", "Moreno", "Jiménez", "Álvarez", "Sánchez", "Roca", "Pérez", "Salvador", "Ramos", "Quesada", "Garrido", "Guerrero", "Cabrera", "García", "Zorrilla", "Fernández"};
            string[] nombre2   = {"José", "Sara", "Isabel", "Isabel", "José", "Roberto", "Alejandro", "David", "María", "Isabel", "María", "José María", "José María", "José", "María", "Ana María", "Maite", "Miguel", "Juan", "Montserrat", "Josefa", "David", "Jesús", "Pedro", "Roberto", "David", "Carmen", "Pilar", "Alejandro", "Manuel", "María Dolores", "Ana María", "Jaime", "María", "Laura", "Mercedes", "Ángel", "Manuel", "Rosa", "Francisca", "Juan Antonio"};

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno{ Nombre=$"{n1} {n2} {a1}" };
            return listaAlumnos.OrderBy( (al)=> al.UniqueId ).Take(cantidad).ToList(); 
        }

        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso() { Nombre = "101" , Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "201" , Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "301" , Jornada = TiposJornada.Mañana },
                new Curso() { Nombre = "401" , Jornada = TiposJornada.Tarde },
                new Curso() { Nombre = "501" , Jornada = TiposJornada.Tarde }
            };

            Random r = new Random();

            foreach (var c in Escuela.Cursos) {
                int cantRandom = r.Next(5, 20);
                c.Alumnos = GenerarAlumnosRandom(cantRandom);
            }
        }
    }
}