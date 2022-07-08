CREATE DATABASE INTELITRADER;

USE INTELITRADER;

CREATE TABLE USUARIO(
id CHAR(6) PRIMARY KEY NOT NULL,
firstName  VARCHAR(50) NOT NULL,
surname  VARCHAR(50),
age INT NOT NULL,
creationDate DATETIME DEFAULT GETDATE() NOT NULL
);
GO

INSERT INTO usuario (id, firstName, surname, age)
VALUES  ('sH2m5T', 'Gustavo', 'Silva', '17'),
		('dJ3z6Y', 'Fabio', 'Silva', '45'),
		('fK4x7U', 'Susana', 'Silva', '44'),
		('gL5c8I', 'Helena', 'Silva', '7'),
		('hA6v9O', 'Leticia', 'Santos', '17'),
		('jS7b0P', 'Mariana', 'Santos', '13');
GO

SELECT * FROM usuario