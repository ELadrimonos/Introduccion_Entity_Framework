
public class Menu
{

    public static int MostrarOpciones()
    {
        Console.Clear();
        Console.WriteLine("1. Crear Nueva Persona | 2. Mostrar Personas | 3. Borrar Persona");
        Console.WriteLine("4. Crear Nuevo Trabajo | 5. Mostrar Trabajos | 6. Borrar Trabajo");
        Console.WriteLine("7. Crear Nueva Persona<->Trabajo | 8. Mostrar Relaciones Trabajos | 9. Borrar Relaciones Trabajos");
        Console.WriteLine("0. Salir");
        int valor = int.Parse(Console.ReadLine());
        return valor;
    }

}
