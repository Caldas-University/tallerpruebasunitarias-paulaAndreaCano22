using NUnit.Framework;
using Entity;
using Controller;

namespace Test
{
    [TestFixture]
    public class CuentaControllerTests
    {
        private Cuenta CrearCuentaBase()
        {
            return new Cuenta
            {
                Activa = true,
                Saldo = 1000,
                LimiteDiarioRetiro = 500,
                BloqueadaPorFraude = false,
                RetiroDelDia = 0,
                Contraseña = 1234,
                Intentos = 0
            };
        }

        [Test]
        public void TC1_CumpleTodasLasCondiciones_DeberiaPermitirRetiro()
        {
            var cuenta = CrearCuentaBase();
            var controller = new CuentaController(cuenta);
            Assert.IsTrue(controller.PuedeRetirar(100));
        }

        [Test]
        public void TC2_CuentaInactiva_DeberiaRechazarRetiro()
        {
            var cuenta = CrearCuentaBase();
            cuenta.Activa = false;
            var controller = new CuentaController(cuenta);
            Assert.IsFalse(controller.PuedeRetirar(100));
        }

        [Test]
        public void TC3_SaldoInsuficiente_DeberiaRechazarRetiro()
        {
            var cuenta = CrearCuentaBase();
            cuenta.Saldo = 50;
            var controller = new CuentaController(cuenta);
            Assert.IsFalse(controller.PuedeRetirar(100));
        }

        [Test]
        public void TC4_MontoExcedeLimiteDiario_DeberiaRechazarRetiro()
        {
            var cuenta = CrearCuentaBase();
            var controller = new CuentaController(cuenta);
            Assert.IsFalse(controller.PuedeRetirar(600));
        }

        [Test]
        public void TC5_CuentaBloqueadaPorFraude_DeberiaRechazarRetiro()
        {
            var cuenta = CrearCuentaBase();
            cuenta.BloqueadaPorFraude = true;
            var controller = new CuentaController(cuenta);
            Assert.IsFalse(controller.PuedeRetirar(100));
        }

        [Test]
        public void TC6_MontoNoMultiploDe10_DeberiaRechazarRetiro()
        {
            var cuenta = CrearCuentaBase();
            var controller = new CuentaController(cuenta);
            Assert.IsFalse(controller.PuedeRetirar(105));
        }
    }
}
