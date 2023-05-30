int[,] tablero = new int[5, 5];

int intentos = 0;
int barcos = 0;
void paso1_crear_tablero()
{
    for(int i = 0; i < tablero.GetLength(0); i++)
    {
        for(int j = 0; j < tablero.GetLength(1); j++)
        {
            tablero[i, j] = 0;
        }
    }
}
void paso2_colocar_barcos()
{
    //se ponen barcos pos fija

    tablero[1,1] = 1;
    tablero[1, 3] = 1;
    tablero[2, 4] = 1;
    tablero[4, 4] = 1;
    tablero[4, 2] = 1;
}

void paso3_imprimir_tablero()
{
    Console.WriteLine("Información");
    Console.WriteLine("Las filas y columnas empiezan por el numero 1");
    Console.WriteLine("Los - indican las posiciones, no indican si hay barco o no");
    Console.WriteLine("Los * indican que le ha dado a un barco");
    Console.WriteLine("Las X indican que no se encontraba un barco en esa posición\n");
    barcos = tablero.GetLength(0);
    intentos = 10;


        for (int i = 0; i < tablero.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.GetLength(1); j++)
            {
                    string caracter_imprimir;
                    switch (tablero[i, j])
                    {
                        case 1://barco en el tablero
                            caracter_imprimir = "-";
                            break;

                        case 2://le dió
                            caracter_imprimir = "*";
                            barcos--;
                            intentos--;
                            break;
                        case -1://falló
                            caracter_imprimir = "X";
                            intentos--;
                            break;
                        default:
                            caracter_imprimir = "-";
                            break;
                    }
                    Console.Write(caracter_imprimir + " ");

            }
            Console.WriteLine();
        }
        Console.WriteLine("\nBarcos restantes: " + barcos);
        Console.WriteLine("Intentos restantes: " + intentos);
}

void paso4_ingreso_coordenadas()
{
    int fila, columna = 0;
    int estado = 1;
    try {
        do
        {
            
            Console.Write("\nIngresa la Fila: ");
            fila = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingresa la Columna: ");
            columna = Convert.ToInt32(Console.ReadLine());


            if (tablero[fila - 1, columna - 1] == 1)
            {
                Console.Beep();
                tablero[fila - 1, columna - 1] = 2; //Se cambió a 2 porque sino nunca le iba a dar, antes tenía -1 
                
            }
            else
            {
                tablero[fila - 1, columna - 1] = -1;
                Console.WriteLine("Ha falldo el disparo");
            }
            Console.Clear();
            paso3_imprimir_tablero();
            if(barcos == 0)
            {
                estado = 0;
            }
            else if(intentos == 0)
            {
                estado = 0;
            }

        } while (estado != 0);
        
        if(barcos == 0)
        {
            Console.WriteLine("Todos los barcos han sido destruidos, felicidades juego terminado");
        }
        else if(intentos == 0)
        {
            Console.WriteLine("Todos los intentos han sido utilizados, juego terminado");

        }

    }
    catch(Exception e)
    {
        Console.WriteLine("Hubo un error: " + e);
    }
    
}

paso1_crear_tablero();
paso2_colocar_barcos();
paso3_imprimir_tablero();
paso4_ingreso_coordenadas();