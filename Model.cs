using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

// Para actualizar la estructura de la BBDD hay que ejecutar lo siguiente en la consola
// dotnet ef migrations add Mensaje (Como si fuera un commit de Git)
// dotnet ef database update
//

public class PersonasContext : DbContext
{
    public DbSet<Persona> Personas { get; set; }
    public DbSet<Trabajo> Trabajos { get; set; }
    public DbSet<PersonaTrabajo> PersonaTrabajos { get; set; }


    public string DbPath { get; }

    public PersonasContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "personas.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    // Mediante este metodo podemos hacer que la clave principal de PersonaTrabajo sean las claves foraneas de la tabla
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonaTrabajo>()
            .HasKey(pt => new { pt.PersonaId, pt.TrabajoId });
    }
}

public class Persona
{
    // La clave principal debe llamarse nombreTablaId o sino migrations no compila bien al parecer
    // Es importante tener tanto getter como setter en los atributos
    // Es muy importante tambien tener los atributos publicos, o Entity Framework no podra leerlos
    public int PersonaId { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Apellido2 { get; set; }

    public DateTime FechaCreacion { get; set; } = DateTime.Now;

    public List<PersonaTrabajo> PersonaTrabajos { get; } = new();

}

public class Trabajo
{
    public int TrabajoId { get; set; }
    public string Nombre { get; set; }
    public string Jornada { get; set; }

    public List<PersonaTrabajo> PersonaTrabajos { get; } = new();

}

public class PersonaTrabajo
{

    public int PersonaId { get; set; }
    public Persona Persona { get; set; }

    public int TrabajoId { get; set; }
    public Trabajo Trabajo { get; set; }
}