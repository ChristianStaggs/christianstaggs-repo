using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_21
{
    public class BookReport
    {
        private Book[] books;

        public BookReport(Book[] books){
            this.books = books;
        }

        public void PrintAllBooks(){
            for(int i = 0; i<Book.GetCount(); i++){
                System.Console.WriteLine(books[i].ToString());
            }
        }
        

        public void PagesByGenre(){
            int total = books[0].GetPageCount();
            int genreCount = 1;
            string curr = books[0].GetGenre();
            for(int i = 1; i<Book.GetCount();i++){
                if(curr == books[i].GetGenre()){
                    total += books[i].GetPageCount();
                    genreCount++;
                }
                else{
                    ProcessBreak(ref curr, ref total, ref genreCount, i);
                }
            }
            ProcessBreak(curr, total, genreCount);
        }

        private void ProcessBreak(ref string curr, ref int total, ref int genreCount, int i){
            System.Console.WriteLine($"{curr}\t{total/genreCount}");
            curr = books[i].GetGenre();
            total = books[i].GetPageCount();
            genreCount = 1;
        }

        private void ProcessBreak(string curr, int total, int genreCount){
            System.Console.WriteLine($"{curr}\t{total/genreCount}");
        }
    

    public void CombinationPageCountReport(){
        for(int i = 0; i<Book.GetCount()-1; i++){
            for(int j = i+1; j<Book.GetCount(); j++){
                if(books[i].GetPageCount()+books[j].GetPageCount() > 800){
                System.Console.WriteLine($"{books[i].GetTitle()}: {books[i].GetPageCount()}\t{books[j].GetTitle()}: {books[j].GetPageCount()}");
            }
            }
        }
    }
    }
}