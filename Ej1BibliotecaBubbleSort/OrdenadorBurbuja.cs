using System.Globalization;

public static class OrdenadorBurbuja
{
    public static EstadisticasOrdenamiento OrdenarPorTitulo(
        Libro[] libros,
        Action<PasoOrdenamiento>? alCompletarPaso = null)
    {
        int comparaciones = 0;
        int intercambios = 0;
        int numeroPaso = 0;

        for (int pasada = 0; pasada < libros.Length - 1; pasada++)
        {
            bool huboIntercambio = false;

            for (int indice = 0; indice < libros.Length - 1 - pasada; indice++)
            {
                Libro libroIzquierdo = libros[indice];
                Libro libroDerecho = libros[indice + 1];
                comparaciones++;

                bool debeIntercambiar = string.Compare(
                    libroIzquierdo.Titulo,
                    libroDerecho.Titulo,
                    CultureInfo.CurrentCulture,
                    CompareOptions.IgnoreCase) > 0;

                if (debeIntercambiar)
                {
                    (libros[indice], libros[indice + 1]) =
                        (libros[indice + 1], libros[indice]);
                    intercambios++;
                    huboIntercambio = true;
                }

                numeroPaso++;
                alCompletarPaso?.Invoke(new PasoOrdenamiento(
                    numeroPaso,
                    pasada + 1,
                    indice,
                    libroIzquierdo.Titulo,
                    libroDerecho.Titulo,
                    debeIntercambiar,
                    libros.ToArray()));
            }

            // El arreglo ya esta ordenado.
            if (!huboIntercambio)
            {
                break;
            }
        }

        return new EstadisticasOrdenamiento(comparaciones, intercambios);
    }
}

public record PasoOrdenamiento(
    int Numero,
    int Pasada,
    int Indice,
    string TituloIzquierdo,
    string TituloDerecho,
    bool HuboIntercambio,
    Libro[] Libros);

public record EstadisticasOrdenamiento(int Comparaciones, int Intercambios);
