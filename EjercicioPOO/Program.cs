using System.Text.Json;
using System.Text.Json.Serialization;

namespace EjercicioPoo
{
    public class Program
    {
        static void Main()
        {
            #region Carga de datos
            string data = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"data.json")   );

            #endregion
            
            try
            {
                List<CLibro> biblioteca = JsonSerializer.Deserialize<List<CLibro>>(data)!;
                CBiblioteca Biblioteca = new CBiblioteca();
                foreach (CLibro libro in biblioteca)
                {
                    Biblioteca.listaLibros.Add(libro);
                }
                char opcion;
                uint id;
                string titulo;
                do
                {
                    
                    char.TryParse(CInterfaz.DarOpcion().ToUpper(), out opcion);

                    switch (opcion)
                    {   
                        case 'A':
                              while(uint.TryParse(CInterfaz.PedirDato("Identificador del estudiante a registrar"), out id) == false)
                              {
                                CInterfaz.MostrarInfo("El identificador debe ser un entero sin signo");
                              }
                              if(Biblioteca.EstudianteUnico(id))
                              {
                                CInterfaz.MostrarInfo("Se registro exitosamente el estudiante en la lista de la biblioteca");
                              }
                              else
                              {
                                CInterfaz.MostrarInfo("Ya se encuentra registrado el estudiante con ese ID.");
                              }
                              break;
                        case 'B':
                            while (uint.TryParse(CInterfaz.PedirDato("Identificador del estudiante que pedira el libro"), out id) == false)
                            {
                                CInterfaz.MostrarInfo("El identificador debe ser un entero sin signo");
                            }
                            titulo = CInterfaz.PedirDato("Titulo de la obra");
                            CInterfaz.MostrarInfo(Biblioteca.PrestarLibro(titulo,id));
                            break;
                        case 'C':
                            while (uint.TryParse(CInterfaz.PedirDato("Identificador del estudiante que desea devolver el libro"), out id) == false)
                            {
                                CInterfaz.MostrarInfo("El identificador debe ser un entero sin signo");
                            }
                            titulo = CInterfaz.PedirDato("Titulo de la obra que quiere devolver");
                            CInterfaz.MostrarInfo(Biblioteca.DevolverLibro(titulo,id));
                            break;
                        case 'D':
                            CInterfaz.MostrarInfo(Biblioteca.ListarLibros());
                            break;
                        case 'E':
                            while (uint.TryParse(CInterfaz.PedirDato("Identificador del estudiante que desea listar sus libros"), out id) == false)
                            {
                                CInterfaz.MostrarInfo("El identificador debe ser un entero sin signo");
                            }
                            CInterfaz.MostrarInfo(Biblioteca.LibrosEstudiante(id));
                            break;
                    }

                } while (opcion != 'S');
                    

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hubo un error al leer el Json");
            }

            

            //Gestionar los prestamos de libros de una biblioteca
            // se debe poder prestar libros a estudiantes: 
            //  *  solo hay una copia por libro y hay que verificar a la hora de prestarlo si lo tenemos disponible o no
            // Se debe poder devolver libros 
            // Se debe poder listar todos los libros  y los que se prestaron
            // Se debe poder consultar los libros que tiene prestado un estudiante en particular


        }


    }
}