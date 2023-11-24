using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
    public class CInterfaz
    {
        static CInterfaz()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }
        public static string DarOpcion()
        {
            Console.Clear();
            Console.WriteLine("*****************");
            Console.WriteLine("*     Sistema de Gestión de Biblioteca     *");
            Console.WriteLine("*****************");
            Console.WriteLine("\n[A] Registrar un estudiante.");
            Console.WriteLine("\n[B] Prestar un libro a un estudiante.");
            Console.WriteLine("\n[C] Devolver libro de un estudiante.");
            Console.WriteLine("\n[D] Listar todos los libros.");
            Console.WriteLine("\n[E] Consultar por los libros que tiene prestados un estudiante.");
            Console.WriteLine("\n[S] Salir de la aplicación.");
            Console.WriteLine("\n****************");
            return CInterfaz.PedirDato("opción elegida");
        }
        public static string PedirDato(string nombDato)
        {
            Console.Write("[?] Ingrese " + nombDato + ": ");
            string ingreso = Console.ReadLine();
            while (ingreso == "")
            {
                Console.Write("[!] " + nombDato + "es de ingreso OBLIGATORIO:");
                ingreso = Console.ReadLine();
            }
            Console.Clear();
            return ingreso.Trim();

        }
        public static void MostrarInfo(string mensaje)
        {
            Console.WriteLine(mensaje);
            Console.Write("<Pulse Enter>");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
