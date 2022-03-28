CREATE DATABASE DbTesteHavan

use DbTesteHavan
go


CREATE TABLE Cliente (
Id bigint IDENTITY (1,1) NOT NULL,
Codigo varchar(16),
CPF varchar(11),
CONSTRAINT PK_Cliente PRIMARY KEY (Id)
);


CREATE TABLE TicketSituacao (
Id smallint IDENTITY (1,1) NOT NULL,
Nome varchar(64),
CONSTRAINT PK_TicketSituacao PRIMARY KEY (Id)
);



CREATE TABLE Usuario (
Id bigint IDENTITY (1,1) NOT NULL,
Codigo varchar(8),
Nome varchar(128),
CONSTRAINT PK_Usuario PRIMARY KEY (Id)
);



CREATE TABLE Ticket (
Id bigint IDENTITY (1,1) NOT NULL,
IdUsuarioAbertura bigint NOT NULL,
IdUsuarioConclusao bigint NOT NULL,
IdCliente bigint NOT NULL,
IdSituacao smallint NOT NULL,
Codigo int,
DataAbertura datetime,
DataConclusao datetime,
CONSTRAINT PK_Ticket PRIMARY KEY (Id),
CONSTRAINT FK_Ticket_UsuarioAbertura FOREIGN KEY(IdUsuarioAbertura) REFERENCES Usuario (Id),
CONSTRAINT FK_Ticket_UsuarioConclusao FOREIGN KEY(IdUsuarioConclusao) REFERENCES Usuario (Id),
CONSTRAINT FK_Ticket_Cliente FOREIGN KEY(IdCliente) REFERENCES Cliente (Id),
CONSTRAINT FK_Ticket_TicketSituacao FOREIGN KEY(IdSituacao) REFERENCES TicketSituacao (Id),
);



CREATE TABLE TicketAnotacao (
Id bigint IDENTITY (1,1) NOT NULL,
IdTicket bigint NOT NULL,
IdUsuario bigint NOT NULL,
Texto varchar (512),
Data datetime,
CONSTRAINT PK_TicketAnotacao PRIMARY KEY (Id),
CONSTRAINT FK_TicketAnotacao_Ticket FOREIGN KEY(IdTicket) REFERENCES Ticket (Id),
CONSTRAINT FK_TicketAnotacao_Usuario FOREIGN KEY(IdUsuario) REFERENCES Usuario (Id),
);


------------------------
--INSERT NA TABELA TicketSituacao

use DbTesteHavan
go


INSERT INTO TicketSituacao (Nome) VALUES ('Concluído');
INSERT INTO TicketSituacao (Nome) VALUES ('Em andamento');

------------------------
--CRIAÇÃO DA SEQUENCE

use DbTesteHavan
go

CREATE SEQUENCE [dbo].[SQ_TicketHAVAN_SQL]
	AS [bigint]
	START WITH 1
	INCREMENT BY 1
	NO CACHE
GO