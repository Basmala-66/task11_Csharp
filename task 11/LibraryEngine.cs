namespace task_11
{
    public delegate string BookFunction(Book B);
    public class LibraryEngine
    {


        // case 1,3,4
        public static void ProcessBooks1(List<Book> bList, BookFunction fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        // case 2 

        public static void ProcessBooks2(List<Book> bList, Func<Book, string> Ptr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(Ptr(B));
            }
        }




        

    }
}
