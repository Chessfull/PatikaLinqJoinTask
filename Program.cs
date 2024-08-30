using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PatikaLinqJoinTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ▼ Creating Authors Table ▼
            var authors = new[]
            {
            new {AuthorId=1, Name="Sabahattin Ali"},
            new {AuthorId=2, Name="Yahya Kemal Beyatlı"},
            new {AuthorId=3, Name="Halide Edip Adıvar"},
            new {AuthorId=4, Name="Edgar Ellan Poe"}
            };

            // ▼ Creating Books Table ▼
            var books = new[]
            {
                new {BookId=1, Title="Kürk Mantolu Madonna",AuthorId=1},
                new {BookId=2, Title="Kuyucaklı Yusuf",AuthorId=1},
                new {BookId=3, Title="Bitmemiş Şiirler",AuthorId=2},
                new {BookId=4, Title="Ateşten Gömlek",AuthorId=3},
                new {BookId=5, Title="Türk'ün Ateşla İmtihanı",AuthorId=3},
                new {BookId=6, Title="Kuzgun",AuthorId=4},
            };

            // ▼ Join two tables on AuthorId with Book Title and Author Linq method way ▼
            var titleAuthor = authors.Join(books,
                author => author.AuthorId,
                book => book.AuthorId,
                (author, book) => new
                {
                    Title = book.Title,
                    AuthorName = author.Name
                }).ToList();
            // ▼ Join with query way ▼
            var titleAuthorQuery = (from author in authors
                                   join book in books
                                   on author.AuthorId equals book.AuthorId
                                   select new { Title = book.Title, AuthorName = author.Name }).ToList();



            // ▼ Printing Title and Author
            titleAuthor.ForEach(I => Console.WriteLine(I.Title + " -> " + I.AuthorName));

            titleAuthorQuery.ForEach(I => Console.WriteLine(I.Title + " -> " + I.AuthorName));
        }
    }
}
