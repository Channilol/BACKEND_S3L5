USE [eCommerceEpicode]
GO
/****** Object:  Table [dbo].[Carrello]    Script Date: 16/02/2024 20:29:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrello](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProdotto] [int] NOT NULL,
	[Quantità] [tinyint] NOT NULL,
 CONSTRAINT [PK_Carrello] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carrello]  WITH CHECK ADD  CONSTRAINT [FK_Carrello_Prodotti] FOREIGN KEY([IdProdotto])
REFERENCES [dbo].[Prodotti] ([Id])
GO
ALTER TABLE [dbo].[Carrello] CHECK CONSTRAINT [FK_Carrello_Prodotti]
GO
