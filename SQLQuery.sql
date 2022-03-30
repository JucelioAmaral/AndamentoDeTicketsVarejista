/*

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



----CONSULTA NA SEQUENCE
SELECT cache_size, current_value   
FROM sys.sequences  
WHERE name = 'SQ_TicketHAVAN_SQL' 

*/

/*
------------------------
--CRIAÇÃO DA FUNCTION

use DbTesteHavan
go

CREATE FUNCTION FN_DADOS_HAVAN (@codigo varchar(8), @nome varchar(128),@cpf varchar(11))
RETURNS TABLE
AS
RETURN
(
SELECT
T.Id,
T.IdUsuarioAbertura,
T.IdUsuarioConclusao,
T.IdCliente,
T.IdSituacao,
T.Codigo AS CodigoDoTicket,
T.DataAbertura,
T.DataConclusao,
C.Codigo AS CodigoDoCliente,
C.CPF,
TS.Nome AS TicketSitucao,
U.Codigo AS CodigoDoUsuario,
U.Nome AS NomedoUsuario,
COUNT(TA.IdTicket) AS QtdeAnotaçõesTicket
FROM Ticket T
INNER JOIN Cliente C
ON (T.IdCliente = C.Id)
INNER JOIN TicketSituacao TS
ON (T.IdSituacao = TS.Id)
INNER JOIN Usuario U
ON (T.IdUsuarioAbertura = U.Id)
INNER JOIN TicketAnotacao TA
ON (T.Id = TA.IdTicket)
WHERE T.Codigo = @codigo
AND U.Nome = @nome
AND C.CPF = @cpf
GROUP BY T.Id,T.IdUsuarioAbertura,T.IdUsuarioConclusao,T.IdCliente,T.IdSituacao,T.Codigo,T.DataAbertura,T.DataConclusao,C.Codigo,C.CPF,TS.Nome,U.Codigo,U.Nome 
)

*/
----CONSULTA DA FUNCTION FN_DADOS_HAVAN
SELECT * FROM FN_DADOS_HAVAN (2, 'Ana','12345678910')


--------------------------------------------------------------------------------------------

/*
------------------------
--CRIAÇÃO DA VIEW

use DbTesteHavan
go


--DECLARE @codigo varchar(8)= 2
--DECLARE @nome varchar(128)= 'Ana'
--DECLARE @cpf varchar(11)= '12345678910'

CREATE VIEW VW_DADOS_HAVAN
AS
SELECT
T.Id,
T.IdUsuarioAbertura,
T.IdUsuarioConclusao,
T.IdCliente,
T.IdSituacao,
T.Codigo AS CodigoDoTicket,
T.DataAbertura,
T.DataConclusao,
C.Codigo AS CodigoDoCliente,
C.CPF,
TS.Nome AS TicketSitucao,
U.Codigo,
U.Nome AS NomedoUsuario,
COUNT(TA.IdTicket) AS QtdeAnotaçõesTicket
FROM Ticket T
INNER JOIN Cliente C
ON (T.IdCliente = C.Id)
INNER JOIN TicketSituacao TS
ON (T.IdSituacao = TS.Id)
INNER JOIN Usuario U
ON (T.IdUsuarioAbertura = U.Id)
INNER JOIN TicketAnotacao TA
ON (T.Id = TA.IdTicket)
WHERE T.Codigo = 2
AND U.Nome = 'Ana'
AND C.CPF = '12345678910'
GROUP BY T.Id,T.IdUsuarioAbertura,T.IdUsuarioConclusao,T.IdCliente,T.IdSituacao,T.Codigo,T.DataAbertura,T.DataConclusao,C.Codigo,C.CPF,TS.Nome,U.Codigo,U.Nome 

----CONSULTA DA VIEW
--SELECT * FROM VW_DADOS_HAVAN
*/

/*
------------------------
--CRIAÇÃO DA PROCEDURE

use DbTesteHavan
go

CREATE PROCEDURE SP_DADOS_HAVAN
@codigo varchar(8),
@nome varchar(128),
@cpf varchar(11)
AS
SELECT
T.Id,
T.IdUsuarioAbertura,
T.IdUsuarioConclusao,
T.IdCliente,
T.IdSituacao,
T.Codigo,
T.DataAbertura,
T.DataConclusao,
C.Codigo,
C.CPF,
TS.Nome AS TicketSitucao,
U.Codigo,
U.Nome AS NomedoUsuario,
COUNT(TA.IdTicket) AS QtdeAnotaçõesTicket
FROM Ticket T
INNER JOIN Cliente C
ON (T.IdCliente = C.Id)
INNER JOIN TicketSituacao TS
ON (T.IdSituacao = TS.Id)
INNER JOIN Usuario U
ON (T.IdUsuarioAbertura = U.Id)
INNER JOIN TicketAnotacao TA
ON (T.Id = TA.IdTicket)
WHERE T.Codigo = @codigo
AND U.Nome = @nome
AND C.CPF = @cpf
GROUP BY T.Id,T.IdUsuarioAbertura,T.IdUsuarioConclusao,T.IdCliente,T.IdSituacao,T.Codigo,T.DataAbertura,T.DataConclusao,C.Codigo,C.CPF,TS.Nome,U.Codigo,U.Nome 


----CONSULTA DA PROCEDURE SP_DADOS_HAVAN
--EXEC SP_DADOS_HAVAN @codigo= 2, @nome = 'Ana', @cpf= '12345678910'

*/