Using System.Collections;
// definición e inicialización de los arreglos en paralelo y diccionario.
int[] población={185013,197119,439906,190863,530586,414543,229866,214317,475630,421050,174744,1546939,391903,593503,271581,135446,182645};
string[] Departamento ={"Boaco", "Carazo"," Chinanadega","Chontales","Costa caribe Norte","Costa Caribe Sur","Esteli,"" Granada","Jinotega","León","Madriz"," Managua","Masaya","Matagalpa","Nueva Segovia"};
Dictionary<string,int>diccionario=Departamento
  .Zip(población,(K,V)=>new{clave=K,valor=V})
  .ToDictionary(X=> X.clave,x =>x.valor);
//Ordenando el diccionario de menor a mayor 
var ordenando = diccionario.OrderBy(x =>x.value).ToDictionary(x => x.Key,x=>x.value);
//fijando los nombres de los departamentos con menor y mayor población.
string minDepkey = ordenado.First().key;
string maxDepkey = ordenado.Last().key;
//reasignación de los arreglos en paralelo. 
Departamento= ordenado.Keys.ToArray();
población = ordenando.Values.ToArray();
//Mostrar los arreglos oredenados de menor a mayor.
for  (var!=0;¡<población.Length;¡++)
 console.WriteLine($"{Departamento[¡],20} ==>{población[¡];10:N0}");
// suma de toda la población y nombre de mayor y menor.
 console.WriteLine($"población General:{población.sum():N0}";)
 console.WriteLine($" mayor población:{maxDepkey}");
 console.WriteLine($" menor población:{minDepkey}");
