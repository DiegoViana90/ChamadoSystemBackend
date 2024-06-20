    namespace ChamadoSystemBackend.DTOs{
    public class TicketUpdateDto
    {
        public string Description { get; set; }
        public bool IsClosed { get; set; }
        public int TicketId { get; set; }
        public int UserId  { get; set; }
    }
    }