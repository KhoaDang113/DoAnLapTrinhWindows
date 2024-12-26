CREATE DATABASE DoAnLapTrinhWindowsMoi
GO
USE DoAnLapTrinhWindowsMoi
GO


CREATE TABLE USER_ACCOUNT(
	ID_USER INT PRIMARY KEY,
	USERNAME NVARCHAR(20)  ,
	PASSWORD1 VARCHAR(200),
);
CREATE TABLE BOOK(
	ID_BOOK INT PRIMARY KEY IDENTITY(1,1),
	NAME_BOOK NVARCHAR(100) NOT NULL,
	CATEGORY NVARCHAR(50),
	AUTHOR NVARCHAR(100),
	PRICE INT,
	QUANTITY INT DEFAULT 0,
	LINK_IMG NVARCHAR(200),
);
DROP TABLE BOOK
DROP TABLE USER_ACCOUNT
DROP TABLE INVOICE_DETAILS
CREATE TABLE INVOICE_DETAILS(
	ID_INVOICE_DETAILS INT,
	ID_BOOK INT ,
	ID_USER INT ,
	BUY_DATE DATETIME,
	BUY_QUANTITY INT,
	TOTAL INT,
	PRIMARY KEY(ID_INVOICE_DETAILS),
	CONSTRAINT FK_BOOK FOREIGN KEY (ID_BOOK) REFERENCES BOOK(ID_BOOK),
	CONSTRAINT FK_USER FOREIGN KEY (ID_USER) REFERENCES USER_ACCOUNT(ID_USER),
);

CREATE TABLE ADMIN_ACCOUNT(
	ID_ADMIN INT PRIMARY KEY,
	ADMINNAME NVARCHAR(20),
	PASSWORD1 VARCHAR(200),
	EDIT BIT,
);

Select * from BOOK
--NHAP LIEU
INSERT INTO ADMIN_ACCOUNT (ID_ADMIN, ADMINNAME, PASSWORD1, EDIT)
VALUES (1, 'AdminKhoa', '$2y$10$34nImqlLvVCym1rFCUvLluCs1JXZpRVKCZbcxDpvmsLQNVyrk2Lue', 1);
INSERT INTO USER_ACCOUNT (ID_USER, USERNAME, PASSWORD1)
VALUES (1, 'UserLuan', '$2y$10$4W6vzEfGTM/RYIpaMWYjaeSLda.5K7Xa/YQbA21R5U.6/uj991SFG');

