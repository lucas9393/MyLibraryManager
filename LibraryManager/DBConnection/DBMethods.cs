﻿
using LibraryManager.Model;
using System.Collections.Generic;

namespace LibraryManager
{
    interface DBMethods
    {
        bool AddAuthor(Author author);
        bool AddBook(Book book);
        bool AssignBookToAuthor(int bookId, int authorId);
        bool RemoveBookFromAuthor(int bookId, int authorId);
        List<Book> ShowBooksByAuthor(int authorId);
        List<Book> ShowBooksByAuthorAndCategory(int authorId, string category);
        int CountBooksByAuthor(int authorId);

        List<Store> ShowStoresByBook(int bookId);
        List<Conference> ShowConferencesByAuthor(int authorId);

        bool VerifyExistingBook(int bookId);
        bool VerifyExistingAuthor(int authorId);
    }
}
