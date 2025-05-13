namespace SistemaBancario.Communication.Requests
{
    public class RequestListTransfersJson
    {
        /// <summary>
        /// Data inicial (inclusive) do filtro. Opcional.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Data final (inclusive) do filtro. Opcional.
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
