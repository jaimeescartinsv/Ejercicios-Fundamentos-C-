namespace Models;

class Estudiante
{
    public string Nombre { get; set; }
    private Dictionary<Asignatura, double> calificaciones;

    public Estudiante(string nombre)
    {
        Nombre = nombre;
        calificaciones = new Dictionary<Asignatura, double>();
    }

    public void AñadirCalificacion(Asignatura asignatura, double calificacion)
    {
        // Validar que la calificación esté en el rango 0 a 10
        if (calificacion < 0 || calificacion > 10)
        {
            Console.WriteLine($"Error: La calificación {calificacion:F2} para la asignatura '{asignatura.Nombre}' no es válida. Debe estar entre 0 y 10.");
            return;
        }

        // Añadir o actualizar la calificación
        calificaciones[asignatura] = calificacion;
        Console.WriteLine($"Calificación {calificacion:F2} añadida para la asignatura '{asignatura.Nombre}'.");
    }

    public void MostrarCalificaciones()
    {
        Console.WriteLine($"\n--- Calificaciones de {Nombre} ---");
        foreach (var entrada in calificaciones)
        {
            Console.WriteLine($"{entrada.Key.Nombre}: {entrada.Value:F2}");
        }
    }

    public double CalcularPromedio()
    {
        double suma = 0;
        foreach (var entrada in calificaciones)
        {
            suma += entrada.Value;
        }
        return calificaciones.Count > 0 ? suma / calificaciones.Count : 0;
    }

    public void ModificarCalificacion(Asignatura asignatura, double nuevaCalificacion)
    {
        if (calificaciones.ContainsKey(asignatura))
        {
            calificaciones[asignatura] = nuevaCalificacion;
            Console.WriteLine($"Calificación de {Nombre} en {asignatura.Nombre} modificada a {nuevaCalificacion:F2}.");
        }
        else
        {
            Console.WriteLine($"El estudiante {Nombre} no tiene una calificación en {asignatura.Nombre}.");
        }
    }


    public Dictionary<Asignatura, double> GetCalificaciones()
    {
        return calificaciones;
    }

}