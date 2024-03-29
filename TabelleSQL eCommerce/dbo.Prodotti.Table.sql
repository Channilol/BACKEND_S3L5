USE [eCommerceEpicode]
GO
/****** Object:  Table [dbo].[Prodotti]    Script Date: 16/02/2024 20:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prodotti](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](255) NOT NULL,
	[Brand] [varchar](50) NOT NULL,
	[Descrizione] [varchar](500) NOT NULL,
	[Prezzo] [decimal](6, 2) NOT NULL,
	[Image] [varchar](500) NOT NULL,
	[Rate] [decimal](2, 1) NOT NULL,
 CONSTRAINT [PK_Prodotti] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
