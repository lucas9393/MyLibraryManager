using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using LibraryManager.Model;
using System.Linq;

namespace LibraryManager.DBConnection
{
    class EntityDBMethods : DBMethods
    {
        public bool AddAuthor(Author author)
        {
            using (var context = new LibraryContext())
            {            
                try
                {
                    context.Authors.Add(author);
                    context.SaveChanges();
                }

                catch (DbUpdateException)
                {
                    return false;
                }

                return true;
            }
        }

        public bool AddBook(Book book)
        {
            using (var context = new LibraryContext())
            {
                try
                {
                    context.Books.Add(book);
                    context.SaveChanges();
                }

                catch (DbUpdateException)
                {
                    return false;
                }

                return true;
            }
        }

        public bool AssignBookToAuthor(int bookId, int authorId)
        {
            using (var context = new LibraryContext())
            {            
                var book = context.Books.Find(bookId);

                if (book == null)
                {
                    return false;
                }

                book.AuthorId = authorId;
                
                try
                {
                    context.SaveChanges();
                }

                catch (DbUpdateException)
                {
                    return false;
                }

                return true;
            }
        }

        public bool RemoveBookFromAuthor(int bookId, int authorId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);

                if (book == null || book.AuthorId != authorId)
                {
                    return false;
                }

                book.AuthorId = null;
                

                try
                {
                    context.SaveChanges();
                }

                catch (DbUpdateException)
                {
                    return false;
                }

                return true;
            }
        }


        public List<Book> ShowBooksByAuthor(int authorId)
        {
            using (var context = new LibraryContext())
            {
                return context.Books.Where(b => b.AuthorId == authorId).ToList();
            }

        }

        public List<Book> ShowBooksByAuthorAndCategory(int authorId, string category)
        {
            using (var context = new LibraryContext())
            {
                return context.Books.Where(b => b.AuthorId == authorId && b.Category == category).ToList();
            }
        }

        public int CountBooksByAuthor(int authorId)
        {
            using (var context = new LibraryContext())
            {
                return context.Books.Where(b => b.AuthorId == authorId).Count();
            }
        }

        public List<Store> ShowStoresByBook(int bookId)
        {

            using (var context = new LibraryContext())
            {
              
                IEnumerable<Book> books = context.Books
                                          .Where(b => b.BookId == bookId)
                                          .Include(b => b.BookStores).ThenInclude(bs => bs.Store);

                Book myBook = books.First();

                IEnumerable<Store> stores = myBook
                                            .BookStores
                                            .Select(bs => bs.Store);


                List<Store> storeList = stores.ToList();
                return storeList;

            }
        }


        public List<Conference> ShowConferencesByAuthor(int authorId)
        {
            using (var context = new LibraryContext())
            {
                IEnumerable<Author> authors = context.Authors
                                          .Where(a => a.AuthorID == authorId)
                                          .Include(a => a.AuthorConferences).ThenInclude(ac => ac.Conference);

                Author myAuthor = authors.First();

                IEnumerable<Conference> conferences = myAuthor
                                            .AuthorConferences
                                            .Select(ac => ac.Conference);


                List <Conference> conferenceList = conferences.ToList();
                return conferenceList;

            }
        }


        public bool VerifyExistingBook(int bookId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Books.Find(bookId);

                if (book == null)
                    return false;

                else
                    return true;
            }

        }

        public bool VerifyExistingAuthor(int authorId)
        {
            using (var context = new LibraryContext())
            {
                var book = context.Authors.Find(authorId);

                if (book == null)
                    return false;

                else
                    return true;
            }

        }

    }
}
