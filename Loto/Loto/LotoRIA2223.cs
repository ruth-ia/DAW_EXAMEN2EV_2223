using System;

namespace LotoClassNS
{
    // Clase que almacena una combinación de la lotería
    //
    public class LotoRIA2223
    {
        // definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;
        
        private int[] numeros = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool combinacionValida = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        public int[] Numeros { 
            get =>  numeros; 
            set =>  numeros = value; 
        }

        // En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta
        //
        public LotoRIA2223()
        {
            Random r = new Random();    // clase generadora de números aleatorios

            int i = 0, num;

            do             // generamos la combinación
            {                       
                num = r.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);     // generamos un número aleatorio del 1 al 49
                for (int j = 0; j < i; j++)    // comprobamos que el número no está
                    if (Numeros[j] == num)
                        break;
                if (i == j)               // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                {
                    Numeros[i] = num;
                    i++;
                }
            } while (i < MAX_NUMEROS);

            combinacionValida = true;
        }

        // La segunda forma de crear una combinación es pasando el conjunto de números
        // misnums es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)
        public LotoRIA2223(int[] misnums)  // misnumeros: combinación con la que queremos inicializar la clase
        {
            for (int i = 0; i < MAX_NUMEROS; i++)
                if (misnums[i] >= NUMERO_MENOR && misnums[i] <= NUMERO_MAYOR) {
                    int j;
                    for (j=0; j<i; j++) 
                        if (misnums[i] == Numeros[j])
                            break;
                    if (i == j)
                        Numeros[i] = misnums[i]; // validamos la combinación
                    else {
                        combinacionValida = false;
                        return;
                    }
                }
                else
                {
                    combinacionValida = false;     // La combinación no es válida, terminamos
                    return;
                }
	    combinacionValida = true;
        }

        // Método que comprueba el número de aciertos
        // premi es un array con la combinación ganadora
        // se devuelve el número de aciertos
        public int comprobar(int[] premi)
        {
            int a = 0;                    // número de aciertos
            for (int i = 0; i < MAX_NUMEROS; i++)
                for (int j = 0; j < MAX_NUMEROS; j++)
                    if (premi[i] == Numeros[j]) a++;
            return a;
        }
    }

}
