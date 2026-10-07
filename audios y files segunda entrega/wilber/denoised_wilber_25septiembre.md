Entonces estos archivos se los voy a compartir para que ustedes puedan hacer estas pruebas.
Pero la idea de hoy es más que, porque todavía les falta un montón, porque no han hecho la configuración como tienen que hacerla.
Entonces, lo que vamos a probar ahorita es simplemente mostrarles cómo funciona el Notebook, este, el Jupyter, el JupyterLab, cómo funciona.
Y les quiero mostrar una prueba de un modelo entrenado, explicarles cómo funciona el entrenamiento y el por qué está malo.
Por qué está malo. Entonces miren, esto es normal, o sea, que un modelo, que un dataset le salga mal en un modelo de entrenamiento es normal.
A ver, no es que no se pueda ajustar o que el dataset sea totalmente inútil, o los datos originales sean totalmente inútiles,
sino que la forma en que se calcularon los datos o la cantidad de datos que se ejecutaron son incorrectos.
Entonces, la idea de esto es que podamos, a raíz de la ejecución de un pequeño modelo, podamos ver más o menos y intuir cuándo un modelo funciona y cuándo no funciona.
Entonces miren, es por estándar, aquí vamos a ver por acá. El Notebook es bastante sencillo, ya les muestro por acá.
Le he puesto aquí este nombre, vamos a ponerlo un poquito más, un poquito más, ahí, ahí, ahí.
Entonces, crea lo que afecta a Notebooks, ¿verdad? Le he puesto el nombre para hacer cualquier cosa, ¿verdad?
Yo le he puesto el 03modelado.ypynb, ¿verdad?
Y tengo dos archivos más que son el modelo corregido y el modelo comparativo, pero lo que les quiero mostrar es el modelo original, ¿verdad?
Con el primero que yo corrí, el que yo dije, ah, no funciona, ya no sirvo.
Entonces, lo primero, cuando yo creo un archivo de Notebook, voy a crear uno por acá, ¿verdad?
Vamos a crear aquí 01prueba.ipynb.
Este es Jupyter, ¿verdad? Lo que hace es crear un archivo.
Originalmente tengo un archivo de texto cualquiera, ¿verdad? Un archivo de texto cualquiera.
Lo que pasa es que con la extensión de Jupyter tenés los botones, pero que al final no son muy allá, ¿verdad?
El JupyterLab, ya saben que lo corremos ejecutando primero.
Después de que tenemos todo instalado, todos los requerimientos, todos los requisitos, ¿verdad?
Instalamos el JupyterLab y una vez que esté instalado, pues lo podemos correr dentro del entorno virtual.
O sea, entrando al BNB, entramos y ejecutamos, ¿verdad?
El JupyterLab y directamente ya el servidor está corriendo.
El JupyterLab es bastante sencillo. Voy a ejecutarlo por acá. Por ejemplo, aquí tengo prueba.
Tengo el archivo, me da un error, es correcto, me da un error porque no tiene absolutamente nada.
Y como pueden ver se ha ejecutado de forma directa. Voy a darlo por aquí.
Ahí actualizo. Por lo general me gusta realizar. Ya ven que como tengo el 1, ¿verdad?
Él me está dando un error porque obviamente esto no tiene absolutamente nada.
Lo disminuyo ahí, lo descarto y continuo con el que estaba seleccionado.
Entonces acá, ¿verdad? Voy a abrirlo por acá y ya ven que no me da absolutamente nada.
Entonces, ¿qué es lo que pasa? Que este notebook está vacío.
Él quiere ejecutar una acción, pero no hay ninguna acción que ejecutara.
Entonces es bastante, ejecutar acción es bastante sencillo.
Este es un ejecutor de script, pero que comparte memoria entre los scripts.
Por poner un ejemplo, vamos a hacer esto, algo como esto.
Voy a agarrar un print cualquiera. Vamos a darle ahí.
Este es el chuchadito, vamos a poner ahí.
Voy a ejecutar por acá. Ya ven que le di el signo más.
Entonces agrego el script.
Ahora si me voy acá a este muchacho, lo voy a actualizar para que me lo abra.
Y miren, ahí está. Ahí tiene el script.
Ahora el nombre de error. Vamos a darle zoom, ¿verdad?
Nome de error, ahí solo está el script. No ha ejecutado nada.
Si yo lo selecciono y le doy play, mira ahí está.
Ahí está la salida. Hola mundo
No tiene más.
¿Qué ventaja tiene? Bueno, que podemos tener bloques de código segmentados.
Podemos ir haciendo logs de cada uno de los bloques de código segmentados.
Y los podemos ir almacenando en variables globales que se comparten entre ellas mismas.
Y ahí donde vamos a trabajar mayormente.
Aquí en el 0.3 modelado, aquí tenemos la primera ejecución.
Primero, el primer script es sencillo.
Un script pendejo de comprobación.
Simplemente es ver si todas las cosas están en orden.
Primero, importo todas las librerías que voy a ocupar.
Hago un apen, en verdad, de las variables generales del sistema, etcétera, etcétera, etcétera.
Y verifico que pueda importar las funciones que voy a estar ocupando a lo largo de la ejecución.
Por ejemplo, cargar dataset de abandono.
Y por ejemplo, cargar el train test split de las librerías de SQL.
Y el de Xbox, que también voy a utilizar.
Una vez que yo tengo esto importado, ya lo puedo utilizar a lo largo de todas las ejecuciones.
Lo que pasa es que voy a poder ir ejecutándolo por partes.
Esa es la ventaja que vamos a tener aquí.
Y luego, sencillo. Algo tan simple como hacer un play.
Por aquí vamos a reflejar esto.
Start.
Por acá, start.
Es sencillo. Entonces, yo puedo venir aquí, por ejemplo, me voy a ir a aquel fondo.
Me voy a ir a aquel fondo, voy a agarrar este script y luego a play.
Miren, me di error. ¿Por qué me di error? Porque estos datos no existen.
¿Por qué? Porque me fui a la última parte del script.
O sea, me salté varios pasos, ¿verdad? Entonces, vamos por partes.
Primero, ejecutamos aquí. Play.
Boom.
Salida.
¿Verdad? Ahí está la salida.
La salida de abandono, 58%.
Datos cargados, 3.046 filas, 27.1.
¿Ya?
Ahí está la datos.
Entonces, ahí lo tenemos con 58%.
Con 58.55%.
Este error que te manda acá. Bueno, no es un error realmente.
No sé por qué es tan rojo. Es un warning. ¿Verdad?
Y ahí te dice cosas de que mejor utiliza esto, mejor utiliza lo otro, pendejas.
¿Qué quiere que haga?
¿Qué quiere que haga? ¿Verdad? Pero bueno.
Ya está en nosotros hacerle caso o no hacerle caso, ¿verdad?
Entonces, ahí ya tenemos lo primero, ¿verdad?
Tenemos los datos, ¿verdad? Tenemos los datos cargados.
Entonces, ahí tenemos el informe de las librerias cargadas.
Vámonos por acá. Vamos a escutarlo el segundo.
Este dato era nuevo. Era nuevo, ¿verdad?
Vamos para acá. Play.
Ahí tenemos, ¿verdad?
Ahí me dice columnas detectadas.
Ahí tenemos la primera, ¿verdad?
Ahí tenemos la lista de las variables.
Ahí están todas las variables.
Ahí tenemos la información, ¿verdad?
Y entonces, aquí es donde quiero que le pongamos mente, ¿verdad?
Entonces, tenemos por acá.
Se cargan los datos. ¿De quién?
De la función Cargar Dataset Abandono.
Así nos vamos al código.
Tenemos la...
Tenemos la función Cargar Datos.
Y nos vamos aquí al código.
Tenemos, mira, ahí está el Dataset Abandono.
¿Qué es lo que hace esto?
Pues es un select  * from etc, te avisa Abandono.
Guarda los datos.
Imprime esto, ¿verdad?
Simple y sencillamente hace eso, ¿verdad?
Entonces, ¿qué es lo que significa esto?
Que yo puedo tener mi archivo.pyton
y mandarlo a ejecutar o mandarlo a llamar
y portarlo desde acá, desde el notebook, ¿verdad?
Luego de esto,
luego de esto, tenemos, por ejemplo, acá
el información que he implementado, ¿verdad?
Dimensiones, 3000 pilas, 27 columnas,
una distribución de variables, ¿verdad?
De 1,
de 1780 Abandono,
versus 1266,
perdón, 1266 Abandono
versus 1780
aprobado o comprobado, ¿ya?
Y luego de esto, bueno, ahí tenemos
Abandono, 58.55, ¿verdad?
Que son los que tienen el valor 1.
Y tenemos allá, bueno,
27 columnas encontradas, ¿ok?
Lo siguiente, aquí si quiero que me ponga
lo que pasa es que no se ve tanto,
a ver si puedo hacer de azul,
a ver si puedo bajar la recta para acá.
Ahí se lee más o menos, ¿verdad?
Igual esto lo van a tener, ¿verdad?
Ahí tienen los comentarios también que básicamente
lo primero,
sacar, porque todo esto que estás haciendo
lo vamos a utilizar para entrenamiento,
recuerden algo, el dataset original
era para analítica, que era
la que gestionaba y
graficaba el dashboard, ¿verdad?
Entonces, ese dataset original que era para analítica,
tenía datos que eran para
poder hacer comparativas de clientes,
de esto, de fecha, etc. En este caso
vamos a eliminar aquello que no nos funciona,
y vamos solamente con las cosas que son
proyectivos o analizables. Entonces veamos por ejemplo acá,
lo primero,
limpiamos del dataset,
o sea, de los datos guardados, eliminar
todos aquellos columnas que no me
interesan, por ejemplo el cliente, el de reserva,
la fecha, esas cosas no me interesan, ¿verdad?
Luego, seleccionar
los tipos que me interesan, ¿verdad?
Las columnas que me interesan.
Y luego de esto, bueno,
aquí ya imprimo cuáles son las
columnas detectadas y cuáles son las variables
que... y todas las variables
que ya son numéricas.
Entonces, aquí tenemos
lo siguiente, una vez que se carga
todo esto, ¿verdad? Aquí lo que imprimimos
son esto, ¿verdad? La lista de variables detectadas,
ahí lo tenemos, ¿verdad?
Y luego ahí tenemos, ¿verdad?
la parte del entrenamiento. Entonces,
la parte del entrenamiento, lo vamos
a colocar en el siguiente script.
¿Qué es lo que vamos a hacer con este entrenamiento?
Miren, esta parte
es de la función split,
que es que va...
lo que va a hacer es la librería
de Jupyter, es separar
todo lo anterior,
es carga de datos
y comprobaciones,
¿verdad? Todo lo anterior es eso.
Lo siguiente,
eliminar aquellas cosas que no son
fundamentales.
Lo siguiente va a ser separar
la información. Entonces, aquí
esta parte quiero que me interese
que ustedes la entiendan. Uno,
si tenemos 3000 datos,
3000 datos,
para entrenar
un modelo y que el dato
sea predictivo, no podemos decir,
aquí están los 3000 datos, ahora comenzamos
a predecir. No funciona así.
¿Qué es lo que se hace?
Lo que se hace es que se agarran
un porcentaje de los datos como
muestra. Entonces,
ahí lo que le estoy diciendo es que me separe, ¿verdad?
Me separe
los datos y que me segmente
para hacer una prueba, para hacer la prueba,
para hacer los tests, para que me segmente el
20% de los datos, o sea que el otro 80%
va a quedar como muestra.
Entonces, el 80% de los datos,
el modelo los va a tomar como referencia.
Hagan de cuánto caso que es el contexto,
¿verdad? Y luego, los otros
datos, ¿verdad?
El otro porcentaje, el otro 20%
lo voy a utilizar para entrenar.
¿Qué es el entrenamiento?
Basado en el contexto,
él va a tratar de predecir, ¿verdad?
Él va a tratar de predecir
si es correcto
o si es incorrecto.
En este caso, si abandona o no abandona.
De forma dicotómica. Entonces,
él va a funcionar de esta manera.
Como son 3.000 registros, va a agarrar
más o menos 600, aproximadamente
600, para poder
hacer la prueba. Entonces, él va a decir,
bueno, el entrenamiento funciona de la siguiente manera.
Tengo el contexto que son 2.400 registros.
Entonces, él comienza.
Prueba uno. Dice más.
Abandona o no abandona. Basado en el contexto,
él va a decir,
sin ver los datos, sin ver qué valores tiene,
él va a decir, abandona o no abandona.
Entonces, él va a decir, abandona.
Después, él va a ver qué resultado tiene.
¿Verdad?
Y él va a decir,
acerté o no acerté.
¿Verdad?
Si no acierta, vamos con el segundo.
En la segunda corrida,
es lo que va a hacer él.
El segundo registro, abandona o no abandona.
Pero, antes, va a fijarse.
El primero, acertó o no acertó.
Entonces, si dice,
acertó. Ok.
¿Qué valores tenía el registro?
Para poderlo tomarlo.
Como referencia, para poder decir,
se abandonó o no abandonó.
Y va a aprender de su error.
Entonces, por ejemplo, él se equivocó
y él miró de que, por ejemplo,
las personas entraron desde la web.
Desde la web.
¿Verdad? O a todo el número de intento.
Entonces, él va a sacar un porcentaje,
más o menos, de cuánto peso tiene cada una de las variables.
Eso lo vamos a ver. ¿Verdad?
Él dice, ok, abandona o no abandona.
Abandona. Y no abandona.
Entonces, él tiene el segundo
y tiene un segundo fallo.
Entonces, va con el tercero. Y él va a ver
qué errores tenía el primero
versus los errores que tenía el segundo.
Va a ser un cruce de variables.
Y va a decir, bueno,
este no abandonó, pero este tiene una variable que vale esto.
Al inicio es bien caótico, porque claro,
él va a ir comparando. Pero luego, él va a ir encontrando patrones.
Entonces, él va a decir, bueno.
Entonces, él va a poner otra vez. Abandona o no abandona.
No abandona. Abandona. No abandona.
Y cada cruce de variable, él va a ir encontrando
un patron. Va a ir buscando una distribución estándar.
Entonces, él va a decir que algunos valores
se agrupan más.
¿Verdad? Se agrupan más
entre los que abandonan.
Se agrupan más algunos patrones,
con algunas variables, con un
porcentaje bastante alto. Y en otros
que no. Entonces, de tal manera
que en algún momento él va a tratar de
va a ir acercándose cada vez más
al patron más reconocible.
Y de esa manera va a poder identificar,
¿Verdad? Si él va a tener
un mayor índice de predicción.
Entonces, cuando él termine el entrenamiento
de los 600, ¿Verdad?
Termina el entrenamiento, él ya va a decir
cuántas veces acertó y cuántas veces no acertó.
¿Ya?
Entonces, cuando él determine
ese porcentaje de acertación, ahí nosotros
decimos, el modelo sirve o no sirve,
pues se vuelve el porcentaje de acertación.
Entonces, va a decir, bueno,
si el porcentaje es alto,
entonces yo digo, el modelo sirve. Entonces,
vamos a hacer pruebas ahora con pruebas reales.
Ahora insertemos un registro, ¡pum!
Un registro nuevo que no existía en el data set,
sino un registro nuevo, y
se lo pasaremos y él dirá, abandona o no abandona.
Y él va a tratar de predecir
de que abandona o no abandona. Obviamente, en ese
momento, el registro no sabe si va a
abandonar o no va a abandonar, sino que él
va a categorizar, él va a decir, bueno,
este registro nuevo que ha ingresado
tiene altas probabilidades de que abandone
o tiene altas probabilidades de que no abandona.
¿Ya? No sé si se está entendiendo
más o menos cómo es. O sea, esto es,
al final, tengan en cuenta de que
es como que yo le digo,
¿este es duro o es suave?
¿Verdad? Entonces, él va a decir,
¿qué características tiene este que lo hace en duro?
Va a tener, tiene este, este, este.
Puede que haya características que algo suave,
también las tenga. Entonces, él va a ir agrupando.
Pero él, mientras más vaya acertando
y más vaya equivocándose, él lo va a ir agrupando
y va a poder decir, bueno, tal
característica con tales valores
hace que la probabilidad
de que abandone
sea mayor o sea menor.
¿Verdad? Entonces, todo esto es probabilismo.
¿Ya? Entonces, una vez que hacemos
esto, él dice, bueno, tengo
2.400 registros que tengo
de muestra
y tengo 600
para probar. ¿Verdad?
Vamos a ver cuánto he aceptado
y luego aquí ejecuto
ya el modelo. Este es el modelo.
Miren, es una pendeja.
Ah, si es que esta vaina son, son,
son pendejadas, ¿verdad? O sea, no tienen
nada del otro mundo. Entonces, el modelo es
llamar a la, a la, este,
a la librería,
le digo cuántas van a hacer las
pruebas estimadas, le digo que son 600.
Cuánto es el máximo
de profundidad
de combinaciones que va a utilizar. En este caso,
vamos a utilizar un máximo de combinaciones
de cinco variables, ¿verdad?
O sea, cinco permutaciones que
él va a ir buscando cómo
usar entre, entre todas las variables hasta
cinco niveles, ¿verdad?
¿Cuánto es el índice de confianza que
espero, que 0.05,
perdón, perdón,
0.05, que saben que es el 5%,
que es el índice de confianza estándar
para cualquier
método investigativo
proinvestigativa, ¿verdad?
Se puede con 10%,
sí se puede, pero condiciones
aplican, ¿verdad? Entonces, 5% es el
estándar. Si usted, o sea, un,
un modelo que se corra en menos de
más del 5% ya es un modelo
que está en tela de duda, ¿verdad?
Se espera un margen de error de 5%
de
máximo, ¿verdad?
Una escala de peso,
¿verdad? Ahí tenemos, ¿verdad? Que es lo que
quiero encontrar, que en este caso
son los datos desbalanceados
y el,
bueno, el estado y la
métrica. En este caso, pues son,
es cómo se va a configurar para medir, estos son
los propios de la librería. Entonces,
una vez que yo lo entreno y lo
ejecuto, tengo, ¿verdad? Ahí
en dependencia de qué tantos datos
tengamos, todo tartar mas , o va a tartar menos
y nos vamos a dar cuenta,
¿verdad? Que el modelo, una vez que el modelo
está entrenado de manera exitosa , entonces ahora sí lo podemos
probar, ¿verdad? Ahora se entrenan,
¿verdad? Se cargan los datos y ahora
vamos a probarlo. Entonces dice,
aquí tenemos el script de prueba.
El script de prueba es básico,
¿verdad? Entonces tenemos, modelo,
¿qué voy a predecir? Voy a predecir
ex-test, que ex-test está declarado
aquí arribita, ¿verdad?
Ex-test se declara por aquí arriba,
o sea, aquí está ex-test, ¿verdad? Entonces,
esto lo voy a probar. Entonces,
recuerden que las variables
se pueden llamar como ustedes quieran, ¿verdad?
Simple y sencillamente esto es lo más,
lo más básico en bibliografía
de tasas, pero luego tienen que poner
los nombres que corresponde, ¿verdad?
Y luego, ¿verdad? Una vez que
ejecutamos, ¿verdad?
Este test, obtenemos este reporte,
¿verdad? Ahí tenemos, miren.
En este caso,
es el reporte que estoy pidiendo, aquí.
Entonces, básicamente
lo que busca es, primero, busca la
precisión, ahí ya me dice el reporte de
la precisión, y miren, me he encontrado
precisión, pagadas,
o sea, que ha
predecido, que ha
predecido cuántas veces
este
un registro iba a pagar y cuántas veces
no iba a pagar. Y dice que
la predicción es de 1, o sea que
es de 100%, o sea que el modelo
todas las veces que agarró un registro
la pegó.
La pegó, ¿verdad?
Y abandonada, ¿verdad? Ahí está.
0.99, o sea que
0.99% de las veces
que él dijo que iba a abandonar,
abandonó, ¿verdad?
Entonces, ahí tenemos,
bueno, cuenta el accuracy,
la rellamada, el
fscore, ¿verdad? Y aquí
es donde tenemos el mayor problema.
¿Ustedes
creen
que un modelo entrenado
con datos así te puede dar
tanto porcentaje
de acertación?
¿Creen ustedes que es correcto?
Usted
Diran ostian, la pegó 100%,
¿es correcto?
No.
Un modelo nuevo no puede...
¿Y si fuera el 10, el 20,
el 30% de acertación?
Tampoco.
Porque aquí es para lo que quiero yo
ejecutar un modelo que es solo el 20%
de la vez.
No sirve para nada eso.
Ya. Entonces, ¿qué es lo que yo
quiero acá? Aquí lo que yo quiero
es tener un porcentaje
moderado, aceptable,
validable. 70, 80,
por ahí. 70, 80,
85, ya se está
acercando al 90 y es peligroso.
Porque significa que estamos teniendo o datos muy
sucios o datos
o el modelo está
haciendo trampas.
OK. Entonces,
entonces, escuchen bien.
Aquí está
la clave. Entonces, miren,
puede ser de que los modelos
aprenden de diversas maneras,
¿verdad? Y pueden hacer,
pueden aprender, y esto claro
lo pueden investigar si quieren, ¿verdad?
Por ejemplo. Entonces, los modelos pueden hacer
trampas. Pueden hacer trampas
de muchas maneras. Por ejemplo,
pueden investigar. Y esos son de conocimiento
público porque hay paper
de eso.
Por ejemplo, imagínense que ustedes tienen
un brazo, un brazo simulado,
un brazo robot, ¿verdad? Que necesita
entrenarse con los movimientos necesarios
para poder hacer de que
este
de que este mouse se pose encima de él.
¿Ya?
Se puede
pueden hacer. Entonces,
ustedes saben lo complicado que es para un
brazo robot. Todos los movimientos que implica
acercarse, presionar, aplicar
fuerza, levantar, moverse,
colocarlo, ¿verdad? Todo lo complicado.
Entonces, ¿qué es lo que pasa?
Un modelo para poder
saber cuándo ha cumplido su tarea
porque él no es consciente
y cuando no lo ha cumplido, entonces lo que
se le hace es definir parámetros.
Entonces, por ejemplo,
puede ser de que un modelo
se le diga, oye, mira,
cuándo vos sabes
que ya está arriba, o sea,
que el elemento ya está arriba, ¿verdad? Porque él va a comenzar
a hacer pruebas con todos
los movimientos, falló, no falló,
falló, no falló, entonces
se le define parámetros. El parámetro
aquí ¿cuál es? Que abandona, no abandona,
que sí, sí o no. Pero él no sabe,
él no conoce ese parámetro porque ese parámetro
se le esconde. Pero entonces se le comienzan a
dar otros valores, otros
parámetros alrededor de eso
para tratar de predecir el entorno
y entonces él va una vez que él diga
cada vez que él tiene un resultado
se le revela el valor para que así él pueda
tener más o menos
una consideración
de cómo
de que si le ha acertado no le ha acertado.
Y así la siguiente prueba, él
valida con los aciertos
o los desaciertos de la prueba
anterior. Así funciona. Entonces
él dice, bueno, el ejemplo
aquí es un poquito malo porque la verdad es que
son dos cuadritos del mismo
tamaño, eso es lo que está documentado. Entonces
por ejemplo, entonces le dijeron
obviamente esto es parte de
el análisis humano y
la configuración humana. Le dijeron que
la forma para que él supiera
que ya había puesto uno encima
del otro, era de que
la línea, la
línea de abajo del
elemento, que tiene un parámetro
y tiene algo para identificarlo,
tenía que estar a la altura de la línea de arriba
del segundo elemento.
¿Verdad?
Obviamente estos son ejemplos
académicos para que uno entienda
cómo puede confundir su modelo, o sea, cómo puede
ensuciarse o cómo puede
hacer trampa un modelo. Entonces él dice,
bueno, él comenzó a probar, él comenzó a probar
y él descubrió que en uno de los movimientos
se le cayó el objeto
como tiene la misma altura, porque eran dos cuadros
exactamente iguales, entonces él descubrió
que en una que se le volvió el cuadro
el elemento, la línea, quedó
exactamente a la misma altura que el otro.
Entonces él dice, ah,
le pegué, ya la subí.
Él no conoce el concepto de
subir, ¿verdad que no?
Para poder conocer el concepto de subir, él tiene que tener
un parámetro que le diga, está arriba.
Entonces claro, él dice, cumplí.
La línea
de abajo del cuadro está
a la misma altura que la línea del cuadro de arriba.
Del otro, exacto, de allí
se llega al otro cuadro. Entonces él cumplió.
Y entonces él, en vez de intentar
en las siguientes pruebas, en vez de intentar
agarrarlo para subirlo, en lo que
hacía, era solamente, pum, lo volteaba.
Y en el siguiente lo volteaba. Lo volteaba.
Lo volteaba. ¿Y qué pasó?
Obtuvo el 100% de acertación.
¿Ya?
Obtuvo el 100% de la acertación.
Cuando fue de cierto
grado de la prueba. Entonces, ¿por qué?
¿Qué estaba haciendo? Estaba haciendo trampa.
O sea, entiéndase trampa en el sentido de que
él llegó al resultado esperado
sin cumplir la
tarea esperada.
Entonces, el resultado esperado
era que las dos líneas fueran a la misma altura.
Claro, uno estaba aquí, otro estaba aquí.
Cuando él lo volteaba, quedaban así. Entonces
él cumplía el resultado esperado.
Él cumplió. Él cumplió.
Exactamente. Pero no cumplió su tarea.
Era agarrar el objeto o la tarea esperada.
Cumplió el parámetro de relación.
Exactamente. Entonces, ¿qué es lo que
después está pasando aquí? Y aquí está la clave.
Dentro de los datos, y ahí está el error,
dentro de los datos, se han colado
datos de sumatoria de los pagos.
Entonces, este
modelo ha aprendido, ¿verdad?
De que los pagos
acumulados mayores
a cierto porcentaje o dentro de
cierto rango, tienen un porcentaje
de acertación clave.
Ya él aprendió eso.
¿Por qué? Porque... Lo sacó como ejemplo para
hacer los otros aciertos. Exactamente.
Entonces él dice, bueno, los pagos que están
dentro de este margen son pagos elevados,
por lo tanto son recompras. Entonces él dice,
como es un porcentaje muy
alto de probabilidades de que sea cierto,
entonces él se fue por allí, bum bum bum bum bum bum,
y las pegó todas.
Así lo consiguió.
Porque obviamente él tenía datos
contundentemente. ¿Qué falló?
¿Qué falló ahí?
Pero ¿qué fue lo que falló?
El data set.
No estuvo bien estructurado.
Hicieron cálculos que no se
debieron haber hecho.
O sea que salimos mal por tal data set.
Por el data set y culpó por lo tanto el programador
que hizo el data set.
Entonces claro,
esta chucha no se repara nada.
¿Por qué? Porque me va a dar...
O sea, está haciendo trampa.
Está haciendo trampa, ¿no?
De hecho no está tomando ni siquiera los valores adecuados.
Bajemos un poquito
para que lo podamos ver más claro.
Entonces, aquí,
ahí tenemos la siguiente parte del script,
que es para ver la matriz
de decisión. Aquí tenemos un gráfico.
Entiéndase que esto no es dashboard.
Esto es un dato estadístico.
Esto no es un dashboard, esto es un dato estadístico,
gráfico de mediciones estadísticas, ¿verdad?
Entonces, ahí lo tenemos.
Aquí tenemos la matriz de confusión.
Ahí tenemos las pruebas.
Ahí tenemos las veces que él
aseguró que abandonaba, ¿verdad?
Y las veces que aseguró que pagaba.
Ahí también, el segundo se equivocó cuatro veces
en el pago
y se equivocó cero veces
en abandono, ¿verdad?
Acertó cientos por ciento, ¿verdad?
Y luego, en la parte de acá,
en la parte de acá vamos a ver,
vamos a correrlo todo.
Lo que pasa es que corrí esa...
Vamos a correr el gráfico, vamos.
Ahí está. Entonces, ahí está la gráfica.
Miren.
Ahí está la gráfica. Entonces, ahí está la gráfica
de las variables. Todas las variables a su alrededor,
¿verdad? Y más o menos
él ha decidido, ¿verdad?
de que los
intentos de pago fallido
están elevados, ¿verdad?
Luego, para la parte de la ruta,
¿verdad? Ahí tenemos, ¿verdad?
El monto total, ¿vienen?
El monto total ha agarrado tres variables.
Ha agarrado tres variables.
El monto total, que es elevadísimo, miren,
está muy por encima, ¿verdad?
La ruta y
el pago. Entonces, él, con estos,
con estas tres variables,
asumiendo el valor de las tres variables
más la otra, entonces él
obtuvo un resultado
bastante alto, ¿verdad? Pero, como digo,
inexpertamente podemos pensar
que tú, excelente, la pegué,
no, la pegaste, ¿verdad?
Porque claro, un modelo que pega
100% a las veces no es correcto.
Se espera entre 75-
85, ¿verdad?
Que es lo más...
A ver,
cabe de mencionar, cabe de mencionar que
estos son mediciones estándar
que uno considera apropiada.
No es que el modelo,
el modelo no se equivocó,
volvemos a lo mismo. El concepto de equivocarse
es un concepto nuestro.
No es un concepto del modelo, el modelo que la pegó
cumplió con sus requisitos
y cumplió identificando
patrones. Lo que pasa es que los patrones
de los data sets no estaban adecuados
para que, no sea, no son un patrón
que refleja el mundo real. Eso es lo que está
pasando. El mundo real no se refleja
de esa manera, ¿ya?
Ok, veamos el modelo corregido.
Hay un script también
que se lo voy a compartir para que podamos ver el modelo
corregido, ¿verdad? Que básicamente
hacer otro data set corregido.
¿Qué es lo que se hizo en el segundo data set? En vez de
agruparlos, ¿verdad?
Con los sumadores, todos los pagos, todos los reintentos
lo que se hizo fue
segmentarlo por reintento
y por pago individual.
De tal manera que estaban agrupados simplemente
por bloque de reintento.
Eso hace, eso, todo eso
provocó de que el registro de los data sets
veámoslo por acá.
Bueno, no voy a explicar eso porque es básicamente
lo mismo.
En vez de
agarrar 3.000 registros que teníamos antes
he agarrado 10.786
registros.
Que casualmente
casi, casi corresponden al total
de registros de datos de entrenamiento.
O sea, que en el anterior
como estábamos agrupando los datos, se agrupaban
en categorías muy amplias
y eso provocaba que el modelo sea
muy fácil de adivinar.
En este caso, ya básicamente vamos 1 a 1.
O sea, no es 100% 1 a 1
pero es muy similar a 1 a 1, ¿verdad?
Simplemente se hizo la conversión.
Entonces, en este sentido, ahí lo tenemos
10.000 registros, 27 columnas
ahí lo tenemos, tasa de
abandono, 64%,
ahí está. Y luego
vamos por acá, por ahí está
la variable, no voy a detenerme aquí.
Ahí está, bueno, están bien, esto son las medianas
no me interesa eso, ¿verdad? Son simplemente
información.
Entonces la variable, vamos
por acá. Aquí es donde me interesa, ¿verdad?
Entonces, después
de pegar el entrenamiento
al 20% nuevamente
al 20%
entonces tenemos ahí
que tenemos un set de datos de prueba
de 2.158
registros. Otra cosa importante
600 registros para un entrenamiento
para un test de entrenamiento es muy poco.
O sea, es que de hecho
3.000 registros para un
modelo de entrenamiento es poquísimo.
Incluso
si tuviéramos los datos correctos, pero con poquitos
registros no es posible hacer minería de datos.
Ya, no es posible hacer minería de datos.
ahí tenemos, ¿verdad? el porcentaje
y movimos rápido a la parte
de este modelo. Miren.
Lo mismo, ¿verdad?
Lo mismo. Ahí tenemos ahí
pesos 75, ¿verdad?
600 de tolerancia.
Entonces 600 de tolerancia. Ahí
tenemos, ¿verdad? Ahí están los números
de iteraciones estimadas.
Y luego veamos la evaluación.
Vamos para acá.
Ahí está.
Entonces miren, ahí está la
precisión.
Ha predecido con certeza
de un 84%
la tasa de abandono.
Cumple mi KPI.
Ahí está.
Ha fallado más en la tasa
de pago.
73%. Está bajo.
Pero no me importa.
¿Por qué no me importa? ¿Cómo se llama el
KPI? Tasa de
abandono.
Me interesa más precios la tasa de abandono.
Ya. Entonces
claro, hubiera sido genial.
Habría que ajustar más el modelo, ¿verdad?
Que me pudiera hacer
85% en ambos.
Pero claro, tendría que ajustar el modelo, ¿verdad?
Para eso, ¿ya?
Para tratar de buscar un mayor precios. O con más
datos. Tal vez con
100.000 registros.
Que no es descabellado. 100.000 registros es una pendejada,
¿verdad? Para un modelo de entrenamiento es
rapidísimo. Eso no es nada, ¿verdad? 100.000 registros
de la tasa de abandono, muy probablemente
sea mayor.
Porque el conjunto de datos lo
permite. Entonces, ahí lo tenemos,
¿verdad?
Sí, mayor,
más acercamiento va a tener. Entonces,
ahí lo tenemos. Y aquí lo que me interesa
es esto.
Ahí es lo que me interesa. Bueno, ahí está la prueba. Ahí
están las veces que hay poco. No pasa
nada. Y acá
me interesa que veamos
la curva. ¿Cómo
se comporta? Ahí tenemos ahí
el entrenamiento. Inició bastante bajo y
fue aumentando, fue aumentando, fue aumentando, fue aumentando y se quedó
aquí, ¿ya?
Entonces, no fue lineal,
sino que la curva fue del 82% de incremento,
¿verdad? De cada iteración.
Ahí tenemos el punto
de los elementos y las variables.
Esta parte es la parte más
importantísima de esto.
Intentas fallidas 34.
¿Se acuerdan? ¿Se acuerdan
que les dije
que cuando hacemos
analítica de datos podemos
intuir qué es lo que está
pasando, pero no podemos saber
realmente qué lo está provocando.
Y mirábamos dentro de la gráfica
que la tenemos ahí, ¿verdad?
La voy a seguir para que también la tengan disponible.
Yo creo que la tenían disponible, pero
tenemos en la gráfica del dashboard, mirábamos
qué, setenta y pico por ciento en
web, en web móvil,
setenta y pico por ciento en malaga, no sé
cuánto, setenta y cinco por ciento, ¿verdad?
O sea, ¿qué es lo que
pasa? Esos datos
para hacernos una idea.
Están bien, pero no nos dicen
la verdad, no sabemos realmente cuál es
el verdadero peso. Y ahí lo tenemos.
Miren, la
mayor, pero es que con un impacto
elevadísimo, el
34
por ciento de las veces
que abandonó,
o sea, de las veces que
abandonó, el 34 por ciento
del peso mayor lo tuvo, intento
fallido. ¿Qué significa esto? De que la
aplicación está fallando al momento de que
intento hacer un pago, entonces la gente abandona
más fácilmente porque no está pagando,
porque no logra
pagar, ¿no? Porque no lo quiere hacer.
Con un peso del 34
por ciento, miren eso, eso es
buenísimo saberlo.
Porque sí yo sé cuál es el síntoma
verdadero. Luego hay otros factores,
por ejemplo, con un 8 por ciento, la ruta,
o sea, ¿se acuerdan que en la ruta decía
setenta y pico por ciento en la ruta de abandono?
Pero ojo,
realmente, ¿cuánto peso
tenía esa ruta
para la decisión de
abandonar o no abandonar? Entonces más o menos
se estima que tiene un 8 por ciento,
o sea que la ruta no es tan importante.
Si tiene un peso importante,
8 por ciento es un peso importante, pero no es
tan catastrófico,
tan catastrófico como
se miraba
en la analítica de datos.
La analítica de datos es incorrecta, no, la analítica de datos
no es incorrecta, la analítica de datos es lo que es,
verdad, business intelligence.
Datos con tendencia,
con tendencia a medida, ¿verdad?
Pero un minería de datos te va a decir la verdad,
ya te va a decir los detalles, va a escalar,
va a entrar hasta el fondo.
Va a poder sacarte esa información con
prueba de estadística
verificable.
Luego, el web , 7 por ciento,
que sea internacional,
7 por ciento, que sea sucursal,
5 por ciento, y miren qué interesante,
el app móvil, miren cuánto tienen 2%.
¿Y cuánto salía en analítica?
60 y pico la madre, ¿verdad?
¿Por qué? Porque resulta,
resulta y acontece
de que
la app móvil es la que más se utiliza, entonces los datos
te están engañando.
Porque claro, en la agrupación categórica
se agrupan muchos de los abandonos
en app móvil, pero el app móvil realmente
no es el que tiene la pulpa como tal,
sino que es la sumatoria
de todos los factores antes incluidos.
Y podemos determinar que el
mayor factor de peso para el
abandono es pago fallido.
Pago fallido, significa que algo está fallando
en los pagos.
Algo está fallando en los pagos.
Y bueno, y ahí están, miren,
todo, todo.
Todo un por ciento, ¿eh? Si es estudiante,
que si es precio promedio de la ruta,
que si es antigüedad de cliente en día.
Bajo hasta que comparado con el precio fallido.
Ehh, sí.
O sea, con super bajo. O sea, aquí
no digo 2 por ciento, no es
depreciable, el porcento es un porcentaje
importante, ¿verdad? Pero no es
la clave, claro.
Cuando se interceptan todo esto,
pues, te da,
te da, lo que estamos haciendo
son las intercepciones de las variadas, entonces, cuando
están todas interceptadas, juntas, ahí donde está
el mayor problema de verdad.
Bueno, dicho esto,
me interesaba sobre todo ver eso,
¿verdad? Ahí hay más cosas.
Ahí hay más cosas, ¿verdad?, que se pueden
ver en la prueba. Se las voy a
partir para que ustedes lo puedan analizar,
y les voy a pasar otras pruebas para que
también lo puedan ver, ¿verdad? Entonces,
aquí lo importante es que
entendamos por qué un modelo
falla y por qué un modelo
acierta. ¿Cómo podemos
entender los síntomas cuando un modelo
está fallando, ya? Y luego,
aunque se mire la chorrera
de código, realmente el modelo
y el entrenamiento son tres pendejadas, ¿verdad? Que son
todos los, todos los iniciales
son datos, log y carga.
Todos normales, ¿verdad? Es básicamente
el entrenamiento de...
El entrenamiento de hacer el split,
de hacer el split,
¿verdad? Para sacar la
certificación de lo que voy a entrenar
y ejecutar el modelo.
¿Qué es eso? ¿Verdad?
Y luego, simplemente se hacen las pruebas
predictivas y ya comenzamos
a ver los datos. Si se mira mucho
código, como pueden ver,
es más información
que yo estoy poniendo para que se pueda leer
algo, ¿verdad?
Entonces, ahí está.
Quedamos ahí, pues.