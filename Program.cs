using Microsoft.Data.Sqlite;

namespace SQliteConnectProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter id: ");
            var id =Console.ReadLine();
            using (var connection = new SqliteConnection("Data Source=C:\\Users\\Admin\\Desktop\\SQLiteStudio\\bookstores.db"))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                    @"
                       SELECT *
                       FROM book;
                    ";
                command.Parameters.AddWithValue("id", id);
                using (var reader = command.ExecuteReader()) 
                { 
                    while (reader.Read()) 
                    { 
                        var bookId = reader.GetString(0);
                        var title = reader.GetString(1);
                        var year = reader.GetString(2);
                        var publisher = reader.GetString(3);

                        Console.WriteLine($"Book id: {bookId}");
                        Console.WriteLine($"Title: {title}");
                        Console.WriteLine($"Year: {year}");
                        Console.WriteLine($"Publisher: {publisher}");
                    }
                }

            }
        }
    }
}