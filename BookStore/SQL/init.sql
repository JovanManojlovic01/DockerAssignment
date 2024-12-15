CREATE DATABASE BookStore;
GO

USE BookStore;
GO

-- Create the Books table with additional parameters
CREATE TABLE Books (
    Id INT PRIMARY KEY IDENTITY(1, 1),           -- Auto-incrementing primary key
    Title NVARCHAR(100) NOT NULL,               -- Book title (required)
    Author NVARCHAR(100) NOT NULL,              -- Author name (required)
    YearOfRelease INT NOT NULL,                 -- Year the book was released (required)
    Genre NVARCHAR(50),                         -- Genre of the book (optional)
    ImageURL NVARCHAR(200),                     -- Image URL for the book cover (optional)
    Description NVARCHAR(MAX)                   -- Description of the book (optional)
);
GO

-- Insert sample data into the Books table
INSERT INTO Books (Title, Author, YearOfRelease, Genre, ImageURL, Description)
VALUES 
    ('The Catcher in the Rye', 
     'J.D. Salinger', 
     1951, 
     'Fiction', 
     'https://example.com/catcher.jpg', 
     'A story about teenage alienation and rebellion.'),
     
    ('To Kill a Mockingbird', 
     'Harper Lee', 
     1960, 
     'Drama', 
     'https://example.com/mockingbird.jpg', 
     'A profound look at racial injustice in the American South.'),
     
    ('1984', 
     'George Orwell', 
     1949, 
     'Dystopian', 
     'https://example.com/1984.jpg', 
     'A chilling tale of a totalitarian regime and pervasive surveillance.'),
     
    ('Pride and Prejudice', 
     'Jane Austen', 
     1813, 
     'Romance', 
     'https://example.com/pride.jpg', 
     'A classic romance exploring themes of love, class, and social expectations.'),
     
    ('The Great Gatsby', 
     'F. Scott Fitzgerald', 
     1925, 
     'Tragedy', 
     'https://example.com/gatsby.jpg', 
     'The story of the enigmatic millionaire Jay Gatsby and his obsession with Daisy Buchanan.');
GO
