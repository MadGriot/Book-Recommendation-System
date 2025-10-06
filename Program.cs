namespace BookRecommendationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the book Recommendation Program");

            bool filesFound = false;
            string? booksFilePath;
            string? ratingsFilePath;
            StreamReader booksReader = null;
            StreamReader ratingsReader = null;
            while (!filesFound)
            {
                Console.Write("Enter books file: ");
                booksFilePath = Console.ReadLine();
                Console.Write("Enter ratings file: ");
                ratingsFilePath = Console.ReadLine();
                try
                {
                    booksReader = new StreamReader(booksFilePath);
                    ratingsReader = new StreamReader(ratingsFilePath);

                    filesFound = true;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("One of your file paths is incorrect.");
                }
                catch (Exception)
                {
                    Console.WriteLine("An error has occured.");
                }
                Console.WriteLine();
                int numberOfBooks = BookSystem.CountAndStoreBooks(booksReader);
                Console.WriteLine($"Number of Books: {numberOfBooks}");
                int numberOfMembers = BookSystem.CountAndStoreMembers(ratingsReader);
                Console.WriteLine($"Number of Members: {numberOfMembers}");
            }

        }
    }
}