INSERT INTO BOOK (NAME_BOOK, CATEGORY, AUTHOR, QUANTITY, PRICE, LINK_IMG) VALUES
('The Hobbit', 'Fantasy', 'J.R.R. Tolkien', 12,300000,'https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781608873869/the-hobbit-9781608873869_hr.jpg'),
('Pride and Prejudice', 'Romance', 'Jane Austen', 10, 180000, 'https://m.media-amazon.com/images/I/712P0p5cXIL._AC_UF1000,1000_QL80_.jpg'),
('The Alchemist', 'Philosophy', 'Paulo Coelho', 18, 270000 ,'https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1654371463i/18144590.jpg'),
('The Catch-22', 'Satire', 'Joseph Heller', 6, 250000 ,'https://upload.wikimedia.org/wikipedia/commons/8/80/Catch-22_%281961%29_front_cover%2C_first_edition.jpg'),
('Moby Dick', 'Adventure', 'Herman Melville', 4, 320000 ,'https://images-na.ssl-images-amazon.com/images/I/71d5wo+-MuL.jpg'),
('Brave New World', 'Dystopian', 'Aldous Huxley', 11,210000, 'https://m.media-amazon.com/images/I/71GNqqXuN3L.jpg'),
('The Road', 'Post-Apocalyptic', 'Cormac McCarthy', 9, 230000 ,'https://m.media-amazon.com/images/I/51M7XGLQTBL._AC_UF894,1000_QL80_.jpg'),
('War and Peace', 'Historical', 'Leo Tolstoy', 7, 350000 ,'https://m.media-amazon.com/images/I/81W6BFaJJWL.jpg'),
('The Odyssey', 'Epic', 'Homer', 13,290000 ,'https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781451674187/the-odyssey-9781451674187_hr.jpg'),
('Frankenstein', 'Horror', 'Mary Shelley', 5, 200000, 'https://product.hstatic.net/200000090679/product/frankenstein_165d77657e2343468e08ffe588d807a8_master.jpg'),
('The Shining', 'Horror', 'Stephen King', 8, 280000,'https://m.media-amazon.com/images/I/91U7HNa2NQL._AC_UF894,1000_QL80_.jpg'),
('Dracula', 'Gothic', 'Bram Stoker', 6, 260000 ,'https://m.media-amazon.com/images/I/91wOUFZCE+L._UF1000,1000_QL80_.jpg'),
('Crime and Punishment', 'Classic', 'Fyodor Dostoevsky', 10, 300000,'https://m.media-amazon.com/images/I/71O2XIytdqL.jpg'),
('The Kite Runner', 'Drama', 'Khaled Hosseini', 14, 240000,'https://m.media-amazon.com/images/I/81LVEH25iJL.jpg'),
('The Hunger Games', 'Young Adult', 'Suzanne Collins', 20, 250000,'https://m.media-amazon.com/images/I/71un2hI4mcL.jpg'),
('The Fault in Our Stars', 'Romance', 'John Green', 18, 220000,'https://cdn0.fahasa.com/media/catalog/product/9/7/9780142424179.jpg'),
('Dune', 'Science Fiction', 'Frank Herbert', 12,400000 ,'https://cdn0.fahasa.com/media/flashmagazine/images/page_images/dune/2023_03_30_10_46_34_1-390x510.jpg'),
('A Song of Ice and Fire: A Game of Thrones', 'Fantasy', 'George R.R. Martin', 15, 450000 ,'https://pibook.vn/upload/products/A-Game-of-Thrones-A-Song-of-Ice-and-Fire-Book-9888.jpg'),
('Little Women', 'Classic', 'Louisa May Alcott', 7, 210000 ,'https://m.media-amazon.com/images/I/81XxP9qyfzL.jpg'),
('The Chronicles of Narnia: The Lion, the Witch, and the Wardrobe', 'Fantasy', 'C.S. Lewis', 13,270000, 'https://m.media-amazon.com/images/I/81QUw81WcoL._AC_UF894,1000_QL80_.jpg'),
('Percy Jackson & The Olympians: The Lightning Thief', 'Young Adult', 'Rick Riordan', 19, 250000,'https://images-na.ssl-images-amazon.com/images/I/91RQ5d-eIqL.jpg'),
('The Maze Runner', 'Dystopian', 'James Dashner', 11, 240000,'https://images-na.ssl-images-amazon.com/images/I/91Jra1QAMPL.jpg'),
('Gone Girl', 'Thriller', 'Gillian Flynn', 9, 300000,'https://m.media-amazon.com/images/I/713e4Yk6brL._AC_UF894,1000_QL80_.jpg'),
('The Da Vinci Code', 'Mystery', 'Dan Brown', 10, 280000,'https://m.media-amazon.com/images/I/71y4X5150dL.jpg'),
('The Girl with the Dragon Tattoo', 'Thriller', 'Stieg Larsson', 8, 260000,'https://m.media-amazon.com/images/I/61Qs-hoZ-TL._AC_UF894,1000_QL80_.jpg'),
('The Secret Garden', 'Children', 'Frances Hodgson Burnett', 5, 180000,'https://m.media-amazon.com/images/I/91qOXqI3aQL.jpg'),
('The Art of War', 'Philosophy', 'Sun Tzu', 20, 120000,'https://nhasachphuongnam.com/images/detailed/227/71FuxEOOhXL.jpg'),
('Thinking, Fast and Slow', 'Psychology', 'Daniel Kahneman', 10, 200000,'https://nhasachphuongnam.com/images/detailed/173/51oXKWrcYYL.jpg'),
('Sapiens: A Brief History of Humankind', 'History', 'Yuval Noah Harari', 16, 320000,'https://salt.tikicdn.com/cache/w1200/ts/product/93/b3/6c/d1b2fb27db34caa0b578afad955b4d84.jpg'),
('Rich Dad Poor Dad', 'Finance', 'Robert Kiyosaki', 25, 150000,'https://salt.tikicdn.com/cache/w1200/ts/product/2d/46/09/a35b593351a4f7b133070985f90f87a5.jpg');

INSERT INTO USER_ACCOUNT (ID_USER, USERNAME, PASSWORD1) VALUES
(2, 'jane_smith', 'qwerty456'),
(3, 'alice_johnson', 'abc123xyz');


INSERT INTO ADMIN_ACCOUNT (ID_ADMIN, ADMINNAME, PASSWORD1, EDIT) VALUES
(2, 'admin01', 'adminpass', 1),
(3, 'admin02', 'securepass', 0);

INSERT INTO INVOICE_DETAILS (ID_INVOICE_DETAILS, ID_BOOK, ID_USER, BUY_DATE, BUY_QUANTITY, TOTAL)
VALUES
    (1, 1, 1, '2024-12-01 10:00:00', 2, 400),
    (2, 2, 1, '2024-12-05 15:30:00', 1, 200),
    (3, 3, 2, '2024-12-10 09:45:00', 3, 900),
    (4, 1, 3, '2024-12-15 14:20:00', 1, 200), 
    (5, 2, 2, '2024-12-18 12:00:00', 2, 400);
SELECT * FROM INVOICE_DETAILS