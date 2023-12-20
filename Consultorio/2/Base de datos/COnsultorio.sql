CREATE DATABASE Consultorio
go
Use Consultorio
go
--Tabla para hacer el login del doctor/recepcionista
CREATE TABLE Usuarios(
UsuarioID int primary key identity,
Sesion nvarchar (20) unique not null,
Contra nvarchar (30) not null,
NombreUsuario nvarchar (50) not null,
Rango nvarchar (20) not null,
CelularUsuario nvarchar (10) not null
)
go
--Tabla para los pacientes
CREATE TABLE Pacientes(
PacienteID int primary key identity,
NombrePaciente varchar(50) not null,
Edad int not null,
TipoSangre varchar (3) not null,
Direccion nvarchar(60) null,
PolizaSeguro varchar(30) null ,
CelularPaciente int not null
)
go
--Crear la tabla para las citas
CREATE TABLE Citas(
CitaID int primary key identity,
PacienteID int foreign key references Pacientes(PacienteID),
Hora varchar(5) not null,
Dia date not null
)
go
--Tabla para el historial
CREATE TABLE Historial(
HistorialID int primary key identity,
PacienteID int foreign key references Pacientes(PacienteID),
Fecha date not null,
Sintomas varchar (150) not null,
)
go
--Tabla para las recetas
CREATE TABLE Recetas(
RecetasID int primary key identity,
PacienteID int foreign key references Pacientes(PacienteID),
Medicamentos varchar (100) not null,
Fecha date not null
)
go

INSERT INTO Usuarios values('CAIR','123','Carlos Iribe','Administrador','6673889550')
INSERT INTO Usuarios values('Mois','456','Moises Medina','Doctor','6673739475')
INSERT INTO Usuarios values('Dani','789','Daniel Lizarraga','Recepcionista','6673500800')
declare @user nvarchar(10)='CAIR'
declare @pass nvarchar(10)='123'
select * from Usuarios where Sesion=@user and Contra=@pass
select * From Usuarios