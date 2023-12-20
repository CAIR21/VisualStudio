--Base de datos
--*************************--
CREATE DATABASE Consultorio
USE Consultorio            
go
--*************************--
--Tablas
--********************************************************************--
--Tabla para hacer el login del doctor/recepcionista
CREATE TABLE Usuarios(
UsuarioID varchar (5) primary key ,
Sesion varchar (20) unique not null,
Contra varchar (30) not null,
NombreUsuario varchar (50) not null,
Rango varchar (20) not null,
CelularUsuario varchar (10) not null
)
go
--Tabla para los pacientes
CREATE TABLE Pacientes(
PacienteID varchar (5) not null,
NombrePaciente varchar(50) primary key,
Edad int not null,
TipoSangre varchar (3) not null,
Direccion nvarchar(60) not null,
PolizaSeguro varchar(30) not null ,
CorreoPaciente varchar(30) not null,
CelularPaciente varchar(10) not null
)
go
drop table Pacientes
--Crear la tabla para las citas
CREATE TABLE Citas(
CitaID varchar (5) primary key,
NombrePaciente varchar (50) foreign key references Pacientes(NombrePaciente),
Hora varchar(5) not null,
Dia date not null,
Motivo varchar (80) not null,
ConsultorioPreferencia varchar(30) not null
)
go
drop table Citas
--Tabla para las recetas
CREATE TABLE Recetas(
RecetasID varchar (5) primary key,
PacienteID varchar (5) foreign key references Pacientes(PacienteID),
UsuarioID varchar (5) foreign key references Usuarios(UsuarioID),
Medicamentos varchar (100) not null,
Fecha date not null,
Consultorio int not null,
Anotaciones varchar (100) default ' ' 
)
go
--Tabla para el historial
CREATE TABLE Historial(
HistorialID varchar (5) primary key,
PacienteID varchar (5) foreign key references Pacientes(PacienteID),
Fecha date not null,
AnotacionesConsulta varchar(150) not null,
PadecimientosSeveros varchar (150) not null,
RecetasID varchar (5) foreign key references Recetas(RecetasID) 
)
go
--********************************************************************--
--Procedimientos almaceados para los usuarios
--******************************************************************************************************************************************************************--
--Sp para la lista de usuarios
CREATE PROCEDURE SP_ListaUsuarios
AS
SELECT * FROM Usuarios order by UsuarioID
go
--Buscar al usuario
CREATE PROCEDURE SP_BuscarUsuario
@Nombre VARCHAR (50)
AS
SELECT * FROM Usuarios WHERE NombreUsuario like @Nombre + '%'
go
CREATE PROCEDURE SP_OpcionesUsuarios
@UsuarioID varchar (5),
@Sesion varchar(20),
@Contra varchar(30),
@NombreUsuario varchar(50),
@Rango varchar (20),
@CelularUsuario varchar (10),
@Accion varchar(50) output
AS
IF(@Accion='1')
BEGIN
	--DECLARE @UsuarioIDNuevo varchar (5), @IDMax varchar (5)
	--SET @IDMax =(SELECT MAX(UsuarioID) FROM Usuarios)
	--SET @IDMax=ISNULL(@IDMax, 'A0000')
	--SET @UsuarioIDNuevo = 'A'+ RIGHT(RIGHT(@UsuarioIDNuevo,4)+10001,4)
	INSERT INTO Usuarios (UsuarioID,Sesion,Contra,NombreUsuario,Rango,CelularUsuario)
	VALUES(@UsuarioID,@Sesion,@Contra,@NombreUsuario,@Rango,@CelularUsuario)
	SET @Accion = 'Se ha generado un nuevo ID: ' +@UsuarioID
END
ELSE IF (@Accion='2')
BEGIN
	UPDATE Usuarios SET Sesion=@Sesion,Contra=@Contra, NombreUsuario=@NombreUsuario,Rango=@Rango,CelularUsuario=@CelularUsuario WHERE UsuarioID=@UsuarioID
	SET @Accion='Se modifico el ID: ' +@UsuarioID
