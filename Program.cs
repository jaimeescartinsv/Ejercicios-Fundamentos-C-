using Models;

ProgramaEducativo programa = new ProgramaEducativo();

// Crear asignaturas
Asignatura servidor = new Asignatura("Servidor", 6);
var cliente = new Asignatura("Cliente", 4);
Asignatura diseño = new("Diseño", 8);

// Crear estudiantes
var estudiante1 = new Estudiante("Vanessa Llorente");
Estudiante estudiante2 = new Estudiante("Alejandro Giménez");

// Añadir estudiantes al programa educativo
programa.AñadirEstudiante(estudiante1);
programa.AñadirEstudiante(estudiante2);

// Asignar calificaciones
Console.WriteLine("\n--- Asignar Calificaciones ---");
estudiante1.AñadirCalificacion(servidor, 11.0); // Inválido
estudiante1.AñadirCalificacion(cliente, -1.0); // Inválido
estudiante1.AñadirCalificacion(diseño, 9.0);

estudiante2.AñadirCalificacion(servidor, 7.5);
estudiante2.AñadirCalificacion(cliente, 8.5);

// Mostrar estudiantes
programa.MostrarEstudiantes();

// Mostrar calificaciones de un estudiante específico
Estudiante estudianteSeleccionado = programa.ObtenerEstudiante("Vanessa Llorente");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}

// Mostrar calificaciones del segundo estudiante
estudianteSeleccionado = programa.ObtenerEstudiante("Alejandro Giménez");
if (estudianteSeleccionado != null)
{
    estudianteSeleccionado.MostrarCalificaciones();
    double promedio = estudianteSeleccionado.CalcularPromedio();
    Console.WriteLine($"Promedio de {estudianteSeleccionado.Nombre}: {promedio:F2}");
}

// Modificar calificación de un estudiante
Console.WriteLine("\n--- Modificar Calificación ---");
string nombreEstudiante = "Vanessa Llorente";
string nombreAsignatura = "Cliente";
double nuevaCalificacion = 9.3;

Estudiante estudianteParaModificar = programa.ObtenerEstudiante(nombreEstudiante);
if (estudianteParaModificar != null)
{
    // Buscar la asignatura
    Asignatura asignaturaParaModificar = null;

    foreach (var entrada in estudianteParaModificar.GetCalificaciones())
    {
        if (entrada.Key.Nombre == nombreAsignatura)
        {
            asignaturaParaModificar = entrada.Key;
            break;
        }
    }

    if (asignaturaParaModificar != null)
    {
        estudianteParaModificar.ModificarCalificacion(asignaturaParaModificar, nuevaCalificacion);
    }
    else
    {
        Console.WriteLine($"El estudiante {nombreEstudiante} no tiene calificación registrada para la asignatura {nombreAsignatura}.");
    }
}
else
{
    Console.WriteLine($"Estudiante {nombreEstudiante} no encontrado.");
}

// Eliminar un estudiante por nombre
Console.WriteLine("\n--- Eliminar Estudiante ---");
string nombreEliminar = "Alejandro Giménez";

Estudiante estudianteAEliminar = programa.ObtenerEstudiante(nombreEliminar);
if (estudianteAEliminar != null)
{
    programa.EliminarEstudiante(nombreEliminar);
}
else
{
    Console.WriteLine($"El estudiante {nombreEliminar} no se encuentra en el sistema.");
}

// Buscar estudiantes por parte de su nombre
Console.WriteLine("\n--- Buscar Estudiantes ---");
string parteDelNombre = "Llorente";

List<Estudiante> resultados = programa.BuscarEstudiantesPorNombre(parteDelNombre);

if (resultados.Count > 0)
{
    Console.WriteLine($"Se encontraron {resultados.Count} estudiantes que coinciden con '{parteDelNombre}':");
    foreach (var estudiante in resultados)
    {
        Console.WriteLine($"- {estudiante.Nombre}");
    }
}
else
{
    Console.WriteLine($"No se encontraron estudiantes que coincidan con '{parteDelNombre}'.");
}

// Añadir nuevas asignaturas al programa educativo
Console.WriteLine("\n--- Añadir Asignaturas ---");

Asignatura nuevaAsignatura1 = new Asignatura("Matemáticas", 5);
Asignatura nuevaAsignatura2 = new Asignatura("Diseño", 8);
Asignatura nuevaAsignatura3 = new Asignatura("Historia", 3);
Asignatura nuevaAsignatura4 = new Asignatura("Historia", 3);

programa.AñadirAsignatura(nuevaAsignatura1);
programa.AñadirAsignatura(nuevaAsignatura2);
programa.AñadirAsignatura(nuevaAsignatura3);
programa.AñadirAsignatura(nuevaAsignatura4);

// Mostrar lista de asignaturas
programa.MostrarAsignaturas();

// Generar un reporte detallado para un estudiante
Console.WriteLine("\n--- Generar Reporte de Estudiante ---");
string nombreReporte = "Vanessa Llorente";

Estudiante estudianteReporte = programa.ObtenerEstudiante(nombreReporte);
if (estudianteReporte != null)
{
    programa.GenerarReporteEstudiante(estudianteReporte);
}
else
{
    Console.WriteLine($"No se encontró un estudiante con el nombre: {nombreReporte}");
}

// Mostrar lista actualizada de estudiantes
programa.MostrarEstudiantes();

// Mostrar ranking de estudiantes
programa.MostrarRankingEstudiantes();

// Calcular el promedio global del programa educativo
Console.WriteLine("\n--- Calcular Promedio Global ---");
double promedioGlobal = programa.CalcularPromedioGlobal();

if (promedioGlobal > 0)
{
    Console.WriteLine($"El promedio global del programa educativo es: {promedioGlobal:F2}");
}
else
{
    Console.WriteLine("No hay estudiantes registrados o no tienen calificaciones.");
}