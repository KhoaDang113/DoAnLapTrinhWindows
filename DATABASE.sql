CREATE DATABASE DoAnLapTrinhWindowsMoi
USE DoAnLapTrinhWindowsMoi
GO

CREATE TABLE USER_ACCOUNT(
	ID_USER INT PRIMARY KEY,
	USERNAME NVARCHAR(20)  ,
	PASSWORD1 VARCHAR(20),
);

CREATE TABLE BOOK(
	ID_BOOK INT PRIMARY KEY IDENTITY(1,1),
	NAME_BOOK NVARCHAR(100) NOT NULL,
	CATEGORY NVARCHAR(50),
	AUTHOR NVARCHAR(100),
	QUANTITY INT DEFAULT 0,
	LINK_IMG NVARCHAR(200),
);

CREATE TABLE INVOICE_DETAILS(
	ID_BOOK INT ,
	ID_USER INT ,
	BORROW_DATE DATETIME,
	DUE_DATE DATETIME,
	PRIMARY KEY(ID_BOOK,ID_USER),
	CONSTRAINT FK_BOOK FOREIGN KEY (ID_BOOK) REFERENCES BOOK(ID_BOOK),
	CONSTRAINT FK_USER FOREIGN KEY (ID_USER) REFERENCES USER_ACCOUNT(ID_USER),
	CONSTRAINT CHK_DATE CHECK (BORROW_DATE < DUE_DATE),
);

CREATE TABLE ADMIN_ACCOUNT(
	ID_ADMIN INT PRIMARY KEY,
	ADMINNAME NVARCHAR(20),
	PASSWORD1 VARCHAR(20),
	EDIT BIT,
);

DROP TABLE ADMIN_ACCOUNT

--NHAP LIEU
INSERT INTO ADMIN_ACCOUNT(ID_ADMIN, ADMINNAME, PASSWORD1, EDIT)
VALUES (1, 'AdminKhoa', 'password123', 1);
INSERT INTO uSER_ACCOUNT (ID_USER, USERNAME, PASSWORD1)
VALUES (1, 'UserLuan', 'password123');
