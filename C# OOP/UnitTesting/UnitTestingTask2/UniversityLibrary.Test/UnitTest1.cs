namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tests
    {
        

        [Test]
        public void ConstructorTitle()
        {
            TextBook textb = new TextBook("Book", "Me", "Love");
            string expexted = "Book";
            string actual = textb.Title;

            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void ConstructorAuthor()
        {
            TextBook textb = new TextBook("Book", "Me", "Love");
            string expexted = "Me";
            string actual = textb.Author;

            Assert.AreEqual(expexted, actual);
        }
        [Test]
        public void ConstructorCategory()
        {
            TextBook textb = new TextBook("Book", "Me", "Love");
            string expexted = "Love";
            string actual = textb.Category;

            Assert.AreEqual(expexted, actual);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("Book book")]
        public void SetTitle(string title)
        {
            TextBook textb = new TextBook(title, "Me", "Love");
            string expexted = title;
            string actual = textb.Title;

            Assert.AreEqual(expexted, actual);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("Author Author")]
        public void SetAuthor(string author)
        {
            TextBook textb = new TextBook("Book","Me", author);
            string expexted = author;
            string actual = textb.Category;

            Assert.AreEqual(expexted, actual);
        }

        [TestCase("")]
        [TestCase(" ")]
        [TestCase("Category category")]
        public void SetCategory(string categ)
        {
            TextBook textb = new TextBook("Book", "Me", categ);
            string expexted = categ;
            string actual = textb.Category;

            Assert.AreEqual(expexted, actual);
        }

        [Test]
        public void ToStringConstr()
        {
            TextBook textb = new TextBook("Book", "Me", "Love");
            textb.InventoryNumber = 1;
            string actual = textb.ToString();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: Book - 1");
            sb.AppendLine($"Category: Love");
            sb.AppendLine($"Author: Me");

            string expected = sb.ToString().TrimEnd();

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void AddBook()
        {
            UniversityLibrary lib = new UniversityLibrary();
            TextBook textb = new TextBook("Book", "Me", "Love");

            string actual = lib.AddTextBookToLibrary(textb);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Book: Book - 1");
            sb.AppendLine($"Category: Love");
            sb.AppendLine($"Author: Me");

            string expected = sb.ToString().TrimEnd();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoanBook()
        {
            UniversityLibrary lib = new UniversityLibrary();
            TextBook textb = new TextBook("Book", "Me", "Love");
            textb.Holder = "Nikol";
            lib.AddTextBookToLibrary(textb);
            TextBook textb2 = new TextBook("Book", "Me", "Love");
            textb2.Holder = "Vasi";
            lib.AddTextBookToLibrary(textb2);

            string actual = lib.LoanTextBook(1, "Nikol");
            string expected = $"Nikol still hasn't returned Book!";

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void LoanBook2()
        {
            UniversityLibrary lib = new UniversityLibrary();
            TextBook textb = new TextBook("Book", "Me", "Love");
            textb.Holder = "Nikol";
            lib.AddTextBookToLibrary(textb);

            TextBook textb2 = new TextBook("Book", "Me", "Love");
            textb2.Holder = "Vasi";
            lib.AddTextBookToLibrary(textb2);


            string actual = lib.LoanTextBook(1, "Vasi");
            string expected = $"Book loaned to Vasi.";

            Assert.AreEqual(expected, actual);
        }
         [TestCase(2)]
         [TestCase(1)]
        public void ReturnBook(int n)
        {
            UniversityLibrary lib = new UniversityLibrary();
            TextBook textb = new TextBook("Book", "Me", "Love");
            textb.Holder = "Nikol";
            lib.AddTextBookToLibrary(textb);

            TextBook textb2 = new TextBook("Book", "Me", "Love");
            textb2.Holder = "Vasi";
            lib.AddTextBookToLibrary(textb2);


            string actual = lib.ReturnTextBook(2);
            string expected = $"Book is returned to the library.";

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReturnBookName()
        {
            UniversityLibrary lib = new UniversityLibrary();
            TextBook textb = new TextBook("Book", "Me", "Love");
            textb.Holder = "Nikol";
            lib.AddTextBookToLibrary(textb);

            TextBook textb2 = new TextBook("Book", "Me", "Love");
            textb2.Holder = "Vasi";
            lib.AddTextBookToLibrary(textb2);


           lib.ReturnTextBook(2);

            string expexted = "";
            string actual = lib.Catalogue.FirstOrDefault(x => x.InventoryNumber == 2).Holder;

            Assert.AreEqual(expexted, actual);
        }


        public void LoanBook2NAme()
        {
            UniversityLibrary lib = new UniversityLibrary();
            TextBook textb = new TextBook("Book", "Me", "Love");
            textb.Holder = "Nikol";
            lib.AddTextBookToLibrary(textb);

            TextBook textb2 = new TextBook("Book", "Me", "Love");
            textb2.Holder = "Vasi";
            lib.AddTextBookToLibrary(textb2);


             lib.LoanTextBook(2, "Nikol");
            string actual = lib.Catalogue.FirstOrDefault(x => x.InventoryNumber == 1).Holder;
            string expected ="Nikol";

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoanTextBookShouldWork2()
        {
            UniversityLibrary library = new UniversityLibrary();
            TextBook book = new TextBook("Book", "Vasi", "comedy");
            book.InventoryNumber = 1;
            book.Holder = "Neli";
            library.AddTextBookToLibrary(book);

            string expexted = $"{book.Title} loaned to Nikol.";
            Assert.AreEqual(library.LoanTextBook(1, "Nikol"), expexted);
            library.LoanTextBook(1, "Nikol");
            Assert.AreEqual(book.Holder, "Nikol");
        }


    }
}