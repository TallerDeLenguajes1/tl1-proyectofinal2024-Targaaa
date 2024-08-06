<section align='center'>
    <img src='https://imgsrv.crunchyroll.com/cdn-cgi/image/fit=contain,format=auto,quality=85,width=1200,height=675/catalog/crunchyroll/fdc0dff409f19dfd8ffff5037257ac98.jpe' border='0' alt='Portada Fate Zero'/>
</section>

<p align="center" style="margin: 10px 0;">
  <a href="#introducción">Introducción</a> •
  <a href="#historia">Historia</a> •
  <a href="#datos-técnicos">Datos técnicos</a> •
  <a href="#próximas-implementaciones">Próximas implementaciones</a> •
  <a href="#fuentes">Fuentes</a>
</p>

## Introducción
The Glory grail es un juego en donde participarás de una guerra en contra de poderosos rivales para hacerte con el santo grial. Deberas ganar en varias peleas por turnos y pasar por minijuegos de adivinar palabras para hacerte más fuerte.

## Historia
Este juego esta basado en una serie llamada Fate Zero. La historia se centra en la guerra del Santo Grial, una batalla de magos ocultada a los humanos en donde se invocan famosos  guerreros del pasado llamados servants para luchar al lado del mago que lo invocó, todos irán tras el Santo Grial, un artefacto místico que concede cualquier deseo.

## Datos técnicos

Si bien en la serie la guerra es todos contra todos, en este juego decido hacer de cuenta que se hace lo mismo que en la serie a través de combates "inesperados", pero en el fondo es un torneo donde al ser 16 personajes tendras que ganar 4 combates para terminar el juego. 
El ataque de los personajes se define de forma aleatoria pero dependiendo del nivel de rareza que tenga cada uno, ya que los personajes dentro de la serie tienen ciertas diferencias de fuerza, por ello con la api que utilicé  aproveche la característica de la rareza y les di un nuevo ataque a cada personaje.
Por ej: Los personajes con mayor rareza tendran un ataque de entre 35 y 40, y a partir de ahi iran disminuyendo los valores segun la rareza.
Ademas el ataque especial el cual hace justo el doble de daño, tiene mas probabiolidad de fallar que de acertar por lo que es peligroso usarlo.
Tambien tenemos el minijuego de wordle que ya todos conoceran, decidi agregarlo como innovacion y si adivinas la palabra correctamente obtendras un +5 en el ataque.
Para poder utilizar musica debes descargar una extension de windows en tu consola utilizando el comando: dotnet add package System.Windows.Extensions

### Próximas implementaciones
Algunas de las ideas que tuve para hacer este proyecto mas elaborado:

-Agregar un sistema de monedas como recompensa para usarla en la tienda.

-En la serie, los servants tienen un arma especial fantasma noble, que se desbloquea cumpliendo ciertos requisitos.

-Sistema de niveles que cambien directamente las caracteristicas del personaje.

-Por lo general, en la serie los servants suelen ocultar su identidad para que no tengan informacion sobre ellos en el combate, por lo que se me ocurrio dar pistas de cada personaje para ver si el usuario lo conoce y disminuir las estadisticas del rival

### Fuentes
Fuentes de informacion: https://atlasacademy.io/

Api utilizada: https://api.atlasacademy.io/export/NA/basic_servant.json

Pagina para el titulo: https://patorjk.com/software/taag/#p=display&f=Bloody&t=BakeOff

## Autor
Leandro Exequiel Targa Garcia
