using System;

namespace LotoClassNS
{   /// <summary>
    /// Clase que almacena una combinación de la lotería
    /// </summary>
    public class LotoRIA2223
    {
        // definición de constantes
        public const int MAX_NUMEROS = 6;
        public const int NUMERO_MENOR = 1;
        public const int NUMERO_MAYOR = 49;
        
        private int[] numeros = new int[MAX_NUMEROS];   // numeros de la combinación
        public bool combinacionValida = false;      // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)

        /// <summary>
        /// Obtiene y devuelve la lista de numeros.
        /// Cada numero debe estar entre 1 y 49
        /// </summary>
        /// <value>Numeros de la loto</value>
        public int[] Numeros { 
            get =>  numeros; 
            set =>  numeros = value; 
        }

        /// <summary>
        /// <para> Constructor para inicializar sin parámetos una combinacion de loteria </para>
        /// <para> En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta </para>
        /// </summary>
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

        /// <summary>
        /// <para> Constructor con parámetros </para>
        /// <para> La segunda forma de crear una combinación es pasando el conjunto de números </para>
        /// <para> En el caso de que el constructor sea vacío, se genera una combinación aleatoria correcta </para>
        /// </summary>
        /// <param 
        ///     name="misNumeros">Lista de numeros elegidos por el usuario.
        ///     <remarks> Es un array de enteros con la combinación que quiero crear (no tiene porqué ser válida)</remarks>
        /// </param>
        public LotoRIA2223(int[] misNumeros)  
        {
            for (int i = 0; i < MAX_NUMEROS; i++)
                if (misNumeros[i] >= NUMERO_MENOR && misNumeros[i] <= NUMERO_MAYOR) {
                    int j;
                    for (j=0; j<i; j++) 
                        if (misNumeros[i] == Numeros[j])
                            break;
                    if (i == j)
                        Numeros[i] = misNumeros[i]; // validamos la combinación
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

        /// <summary>
        /// <para> Método que comprueba el número de aciertos </para>
        /// </summary>
        /// <param 
        ///     name="premi">Es un array con la combinación ganadora.
        /// </param>
        /// <returns>Se devuelve el numero de aciertos</returns>
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
