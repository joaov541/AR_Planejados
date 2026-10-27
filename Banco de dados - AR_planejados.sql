
-- =============================================
-- BANCO DE DADOS: ARPlanejadosDB
-- =============================================

CREATE DATABASE ARPlanejadosDB;
GO

USE ARPlanejadosDB;
GO

-- =============================================
-- TABELA: CLIENTE
-- Armazena os dados dos clientes
-- =============================================

CREATE TABLE Cliente (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    Email VARCHAR(150) NULL,
    DataCadastro DATETIME2 NOT NULL
        DEFAULT SYSDATETIME()
);
GO

-- =============================================
-- TABELA: PROJETO
-- Armazena os projetos da marcenaria
-- =============================================

CREATE TABLE Projeto (
    IdProjeto INT IDENTITY(1,1) PRIMARY KEY,
    NomeProjeto VARCHAR(100) NOT NULL,
    TipoAmbiente VARCHAR(50) NOT NULL,
    Descricao VARCHAR(1000) NULL,
    FotoProjeto VARCHAR(500) NULL,
    DataCadastro DATETIME2 NOT NULL
        DEFAULT SYSDATETIME(),
    Ativo BIT NOT NULL DEFAULT 1
);
GO

-- =============================================
-- TABELA: ORCAMENTO
-- Armazena as solicitações de orçamento
-- =============================================

CREATE TABLE Orcamento (
    IdOrcamento INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    TipoAmbiente VARCHAR(50) NOT NULL,
    Descricao VARCHAR(1500) NOT NULL,
    ValorEstimado DECIMAL(12,2) NULL,
    Status VARCHAR(20) NOT NULL
        DEFAULT 'Pendente',
    DataSolicitacao DATETIME2 NOT NULL
        DEFAULT SYSDATETIME(),

    CONSTRAINT FK_Orcamento_Cliente
        FOREIGN KEY (IdCliente)
        REFERENCES Cliente(IdCliente),

    CONSTRAINT CK_Orcamento_Status
        CHECK (Status IN (
            'Pendente',
            'Em analise',
            'Aprovado',
            'Recusado',
            'Concluido'
        )),

    CONSTRAINT CK_Orcamento_Valor
        CHECK (
            ValorEstimado IS NULL
            OR ValorEstimado >= 0
        )
);
GO

-- =============================================
-- ÍNDICES PARA CONSULTAS
-- =============================================

CREATE INDEX IX_Orcamento_IdCliente
    ON Orcamento(IdCliente);

CREATE INDEX IX_Orcamento_Status
    ON Orcamento(Status);

CREATE INDEX IX_Projeto_TipoAmbiente
    ON Projeto(TipoAmbiente);

GO


SELECT * FROM Cliente