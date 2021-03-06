USE [ControleAtividadesDB]
GO
/****** Object:  Table [dbo].[Atividades]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Atividades](
	[AtividadeID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](30) NOT NULL,
	[Descricao] [nvarchar](max) NULL,
	[Ativo] [bit] NOT NULL,
	[CategoriaID] [int] NOT NULL,
	[UsuarioID] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Atividades] PRIMARY KEY CLUSTERED 
(
	[AtividadeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[CategoriaID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Categorias] PRIMARY KEY CLUSTERED 
(
	[CategoriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Consultas]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Consultas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Hora] [datetime] NOT NULL,
	[Medico_MedicoId] [int] NULL,
	[Paciente_PacienteId] [int] NULL,
	[Secretaria_SecretariaId] [int] NULL,
 CONSTRAINT [PK_dbo.Consultas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contas]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Banco] [nvarchar](max) NULL,
	[ContaCorrente] [nvarchar](max) NULL,
	[Agencia] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Contas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Convenios]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Convenios](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Empresa] [nvarchar](max) NULL,
	[Telefone] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Convenios] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Valor] [real] NOT NULL,
 CONSTRAINT [PK_dbo.Especialidades] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[MedicoId] [int] IDENTITY(1,1) NOT NULL,
	[CRM] [nvarchar](max) NULL,
	[Turno] [nvarchar](max) NULL,
	[Nome] [nvarchar](max) NULL,
	[Nascimento] [datetime] NOT NULL,
	[Telefone] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[conta_Id] [int] NULL,
	[Especialidade_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Medicos] PRIMARY KEY CLUSTERED 
(
	[MedicoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[PacienteId] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Nascimento] [datetime] NOT NULL,
	[Telefone] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[Convenio_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Pacientes] PRIMARY KEY CLUSTERED 
(
	[PacienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Secretarias]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Secretarias](
	[SecretariaId] [int] IDENTITY(1,1) NOT NULL,
	[Turno] [nvarchar](max) NULL,
	[Nome] [nvarchar](max) NULL,
	[Nascimento] [datetime] NOT NULL,
	[Telefone] [nvarchar](max) NULL,
	[CPF] [nvarchar](max) NULL,
	[conta_Id] [int] NULL,
 CONSTRAINT [PK_dbo.Secretarias] PRIMARY KEY CLUSTERED 
(
	[SecretariaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 2018-07-02 11:11:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](max) NULL,
	[Ativo] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Consultas] ON 
GO
INSERT [dbo].[Consultas] ([Id], [Hora], [Medico_MedicoId], [Paciente_PacienteId], [Secretaria_SecretariaId]) VALUES (2, CAST(N'2018-06-25T10:10:00.000' AS DateTime), 1, 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Consultas] OFF
GO
SET IDENTITY_INSERT [dbo].[Contas] ON 
GO
INSERT [dbo].[Contas] ([Id], [Banco], [ContaCorrente], [Agencia]) VALUES (1, N'BB', N'1234', 1)
GO
INSERT [dbo].[Contas] ([Id], [Banco], [ContaCorrente], [Agencia]) VALUES (2, N'Santander', N'2345', 2)
GO
INSERT [dbo].[Contas] ([Id], [Banco], [ContaCorrente], [Agencia]) VALUES (3, N'Bradesco', N'3456', 3)
GO
SET IDENTITY_INSERT [dbo].[Contas] OFF
GO
SET IDENTITY_INSERT [dbo].[Convenios] ON 
GO
INSERT [dbo].[Convenios] ([Id], [Nome], [Empresa], [Telefone]) VALUES (1, N'Unimed Premium', N'Unimed', N'123456')
GO
INSERT [dbo].[Convenios] ([Id], [Nome], [Empresa], [Telefone]) VALUES (2, N'Amil Standard', N'Amil', N'234567')
GO
SET IDENTITY_INSERT [dbo].[Convenios] OFF
GO
SET IDENTITY_INSERT [dbo].[Especialidades] ON 
GO
INSERT [dbo].[Especialidades] ([Id], [Nome], [Valor]) VALUES (1, N'Medico Geral', 10)
GO
INSERT [dbo].[Especialidades] ([Id], [Nome], [Valor]) VALUES (2, N'Cardiologista', 40)
GO
INSERT [dbo].[Especialidades] ([Id], [Nome], [Valor]) VALUES (3, N'Dermatologista', 25)
GO
SET IDENTITY_INSERT [dbo].[Especialidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 
GO
INSERT [dbo].[Medicos] ([MedicoId], [CRM], [Turno], [Nome], [Nascimento], [Telefone], [CPF], [conta_Id], [Especialidade_Id]) VALUES (1, N'CRM-012', N'Manha', N'dr. Oz', CAST(N'1990-01-02T00:00:00.000' AS DateTime), N'1234', N'1234', 1, 1)
GO
INSERT [dbo].[Medicos] ([MedicoId], [CRM], [Turno], [Nome], [Nascimento], [Telefone], [CPF], [conta_Id], [Especialidade_Id]) VALUES (2, N'CRM-123', N'M', N'dr. Lerguino', CAST(N'1990-01-02T00:00:00.000' AS DateTime), N'123', N'123', 1, 1)
GO
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON 
GO
INSERT [dbo].[Pacientes] ([PacienteId], [Nome], [Nascimento], [Telefone], [CPF], [Convenio_Id]) VALUES (1, N'Juca', CAST(N'1980-02-02T00:00:00.000' AS DateTime), N'123', N'456', 1)
GO
INSERT [dbo].[Pacientes] ([PacienteId], [Nome], [Nascimento], [Telefone], [CPF], [Convenio_Id]) VALUES (2, N'Tiao', CAST(N'2018-06-11T00:00:00.000' AS DateTime), N'1111', N'123', 2)
GO
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Secretarias] ON 
GO
INSERT [dbo].[Secretarias] ([SecretariaId], [Turno], [Nome], [Nascimento], [Telefone], [CPF], [conta_Id]) VALUES (1, N'Noturno', N'Angelica', CAST(N'2018-06-25T00:24:42.100' AS DateTime), N'2222222', N'1111111', 1)
GO
INSERT [dbo].[Secretarias] ([SecretariaId], [Turno], [Nome], [Nascimento], [Telefone], [CPF], [conta_Id]) VALUES (2, N'Manhã', N'Gertrudez', CAST(N'2018-06-25T00:24:42.110' AS DateTime), N'3333333', N'222222', 2)
GO
INSERT [dbo].[Secretarias] ([SecretariaId], [Turno], [Nome], [Nascimento], [Telefone], [CPF], [conta_Id]) VALUES (3, N'Noturno', N'Antonieta', CAST(N'2018-06-25T00:24:42.110' AS DateTime), N'4444444', N'333333', 3)
GO
SET IDENTITY_INSERT [dbo].[Secretarias] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 
GO
INSERT [dbo].[Usuarios] ([UsuarioID], [Nome], [Ativo]) VALUES (1, N'test', 1)
GO
INSERT [dbo].[Usuarios] ([UsuarioID], [Nome], [Ativo]) VALUES (2, N'123', 1)
GO
INSERT [dbo].[Usuarios] ([UsuarioID], [Nome], [Ativo]) VALUES (3, N'Joao', 1)
GO
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Consultas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Consultas_dbo.Medicos_Medico_MedicoId] FOREIGN KEY([Medico_MedicoId])
REFERENCES [dbo].[Medicos] ([MedicoId])
GO
ALTER TABLE [dbo].[Consultas] CHECK CONSTRAINT [FK_dbo.Consultas_dbo.Medicos_Medico_MedicoId]
GO
ALTER TABLE [dbo].[Consultas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Consultas_dbo.Pacientes_Paciente_PacienteId] FOREIGN KEY([Paciente_PacienteId])
REFERENCES [dbo].[Pacientes] ([PacienteId])
GO
ALTER TABLE [dbo].[Consultas] CHECK CONSTRAINT [FK_dbo.Consultas_dbo.Pacientes_Paciente_PacienteId]
GO
ALTER TABLE [dbo].[Consultas]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Consultas_dbo.Secretarias_Secretaria_SecretariaId] FOREIGN KEY([Secretaria_SecretariaId])
REFERENCES [dbo].[Secretarias] ([SecretariaId])
GO
ALTER TABLE [dbo].[Consultas] CHECK CONSTRAINT [FK_dbo.Consultas_dbo.Secretarias_Secretaria_SecretariaId]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Medicos_dbo.Contas_conta_Id] FOREIGN KEY([conta_Id])
REFERENCES [dbo].[Contas] ([Id])
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_dbo.Medicos_dbo.Contas_conta_Id]
GO
ALTER TABLE [dbo].[Medicos]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Medicos_dbo.Especialidades_Especialidade_Id] FOREIGN KEY([Especialidade_Id])
REFERENCES [dbo].[Especialidades] ([Id])
GO
ALTER TABLE [dbo].[Medicos] CHECK CONSTRAINT [FK_dbo.Medicos_dbo.Especialidades_Especialidade_Id]
GO
ALTER TABLE [dbo].[Pacientes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Pacientes_dbo.Convenios_Convenio_Id] FOREIGN KEY([Convenio_Id])
REFERENCES [dbo].[Convenios] ([Id])
GO
ALTER TABLE [dbo].[Pacientes] CHECK CONSTRAINT [FK_dbo.Pacientes_dbo.Convenios_Convenio_Id]
GO
ALTER TABLE [dbo].[Secretarias]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Secretarias_dbo.Contas_conta_Id] FOREIGN KEY([conta_Id])
REFERENCES [dbo].[Contas] ([Id])
GO
ALTER TABLE [dbo].[Secretarias] CHECK CONSTRAINT [FK_dbo.Secretarias_dbo.Contas_conta_Id]
GO
