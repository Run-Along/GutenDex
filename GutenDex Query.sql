CREATE DATABASE GutenDex;
USE GutenDex;

/* CREATE TABLES */
CREATE TABLE Authors(
	AuthorId INT NOT NULL AUTO_INCREMENT,
    AuthorName VARCHAR(200) NOT NULL,
    Birth_Year INT NOT NULL,
    Death_Year INT NOT NULL,
    PRIMARY KEY (AuthorId)
);

CREATE TABLE Books(
	BookId INT NOT NULL AUTO_INCREMENT,
    Title VARCHAR(200) NOT NULL,
    Year_Published INT NOT NULL,
    PRIMARY KEY (BookId)
);

## MAKE FOREIGN KEY
ALTER TABLE Books ADD COLUMN AuthorId INT;
ALTER TABLE Books ADD CONSTRAINT FK_BookAuthor FOREIGN KEY (AuthorId) REFERENCES Authors(AuthorId);

## LOAD AUTHORS
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Mary Shelley", 1797, 1851);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Voltaire", 1964, 1778);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Geoffrey Chaucer", 1340, 1400);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Alexandre Dumas", 1802, 1870);

INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Montague Rhodes James", 1862, 1936);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Charles Dickens", 1812, 1870);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Edgar Allan Poe", 1809, 1849);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Francis Scott Key Fitzgerald", 1896, 1940);

INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Ernest Hemingway", 1899, 1961);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("John Steinbeck", 1902, 1968);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("Mark Twain", 1835, 1910);
INSERT INTO Authors (AuthorName, Birth_Year, Death_Year) VALUES ("William Shakespeare", 1564, 1616);


## LOAD BOOKS
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Mathilda", 1959, 1);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Frankenstein", 1818, 1);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Valperga", 1823, 1);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Candide", 1759, 2);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The World as it Goes", 1748, 2);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Plato's Dream", 1756, 2);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Canterbury Tales", 1400, 3);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Parliament of Fowls", 1400, 3);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Chanticleer and the Fox", 1400, 3);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Three Musketeers", 1844, 4);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Count of Monte Cristo", 1844, 4);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Man in the Iron Mask", 1850, 4);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Oh, Whistle, and I'll Come to You, My Lad", 1904, 5);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Ash-tree", 1904, 5);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("A Warning to the Curious", 1925, 5);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Signal-Man", 1866, 6);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Oliver Twist", 1837, 6);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("David Copperfield", 1850, 6);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Raven", 1845, 7);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Tell-Tale Heart", 1843, 7);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("A Dream Within a Dream", 1849, 7);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Curious Case of Benjamin Button", 1922, 8);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Great Gatsby", 1925, 8);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Beautiful and Damned", 1922, 8);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Old Man and the Sea", 1952, 9);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Sun Also Rises", 1926, 9);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("For Whom the Bell Tolls", 1940, 9);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Grapes of Wrath", 1939, 10);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("East of Eden", 1952, 10);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Cannery Row", 1945, 10);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Adventures of Tom Sawyer", 1876, 11);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Adventures of Huckleberry Finn", 1884, 11);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("A Connecticut Yankee in King Arthur's Court", 1889, 11);

INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Hamlet", 1603, 12);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("Macbeth", 1623, 12);
INSERT INTO Books (Title, Year_Published, AuthorId) VALUES ("The Merchant of Venice", 1600, 12);

/*
I did not like David Copperfield or maybe I did but it was too long and I can't be bothered to remember the plot.
It was the first time I felt reading to be a chore. 
I have since been cured of that malady by realizing I can just stop reading a book I find tedious.

The author is sorry if this listing of books brings back memories of rushed and procrastinated essays written 
amidst the whirlwind of social awkwardness that is high school.
*/