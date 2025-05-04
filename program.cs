using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Definición e inicialización de los arreglos en paralelo y diccionario
        int[] población = { 185013, 197119, 439906, 190863, 530586, 414543, 229866, 214317, 475630, 421050, 174744, 1546939, 391903, 593503, 271581, 135446, 182645 };
        string[] Departamento = { "Boaco", "Carazo", "Chinandega", "Chontales", "Costa Caribe Norte", "Costa Caribe Sur", "Esteli", "Granada", "Jinotega", "León", "Madriz", "Managua", "Masaya", "Matagalpa", "Nueva Segovia" };

        // Crear un diccionario a partir de los arreglos
        Dictionary<string, int> diccionario = Departamento
            .Zip(población, (K, V) => new { clave = K, valor = V })
            .ToDictionary(X => X.clave, x => x.valor);

        // Ordenando el diccionario de menor a mayor
        var ordenando = diccionario.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        // Fijando los nombres de los departamentos con menor y mayor población
        string minDepkey = ordenando.First().Key;
        string maxDepkey = ordenando.Last().Key;

        // Reasignación de los arreglos en paralelo
        Departamento = ordenando.Keys.ToArray();
        población = ordenando.Values.ToArray();

        // Mostrar los arreglos ordenados de menor a mayor
        for (int i = 0; i < población.Length; i++)
        {
            Console.WriteLine($"{Departamento[i],20} => {población[i],10:N0}");
        }

        // Suma de toda la población y nombre de mayor y menor
        Console.WriteLine($"Población General: {población.Sum():N0}");
        Console.WriteLine($"Mayor población: {maxDepkey}");
        Console.WriteLine($"Menor población: {minDepkey}");
        
        // Cálculo de la población promedio
        Console.WriteLine($"Población promedio: {diccionario.Values.Average():N2}");
    }
}
