create database PagoServicios
use PagoServicios

CREATE TABLE ConfiguracionCanal
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Canal VARCHAR(15) NOT NULL,
	Descripcion VARCHAR(200) NOT NULL,
    UrlServicio VARCHAR(500) NOT NULL,
    ApiKey VARCHAR(200) NOT NULL,
    MostrarMenu BIT NOT NULL,
    PaginaDestino VARCHAR(200) NOT NULL,
    TimeoutSegundos INT NOT NULL
)

INSERT INTO ConfiguracionCanal (Canal, Descripcion, UrlServicio, ApiKey, MostrarMenu, PaginaDestino, TimeoutSegundos)
VALUES ('AB', 'Empresas AB', 'https://localhost:44374/empresas', 'AB123', 1, 'canal=AB', 10)
INSERT INTO ConfiguracionCanal (Canal, Descripcion, UrlServicio, ApiKey, MostrarMenu, PaginaDestino, TimeoutSegundos)
VALUES ('CJ', 'Empresas CJ', 'https://localhost:44374/empresas', 'CJ123', 0, 'canal=CJ', 5)
INSERT INTO ConfiguracionCanal (Canal, Descripcion, UrlServicio, ApiKey, MostrarMenu, PaginaDestino, TimeoutSegundos)
VALUES ('XX', 'Canal Inexistente', 'https://localhost:44374/empresas', 'XX123', 1, 'canal=XX', 5)
INSERT INTO ConfiguracionCanal (Canal, Descripcion, UrlServicio, ApiKey, MostrarMenu, PaginaDestino, TimeoutSegundos)
VALUES ('LENTO', 'Simula TimeOut', 'https://localhost:44374/empresas', 'LE123', 1, 'canal=LENTO', 5)
INSERT INTO ConfiguracionCanal (Canal, Descripcion, UrlServicio, ApiKey, MostrarMenu, PaginaDestino, TimeoutSegundos)
VALUES ('ERROR', 'Simula Error', 'https://localhost:44374/empresas', 'ER123', 1, 'canal=ERROR', 5)
INSERT INTO ConfiguracionCanal (Canal, Descripcion, UrlServicio, ApiKey, MostrarMenu, PaginaDestino, TimeoutSegundos)
VALUES ('UNAUTHORIZED', 'No Autorizado', 'https://localhost:44374/empresas', 'ER456', 1, 'canal=UNAUTHORIZED', 5)



CREATE PROCEDURE sp_getConfigCanal
(
    @Canal VARCHAR(15)
)
AS
BEGIN

    SELECT
        Canal,
        UrlServicio,
        ApiKey,
        MostrarMenu,
        PaginaDestino,
        TimeoutSegundos
    FROM ConfiguracionCanal
    WHERE Canal = @Canal

END

CREATE PROCEDURE sp_getMenuCanal
AS
BEGIN

    SELECT
        Canal,
        Descripcion,
        UrlServicio,
        ApiKey,
        MostrarMenu,
        PaginaDestino,
        TimeoutSegundos
    FROM ConfiguracionCanal
    WHERE MostrarMenu = 1
END