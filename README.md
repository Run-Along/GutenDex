# GutenDex API

### A Library API
---


The GutenDex API is a collection of books taught in High School and College. The original intent was to create an API library of copyright free books. However, the author got carried away with compiling a collection of books that have tortured students ever since the word "literature" was invented. 
A keen client will notice that all of these authors do fall into the copyright domain so the original intent was preservered. A keener client will notice that two of these authors were not taught in High School. But they were a source of comfort to those who liked the weirder and macabre tales. 

### Endpoints
- https://localhost:7201/api/Author
- https://localhost:7201/api/Author/id
- https://localhost:7201/api/book
- https://localhost:7201/api/book/id

### HTTP Methods: Response & Request  Body
Every http method lsited below comes with a standard response body:
statusCode: 200/400
statusDescription: "Short message on success or reason upon failure"

- GET METHODS
    - GET: api/Author
    - GET: api/Author/id
    - GET: api/Book
    - GET: api/book/id
- POST METHODS
    - POST: api/Author/id
    - POST: api/book/id
- DELETE METHODS
    - DELETE: api/Author/id
    - DELETE: api/book/id
 
 ### Sample POST
 #### POST Author
 {
    "authorName": "Mary",
    "birth_Year": 1797,
    "death_Year": 1851,
    "books": [
        {
            "bookId": 37,
            "title": "Mathilda",
            "year_Published": 1959
        }
    ]
}

#### POST Book
{
    "title": "Drive",
    "year_Published": 1959
}

## Notes
Pleae Note: The author wanted to use serious messages on success but the spirit of the API requested (demanded) that Author use a combination of serious and sassy responses in honor of the great librarians who silently judge our book choices on checkout.

Please Note: My connection string uses Server=127.0.0.9 instead of the very popular Server=127.0.0.1

Thank you
