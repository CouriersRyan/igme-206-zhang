/*
 * Ryan Zhang
 * PE - Properties
 * https://docs.google.com/document/d/1z9HVMUdQWjPEswC2UwoDFwaoHdpaLT1Yvo7KtKBBaYs/edit?usp=sharing
 */

namespace PE_Properties_Zhang
{
    /// <summary>
    /// Represents a book with a title, author, page count, and owner that are defined when instantiated.
    /// </summary>
    internal class Book
    {
        // Fields
        private string title;
        private string author;
        private int pages;
        private string owner;
        private int timesRead;

        // Properties
        public string Title
        {
            get => title;
        }
        public string Author
        {
            get => author;
        }

        public int NumberOfPages
        {
            get => pages;
        }

        public string Owner
        {
            get => owner;
            set
            {
                // Can only set if the new owner string isn't null and isn't empty.
                if (value != null && !value.Equals(String.Empty))
                {
                    owner = value;
                }
            }
        }

        public int TimesRead
        {
            get => timesRead;
            set {
                // Only allows a new number of times read to be set
                // if it is greater than the old value
                if (value > timesRead)
                {

                timesRead = value; 
                }
            }
        }

        // Constructor
        public Book(string title, string author, int pages, string owner)
        {
            this.title = title;
            this.author = author;   
            this.pages = pages;
            this.owner = owner;
            timesRead = 0;
        }

        // Methods
        /// <summary>
        /// Prints information contained on the book instance as a formatted sentence to the console.
        /// </summary>
        public void Print()
        {
            Console.WriteLine("{0} by {1} has {2} pages. It is owned by {3} and has been read {4} times.",
                Title, Author, NumberOfPages, Owner, TimesRead);
        }
    }
}
