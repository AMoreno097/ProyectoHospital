using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Negocio
{
    public class Hospital
    {
        public static Modelo.Result GetAll(Modelo.Hospital hospital)
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.HospitalesCdmxContext context = new Conexion.HospitalesCdmxContext()) 
                {

                    var query = context.Hospitals.FromSqlRaw($"MostrarHospitales").ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            hospital = new Modelo.Hospital();
                            hospital.IdHospital = obj.IdHospital;
                            hospital.Nombre = obj.Nombre;
                            hospital.Direccion = obj.Direccion;
                            hospital.AñodeCreacion = obj.AñodeConstruccion.Value;
                            hospital.Capacidad = obj.Capacidad.Value;
                            hospital.Especialidad = new Modelo.Especialidad();
                            hospital.Especialidad.IdEspecialidad = obj.IdEspecialidad.Value;
                            hospital.Especialidad.Nombre = obj.Especialidad;

                            result.Objects.Add(hospital);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puedo obtener la tabla";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;

        }

        public static Modelo.Result Delete(int IdHospital)
        {

            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.HospitalesCdmxContext context = new Conexion.HospitalesCdmxContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"EliminarHospital {IdHospital}");

                    if (query != 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al eliminar el hospital";
                    }
                }
                return result;
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return new Modelo.Result();

        }
        public static Modelo.Result Add(Modelo.Hospital hospital)
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.HospitalesCdmxContext context = new Conexion.HospitalesCdmxContext())
                {
                    int filasAfectadas = context.Database.ExecuteSqlRaw($"AgregarHospital '{hospital.Nombre}', '{hospital.Direccion}', {hospital.AñodeCreacion}, {hospital.Capacidad}, {hospital.Especialidad.IdEspecialidad}");
                    if (filasAfectadas > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
        public static Modelo.Result GetById(int IdHospital)
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.HospitalesCdmxContext context = new Conexion.HospitalesCdmxContext())
                {
                    var obj = context.Hospitals.FromSqlRaw($"MostrarHospitalXId {IdHospital}").AsEnumerable().FirstOrDefault();
                    result.Object = new List<object>();
                    if (obj != null)
                    {

                        Modelo.Hospital hospital = new Modelo.Hospital();
                        hospital.IdHospital = obj.IdHospital;
                        hospital.Nombre = obj.Nombre;
                        hospital.Direccion = obj.Direccion;
                        hospital.AñodeCreacion = obj.AñodeConstruccion.Value;
                        hospital.Capacidad = obj.Capacidad.Value;

                        hospital.Especialidad = new Modelo.Especialidad();
                        hospital.Especialidad.IdEspecialidad = obj.IdEspecialidad.Value;
                        hospital.Especialidad.Nombre = obj.Especialidad;

                        result.Object = hospital;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se puedo obtener la tabla";
                    }
                }
            }
            catch
            {

            }
            return result;
        }
        public static Modelo.Result Update(Modelo.Hospital hospital)
        {
            Modelo.Result result = new Modelo.Result();
            try
            {
                using (Conexion.HospitalesCdmxContext context = new Conexion.HospitalesCdmxContext())
                {
                    int query = context.Database.ExecuteSqlRaw($"ModificarHospital {hospital.IdHospital}, '{hospital.Nombre}', '{hospital.Direccion}', {hospital.AñodeCreacion}, {hospital.Capacidad}, {hospital.Especialidad.IdEspecialidad}");

                    if (query >= 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al modificar al usuario";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }

            return result;
        }
    }
}