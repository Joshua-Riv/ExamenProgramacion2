using System;

string[] libros =
{
    "Don Quijote",
    "1984",
    "El Principito",
    "Dracula",
    "La Odisea"
};

string[,] prestamos = new string[20, 4];

int totalPrestamos = 0;

void pausa()
{
    Console.WriteLine();
    Console.WriteLine("Presione una tecla para continuar...");
    Console.ReadKey();
}

void mostrarCatalogo()
{
    Console.Clear();

    Console.WriteLine("===== CATALOGO DE LIBROS =====");

    for (int i = 0; i < libros.Length; i++)
    {
        Console.WriteLine($"{i}. {libros[i]}");
    }

    pausa();
}

void registrarPrestamo()
{
    Console.Clear();

    if (totalPrestamos >= 20)
    {
        Console.WriteLine("No hay espacio para mas prestamos.");
        pausa();
        return;
    }

    Console.WriteLine("Ingrese el nombre:");
    string nombre = Console.ReadLine();

    Console.WriteLine("Ingrese la cedula:");
    string cedula = Console.ReadLine();

    Console.WriteLine();
    Console.WriteLine("===== CATALOGO =====");

    for (int i = 0; i < libros.Length; i++)
    {
        Console.WriteLine($"{i}. {libros[i]}");
    }

    Console.WriteLine();
    Console.WriteLine("Seleccione el numero del libro:");

    int libro = int.Parse(Console.ReadLine());

    if (libro < 0 || libro >= libros.Length)
    {
        Console.WriteLine("Libro invalido.");
        pausa();
        return;
    }

    prestamos[totalPrestamos, 0] = nombre;
    prestamos[totalPrestamos, 1] = cedula;
    prestamos[totalPrestamos, 2] = libros[libro];
    prestamos[totalPrestamos, 3] = "Activo";

    totalPrestamos++;

    Console.WriteLine("Prestamo registrado correctamente.");

    pausa();
}

void buscarPersona()
{
    Console.Clear();

    Console.WriteLine("Ingrese la cedula:");
    string cedulaBuscar = Console.ReadLine();

    bool encontrado = false;

    for (int i = 0; i < totalPrestamos; i++)
    {
        if (prestamos[i, 1] == cedulaBuscar)
        {
            Console.WriteLine();
            Console.WriteLine("Nombre: " + prestamos[i, 0]);
            Console.WriteLine("Cedula: " + prestamos[i, 1]);
            Console.WriteLine("Libro: " + prestamos[i, 2]);
            Console.WriteLine("Estado: " + prestamos[i, 3]);

            encontrado = true;
            break;
        }
    }

    if (encontrado == false)
    {
        Console.WriteLine("Persona no encontrada.");
    }

    pausa();
}

void mostrarPrestamos()
{
    Console.Clear();

    Console.WriteLine("===== PRESTAMOS REGISTRADOS =====");

    if (totalPrestamos == 0)
    {
        Console.WriteLine("No hay prestamos registrados.");
    }
    else
    {
        for (int i = 0; i < totalPrestamos; i++)
        {
            Console.WriteLine(
                "Nombre: " + prestamos[i, 0] +
                " | Cedula: " + prestamos[i, 1] +
                " | Libro: " + prestamos[i, 2] +
                " | Estado: " + prestamos[i, 3]
            );
        }
    }

    pausa();
}

void menu()
{
    int opcion = 0;

    do
    {
        Console.Clear();

        Console.WriteLine("===== BIBLIOTECA SOLIDARISTA =====");
        Console.WriteLine("1. Mostrar catalogo");
        Console.WriteLine("2. Registrar prestamo");
        Console.WriteLine("3. Buscar persona por cedula");
        Console.WriteLine("4. Mostrar prestamos");
        Console.WriteLine("5. Salir");

        Console.WriteLine();
        Console.WriteLine("Digite una opcion");

        int.TryParse(Console.ReadLine(), out opcion);

        switch (opcion)
        {
            case 1:
                mostrarCatalogo();
                break;

            case 2:
                registrarPrestamo();
                break;

            case 3:
                buscarPersona();
                break;

            case 4:
                mostrarPrestamos();
                break;

            case 5:
                Console.WriteLine("Gracias por utilizar el sistema.");
                break;

            default:
                Console.WriteLine("Opcion invalida.");
                pausa();
                break;
        }

    } while (opcion != 5);
}

menu();