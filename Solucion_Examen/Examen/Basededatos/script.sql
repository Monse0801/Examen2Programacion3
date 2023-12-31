USE [mantenimiento]
GO
/****** Object:  Table [dbo].[Asignaciones]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asignaciones](
	[AsignacionID] [int] NOT NULL,
	[ReparacionID] [int] NULL,
	[TecnicoID] [int] NULL,
	[FechaAsignacion] [date] NULL,
 CONSTRAINT [PK_Asignaciones] PRIMARY KEY CLUSTERED 
(
	[AsignacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesReparacion]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesReparacion](
	[DetalleID] [int] NOT NULL,
	[ReparacionID] [int] NULL,
	[Descripcion] [nchar](50) NULL,
	[FechaInicio] [date] NULL,
	[FechaFinal] [date] NULL,
 CONSTRAINT [PK_DetallesReparacion] PRIMARY KEY CLUSTERED 
(
	[DetalleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Equipos]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Equipos](
	[EquipoID] [int] NOT NULL,
	[TipoEquipo] [nchar](50) NOT NULL,
	[Modelo] [nchar](50) NOT NULL,
	[UsuarioID] [int] NOT NULL,
 CONSTRAINT [PK_Equipos] PRIMARY KEY CLUSTERED 
(
	[EquipoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reparaciones]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reparaciones](
	[ReparacionID] [int] NOT NULL,
	[EquipoID] [int] NULL,
	[FechaSolicitud] [date] NULL,
	[Estado] [char](1) NOT NULL,
 CONSTRAINT [PK_Reparaciones] PRIMARY KEY CLUSTERED 
(
	[ReparacionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tecnicos]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tecnicos](
	[TecnicoID] [int] NOT NULL,
	[Nombre] [nchar](50) NULL,
	[Especialidad] [nchar](50) NULL,
 CONSTRAINT [PK_Tecnicos] PRIMARY KEY CLUSTERED 
(
	[TecnicoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[UsuarioID] [int] NOT NULL,
	[Nombre] [nchar](50) NOT NULL,
	[CorreoElectronico] [nchar](50) NULL,
	[Telefono] [nchar](15) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[UsuarioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Asignaciones]  WITH CHECK ADD  CONSTRAINT [fk_Asignaciones_Reparaciones] FOREIGN KEY([ReparacionID])
REFERENCES [dbo].[Reparaciones] ([ReparacionID])
GO
ALTER TABLE [dbo].[Asignaciones] CHECK CONSTRAINT [fk_Asignaciones_Reparaciones]
GO
ALTER TABLE [dbo].[Asignaciones]  WITH CHECK ADD  CONSTRAINT [fk_Asignaciones_Tecnicos] FOREIGN KEY([TecnicoID])
REFERENCES [dbo].[Tecnicos] ([TecnicoID])
GO
ALTER TABLE [dbo].[Asignaciones] CHECK CONSTRAINT [fk_Asignaciones_Tecnicos]
GO
ALTER TABLE [dbo].[DetallesReparacion]  WITH CHECK ADD  CONSTRAINT [fk_DetallesReparacion_Reparaciones] FOREIGN KEY([ReparacionID])
REFERENCES [dbo].[Reparaciones] ([ReparacionID])
GO
ALTER TABLE [dbo].[DetallesReparacion] CHECK CONSTRAINT [fk_DetallesReparacion_Reparaciones]
GO
ALTER TABLE [dbo].[Equipos]  WITH CHECK ADD  CONSTRAINT [fk_Equipos_Usuarios] FOREIGN KEY([UsuarioID])
REFERENCES [dbo].[Usuarios] ([UsuarioID])
GO
ALTER TABLE [dbo].[Equipos] CHECK CONSTRAINT [fk_Equipos_Usuarios]
GO
ALTER TABLE [dbo].[Reparaciones]  WITH CHECK ADD  CONSTRAINT [fk_Reparaciones_Equipos] FOREIGN KEY([EquipoID])
REFERENCES [dbo].[Equipos] ([EquipoID])
GO
ALTER TABLE [dbo].[Reparaciones] CHECK CONSTRAINT [fk_Reparaciones_Equipos]
GO
/****** Object:  StoredProcedure [dbo].[AGREGAR_USUARIO]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AGREGAR_USUARIO]
  @UsuarioID INT,
    @Nombre VARCHAR(50),
    @CorreoElectronico VARCHAR(100),
    @Telefono VARCHAR(20)
AS
BEGIN
    INSERT INTO dbo.Usuarios (UsuarioID, Nombre, CorreoElectronico, Telefono)
    VALUES (@UsuarioID, @Nombre, @CorreoElectronico, @Telefono)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarEquipo]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarEquipo]
    @EquipoID INT,
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    INSERT INTO Equipos (EquipoID, TipoEquipo, Modelo, UsuarioID)
    VALUES (@EquipoID, @TipoEquipo, @Modelo, @UsuarioID)
END
GO
/****** Object:  StoredProcedure [dbo].[AgregarTecnico]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AgregarTecnico]
    @TecnicoID INT,
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    INSERT INTO Tecnicos (TecnicoID, Nombre, Especialidad)
    VALUES (@TecnicoID, @Nombre, @Especialidad)
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarEquipo]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarEquipo]
    @EquipoID INT
AS
BEGIN
    SELECT EquipoID, TipoEquipo, Modelo, UsuarioID
    FROM Equipos
    WHERE EquipoID = @EquipoID
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarTecnico]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarTecnico]
    @TecnicoID INT
AS
BEGIN
    SELECT TecnicoID, Nombre, Especialidad
    FROM [dbo].[Tecnicos]
    WHERE TecnicoID = @TecnicoID
END
GO
/****** Object:  StoredProcedure [dbo].[ConsultarUsuario]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ConsultarUsuario]
    @UsuarioID INT
AS
BEGIN
    SELECT UsuarioID, Nombre, CorreoElectronico, Telefono
    FROM dbo.Usuarios
    WHERE UsuarioID = @UsuarioID
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarEquipo]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarEquipo]
    @EquipoID INT
AS
BEGIN
    DELETE FROM Equipos
    WHERE EquipoID = @EquipoID
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarTecnico]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarTecnico]
    @TecnicoID INT
AS
BEGIN
    DELETE FROM [dbo].[Tecnicos]
    WHERE TecnicoID = @TecnicoID
END
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario]
    @UsuarioID INT
AS
BEGIN
    DELETE FROM dbo.Usuarios
    WHERE UsuarioID = @UsuarioID
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarEquipo]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarEquipo]
    @EquipoID INT,
    @TipoEquipo VARCHAR(50),
    @Modelo VARCHAR(50),
    @UsuarioID INT
AS
BEGIN
    UPDATE Equipos
    SET TipoEquipo = @TipoEquipo,
        Modelo = @Modelo,
        UsuarioID = @UsuarioID
    WHERE EquipoID = @EquipoID
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarTecnico]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarTecnico]
    @TecnicoID INT,
    @Nombre VARCHAR(50),
    @Especialidad VARCHAR(50)
AS
BEGIN
    UPDATE [dbo].[Tecnicos]
    SET Nombre = @Nombre,
        Especialidad = @Especialidad
    WHERE TecnicoID = @TecnicoID
END
GO
/****** Object:  StoredProcedure [dbo].[ModificarUsuario]    Script Date: 11/20/2023 10:55:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ModificarUsuario]
    @UsuarioID INT,
    @Nombre VARCHAR(50),
    @CorreoElectronico VARCHAR(100),
    @Telefono VARCHAR(20)
AS
BEGIN
    UPDATE dbo.Usuarios
    SET Nombre = @Nombre,
        CorreoElectronico = @CorreoElectronico,
        Telefono = @Telefono
    WHERE UsuarioID = @UsuarioID
END
GO
