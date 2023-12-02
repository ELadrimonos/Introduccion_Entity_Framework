using System;
using System.Linq;

using var baseDatos = new PersonasContext();


// Este ejemplo requiere crear la base de datos antes de ejecutarse. Se usa SQLite

int respuesta;
do
{
    respuesta = Menu.MostrarOpciones();
    switch (respuesta)
    {
        case 1:
            Console.Write("ID persona: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre persona: ");
            string nombre = Console.ReadLine();
            Console.Write("Primer Apellido persona: ");
            string ap1 = Console.ReadLine();
            Console.Write("Segundo Apellido persona: ");
            string ap2 = Console.ReadLine();

            baseDatos.Add(new Persona { PersonaId = id, Nombre = nombre, Apellido = ap1, Apellido2 = ap2 });
            baseDatos.SaveChanges();
            break;

        case 2:
            Console.WriteLine("| ID | Nombre | Apellido 1 | Apellido 2 |");
            var personas = baseDatos.Personas;
            foreach (var personita in personas)
            {
                Console.Write("| " + personita.PersonaId);
                Console.Write(" | " + personita.Nombre);
                Console.Write(" | " + personita.Apellido);
                Console.WriteLine(" | " + personita.Apellido2 + " |");
            }
            break;
        case 3:
            Console.Write("ID persona para borrar: ");
            int idBorrar = int.Parse(Console.ReadLine());
            var persona = baseDatos.Personas.Find(idBorrar);
            if (persona == null)
            {
                Console.WriteLine("Persona no encontrada");
                break;
            }
            baseDatos.Remove(persona);
            baseDatos.SaveChanges();
            Console.WriteLine($"Borrada persona: {persona.Apellido} {persona.Apellido2}, {persona.Nombre}");
            break;
         case 4:
            Console.Write("ID trabajo: ");
            int idTrabajo = int.Parse(Console.ReadLine());
            Console.Write("Nombre trabajo: ");
            string nombreTrabajo = Console.ReadLine();
            Console.Write("Jornada trabajo: ");
            string jornada = Console.ReadLine();

            baseDatos.Add(new Trabajo { TrabajoId = idTrabajo, Nombre = nombreTrabajo, Jornada = jornada });
            baseDatos.SaveChanges();
            break;

        case 5:
            Console.WriteLine("| ID | Nombre | Jornada |");
            var trabajos = baseDatos.Trabajos;
            foreach (var trabajo in trabajos)
            {
                Console.Write("| " + trabajo.TrabajoId);
                Console.Write(" | " + trabajo.Nombre);
                Console.WriteLine(" | " + trabajo.Jornada + " |");
            }
            break;

        case 6:
            Console.Write("ID trabajo para borrar: ");
            int idBorrarTrabajo = int.Parse(Console.ReadLine());
            var trabajoBorrar = baseDatos.Trabajos.Find(idBorrarTrabajo);
            if (trabajoBorrar == null)
            {
                Console.WriteLine("Trabajo no encontrado");
                break;
            }
            baseDatos.Remove(trabajoBorrar);
            baseDatos.SaveChanges();
            Console.WriteLine($"Borrado trabajo: {trabajoBorrar.Nombre}, {trabajoBorrar.Jornada}");
            break;

        case 7:
            Console.Write("ID persona: ");
            int idPersona = int.Parse(Console.ReadLine());
            Console.Write("ID trabajo: ");
            int idTrabajoRelacion = int.Parse(Console.ReadLine());

            baseDatos.Add(new PersonaTrabajo { PersonaId = idPersona, TrabajoId = idTrabajoRelacion });
            baseDatos.SaveChanges();
            break;

        case 8:
            Console.WriteLine("| ID Persona | ID Trabajo |");
            var relaciones = baseDatos.PersonaTrabajos;
            foreach (var relacion in relaciones)
            {
                Console.Write("| " + relacion.PersonaId);
                Console.WriteLine(" | " + relacion.TrabajoId + " |");
            }
            break;

        case 9:
            Console.Write("ID persona para borrar relación: ");
            int idBorrarPersonaRelacion = int.Parse(Console.ReadLine());
            Console.Write("ID trabajo para borrar relación: ");
            int idBorrarTrabajoRelacion = int.Parse(Console.ReadLine());
            var relacionBorrar = baseDatos.PersonaTrabajos.Find(idBorrarPersonaRelacion, idBorrarTrabajoRelacion);
            if (relacionBorrar == null)
            {
                Console.WriteLine("Relación no encontrada");
                break;
            }
            baseDatos.Remove(relacionBorrar);
            baseDatos.SaveChanges();
            Console.WriteLine($"Borrada relación: Persona {relacionBorrar.PersonaId}, Trabajo {relacionBorrar.TrabajoId}");
            break;
    }
    Console.WriteLine("\nPulse Enter para continuar");
    Console.ReadLine();
} while(respuesta != 0);

Console.WriteLine("Fin del programa");





//
// using var db = new BloggingContext();
//
// // Note: This sample requires the database to be created before running.
// Console.WriteLine($"Database path: {db.DbPath}.");
//
// // Create
// Console.WriteLine("Inserting a new blog");
// db.Add(new Persona { Url = "http://blogs.msdn.com/adonet" });
// db.SaveChanges();
//
// // Read
// Console.WriteLine("Querying for a blog");
// var blog = db.Blogs
//     .OrderBy(b => b.BlogId)
//     .First();
//
// // Update
// Console.WriteLine("Updating the blog and adding a post");
// blog.Url = "https://devblogs.microsoft.com/dotnet";
// blog.Posts.Add(
//     new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
// db.SaveChanges();
//
// // Delete
// Console.WriteLine("Delete the blog");
// db.Remove(blog);
// db.SaveChanges();