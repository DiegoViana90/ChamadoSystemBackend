namespace ChamadoSystemBackend.DTOs
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
