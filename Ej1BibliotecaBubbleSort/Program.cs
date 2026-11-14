Libro[] libros =
[
    new(1, "Cien anos de soledad", "Gabriel Garcia Marquez"),
    new(2, "El principito", "Antoine de Saint-Exupery"),
    new(3, "Don Quijote de la Mancha", "Miguel de Cervantes"),
    new(4, "La sombra del viento", "Carlos Ruiz Zafon"),
    new(5, "1984", "George Orwell")
];

Console.WriteLine("BIBLIOTECA - BUBBLE SORT POR TITULO");
Console.WriteLine("\nESTADO INICIAL:");
MostrarLibros(libros);

EstadisticasOrdenamiento estadisticas = OrdenadorBurbuja.OrdenarPorTitulo(
    libros,
    MostrarPaso);

Console.WriteLine("\nRESULTADO FINAL:");
MostrarLibros(libros);
Console.WriteLine($"\nComparaciones: {estadisticas.Comparaciones}");
Console.WriteLine($"Intercambios: {estadisticas.Intercambios}");

static void MostrarPaso(PasoOrdenamiento paso)
{
    string accion = paso.HuboIntercambio ? "intercambio" : "sin intercambio";
    string titulos = string.Join(" | ", paso.Libros.Select(libro => libro.Titulo));

    Console.WriteLine(
        $"Paso {paso.Numero}: pasada {paso.Pasada}, comparacion {paso.Indice + 1} " +
        $"({paso.TituloIzquierdo} - {paso.TituloDerecho}) -> {accion}");
    Console.WriteLine(titulos);
}

static void MostrarLibros(IEnumerable<Libro> libros)
{
    foreach (Libro libro in libros)
    {
        Console.WriteLine($"{libro.Id}. {libro.Titulo} - {libro.Autor}");
    }
}
