USE DB_EVENTOS;
GO

--criando a tabela TBEventos, com uma chave primaria auto incremento
CREATE TABLE TBEventos 
(
	Id			INT IDENTITY(1,1) not null ,
	Descricao	VARCHAR(100) not null,
	Responsavel	varchar(50) not null,
	Data		datetime not null,
	Preco		float not null,
	PRIMARY KEY(Id)
);
GO

CREATE TABLE TBConvidados
(
	Cpf			varchar(11) not null,
	IdEvento	int not null,
	Nome		varchar(50) not null,
	Telefone	varchar(20) not null,
	Email		varchar(60) not null,
	PRIMARY KEY (Cpf),
	FOREIGN KEY (IdEvento) REFERENCES TBEventos(Id)
);
GO
