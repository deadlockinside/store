using System.Text.RegularExpressions;

namespace Store
{
    public class Book
    {
        public int Id { get; }

        public string Isbn { get; }

        public string Autor { get; }

        public string Title { get; }

        public Book(int id, string isbn, string autor, string title)
        {
            Id = id;
            Isbn = isbn;
            Autor = autor;
            Title = title;
        }

        internal static bool IsIsbn(string s) 
        {
            if (s is null)
                return false;

            s = s.Replace("-", "").Replace(" ", "").ToUpper();

            return Regex.IsMatch(s, @"^ISBN\d{10}(\d{3})?$");
        }
    }
}
