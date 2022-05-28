namespace ASP.NET_Core_6._0_API.DTO
{
    public class FilterBooksDTO
    {
        public string? Name { get; set; } = null!;
        public DateTime? PublisherDate { get; set; }
        public int? PublisherId { get; set; }
        public string? Isbn { get; set; } = null!;
        public int? LanguageId { get; set; }

        public string? LanguageName { get; set; } = null!;

        public int? NumberOfPages { get; set; }
        public string? Description { get; set; }
    }
}
