using System;
using System.Collections.Generic;
using LibraryManager.Model;

namespace LibraryManager
{
    class UserInterface
    {
        private Processor processor;
        const string MENU_MESSAGE = "\nInserisci:\n" +
                                        "'A' per aggiungere un autore;\n" +
                                        "'B' per aggiungere un libro;\n" +
                                        "'S' per assegnare un libro all'autore;\n" +
                                        "'R' per rimuovere un libro da un autore\n" +
                                        "'M' per mostrare i libri di un dato autore\n" +
                                        "'C' per mostrare i libri di un dato autore in una data categoria;\n" +
                                        "'N' per vedere il numero dei libri di un dato autore;\n" +
                                        "'T' per mostrare in quanti magazzini si trova un libro;\n" +
                                        "'V' per mostrare quante conferenze ha partecipato un autore;\n" +
                                        "'Q' per uscire dal programma;\n";

        public UserInterface(Processor processor)
        {
            this.processor = processor;
        }

        public void MainMenu()
        {
            Console.WriteLine(MENU_MESSAGE);
            string input = ReadAnswer().ToLower();

            switch (input[0])
            {
                case 'a':
                    AddAuthor();
                    break;

                case 'b':
                    AddBook();
                    break;

                case 's':
                    AssignBookToAuthor();
                    break;

                case 'r':
                    RemoveBookFromAuthor();
                    break;

                case 'm':
                    ShowBooksByAuthor();
                    break;

                case 'c':
                    ShowBooksByAuthorAndCategory();
                    break;

                case 'n':
                    NumberOfBooksByAuthor();
                    break;

                case 't':
                    BookInStores();
                    break;

                case 'v':
                    AuthorToConferences();
                    break;

                case 'q':
                    return;
                default:
                    Console.WriteLine("\nLa lettera non è valida, ritenta");
                    break;
            }

            MainMenu();
        }

        private void AddAuthor()
        {   
            if (!processor.CreateAuthor(ReadAnswer("Inserisci il nome: "), ReadAnswer("Inserisci il cognome: ")))
                Console.WriteLine("Inserimento non valido!\n");

        }

        private void AddBook()
        {
            if (!processor.CreateBook(ReadAnswer("Inserisci il titolo: "), ReadAnswer("Inserisci la categoria: ")))
                Console.WriteLine("Inserimento non valido!\n");
        }

        private void AssignBookToAuthor()
        {
            Console.Write("Inserisci l'id del libro: ");
            int idBook = Convert.ToInt32(Console.ReadLine());

            Console.Write("Inserisci l'id dell'autore: ");
            int idAuthor = Convert.ToInt32(Console.ReadLine());

            if (!processor.AssignBook(idBook, idAuthor))
                Console.WriteLine("Assegnamento non valido!\n");
        }


        private void RemoveBookFromAuthor()
        {
            Console.Write("Inserisci l'id del libro: ");
            int idBook = Convert.ToInt32(Console.ReadLine());

            Console.Write("Inserisci l'id dell'autore: ");
            int idAuthor = Convert.ToInt32(Console.ReadLine());

            if (!processor.RemoveBook(idBook, idAuthor))
                Console.WriteLine("Rimozione non valida!\n");
        }

        private void ShowBooksByAuthor()
        {
            Console.Write("Inserisci l'id dell'autore: ");
            int idAuthor = Convert.ToInt32(Console.ReadLine());

            List <Book> myListBooks = processor.ShowBooks(idAuthor);

            if (myListBooks.Capacity == 0)
                Console.WriteLine("Nessun libro trovato!\n");

            else
            {
                Console.WriteLine("\nI libri cercati risultano:\n");

                foreach (var item in myListBooks)
                    Console.WriteLine(item.Title);
            }           
        }

        private void ShowBooksByAuthorAndCategory()
        {
            Console.Write("Inserisci l'id dell'autore: ");
            int idAuthor = Convert.ToInt32(Console.ReadLine());

            string category = ReadAnswer("Inserisci la categoria: ");
            List<Book> myListBooks = processor.ShowBooks(idAuthor, category);

            if (myListBooks.Capacity == 0)
                Console.WriteLine("Nessun libro trovato!\n");

            else
            {
                Console.WriteLine("\nI libri cercati risultano:\n");

                foreach (var item in myListBooks)
                    Console.WriteLine(item.Title);
            }
        }

        private void NumberOfBooksByAuthor()
        {
            Console.Write("Inserisci l'id dell'autore: ");
            int idAuthor = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Numero di libri: " + processor.CountBooks(idAuthor));
        }

        private void BookInStores()
        {
            Console.Write("Inserisci l'id del libro: ");
            int idBook = Convert.ToInt32(Console.ReadLine());

            bool controlExistingBook = processor.ExistenceBook(idBook);

            if (controlExistingBook)
            {
                List<Store> myStores = processor.ShowStores(idBook);

                if (myStores.Capacity == 0)
                    Console.WriteLine("Nessun negozio disponibile per questo libro!\n");

                else
                {
                    Console.WriteLine("\nI negozi disponibili per il libro sono:\n");

                    foreach (var item in myStores)
                        Console.WriteLine(item.NameStore);
                }
            }

            else
                Console.WriteLine("\nIl libro desiderato non esiste");

        }

        private void AuthorToConferences()
        {
            Console.Write("Inserisci l'id dell'autore: ");
            int idAuthor = Convert.ToInt32(Console.ReadLine());

            bool controlExistingAuthor = processor.ExistenceAuthor(idAuthor);

            if (controlExistingAuthor)
            {

                List<Conference> myConferences = processor.ShowConferences(idAuthor);

                if (myConferences.Capacity == 0)
                    Console.WriteLine("L'autore non ha partecipato a nessuna conferenza!\n");

                else
                {
                    Console.WriteLine("\nLe conferenze alle quali l'autore ha partecipato sono:\n");

                    foreach (var item in myConferences)
                        Console.WriteLine(item.NameConference);
                }
            }

            else
                Console.WriteLine("\nL'autore desiderato non esiste");

        }



        private string ReadAnswer(string prompt = "")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
