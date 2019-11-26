using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            Correo c = new Correo();
            Assert.IsNotNull(c.Paquetes);
        }

        [TestMethod]
        public void IgualTrackingID()
        {
            try
            {
                Correo c = new Correo();
                Paquete p1 = new Paquete("Entrega1", "0123456789");
                Paquete p2 = new Paquete("Entrega2", "0123456789");
                c += p1;
                c += p2;
            
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(TrackingIdRepetidoException));

            }
        }


    }
}
