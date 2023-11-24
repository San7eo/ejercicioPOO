using System.Text.Json.Serialization;

namespace EjercicioPoo
{
    public class CBiblioteca
    {
       public List<CEstudiante> estudiantes = new List<CEstudiante>();
        public List<CLibro> listaLibros {  get; set; }

        public CBiblioteca()
        {
            listaLibros = new List<CLibro>();
        }

       
        public bool EstudianteUnico(uint id)
        {
            foreach (CEstudiante estudiante in estudiantes)
            {
                if (estudiante.Id == id)
                {
                    return false;
                }
            }
            RegistrarEstudiante(id);
            return true;
        }
        public void RegistrarEstudiante(uint id)
        {
            CEstudiante estudiante = new CEstudiante();
            estudiante.Id = id;
            estudiantes.Add(estudiante);
        }

        public CEstudiante BuscarEstudiante(uint id)
        {
            foreach (CEstudiante estudiante in estudiantes)
            {
                if (estudiante.Id == id)
                {
                    return (CEstudiante)estudiante;
                }
            }
            return null;
        }

        public string PrestarLibro(string titulo, uint id)
        {
            string dato = "No se encontro el libro que busca dentro del repertorio";
            foreach(CLibro libro in  listaLibros) 
            { 
                if(libro.titulo.ToUpper() == titulo.ToUpper())
                {//fggfgf
                    if(libro.prestado)
                    {
                        return dato = "El libro que busca ya se encontra prestado";
                    }
                    else
                    {
                        CEstudiante estudiante = BuscarEstudiante(id);
                        if(estudiante != null)
                        {
                            libro.ocupar();
                            estudiante.libros.Add(libro);
                            return dato = "Se asigno el libro a la lista de libros del estudiante y ahora se encuentra ocupado!";
                        }
                        else
                        {
                            return dato = "El estudiante que indico no se encuentra dentro de la lista debe registrarlo primero";
                        }
                    }
                } 
            }
            return dato;
        }

        public string DevolverLibro(string titulo, uint id)
        {
            string dato = "No se encontro el libro que busca dentro del repertorio";
            foreach (CLibro libro in listaLibros)
            {
                if (libro.titulo.ToUpper() == titulo.ToUpper())
                {
                    if (libro.prestado)
                    {
                        CEstudiante estudiante = BuscarEstudiante(id);
                        if (estudiante != null)
                        {
                            libro.desocupar();
                            estudiante.libros.Remove(libro);
                            return dato = "Se devolvio el libro del estudiante y ahora se encuentra desocupado!";
                        }
                    }
                    else
                    {
                        return dato = "El libro ya se encontraba a disposicion en primera instancia";
                    }
                }
            }
            return dato;
        }

        public string ListarLibros()
        {
            string dato = "";

            foreach(CLibro libro in listaLibros)
            {   
                if(libro.prestado)
                {
                    dato += $"{libro.DarDatos()} [PRESTADO]\n\n";
                }
                else
                {
                    dato += $"{libro.DarDatos()}\n\n";
                }
                
            }
            return dato;
        }

        public string LibrosEstudiante(uint id) 
        { 
            foreach(CEstudiante estudiante in estudiantes) 
            { 
                if(estudiante.Id == id)
                {
                    return estudiante.DarDatos();
                }
            }
            return "El estudiante no se encontro";
        }
        
    }
}
