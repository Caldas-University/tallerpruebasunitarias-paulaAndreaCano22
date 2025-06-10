public class Usuario
{
    public int Id { get; set; }                // Identificador único
    public string Nombre { get; set; }         // Nombre completo del usuario
    public string Correo { get; set; }         // Email del usuario
    public string Contraseña { get; set; }     // Contraseña (normalmente encriptada)
    public bool Activo { get; set; }           // Si el usuario está habilitado en el sistema
}
