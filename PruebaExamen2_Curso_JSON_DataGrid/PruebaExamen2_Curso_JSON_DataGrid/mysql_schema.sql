CREATE DATABASE IF NOT EXISTS inscripciones;
USE inscripciones;

CREATE TABLE IF NOT EXISTS curso (
    id INT NOT NULL AUTO_INCREMENT,
    nombreCurso VARCHAR(150) NOT NULL,
    creditos INT NOT NULL,
    nombreProfesor VARCHAR(150) NOT NULL,
    especialidadProfesor VARCHAR(150) NOT NULL,
    PRIMARY KEY (id)
);

CREATE TABLE IF NOT EXISTS profesor (
    id INT NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    especialidad VARCHAR(150) NOT NULL,
    fechaContratacion DATETIME NOT NULL,
    sueldo INT NOT NULL,
    PRIMARY KEY (id)
);