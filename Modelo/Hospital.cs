namespace Modelo
{
    public class Hospital
    {
        public int IdHospital { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int AñodeCreacion  { get; set; }
        public int Capacidad  { get; set; }
        public Modelo.Especialidad Especialidad  { get; set; }

        public List<object> ListaHospitales { get; set; }
    }
}