using _10_21;

Book [] books = new Book[100];
BookFileHandler bookFileHandler = new BookFileHandler(books);
bookFileHandler.GetAllBooks();
BookReport bookReport = new BookReport(books);
bookReport.PrintAllBooks();

BookUtility bookUtility = new BookUtility(books);
System.Console.WriteLine("\n\n");
bookUtility.Sort("gat");
bookReport.PrintAllBooks();

bookUtility.AddBook();
bookFileHandler.SaveAllBooks();
System.Console.WriteLine("\n\n\n");
bookReport.PrintAllBooks();