
namespace Models;

class ProgramaEducativo
{
    private List<Estudiante> estudiantes;
    private List<Asignatura> asignaturas;

    public ProgramaEducativo()
    {
        estudiantes = new List<Estudiante>();
        asignaturas = new List<Asignatura>();
    }

    public void AñadirEstudiante(Estudiante estudiante)
    {
        if (estudiantes.Exists(e => e.Nombre == estudiante.Nombre))
        {
            Console.WriteLine($"El estudiante {estudiante.Nombre} ya existe en el programa.");
        }
        else
        {
            // Añadir la asignatura a la lista global
            estudiantes.Add(estudiante);
            Console.WriteLine($"El estudiante {estudiante.Nombre} ha sido añadido.");
        }
    }

    public void MostrarEstudiantes()
    {
        Console.WriteLine("\n--- Lista de Estudiantes ---");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine($"Estudiante: {estudiante.Nombre}");
        }
    }

    public Estudiante ObtenerEstudiante(string nombre)
    {
        foreach (var estudiante in estudiantes)
        {
            if (estudiante.Nombre == nombre)
            {
                return estudiante;
            }
        }
        return null;
    }

    public List<Estudiante> BuscarEstudiantesPorNombre(string parteDelNombre)
    {
        List<Estudiante> resultados = estudiantes.FindAll(e => e.Nombre.ToLower().Contains(parteDelNombre.ToLower()));
        return resultados;
    }

    public void EliminarEstudiante(string nombre)
    {
        Estudiante estudiante = ObtenerEstudiante(nombre);
        if (estudiante != null)
        {
            estudiantes.Remove(estudiante);
            Console.WriteLine($"Estudiante {nombre} ha sido eliminado del programa educativo.");
        }
        else
        {
            Console.WriteLine($"No se encontró un estudiante con el nombre: {nombre}.");
        }
    }

    public double CalcularPromedioGlobal()
    {
        double sumaPromedios = 0;
        int contadorEstudiantes = 0;

        foreach (var estudiante in estudiantes)
        {
            sumaPromedios += estudiante.CalcularPromedio();
            contadorEstudiantes++;
        }


        return contadorEstudiantes > 0 ? sumaPromedios / contadorEstudiantes : 0;
    }

    public void GenerarReporteEstudiante(Estudiante estudiante)
    {
        Console.WriteLine($"\n--- Reporte Detallado para {estudiante.Nombre} ---");

        // Mostrar todas las calificaciones
        Console.WriteLine("\nCalificaciones:");
        estudiante.MostrarCalificaciones();

        // Calcular y mostrar el promedio
        double promedio = estudiante.CalcularPromedio();
        Console.WriteLine($"\nPromedio final: {promedio:F2}");

        // Mostrar todas las asignaturas inscritas
        Console.WriteLine("\nAsignaturas inscritas:");
        foreach (var asignatura in estudiante.GetCalificaciones().Keys)
        {
            Console.WriteLine($"- {asignatura.Nombre} ({asignatura.Creditos} créditos)");
        }
    }

    public void AñadirAsignatura(Asignatura asignatura)
    {
        // Comparar nombres ignorando mayúsculas y espacios adicionales
        if (asignaturas.Exists(a => a.Nombre.Trim().ToLower() == asignatura.Nombre.Trim().ToLower()))
        {
            Console.WriteLine($"La asignatura '{asignatura.Nombre}' ya está registrada en el programa.");
        }
        else
        {
            asignaturas.Add(asignatura);
            Console.WriteLine($"Asignatura '{asignatura.Nombre}' añadida al programa educativo.");
        }
    }

    public void MostrarAsignaturas()
    {
        Console.WriteLine("\n--- Lista de Asignaturas ---");
        foreach (var asignatura in asignaturas)
        {
            Console.WriteLine($"- {asignatura.Nombre} ({asignatura.Creditos} créditos)");
        }
    }

    public void MostrarRankingEstudiantes()
    {
        // Ordenar los estudiantes por promedio en orden descendente
        var ranking = estudiantes
            .Where(e => e.CalcularPromedio() > 0) // Solo considerar estudiantes con calificaciones
            .OrderByDescending(e => e.CalcularPromedio())
            .ToList();

        Console.WriteLine("\n--- Ranking de Estudiantes por Promedio ---");

        if (ranking.Count > 0)
        {
            int posicion = 1;
            foreach (var estudiante in ranking)
            {
                double promedio = estudiante.CalcularPromedio();
                Console.WriteLine($"{posicion}. {estudiante.Nombre} - Promedio: {promedio:F2}");
                posicion++;
            }
        }
        else
        {
            Console.WriteLine("No hay estudiantes con calificaciones registradas.");
        }
    }

}