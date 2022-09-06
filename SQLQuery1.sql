CREATE TABLE [dbo].[salar1]
(
    [Idsal]  INT NOT NULL IDENTITY,
    [Sname]  NCHAR (100) NOT NULL,
    [Sphone] INT         NOT NULL,
    [Sempol] INT         NOT NULL,
    PRIMARY KEY CLUSTERED ([Idsal] ASC),
);