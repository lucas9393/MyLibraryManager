using System;
using LibraryManager.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace LibraryManager
{
    class Processor  
    {
        private DBMethods dBMethods;

        public Processor(DBMethods dBMethods)
        {
            this.dBMethods = dBMethods;
        }

        public bool CreateAuthor(string name, string surname)
        {
            using (var context = new LibraryContext())
            {
                var author = new Author
                {
                    Name = name,
                    Surname = surname
                };

                return dBMethods.AddAuthor(author);

            }
        }

       
        public bool CreateBook(string title, string category)
        {
            using (var context = new LibraryContext())
            {
                var book = new Book
                {
                    Title = title,
                    Category = category

                };

                return dBMethods.AddBook(book);
            }
        }


        public bool AssignBook(int idBook, int idAuthor)
        {
            return dBMethods.AssignBookToAuthor(idBook, idAuthor);
        }

        public bool RemoveBook(int idBook, int idAuthor)
        {
            return dBMethods.RemoveBookFromAuthor(idBook, idAuthor);
        }

        public List<Book> ShowBooks(int idAuthor)
        {
            return dBMethods.ShowBooksByAuthor(idAuthor);
        }

        public List<Book> ShowBooks(int idAuthor, string category)
        {

            return dBMethods.ShowBooksByAuthorAndCategory(idAuthor, category);
        }

        public int CountBooks(int idAuthor)
        {
            return dBMethods.CountBooksByAuthor(idAuthor);
        }

        public List<Store> ShowStores(int idBook)
        {
            return dBMethods.ShowStoresByBook(idBook);
        }

        public List<Conference> ShowConferences(int idAuthor)
        {
            return dBMethods.ShowConferencesByAuthor(idAuthor);
        }

    }
}
