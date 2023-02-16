using FileAzure.Model;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;

internal class Program
{
    private static int NIP_CORRECTO = 1234; // NIP de ejemplo
    private static double saldo = 1000.0; // Saldo de ejemplo
    private static void Main(string[] args)
    {
        PantallaPrincipal();
    }
    private static void PantallaPrincipal()
    {  
        Console.WriteLine("\n\n");
        Console.WriteLine("\t\t\t\tBienvenido al Banco Unitec");
        Console.WriteLine("\t\t\t------------------------------------------");
        Console.WriteLine("\n\n\n");
        Console.WriteLine("\tIngrese su NIP de 4 dígitos: ");
        int nip = Convert.ToInt32(Console.ReadLine());
        if (nip != NIP_CORRECTO)
        {

            while (nip != NIP_CORRECTO)
            {
                Console.Clear();
                Console.WriteLine("\n\n");
                Console.WriteLine("\t\t\t\tBienvenido al Banco Unitec");
                Console.WriteLine("\t\t\t------------------------------------------");
                Console.WriteLine("\n\n\n");
                Console.WriteLine("\tIngrese su NIP de 4 dígitos: ");
                Console.WriteLine("\tNIP incorrecto.");
                nip = Convert.ToInt32(Console.ReadLine());
                Console.ReadKey();
            }
        }
        MenuPrincipal();
    }
    private static void MenuPrincipal()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("\tMenú principal");
            Console.WriteLine("\t--------------");
            Console.WriteLine("\t1. Consulta de Saldo");
            Console.WriteLine("\t2. Retiro de efectivo");
            Console.WriteLine("\t3. Depósito en efectivo");
            Console.WriteLine("\t4. Cambiar NIP");
            Console.WriteLine("\t5. Salir");
            Console.WriteLine("\tIngrese una opción: ");
            int opcion = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            switch (opcion)
            {
                case 1:
                    consultarSaldo();
                    break;
                case 2:
                    realizarRetiro();
                    break;
                case 3:
                    realizarDeposito();
                    break;
                case 4:
                    cambiarNIP();
                    break;
                case 5:
                    Console.WriteLine("\tSaliendo del programa...");
                    return;
                default:
                    Console.WriteLine("\tOpción inválida. Intente de nuevo.");
                    break;
            }

            Console.WriteLine("\tPresione cualquier tecla para continuar...");
            Console.ReadKey();
            Console.ReadKey();
            Console.Clear();
        }
    }

    private static void consultarSaldo()
    {
        Console.WriteLine("\n\n");
        Console.WriteLine("\tConsulta de Saldo");
        Console.WriteLine("\t-----------------");
        Console.WriteLine($"\tSu saldo actual es: {saldo}");
        Console.WriteLine("\tPresione 0 para volver al menu principal o 9 para terminar la operación ");
        int menu = Convert.ToInt32(Console.ReadLine());
        while (true)
        {

            Console.Clear();

            switch (menu)
            {
                case 0:
                    MenuPrincipal();
                    break;
                case 9:
                    PantallaPrincipal();
                    break;
            }
            Console.Clear();
        }
    }

    private static void realizarRetiro()
    {
        Console.WriteLine("\n\n");
        Console.WriteLine("\tRetiro de efectivo");
        Console.WriteLine("\t------------------");
        Console.WriteLine("\tIngrese la cantidad a retirar: ");
        double cantidad = Convert.ToDouble(Console.ReadLine());
        if (cantidad > saldo)
        {
            Console.WriteLine("\tFondos insuficientes. No se puede realizar la operación.");
            return;
        }
        saldo -= cantidad;
        Console.WriteLine($"\tRetiró {cantidad} Su saldo actual es: {saldo}\n", cantidad, saldo);
        Console.WriteLine("\tPresione 0 para volver al menu principal o 9 para terminar la operación ");
        int menu = Convert.ToInt32(Console.ReadLine());
        while (true)
        {

            Console.Clear();

            switch (menu)
            {
                case 0:
                    MenuPrincipal();
                    break;
                case 9:
                    PantallaPrincipal();
                    break;
            }
            Console.Clear();
        }
    }

    private static void realizarDeposito()
    {
        Console.WriteLine("\n\n");
        Console.WriteLine("\tDepósito en efectivo");
        Console.WriteLine("\t--------------------");
        Console.WriteLine("\tIngrese la cantidad a depositar: ");
        double cantidad = Convert.ToDouble(Console.ReadLine());
        saldo += cantidad;
        Console.WriteLine($"\tDepositó {cantidad} Su saldo actual es: {saldo}\n");
        Console.WriteLine("\tPresione 0 para volver al menu principal o 9 para terminar la operación ");
        int menu = Convert.ToInt32(Console.ReadLine());
        while (true)
        {

            Console.Clear();

            switch (menu)
            {
                case 0:
                    MenuPrincipal();
                    break;
                case 9:
                    PantallaPrincipal();
                    break;
            }
            Console.Clear();
        }
    }

    private static void cambiarNIP()
    {
        Console.WriteLine("\n\n");
        Console.WriteLine("\tCambiar Nip");
        Console.WriteLine("\t------------------");
        Console.WriteLine("\tIngrese su nip actual: ");
        int nip = Convert.ToInt32(Console.ReadLine());
        if (nip != NIP_CORRECTO)
        {
            Console.WriteLine("\tNIP incorrecto. Regresando al menu principal");
            MenuPrincipal();
        }
        else
        {
            Console.WriteLine("\tIngrese su nuevo nip: ");
            int nipNuevo = Convert.ToInt32(Console.ReadLine());
            NIP_CORRECTO = nipNuevo;
        }
        Console.WriteLine("\tPresione 0 para volver al menu principal o 9 para terminar la operación ");
        int menu = Convert.ToInt32(Console.ReadLine());
        while (true)
        {

            Console.Clear();

            switch (menu)
            {
                case 0:
                    MenuPrincipal();
                    break;
                case 9:
                    PantallaPrincipal();
                    break;
            }
            Console.Clear();
        }
    }
}
