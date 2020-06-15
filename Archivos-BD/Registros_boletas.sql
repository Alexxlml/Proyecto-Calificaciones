USE boletas;

-- Asignaciones grado y grupo
INSERT INTO asignacion (grado,grupo) values ('','');
INSERT INTO asignacion (grado,grupo) values ('1','A');
INSERT INTO asignacion (grado,grupo) values ('1','B');
INSERT INTO asignacion (grado,grupo) values ('1','C');
INSERT INTO asignacion (grado,grupo) values ('2','A');
INSERT INTO asignacion (grado,grupo) values ('2','B');
INSERT INTO asignacion (grado,grupo) values ('2','C');
INSERT INTO asignacion (grado,grupo) values ('3','A');
INSERT INTO asignacion (grado,grupo) values ('3','B');
INSERT INTO asignacion (grado,grupo) values ('3','C');
INSERT INTO asignacion (grado,grupo) values ('4','A');
INSERT INTO asignacion (grado,grupo) values ('4','B');
INSERT INTO asignacion (grado,grupo) values ('4','C');
INSERT INTO asignacion (grado,grupo) values ('5','A');
INSERT INTO asignacion (grado,grupo) values ('5','B');
INSERT INTO asignacion (grado,grupo) values ('5','C');
INSERT INTO asignacion (grado,grupo) values ('6','A');
INSERT INTO asignacion (grado,grupo) values ('6','B');
INSERT INTO asignacion (grado,grupo) values ('6','C');
INSERT INTO asignacion (grado,grupo) values ('','');

-- Privilegios

INSERT INTO privilegios values (1,'Director');
INSERT INTO privilegios values (0,'Maestro');
INSERT INTO privilegios values (2,'Subdirector');


-- Insercion de Director
INSERT INTO usuarios values ('alex@outlook.com','Marco Alexis Zacarias Rubio',aes_encrypt('1234',sha('negro')),'¿Color favorito?',sha('negro'),1,1);

-- Insercion de Maestros
INSERT INTO usuarios values ('alda@outlook.com','Aldair Gálvez Medina',aes_encrypt('0000',sha('azul')),'¿Color favorito?',sha('azul'),18,0);

-- Insercion de Alumnos
INSERT INTO alumnos values ('14090628','1234567890','Kevin de Víctor','Meléndez Farías',18,'12','A+','Ninguna','Fco. Madero No. 10','Víctor Meléndez','7341885495','Jessica Farías','7771598456','Andrés Farías','7341659845','');

-- Materias Primer Grado
INSERT INTO materias (grado,nombre) values ('1','Español I');
INSERT INTO materias (grado,nombre) values ('1','Matemáticas I');
INSERT INTO materias (grado,nombre) values ('1','Formación Civica y Ética I');
INSERT INTO materias (grado,nombre) values ('1','Conocimiento del Medio I');
-- Materias Segundo Grado
INSERT INTO materias (grado,nombre) values ('2','Español II');
INSERT INTO materias (grado,nombre) values ('2','Matemáticas II');
INSERT INTO materias (grado,nombre) values ('2','Formación Civica y Ética II');
INSERT INTO materias (grado,nombre) values ('2','Conocimiento del Medio II');
-- Materias Tercer grado
INSERT INTO materias (grado,nombre) values ('3','Español III');
INSERT INTO materias (grado,nombre) values ('3','Matemáticas III');
INSERT INTO materias (grado,nombre) values ('3','Ciencias Naturales I');
INSERT INTO materias (grado,nombre) values ('3','La Entidad Donde Vivo');
INSERT INTO materias (grado,nombre) values ('3','Formación Civica y Ética III');
INSERT INTO materias (grado,nombre) values ('3','Educación Artistica I');
-- Materias Cuarto Grado
INSERT INTO materias (grado,nombre) values ('4','Español IV');
INSERT INTO materias (grado,nombre) values ('4','Matemáticas IV');
INSERT INTO materias (grado,nombre) values ('4','Ciencias Naturales II');
INSERT INTO materias (grado,nombre) values ('4','Historia I');
INSERT INTO materias (grado,nombre) values ('4','Geografía I');
INSERT INTO materias (grado,nombre) values ('4','Formación Cívica y Ética IV');
INSERT INTO materias (grado,nombre) values ('4','Educación Artística II');
-- Materias Quinto Grado
INSERT INTO materias (grado,nombre) values ('5','Español V');
INSERT INTO materias (grado,nombre) values ('5','Matemáticas V');
INSERT INTO materias (grado,nombre) values ('5','Ciencias Naturales III');
INSERT INTO materias (grado,nombre) values ('5','Historia II');
INSERT INTO materias (grado,nombre) values ('5','Geografía II');
INSERT INTO materias (grado,nombre) values ('5','Formación Cívica y Ética V');
INSERT INTO materias (grado,nombre) values ('5','Educación Artística III');
-- Materias Sexto Grado
INSERT INTO materias (grado,nombre) values ('6','Español VI');
INSERT INTO materias (grado,nombre) values ('6','Matemáticas VI');
INSERT INTO materias (grado,nombre) values ('6','Ciencias Naturales IV');
INSERT INTO materias (grado,nombre) values ('6','Historia III');
INSERT INTO materias (grado,nombre) values ('6','Geografía III');
INSERT INTO materias (grado,nombre) values ('6','Formación Cívica y Ética VI');
INSERT INTO materias (grado,nombre) values ('6','Educación Artística IV');

-- Prueba de asistencia

INSERT INTO asistencias values ('14090628','SI','NO','2020-06-07');
INSERT INTO asistencias values ('14090628','SI','NO','2020-06-08');
INSERT INTO asistencias values ('14090628','SI','NO','2020-06-09');
-- Prueba de calificaciones

INSERT INTO calificaciones values (35, '14090628','100','80','95','90','85','Sin comentarios');
