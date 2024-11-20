using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_21
{
    public class BookUtility
    {
        private Book[] books;

        public BookUtility(Book[] books){
            this.books = books;
        }

        public void AddBook(){
            int count = Book.GetCount();
            books[count] = new Book();
            System.Console.WriteLine("what is the title ");
            books[count].SetTitle(Console.ReadLine());
            System.Console.WriteLine("Whos the author");
            books[count].SetAuthor(Console.ReadLine());
            System.Console.WriteLine("Genre");
            books[count].SetGenre(Console.ReadLine());
            System.Console.WriteLine("how many pages");
            books[count].SetPageCount(int.Parse(Console.ReadLine()));
            Book.IncCount();
        }   
        public void Sort(string compare = "t"){
            for(int i=0; i<Book.GetCount()-1;i++){
                int min = i;
                for(int j = i+1; j<Book.GetCount(); j++){
                    if (books[j].CompareTo(books[min], "gat")<0){
                        min = j;
                    }
                    if (min != i){
                        Swap(min,i);
                    }
                }
            }
        }
        public void Swap(int x, int y){
            Book temp = books[x];
            books[x] = books[y];
            books[y] = temp;
        }

         public int SearchByTitle(string searchVal){
            int foundIndex = -1;
            int first = 0;
            int last = Book.GetCount()-1;
            int middle = 0;
            bool found = false;

            while (!found && first <= last){
                middle = (first+last)/2;
                if(searchVal.ToUpper() == books[middle].GetTitle().ToUpper()){
                    found = true;
                    foundIndex = middle;
                }
                else if (searchVal.ToUpper().CompareTo(books[middle].GetTitle().ToUpper())<0){
                    last = middle-1;
                }
                else{
                    first = middle +1; 
                }
            }
            return foundIndex;
        }
    }

}