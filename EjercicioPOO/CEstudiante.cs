using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioPoo
{
   public class CEstudiante
    {   
        public uint Id { get; set; }
        public List<CLibro> libros { get; set;}

        public CEstudiante()
        {
            libros = new List<CLibro>();
        }

        public string DarDatos()
        {
            string Listalibros = "";

            if(libros.Count > 0) 
            {
                foreach (CLibro libro in libros)
                {
                    Listalibros += libro.DarDatos();
                }
            }
            else
            {
                Listalibros = "El estudiente no cuenta con libros";
            }


            return $"Id: {this.Id} Lista de libros: {Listalibros}";                    
        }
        
    }
}
