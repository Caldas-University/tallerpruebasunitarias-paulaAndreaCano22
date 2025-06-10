public class Cuenta
{
    public int Id { get; set; }                         // Identificador único de la cuenta
    public int LimiteDeRetiro { get; set; }                  // Relación con el usuario dueño
    public decimal Saldo { get; set; }                  // Dinero disponible en la cuenta
    public bool Activa { get; set; }                    // Indica si la cuenta está activa
    public bool BloqueadaPorFraude { get; set; }        // Si la cuenta está bloqueada por seguridad
    public decimal LimiteDiarioRetiro { get; set; }     // Monto máximo que se puede retirar por día
    public decimal Contraseña { get; set; }             // Contraseña de la cuenta
    public decimal Intentos { get; set; }               // Contador de intentos de inicio de sesión
    public decimal RetiroDelDia { get; set; }           // Monto retirado hoy

    // Relación con Usuario (opcional si usas Entity Framework)
    public Usuario? Usuario { get; set; }               // Navegación (si EF)
}
