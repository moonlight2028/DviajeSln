namespace Dviaje.Models
{
    /// <summary>
    /// Representa los posibles estados de una reserva en el sistema.
    /// Los estados disponibles son:
    /// - Activo: La reserva está activa y pendiente de ser utilizada.
    /// - Cancelado: La reserva ha sido cancelada por el usuario o el sistema.
    /// - Aprobado: La reserva ha sido aprobada y está lista para ser utilizada.
    /// </summary>
    public enum ReservaEstado
    {
        Activo,
        Cancelado,
        Aprobado
    }
}
