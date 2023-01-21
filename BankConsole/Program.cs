/*
Abstracción: Expresar las caraterísticas eseniales de un objeto, asi como su comportamiento.
 ¿Cuáles son sus características?
 ¿Qué acciones puede realizar?

Clase: Una plantilla que define las características y acciones de los objetos de un cierto tipo.

--> Las características se representan por medio de "propiedades"
--> Las acciones por medio de métodos.

Objeto: Un objeto es una entidad concreta basada en una clase

    Es una instancia de una clase.

    Es una variable del tipo de la clase.


Constructores: Los constructores son métodos de una clase que nos permite crear instancias (crear objetos) de la clase.
--> Mismo nombre de la clase
--> No definen un valor de retorno
--> No hay un límite para la cantidad de constructores.

Encapsulamiento: Se refiere al ocultamiento del estado (el conjunto de propiedades) de una clase
para que no sea modificado directamente.

Sobrecarga de métodos: La sobrecarga significa que,en una clase, existen dos o más métodos con el mismo nombre.

                        La diferencia entre ellos es la cantidad y/o el tipo de parámetros.

Clases estáticas (almacenar objetos en archivo JSON): Una clase "estática" no se puede instanciar;no se pueden crear objetos de ella.
                                                      Para acceder a los miembros de una clase estática se debe referenciar a la "clase misma".

Herencia: Es un mecanismo mediant el cuál se puede construir una "jerarquía de clases"

          En esta jerarquía, se definen clases hijas (o subclases) qe heredan las propiedades y métodos de su clase padre.
        
          Al heredar las propiedades y métodos de los padres, se posibilita la "reutilización" de código.

          A su vez, cada clase "hija" define propiedades y métodos propios, que la diferencian del "padre".

          Conforme se baja en la jeraarquía, se desarrollan clases cada vez más especificas.

Sobre escritura de métodos: La sobre escritura ocurre cuando una o más clases hijas implementan un método de la clase padre.

                            El método es el "mismo" (mismo nombre y parámetros), pero tiene una "implementación distinta" en las clases hijas.

Polimorfismo: La sobre escritura es una aplicación del polimmorfismo (muchas formas).

              Es la capacidad de los objetos de implementar de manera "diferente" a un "mismo" método

              Se produce el "mismo" efecto u objetivo básico, pero la implementación es "distinta".

Clases abstractas: Una clase abstracta no se puede instanciar; sólo sirve como clase base (padre). 

                   Su propósito es proveer una definición común que múltiples clases derivadas pueden compartir.

                   ->Puede definir elementos abstractos
                   ->Estos elementos deben ser implementados por las clases hijas
              
Interfaces: Una interfaz tampoco se puede instanciar.

-->Su propósito también es proveer una "definicion común que múltiples clases pueden compartir

-->Todos sus elementos son abstractos

-->Una clase que implementa a una interfaz debe implementar a todos sus elementos.
              
-->Una clase puede heredar de sólo "una clase", sea abstracta o no.

-->Sin embargo,una clase puede implementar múltiples interfaces.
*/

using BankConsole;

if (args.Length == 0)
    EmailService.SendMail();
else
    ShowMenu();

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine("Seleccioa una opción:");
    Console.WriteLine("1. Crear un usuario nuevo.");
    Console.WriteLine("2. Eliminar un usuario nuevo.");
    Console.WriteLine("3. Salir.");

    int option = 0;
    do
    {
        string input = Console.ReadLine();

        if(!int.TryParse(input, out option))
            Console.WriteLine("Debes ingresar un número (1, 2 o 3).");
        else if(option > 3)
            Console.WriteLine("Debes ingresar un número válido (1,2 o 3)");
    }while(option < 1 || option > 3);

    switch (option)
    {
        case 1:
            CreateUser();
            break;
        case 2:
            DeleteUser();
            break;
        case 3:
            Environment.Exit(0);
            break;
    }
}

void CreateUser()
{
    Console.Clear();
    Console.WriteLine("Ingresa la información del usuario:");

    Console.WriteLine("ID: ");
    int ID = int.Parse(Console.ReadLine());
    
    Console.WriteLine("Nombre: ");
    string name = Console.ReadLine();

    Console.WriteLine("Email: ");
    string email = Console.ReadLine();

    Console.WriteLine("Saldo: ");
    decimal balance = decimal.Parse(Console.ReadLine());

    Console.WriteLine("Escribe 'c' si el usuario es Cliente, '2' si es Empleado: ");
    char userType = char.Parse(Console.ReadLine());

    User newUser;

    if(userType.Equals('c'))
    {
        Console.Write("Regimen Fiscal: ");
        char taxRegime = char.Parse(Console.ReadLine());

        newUser = new Client(ID, name, email, balance, taxRegime);

    }
    else
    {
        Console.Write("Departamento: ");
        string departament = Console.ReadLine();

        newUser = new Employee(ID, name, email, balance, departament);
    }

    Storage.AddUser(newUser);

    Console.WriteLine("Usuario creado");
    Thread.Sleep(2000);
    ShowMenu();
}

void DeleteUser()
{
    Console.Clear();

    Console.Write("Ingresa el ID del usuario a eliminar: ");
    int ID = int.Parse(Console.ReadLine());

    string result = Storage.DeleteUser(ID);

    if (result.Equals("Success"))
    {
        Console.Write("Usuario eliminado.");
        Thread.Sleep(2000);
        ShowMenu();
    } 
}
// andres.ID = 1;
// andres.Name = "Andres";
// andres.Email = "andresbc@gmail.com";
// andres.Balance = 10000;
// andres.RegisterDate = DateTime.Now;



// alejandro.SetBalance(2000);

//Storage.AddUser(andres);
// Console.WriteLine(alejandro.ShowData());