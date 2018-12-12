using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private static List<Book> _myBooks = new List<Book>
            {
                new Book()
                {
                    ID = 1, 
                    Title = "The Art of Public Speaking",
                    Author = "Dale Carnegie"
                },
                new Book()
                {
                    ID = 2,
                    Title = "The Picture of Dorian Gray",
                    Author = "Oscar Wilde"
                },
            };

        [HttpGet("")]
        public IEnumerable<Book> AllBooks()
        {
            return _myBooks;
        }

        [HttpGet("{id}")]
        public Book Get(int id)
        {
            Book match = _myBooks.Find(n => n.ID == id);
            if (match != null)
            {
                switch (match.ID)
                {
                    case 1:
                        match.Description = @"The Art of Public Speaking is a fantastic introduction to public speaking by the master of the art, Dale Carnegie. Public speaking is the process of speaking to a group of people in a structured, deliberate manner intended to inform, influence, or entertain the listeners. It is closely allied to ""presenting"", although the latter has more of a commercial connotation.

In public speaking, as in any form of communication, there are five basic elements, often expressed as ""who is saying what to whom using what medium with what effects?"" The purpose of public speaking can range from simply transmitting information, to motivating people to act, to simply telling a story. Good orators should be able to change the emotions of their listeners, not just inform them. Public speaking can also be considered a discourse community. Interpersonal communication and public speaking have several components that embrace such things as motivational speaking, leadership/personal development, business, customer service, large group communication, and mass communication. Public speaking can be a powerful tool to use for purposes such as motivation, influence, persuasion, informing, translation, or simply entertaining. A confident speaker is more likely to use this as excitement and create effective speech thus increasing their overall ethos.";
                        break;
                    case 2:
                        match.Description = @"The Picture of Dorian Gray scandalized readers when it was first published in 1890. Written in Wilde’s signature style, the story has gone on to become an enduring tale of man’s hubris and narcissism.

The well-known artist Basil Hallward meets the young Dorian Gray in the stately London home of his aunt, Lady Brandon. Basil becomes immediately infatuated with Dorian, who is cultured, wealthy, and remarkably beautiful. Such beauty, Basil believes, is responsible for a new mode of art, and he decides to paint a portrait of the young man. While finishing the painting, Basil reluctantly introduces Dorian to his friend Lord Henry Wotton, a man known for scandal and exuberance. Wotton inspires Dorian to live life through the senses, to feel beauty in everyday experience. Dorian becomes enthralled by Wotton’s ideas, and more so becomes obsessed with remaining young and beautiful. He expresses a desire to sell his soul and have the portrait of him age, while he, the man, stays eternally young. A tragic story of hedonism and desire, The Picture of Dorian Gray is Oscar Wilde’s only published novel.";
                        break;
                    default:
                        break;
                }
            }
            return match;
        }

        public class Book
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string Description { get; set; }
        }
    }
}

