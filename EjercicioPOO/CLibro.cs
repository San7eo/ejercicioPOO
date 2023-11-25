
namespace EjercicioPoo
{
    public class CLibro
    {
        public string titulo {  get; set; }
        public string autor {  get; set; }
        public string descripcion { get; set; }
        public bool prestado { get; set; }


        public void ocupar()
        {
            this.prestado = true;
        }
        public void desocupar()
        {
            this.prestado = false;
        }
        public string DarDatos()
        {           
            return $"Titulo: {this.titulo}  -  \nAutor: {this.autor} - \nDescripcion: {this.descripcion} ";          
        }
       
    }
}
