es que aprovechemos para ver otros modelos que podemos probar. Ahorita, toda la prueba inicial que se hizo era para un random forest ¿Verdad? arbol de desiciones, perdón, para un arbol de desiciones. Entonces, el entrenamiento del modelo actual, o sea, el que les pasé muestras para que fueran avanzando, está destinado para tipos de datos, ¿verdad? en los que el arbol de desiciones se comporta de forma adecuada. No todos los modelos funcionan igual y no todos los modelos dan los mismos resultados. Siempre los modelos en función de su entrenamiento pueden variar valores y unos se pueden acercar más a los resultados esperados y otros se pueden alejar. Entonces, ¿qué es lo que pasa? La idea, ¿verdad?, es que salvo algunas características de algunos modelos particulares que necesitas cumplir con ciertos requisitos para poderlos correr, puede ser de que algunos modelos cuando se corran en una estructura, fallen y de otro modo se corran en otra estructura en solo el mismo dato. Entonces, ¿cuál es la gracia de todo este tema? La gracia de todo este tema es que vayamos entendiendo más o menos cómo se estructura, ¿verdad?, en la parte de la creación de los modelos, voy a cambiar esto. Se ve mejor. Entonces, ustedes ya tienen, ya esta parte ya la habíamos hablado, ¿verdad?, pero voy a volver a hablarla para que lo tengáis en cuenta. Por ejemplo, tenemos el arbol de desiciones que estábamos probando, que están basadas en reglas no lineales, o sea, no requiere linealidad, porque eso es importante, no todos los modelos se comportan iguales, y no todos queremos que tengan una estructura idéntica. Por ejemplo, cuando tenemos datos estilo Likert, o sea, que estamos hablando de que los valores van siempre en una escala lineal, o sea, no hay una variabilidad tan alta,
sino que todos los valores están marcados en el mismo rango.
Entonces, hay modelos que tal vez no se van a comportar muy bien cuando los datos sean así, ¿verdad?,
otros que se iban super bien, ¿verdad?
Por ejemplo, la revisión logística es totalmente lineal, o sea, se espera o busca que los datos sean lineales.
Se le puede pasar la revisión logística a un modelo que no tenga datos no lineales,
ese se le puede pasar, pero el resultado no va a ser el esperado, no va a ser el más adecuado.
Puede que el modelo de entrenamiento, más o menos,
encuentre los patrones y encuentre las definiciones, pero no va a ser una regla definitiva.
Entonces, en dependencia de eso, podemos decidir qué modelos vamos a utilizar.
Algunos modelos, porque si estamos hablando de datos lineales,
pues posiblemente vamos a buscar modelos que se comporten de la mejor manera en datos lineales.
Si tenemos datos no lineales, pues entonces, posiblemente tengamos, podamos tener,
Entonces, los modelos, vamos a escogerlos,
según los tipos de datos.
Y, este...
Según qué estructuras
que tengamos en los datos, pues podemos escoger
uno u otro. Entonces vamos a tener
comportamientos un poquito diferentes.
Como vuelvo a decir, por ejemplo,
los datos con los que estoy probando,
les pase todos mis modelos.
Ya vamos a ver, nos vamos a hablar de cómo
se hace, cómo se entrenan y cómo
es de tener un modelo.
Que ya saben, no es una tontería.
Pero que tengan claro que tener un modelo
es una tontería. Lo importante es que los datos
estén bien hechos. ¿Verdad? Entonces,
tenemos lo primero, tenemos el primer
lo que son, por ejemplo, la redacción logística
que trabaja con linealidad. Entonces,
vamos a tener un modelo
de redacción logística y
vamos a ver cómo se comportan con datos
lineales. Vamos a ver a qué
se comporta y funciona según
los datos que nos demuestran.
Por ejemplo,
tenemos para la parte de
este... Bueno, ahí hay una
descripción, ¿verdad?, de la entomología total.
Pues puede ser exactamente cuánto pesa cada
variable y pues puede tratar de
como son lineales, pues
ubicarlo o
secundarlo según lo que
se considere pesado dentro de
el entorno. Por ejemplo,
para que un café sepa
bien, ¿qué es más importante?
El dulzor o la
amargor? La amarga.
La amarga, ¿verdad? Entonces, claro.
Entonces, la variable, ¿verdad?
La propiedad amargor puede tener más peso, ¿verdad?
Dentro del modelo, para tomar
decisiones,
y puede que ese valor
sea el que más se posee
de forma adecuada
para la protección del modelo.
Entonces,
¿qué le pasa?
Hay debilidades.
Cada modelo tiene sus propias debilidades.
Entonces, también
va a tener bastante peso
en la decisión de los modelos que vamos a utilizar.
Yo les recomiendo, ¿verdad?
Que como son fáciles de montar,
podemos hacer dos o tres pruebas.
El ejemplo que les voy a pasar
es para pruebas simples,
y el que, según las pruebas, salga mejor posicionado,
es el que mejor seleccionen ustedes
para el montaje
del modelo oficial ya con la gráfica
y todo el tema, ¿verdad?
El árbol de decisiones,
el random forest, ¿verdad?
Que, por ejemplo,
el random forest lo que hace es que
agarra árboles de decisiones,
los posiciona, ¿verdad?
Este específicamente que nosotros estamos utilizando.
Ya, el que es el xgboost ,
¿verdad?
Es más lento que el xgboost ,
perdón.
Este es más lento que el xgboost , ¿verdad?
Entonces, este trabaja
agrupando los árboles
y haciendo permutaciones entre ellos, ¿verdad?
Es bastante robusto, pero es bastante lento.
No es bastante lento, si los atos son demasiados,
pues le va a costar.
Aquí tenemos el Xbox, que es el que estamos
trabajando.
Este trabaja con seis árboles secuenciales,
o sea, es básicamente el mismo que el anterior,
nada más que tienen más grupos de árboles
de decisiones trabajando,
si no hay problemas.
Tienen más grupos de árboles trabajando,
mientras que los datos se te meten
en bloques más grandes.
Eso hace que los árboles se meten
en bloques más grandes.
Entonces, es robusto,
¿verdad?
Tiene bastante rendimiento,
¿verdad?
Y, pero sí
requiere que se establezcan
demasiados parámetros.
Ahí lo vamos a ver, ¿verdad?
Ya cuando lo vemos.
Tenemos el lightGBM,
¿verdad?
Este trabaja también basado en árboles,
trabaja, por lo general,
la mayoría, por lo general trabajamos
con árboles de árbol, ¿ya?
Entonces, tenemos, ¿verdad?
En este caso, es más rápido que el xgboost ,
¿verdad?
Y el este,
pero,
sufre, ¿verdad?
Si tiene data set
bastante pequeña, o sea, que
si tiene menos de 10.000 registros,
este, pues, no,
va a,
no va a haber pingo. Entonces, necesita muchísimo
porque necesita mucho regreso.
Tenemos KDN, basado en
distancias, no paramétrico,
o sea, a ver, cuando dice basado en distancias,
no paramétrico, es que
los datos no necesariamente son paramétricos,
que son, no son tipos de variables
paramétricas, y el este,
y,
basado en distancias, normalmente lo que busca
es como la separación,
o la diferenciación que entre cada uno
de los bloques te da, ¿ya?
Y calcula, en este
caso, pues,
lo que hace es como que,
como que los agrupa, busca
los datos que son más parecidos, y luego
busca diferencias como segmentaciones
entre otros grupos, ¿verdad?
Es bastante simple,
es bastante lento,
es bastante lento. Por ejemplo,
tenemos el
Naive Bytes,
que es un probabilístico vadeciano
que calcula
probabilidades usando el teorema de Bytes,
¿verdad? Que es una
fórmula estadística,
¿verdad? Que es de,
que trabaja, que se trabaja para
poder hacer previsión, ya,
es pura estadística, o sea,
un teorema. Entonces,
obviamente, por lo menos, yo no voy a poner
a eso, tampoco soy consultor en ese tema,
¿verdad? El este
es bastante rápido, ¿verdad?
Pero tiene su debilidad, ¿verdad?
Que tiene su propia opción,
de diferenciar,
pues no es tan,
o sea, no es tan
realista, en realidad, o sea,
es más, como es probabilístico,
pues,
el
margen de previsión puede ser
demasiado alto, demasiado alto,
sobre todo cuando la presión no sube
tanto.
Y ahí tenemos el SBB,
¿verdad? Que es un geométrico basado
en márgenes, parecido al anterior,
al anterior de este KDN,
y este, y este lo que
hace es que
busca la línea, o
las, la guía
de parámetros que es,
básicamente, lo vayan
indicando los parecidos entre cada uno de ellos.
Es bastante,
eh,
tiene bastante potencia, por lo
menos cuando son datos demasiado complejos,
cuando hay demasiadas variaciones,
cuando hay demasiadas variables
involucradas, sobre todo cuando
las tienen muchas
dimensiones, ¿verdad?
Puede ser que es bastante lento,
¿verdad? Y requiere
este, o sea, cuando tiene muchos datos es bastante
lento y, bueno,
muchas veces es difícil de interpretar, porque
claro, o sea, tener tantas
variable, o sea,
no es como que tenga,
por ejemplo, con el
xgboost , este que,
eh, xgboost , perdón, el
este que, que da un grupo de variables
ya segmentada, y no ahí como que , ¿verdad? Entonces,
este, básicamente, aquí está
como la lista de los modelos que
les voy a enseñar ahorita, y
abajito está como una interpretación de los datos que
estamos, que, que, que hemos obtenido.
Entonces, nos venimos por acá,
En instalación, voy a
voy a volver a subir el
el MD, solo el MD en instalación, porque
esto es muy complicado,
y le voy a pasar solo el archivo, para que no,
porque atrás va a volver a subir el
el penjazo, ¿verdad? Aquí en instalación
si hay algo que tenemos que hacer, porque
hay dos, eh,
hay dos modelos que no están funcionando bien, porque
requieren una instalación,
¿verdad? Este, el final,
entonces, hay que instalar el
light GBM, para poder trabajar
con la prueba de light GBM,
y el este,
y para poderlo correr entonces, porque si no
no corre, hay que instalar esto, aparte de lo que
ya teníamos instalado, y luego
para la parte de los modelos, pues
se está agregando con este
con esta estructura, entonces
vamos, vamos por bloques, vamos a irnos agrupando
por bloques,
ok, entonces lo primero,
lo práctico, ¿verdad?
eh, importar
importar toda la variable,
cargar los datos,
este, cargar,
importar todas las cosas que vamos a utilizar,
¿verdad?, el train speed,
el crossbar response, ¿está? Ahí tenemos
ahí todas las métricas, todas las que
todas las que se ocupan, ¿verdad?, todo esto de él
le sacan literal, y el este,
y aquí tenemos toda la variedad que vamos a utilizar,
el modelo lineal, el de árboles,
el de sablados, del network,
este,
el xgboost , el
light GBM , ya, ahí lo tenemos,
entonces, ahí tenemos,
ahí tenemos los datos,
ahí tenemos todos los datos que estén cargados,
y por ejemplo, a mí el único que
me falla es la XGBM porque
tengo muy poquitos datos, o sea, necesito más de 10 mil
 para que la XGBM
