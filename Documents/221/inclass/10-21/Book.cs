using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_21
{
    public class Book
    {
        private string title;
        private string author;
        private string genre;
        private int pageCount;
        static private int count; // class variable

        public Book (){

        }

        public Book(string title, string author, string genre, int pageCount){
            this.title = title;
            this.genre = genre;
            this.author = author;
            this.pageCount = pageCount;
        }

        public void SetTitle(string title){
            this.title = title;
        }

        public string GetTitle(){
            return title;
        }


        public void SetAuthor(string author){
            this.author = author;
        }

        public string GetAuthor(){
            return author;
        }
        
        public void SetGenre(string genre){
            this.genre = genre;
        }

        public string GetGenre(){
            return genre;
        }
        
        public void SetPageCount(int pageCount){
            this.pageCount = pageCount;
        }

        public int GetPageCount(){
            return pageCount;
        }

        static public void SetCount(int count){
            Book.count = count;
        }

        static public int GetCount(){
            return count;
        }

        static public void IncCount(){
            count++;
        }

        public override string ToString()
        {
            return $"{title}\t{author}\t{genre}\t{pageCount}";
        }

        public string ToFile()
        {
            return $"{title}#{author}#{genre}#{pageCount}";
        }

        public int CompareTo(Book compareBook, string compareType = "t"){
            if (compareType == "t") 
            return title.CompareTo(compareBook.GetTitle());
            if (compareType == "gat"){
                string sortVar = genre + author + title;
                string compareVar = compareBook.GetGenre() + compareBook.GetAuthor() + compareBook.GetTitle();
                return sortVar.CompareTo(compareVar);
               
            }

        if (compareType == "g"){
            return genre.CompareTo(compareBook.GetGenre());
        }
            return 1;
        }
        
    }

}