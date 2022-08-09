Console.WriteLine("BIENVENIDO AL GENERADOR DE CARTONES DE BINGO System 6.0 =)");
Console.WriteLine();
Console.WriteLine("VOY A IR GENERANDO DE A 3 CARTONES, PERO PUEDO CREAR MAS...");
Console.WriteLine();

var numeroAleatorio = new Random();
int cont = 0;

do
{
    cont++;
    Console.WriteLine("Presiona cualquier letra, pulsa enter y creare 3 más!!");
    Console.WriteLine("");
    for (int cards = 0; cards < 4; cards++)
    {
        //Generacion de matriz
        var carton = new int[3, 9];
        //Genero los numeros aleatorios por columna.
        for (int col = 0; col < 9; col++)
        {
            //Genero los numeros aleatorios por filas.
            for (int fil = 0; fil < 3; fil++)
            {
                //Creo una acumulador para los numeros nuevos
                int nuevoNumero = 0;
                var encontreUnoNuevo = false;
                
                while (!encontreUnoNuevo)
                {
                    bool esNuevo = true;
                    if (col == 0)
                    {
                        nuevoNumero = numeroAleatorio.Next(1, 10);
                    }
                    else if (col == 1)
                    {
                        nuevoNumero = numeroAleatorio.Next(11, 20);
                    }
                    else if (col == 2)
                    {
                        nuevoNumero = numeroAleatorio.Next(21, 30);
                    }
                    else if (col == 3)
                    {
                        nuevoNumero = numeroAleatorio.Next(31, 40);
                    }
                    else if (col == 4)
                    {
                        nuevoNumero = numeroAleatorio.Next(41, 50);
                    }
                    else if (col == 5)
                    {
                        nuevoNumero = numeroAleatorio.Next(51, 60);
                    }
                    else if (col == 6)
                    {
                        nuevoNumero = numeroAleatorio.Next(61, 70);
                    }
                    else if (col == 7)
                    {
                        nuevoNumero = numeroAleatorio.Next(71, 80);
                    }
                    else if (col == 8)
                    {
                        nuevoNumero = numeroAleatorio.Next(81, 90);
                    }
                    else
                    {
                        esNuevo = false;
                    }
                    for (int k = 0; k < 3; k++)
                    {
                        if (carton[k, col] == nuevoNumero)
                        {
                            esNuevo = false;
                            break;
                        }
                    }
                    if (esNuevo)
                    {
                        encontreUnoNuevo = true;
                    }
                }
                carton[fil, col] = nuevoNumero;
            }
        }
        //Cada fila tiene que tener 5 numeros distintos y 4 espacios, y en cada columna no tiene que haber 3 numeros.
        var borrados = 0;
        while (borrados < 12)
        {
            var filaAborrar = numeroAleatorio.Next(0, 3);
            var columnaAborrar = numeroAleatorio.Next(0, 9);
            if (carton[filaAborrar, columnaAborrar] == 0)
            {
                continue;
            }
            //Contar huecos en la fila
            var huecosEnFila = 0;
            for (int col = 0; col < 9; col++)
            {
                if (carton[filaAborrar, col] == 0)
                {
                    huecosEnFila++;
                }
            }
            //Contar huecos en la columna
            var huecosEnColumna = 0;
            for (int fil = 0; fil < 3; fil++)
            {
                if (carton[fil, columnaAborrar] == 0)
                {
                    huecosEnColumna++;
                }
            }
            //Contar cuantos numeros hay en cada columna.
            var numerosEnColumna = new int[9];
            for (int col = 0; col < 9; col++)
            {
                for (int fil = 0; fil < 3; fil++)
                {
                    if (carton[fil, col] != 0)
                    {
                        numerosEnColumna[col]++;
                    }
                }
            }
            //Cuantas columnas tiene 1 solo numero.
            var columnasConUnSoloNumero = 0;
            for (int i = 0; i < 9; i++)
            {
                if (numerosEnColumna[i] == 1)
                {
                    columnasConUnSoloNumero++;
                }
            }
            //Chekear los huecos en las filas sean 4 y en las columnas 2 huecos.
            if (huecosEnFila == 4 || huecosEnColumna == 2)
            {
                continue;
            }
            //Si hay  3 columnas con 1 solo numero, borrar las columnas que tiene 3 numeros.
            if (columnasConUnSoloNumero == 3 && numerosEnColumna[columnaAborrar] != 3)
            {
                continue;
            }
            carton[filaAborrar, columnaAborrar] = 0;
            borrados++;
        }
        //Muestro el carton generado.
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                if (j == 0)
                {
                    Console.Write("|");
                }
                if (carton[i, j] == 0)
                {
                    Console.Write("  |");
                }
                else
                {
                    Console.Write($"{carton[i, j]:00}|");
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine("=============================");
        Console.WriteLine($"Iteraccion para conseguir el carton: {cont}");
    }
      Console.WriteLine("Necesitas mas?? pulsa cualquier teclas+enter ó presiona 0 + enter para Cerrar.");
}
while (Console.ReadLine() != "0");