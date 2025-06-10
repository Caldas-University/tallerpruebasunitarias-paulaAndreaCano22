using Entity;

namespace Controller
{
    public class CuentaController
    {
        private readonly Cuenta _cuenta;

        public CuentaController(Cuenta cuenta)
        {
            _cuenta = cuenta;
        }

        public bool PuedeRetirar(decimal monto)
        {
            if (!_cuenta.Activa) return false;
            if (_cuenta.BloqueadaPorFraude) return false;
            if (_cuenta.Saldo < monto) return false;
            if (monto > _cuenta.LimiteDiarioRetiro - _cuenta.RetiroDelDia) return false;
            if (monto % 10 != 0) return false;

            return true;
        }

        public void Retirar(decimal monto)
        {
            if (!PuedeRetirar(monto))
                throw new InvalidOperationException("No se puede realizar el retiro.");

            _cuenta.Saldo -= monto;
            _cuenta.RetiroDelDia += monto;
        }

        public void RegistrarIntentoFallido()
        {
            _cuenta.Intentos++;
            if (_cuenta.Intentos >= 3)
                _cuenta.BloqueadaPorFraude = true;
        }

        public void ReiniciarIntentos()
        {
            _cuenta.Intentos = 0;
        }

        public void ReiniciarRetiroDelDia()
        {
            _cuenta.RetiroDelDia = 0;
        }

        public bool ValidarContraseña(int input)
        {
            return _cuenta.Contraseña == input;
        }
    }
}