funcione bien, ya,
de ahí, este, bueno, ahí tenemos,
ahí tenemos toda la estructura, ¿verdad?, y
aquí simplemente es cargar la librería,
solo cargar la librería, lo segundo,
cargar los datos, este igual al otro,
al otro ejemplo, ¿verdad?, que es
cargamos los datos,
de la, del método
que estamos cargando, lo correcto,
¿verdad?, no lo incorrecto, lo correcto,
y luego, pues, eliminan aquellas
columnas que nos pueden meter
ruido, o sea, todas aquellas
que tienen un par de kilómetros válidos,
y aquellas de tiempo, pues, a poco
son algo importante para esta parte, ¿verdad?,
y el este,
luego de esto,
pues, se incluyen,
hace el cálculo, y, pues,
tenemos un resultado bastante sencillo, pues,
que nos diga, que se conectó,
que se pidieron
10.000 y algo de  registros, ¿verdad?,
ahí tenemos, este,
27
columnas, 10.700
filas, ahí tenemos la distribución,
recuerden que la distribución, ¿cuánto va?,
¿verdad?, es abono,
6.551, y
no es abono,
este, 4.230,
¿verdad?, si ya tenemos la variada,
ahí, en la tasa de abandono,
hacemos que, en torno
del 60 y pico por ciento, porque, más o menos,
así es cuando lo definimos,
no va a ser exacto, porque, claro, obviamente,
yo lo tengo ajustado para que
sea, este, cerca del 60 por ciento,
pero, claro sigue siendo analitico, si es cierto que no lo veréis,
como se va a mover desde el 60, 61,
y va a estar así, ¿verdad?,
porque va a seguir esa tendencia,
pero no, nunca va a ser exactamente el
62 por ciento que teníamos originalmente
, en la tasa de abandono,
y tenemos en el data set listo, ¿verdad?,
con 8.628
registros para entrenamiento
y 2.158
para testeo,
ya sabemos que esto es simple, ¿verdad?,
tenemos
el 80 por ciento
de los datos del
data set  entero, son para entrenamiento,
y el otro 20
por ciento se utiliza para qué?,
para testear, para testear a ver
si realmente el modelo
está preciento, ¿verdad?,
entonces, ¿cuántas pruebas hace
este modelo?, pues hace 2.158
pruebas, son muchas pocas,
son poquitas, o sea, 2.180
pruebas son pocas, a ver, si hubiéramos
100.000 registros, la cosa sería
más interesante, ¿verdad?,
pero, ¿qué es lo que pasa con 100.000 registros?,
va a estar súper lento, ya,
imagínense ustedes que
las pruebas de decisiones son conjunciones
y comparaciones entre
para decisiones, entonces,
de hecho ya está prueba, aquí como estoy
mirando varios árboles, pues
ya es el más lento,
entonces, ahora, aquí de
donde está lo interesante, ¿verdad?, vamos a
cargar los modelos, y aquí,
como les dije, lo primero es
cargar los datos,
luego cargamos la configuración de los modelos
y después los entrenamos, ¿ya?, entonces,
aquí está el bastante
fácil, es que no,
esto no tiene ciencia,
la verdad es que es súper fácil,
esto no tiene ninguna ciencia,
agarramos los modelos y decimos
bueno, revisión logística,
ahí tenemos la libreria que
usted utiliza para, o el objeto que
usted utiliza para, revisión logística, que es
logística y regresión, ¿verdad?, está
encostado y está formada parte
de la librería, ¿qué tenemos?, bueno,
ahí tenemos los parámetros que vamos a utilizar,
¿verdad?, vamos a utilizar
el tipo balanceado
y, bueno, este
es el radio,
en este caso 40,
en este caso 40, lo vamos a trabajar con este tipo de parámetros,
¿ya?,
entonces, como pueden ver, según qué
modelo, más parámetros vamos a poner, ahora,
con los parámetros, chicos,
a como están ahí,
o sea, no nos vamos a complicar la vida,
al final esto es,
así se pueden ajustar, así podemos estar peleándonos,
pero la verdad es que, a como están ahí,
no, no se complican las cosas,
eso es todo, ¿verdad?, entonces,
ahí tenemos, ¿verdad?, árboles de decisiones,
decisión, clasificación,
por árbol de decisiones,
estamos, entonces, aquí es
entonces, como pueden ver,
los modelos son súper fáciles,
obviamente,
la dificultad está en saber
qué significa cada parámetro,
cada valor,
pero en este caso,
los parámetros que están por aquí,
son como los más,
no vamos a tener, ¿verdad?,
entonces, ahí tenemos,
tenemos Random Forest,
ahí está el Random Forest,
está, ¿verdad?,
igual, ¿verdad?,
tenemos parámetros,
normalmente siempre trabajamos balanceados,
tenemos el XGB Classified,
ahí está,
que es para el bus,
este que estamos utilizando,
donde está, ¿verdad?,
con un número estimado a 600,
con una profundidad de 5,
podemos, también,
también se puede probar,
modificando, ¿verdad?, las profundidades,
el scale ratio,
0.05
es el standard,
o sea, no podemos,
no podemos moverlo mucho,
¿por qué?,
si lo subimos, lo que va a hacer es que el modelo,
acierte más,
¿por qué?, porque va a ser,
este, que asuma errores,
como cierto, de forma más seguida,
entonces, ¿qué es lo que hace?,
porque el 0.05
es el margen de error,
el margen de error del 0.05 es
el 0.05% aceptado,
es el aceptado, ¿verdad?, entonces,
¿qué es lo que pasa?, si nosotros lo disminuimos mucho,
él se va a cerrar y no va a poder predecir nada,
¿verdad?, entonces,
tiene que manejarse en este rango,
entonces, es un tipo de estado, ¿verdad?,
eh,
a ver, lo tenemos,
luego está el XGB Classified,
este me falla, ¿verdad?,
porque me faltan tantos,
de entrenamientos,
son 8000 registros de entrenamientos,
entonces, necesita más,
¿verdad?, como no funciona,
ahí tenemos el CANAPOR,
¿verdad?, el certificador
de vecinos más cercanos,
este lo tenemos, ¿verdad?, este,
los pesos son de distancia, porque este es lo que mide,
aquí es lo que mide, ¿no?, es un modelo
de distancia, no es balanceado,
o sea, la mayoría de los modelos
es balanceado, balanceado, balanceado,
estos son, este,
todos estos son,
eh,
este probabilístico, y aquí tenemos, ¿verdad?,
uno que mide distancia, ¿verdad?,
en este caso, pues estamos trabajando con K10,
o sea, que es, eh, de, con grupos
de 10 vecinos, ¿verdad?,
entonces, para poderlo trabajar, y el último, ¿verdad?, ah bueno,
tenemos PAYAX,
CAUCIANO, de mire que no hay parámetro,
no hay nada, o sea, es un teorema,
sin más, y tenemos
el SBC, así está, súper sencillo,
árbol de ediciones
completo, ahí tenemos,
mire, todos los modelos que vamos a utilizar,
sin más, o sea, es que no,
es solo poner uno o poner otro,
básicamente, ¿ya?,
ok,
lo que pasa es que en este ejemplo
no van a haber la gráfica, ¿por qué?, porque aquí solo estamos
haciendo una comparación de
los resultados de todos los modelos,
eh, ahora
vamos a entrenar, bueno,
aquí está el entrenamiento, bastante sencillo,
¿verdad?, ahí está, agarra por modelos
.it, ta ta ta,
ahí ejecuta esto, también,
esto aquí, ustedes lo corten, lo pegan,
sin más, así que no,
no va a haber de perderse, ¿verdad?,
entonces, lo único que tenemos que verificar es que obviamente
los datos que estemos cargando, son los datos que
es, ¿verdad?,
que vienen de cargar datos de las variables
que están más arriba.
Ahí lo tenemos, ¿verdad?,
eh,
ahí tenemos, ¿verdad?, ahí tenemos el modelo,
esto simplemente es para la parte de los resultados,
o sea, para que se vea la tabla de los resultados,
se grafica,
y ahí lo tenemos,
y ahí tenemos los resultados, y por último,
¿verdad?, aquí están los modelos, ¿vienen?,
eh,
ahí están los modelos, ahí están,
bueno, esto ya es el script
corrido, ¿verdad?, entonces, tenemos,
se ve bien ahí,
¿lo ve bien ahí?,
entonces, ahí podemos ver
los datos, mira, ahí se corrió,
ahí está,
ahí están los parámetros,
ahí está, ¿verdad?,
ahí hay un que me falla,
eh,
ahí tenemos, ¿verdad?, el KNN,
el SBM, ahí están todos
los entrenados, aquí los entrenamos todos,
una vez entrenados, ahora lo que vamos a hacer
es ver los resultados, ¿verdad?,
entonces, ahí,
esto que está aquí es simplemente un,
es un script para dibujar una tabla,
no es nada de lo que vamos a hacer,
entonces,
y aquí están los resultados, ¿verdad?,
ahí lo tenemos,
¿ya?, entonces,
para el KNK10,
bueno, tenemos la colación 0.74,
¿verdad?,
con una precisión, ¿verdad?,
una rellamada, y el ROCK, que es lo que
más nos interesa, ¿verdad?, en este caso,
acuérdense que, este tiene
parado variable, entonces, el ROCK,
que es lo que más nos interesa, tenemos 0.83,
entonces, el KNN,
está guapo,
o sea,
el que más tiene,
el que mejor tiene, ¿verdad?,
el segundo que mejor tiene,
el xgboost , que es el que teníamos
anteriormente, ¿verdad?,
entonces, ahí tenemos el XGBoss,
que ya sabemos que tenemos bloques de 600,
de árboles de 600,
de grupos de árboles de 600,
entonces, son grupos de árboles de 600,
agrupadas por
N600,
árboles, ¿verdad?, o sea, que se van haciendo
bosques de árboles, y por cada uno
de estos bosques de árboles, porque vamos a hacer
las comparativas con cada una de los ojos, ¿verdad?
entonces, ahí lo tenemos, ¿verdad?,
para el ROCK,
¿verdad?, tenemos ahí
0.81,
¿verdad?, que es este, ¿verdad?, ROCK Aussell,
0.81,
luego de esto, Random Forest,
79,
miren que el modelo corrió,
puede predecir,
pero la predicción es
baja,
ya estamos hablando de, recuerden que estamos buscando
entre
85,
78,
75, ya estamos muy al borro, o sea,
ya un modelo de 75, ya mismo,
estamos buscando 80, 85, por ahí,
que es lo que sería lo idóneo, ¿verdad?,
a ver, no es que sea muy malo, que
llegara a 90, pues, pero claro, llegara a 90,
en realidad que tenías muchísimos datos,
y si te pasas de 90, ahí sí, ya estamos en,
ya una bandera roja,
entonces, pero fue a ver,
86, 87, es súper
aceptable, o sea,
cuantando bueno, entonces, ahí tenemos 70,
tenemos 79, ¿por qué
Random Forest baja?,
porque son datos no lineales,
entonces, Random Forest hubiera funcionado mejor,
hubiera predecido mejor,
y los datos hubieran sido lineales,
o sea, el tipo de datos hubieran sido lineales,
ahí lo tenés.
Ahí está el SBM, baja a 76,
75, reducción logística,
miren, 75,
Valle, 72,
ya está súper bajo,
y la SBM puede ser 0,
porque no me funcionó el modelo ahí,
entonces, puede ser
que a ustedes les pase esto, ¿verdad?, que hay modelos
que no les funcionen,
si interese ese modelo,
entonces, lo que hay que hacer es meter más datos,
meter más datos para poder probarlo,
entonces, ahí lo tenemos,
entonces, ahí lo tenemos, ¿cuál es el mejor?,
¿verdad?, ¿cuál es el mejor?, perdón,
¿cuál es el mejor aquí?, es 83,
83, con KNN,
bueno, ahí lo pongo, ¿verdad?,
el mejor modelo, porque más alto es
83, ahí lo tenemos, entonces, veamos
ahí, ¿verdad?, aquí,
el informe, ¿verdad?, aquí lo tenemos,
KNN, con 0.83,
con 0.82, ah, por cierto,
tenemos ahí que es la mejor discriminación,
es lento,
pero tiene una discriminación
muy buena, o sea,
está ahí,
está ahí, ¿verdad?,
tenemos el de
el xgboost , que tenemos 0.82
con 0.81, casi igual a KNN,
pero mucho más rápido, o sea, que tiene
un rendimiento similar, pero es más rápido,
por lo general, vamos a
preferir él,
¿por qué?, los rendimientos son similares,
¿ya?,
pero trabajamos más rápido,
y era a propósito, pero bueno, aquí el
correo, ¿qué importamos usted?, ¿un
segundo o menos?, estamos hablando de 10.000
registros, en un mundo real, donde tiene
100.000, 200.000, 300.000,
un millón de registros, imagínense ustedes, la
diferencia, la diferencia es ponencial,
¿verdad?, eso va a ser una escapajada,
entonces, posiblemente, aquí, para este caso
de uso, lo mejor, ¿verdad?, va a ser el
xgboost , ¿verdad?,
el Rando Forest, está allí,
¿verdad?, pero ya, ya
los niveles ya bajan bastante, ¿verdad?,
se parece, ¿verdad?, si está robusto,
confiable, ¿verdad?, y está cercano al top, ¿verdad?,
con los tres, está bien,
sigue estando muy dentro del barco, son
79.88, que está
casi 80, puede render 80,
entonces, podemos decir, ¿verdad?, que
tenemos, ¿verdad?, ahí, un resultado
bastante adecuado, y es muy
cercano al top,
aquí ya tenemos, ¿verdad?, el SBM,
¿verdad?, que tenemos 77, 76,
bueno, pero lento, o sea,
no, no es
la pena, el arbol de
decisión es 77, 75, ¿verdad?,
ya estamos hablando
de menos, de una precisión bastante
más baja, que está
muy cercana, incluso, la de 74,
regresión logística,
bueno,
75, 75, me parece,
me parece súper bajo,
y valles pues,
una precisión súper baja,
no vale la pena.
Con mi data, estos con mi datos,
con otros datos,
con otras data set, el orden
de estos modelos
no va a ser el mismo.
Bueno,
hay que revisarlo bien, entonces
aquí es donde nos vamos a enfocar entonces
para que nos pongamos las pilas
tenemos todo eso
ahí tienen verdad
ahí tienen el este
tienen el scripts de los modelos
entonces la idea no es que
en su presentación, la que van a hacer ustedes
la semana que viene
van a poner
los que van a poner
los que van a posar los todos, verdad?
van y no, y no necesitan
correr el script
ya pueden traer el script corrido
ya, pero obviamente hay que
correrlo primero en su máquina, verdad?
si, ya va a pasar los resultados
que explica cuál es el modelo que utilizaron
ponen una captura de la
de la configuración del modelo
verdad?
y los resultados
entonces
que me tienen que entregar a ustedes
o sea, en la presentación
entonces ustedes me van a entregar
por cada KPI
un solo modelo
cuatro
dijeron tres
tres y ni modo, si no les da
los corridos diez
y todos los tres no funcionan
se los sé
ojo con eso
y no se confundan
no se confundan todos
tienen que montar los diez
para poder saber
ahora
pueden hacer la gracia
van uno a uno
cuando compran con la cubota de los cuatro
ahí la paran
porque realmente
lo que voy a buscar son cuatro
y tres y ni modo
aquí estamos diez corridos
de los cuatro que había
de los diez corridos
si ustedes corren diez, solo están en tres
yo les acepto los tres
pero yo estoy buscando cuatros
si tienen cuatro no necesitan mostrarnos los diez
y si no les da ni tres
hay que hacer replanteo de KPI
y no vamos a permitir
que nos compramos con el mínimo
porque la idea aquí es que corramos
diez modelos
y que presentar solamente
cuatro de diez
entonces
pero como les digo
uno, dos, tres, cuatro
con toda la ganas de
la semana que viene
un modelo
un solo modelo para la semana que viene
eso es lo que el mínimo requiere
los resultados y el diseño del modelo
su, podemos usar los mismos
pero la idea es que sean distintos
y que vean la diferencia
que no les va a dar igual
yo les voy a decir claro
ustedes van con la xgboost que es el primero que se ve confiable pero
no les va a dar
resultado eficiente
en todo los data sets
no les va a dar
algo que ustedes tienen que tener
claro, los data sets
no van a poder
con el mismo data set
no van a poder obtener algún resultado
ya lo vienen aquí
si yo hubiera
si hubiera corrido yo aquí
Valles
no me hubiera servido
Valles no me hubiera servido
entonces hubiera tenido que inmediatamente
ahora
para datos no lineales
obviamente es que xgboost
es uno bastante bueno
en el sentido de
datos no lineales sencillos, rápidos
pero no ser mejor
en datos lineales
regresion logísticas le va a dar
el mejor resultado
tienen datos lineales
ninguno va hacer mejor que regresion logísticas
entonces
para que lo tengan en cuenta
no todos los datos
ni todos los data sets son iguales
por lo tanto no todos los modelos
que pueden implementar
de forma eficiencia
por eso que les digo
entonces les puede pasar este ejemplo
porque esto va a ser fácil
ustedes hacen el data set, lo cargan
corren y ahí les va a decir
y este mismo ejemplo les va a decir
que si funciona o no funciona
cuál es el que va a estar
este me dio
entonces este agarro
entonces yo vengo y digo
estos tres me dieron
los tres están buenos
entonces agarro cualquiera de los tres
y trabajo como uno
el modelo
que vamos a estar trabajando
para el trabajo es este
que es el del 03
que tiene la gráfica, que tiene la distribución
este es para el informe
este que vamos a utilizar
con el que están probando ustedes ahorita
entonces con el 03 corregido
con el 03 modelo corregido
y con el 06
es para que ustedes
hagan su data set, corren el 06
y escogen el que me sirve
agarro este y es el que pongo
en el informe
así es que vamos a trabajar
vamos corregido
ahora si
entendido
alcanzado
1 modelo
para la semana que viene
este informe
ya saben que aquí no van a venir a corregir codigo
para que lo tengan en cuenta , traen el informe
un informe rápido
obviamente
resumido
con su grafiquitas, estructurado
y explican el modelo
que fue lo que hicieron, como lo hicieron, cuantos semillas utilizaron
cuantos datos, cuantos conjuntades
fue el entrenamiento
cuantos conjuntades o porcetanjes fue el a testeo
cuantos o cuales fueron resultados
y explicar la transición del modelo
eso es todo
estamos chicos,bien nos vemos.
