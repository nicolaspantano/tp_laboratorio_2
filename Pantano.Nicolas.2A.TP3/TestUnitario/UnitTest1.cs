using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Archivos;
using Excepciones;
namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ExpecionAlumnoRepetido()
        {

            try
            {
                Universidad u = new Universidad();               
                Alumno a1 = new Alumno(1001, "Juan", "Perez", "43324757", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno a2 = new Alumno(1001, "Juan", "Perez", "43324757", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                u += a1;
                u += a2;        
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
                
            }

        }

        [TestMethod]
        public void ExcepcionNacionalidadInvalida()
        {
            try
            {
                Alumno a1 = new Alumno(1001, "Juan", "Perez", "99998888", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            }
            catch(Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

        }

        [TestMethod]
        public void AtributosNull()
        {                        
            Alumno a1 = new Alumno();
            Assert.IsNotNull(a1.DNI);
            Assert.IsNotNull(a1.Nombre);
            Assert.IsNotNull(a1.Apellido);            
            Assert.IsNotNull(a1.Nacionalidad);

        }
        [TestMethod]
        public void AtributosInt()
        {
            Alumno a1 = new Alumno(1001, "Juan", "Perez", "11111111", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Assert.AreEqual(a1.DNI, 11111111);        
        }
    }
}