END
ELSE IF(@Accion='3')
BEGIN
	DELETE FROM Usuarios WHERE UsuarioID=@UsuarioID
	SET @Accion='Se borro el ID: ' +@UsuarioID
END
go
insert into Usuarios values ('A0001', 'CAIR','123','Carlos Iribe','Administrador','6673889550')
go
--exec SP_ListaUsuarios
---- SP_BuscarUsuario 'Carlos'
--exec SP_OpcionesUsuarios  'A0001','CAIR','123','Carlos Iribe','Administrador','6673889550', '1'
--exec SP_OpcionesUsuarios  'A0002','Mois','456','Moises Medina','Doctor','6673739475', '1'

--drop Procedure SP_ListaUsuarios
--drop procedure SP_BuscarUsuario
--drop procedure SP_OpcionesUsuarios
--******************************************************************************************************************************************************************--
--Procedimientos almacenados para los pacientes
--***************************************************************************************************************************--
--Sp para la lista de los pacientes
CREATE PROCEDURE SP_ListaPacientes
AS
SELECT * FROM Pacientes order by PacienteID
go
--Buscar al paciente
CREATE PROCEDURE SP_BuscarPaciente
@Nombre VARCHAR (50)
AS
SELECT * FROM Pacientes WHERE NombrePaciente like @Nombre + '%'
go
--Sp para los procediminetos
ALTER PROCEDURE SP_OpcionesPacientes
@PacienteID varchar (5),
@NombrePaciente varchar(50),
@Edad int,
@TipoSangre varchar (3),
@Direccion nvarchar(60),
@PolizaSeguro varchar(30),
@CorreoPaciente varchar(30),
@CelularPaciente varchar (10),
@Accion varchar(50) output
AS
IF(@Accion='1')
BEGIN
	--DECLARE @IDNuevo varchar (5), @IDMax varchar (5)
	--SET @IDMax =(SELECT MAX(PacienteID) FROM Pacientes)
	--SET @IDMax=ISNULL(@IDMax, 'P0000')
	--SET @IDNuevo = 'P'+ RIGHT(RIGHT(@IDNuevo,4)+10001,4)
	INSERT INTO Pacientes (PacienteID,NombrePaciente,Edad,TipoSangre,Direccion,PolizaSeguro,CorreoPaciente,CelularPaciente)
	VALUES(@PacienteID,@NombrePaciente,@Edad,@TipoSangre,@Direccion,@PolizaSeguro,@CorreoPaciente,@CelularPaciente)
	SET @Accion = 'Se ha generado un nuevo ID: ' +@PacienteID
END
ELSE IF (@Accion='2')
BEGIN
	UPDATE Pacientes SET NombrePaciente=@NombrePaciente,Edad=@Edad,TipoSangre=@TipoSangre,Direccion=@Direccion,
	PolizaSeguro=@PolizaSeguro,CorreoPaciente=@CorreoPaciente,CelularPaciente=@CelularPaciente WHERE PacienteID=@PacienteID
	SET @Accion='Se modifico el ID: ' +@PacienteID
END
ELSE IF(@Accion='3')
BEGIN
	DELETE FROM Pacientes WHERE PacienteID=@PacienteID
	SET @Accion='Se borro el ID: ' +@PacienteID
END
go
--drop procedure SP_ListaPacientes
--drop procedure SP_BuscarPaciente
--drop procedure SP_OpcionesPacientes
--***************************************************************************************************************************--

--*****
--Sp para la lista de recetas
CREATE PROCEDURE SP_ListaCita
AS
SELECT * FROM Citas order by CitasID
go
--Buscar receta por nombre
CREATE PROCEDURE SP_BuscarCitaN
@Nombre VARCHAR (50)
AS
SELECT * FROM Citas WHERE NombrePaciente like @Nombre + '%'
go
--Buscar receta por fecha
CREATE PROCEDURE SP_BuscarCitaF
@Fecha DATE
AS
SELECT * FROM Citas WHERE Dia like @Fecha + '%'
go
--
