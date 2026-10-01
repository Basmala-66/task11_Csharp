namespace task_11
{

    public class BookFunctions
    {

        public static  string GetTitle(Book B) => B.Title;
        
        public static string[] GetAuthors(Book B) =>B.Authors;
       
        public static string GetPrice(Book B) =>B.Price.ToString();


        public static string GetISBN(Book B) => B.ISBN;
        

    }
}
