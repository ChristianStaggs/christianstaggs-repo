using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//filer class should never change the array, no getter or setter 
namespace _10_21
{
    public class BookFileHandler
    {
        private string fileName;
        private Book[] books;

        public BookFileHandler(Book[] books){
            this.books = books;
            fileName = "books.txt";
        }

        public void GetAllBooks(){
            Book.SetCount(0);
            StreamReader inFile = new StreamReader(fileName); //open file
            // process file
            string line = inFile.ReadLine();
            while(line != null){
                string [] temp = line.Split('#');
                books[Book.GetCount()] = new Book(temp[0], temp[1], temp[2], int.Parse(temp[3]));
                Book.IncCount();
                line = inFile.ReadLine();
            }
            inFile.Close();
        }
        public void SaveAllBooks(){
            StreamWriter outFile = new StreamWriter(fileName);
            for(int i = 0; i<Book.GetCount(); i++){
                outFile.WriteLine(books[i].ToFile());
            }
            outFile.Close();
        }
    }
}