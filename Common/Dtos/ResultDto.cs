namespace Common.Dtos
{
    public class ResultDto
    {
        public Guid Id { get; set; }
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<object> Items { get; set; } = new();
    }
}