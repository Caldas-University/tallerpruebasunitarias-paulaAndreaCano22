namespace Entity
{
public class Cuenta
{
    public int Id { get; set; }
    public int LimiteDeRetiro { get; set; }
    public decimal Saldo { get; set; }
    public bool Activa { get; set; }
    public bool BloqueadaPorFraude { get; set; }
    public decimal LimiteDiarioRetiro { get; set; }
    public int Contraseña { get; set; }
    public int Intentos { get; set; }
    public decimal RetiroDelDia { get; set; }

    public Usuario? Usuario { get; set; }
}


};

