# Juego principal con el nivel 3 de Esther

Se sustituyó el tercer nivel del juego principal por la escena `Nivel3` de `JUEGOESTHER`, con sus recursos, scripts y referencias. Los ZIP originales no se modificaron.

## Cómo abrirlo

1. Guarda y cierra cualquier proyecto que tengas abierto en Unity.
2. Extrae el ZIP completo en una carpeta nueva. No trabajes dentro del ZIP y no reemplaces todavía tu proyecto original.
3. Abre Unity Hub y elige **Add / Añadir → Add project from disk / Añadir proyecto desde disco**.
4. Selecciona la carpeta **JUEGO_PRINCIPAL_NIVEL3_ESTHER**, la que contiene `Assets`, `Packages` y `ProjectSettings`.
5. Abre el proyecto con **Unity 6000.4.2f1**, la versión del juego principal. Espera a que termine de importar los recursos y compilar los scripts. La primera apertura tarda más porque el ZIP no incluye la caché `Library`.
6. En el panel Project, abre **Assets → Pantallas → Scenes → Menu** con doble clic y pulsa **Play**. Para probar directamente el nivel sustituido, abre **Nivel3**.

Si Unity Hub te pide instalar 6000.4.2f1, usa esa versión para la primera prueba. El proyecto Esther fue guardado con 6000.6.4f1, pero en esta integración se conservaron la versión y los paquetes del juego principal; no se realizó una actualización completa del juego.

## Qué se reemplazó

En el ZIP principal, el tercer nivel estaba guardado como **`Nivel4.unity`**, aunque el mapa lo buscaba como `Nivel3`. Ese archivo se eliminó y se sustituyó por:

`Assets/Pantallas/Scenes/Nivel3.unity`

Se conserva el identificador de la escena y se actualiza su ruta en **EditorBuildSettings**, de modo que el tercer punto del mapa pueda cargar `Nivel3`.

Los scripts importados están en **`Assets/Nivel3Esther/Scripts`**, dentro del espacio de nombres `Nivel3Esther`. Sus recursos están en **`Assets/Nivel3Esther/Recursos`**. Se asignaron identificadores nuevos a esos recursos para no sobrescribir las versiones que utilizan los otros niveles.

Se eliminaron la escena antigua, siete scripts exclusivos del antiguo nivel y dos imágenes utilizadas solo por ese nivel. Cada uno se eliminó junto con su `.meta`. Se conservaron los recursos compartidos con las demás escenas, incluidas las copias de recuperación existentes. No borres recursos compartidos solo porque su nombre mencione el nivel 3.

Las escenas **Menu, Mapa, Nivel 1, Nivel 2, creditos y gameover**, los scripts que todavía usan y los ajustes/paquetes del principal permanecen sin sobrescribir. El `.gitignore` se amplió para excluir archivos generados por Unity y los editores de código.

## Ajustes necesarios del nivel importado

Además de copiar la escena y sus dependencias, se corrigieron conexiones incompletas que ya existían en el proyecto Esther:

- Se conectó la detección de suelo del jugador al objeto `Detector` existente y se evita contar el propio collider del jugador como suelo. El movimiento se detiene cuando una pregunta pausa el juego.
- Se retiró un componente `Piedra` duplicado sin referencias de UI.
- El botón **Continuar** de la explicación apunta ahora al componente del panel, no a la piedra que se destruye. Se añadió el método público `Cerrar`, y la barra espaciadora también cierra la explicación.
- Se incluyó el controlador de puntuación que los scripts llamaban pero no estaba conectado en la escena. La primera, segunda y tercera piedra conceden 100, 200 y 300 puntos respectivamente al completar sus ejercicios, sin contar dos veces la misma piedra. Se usa el texto de puntos existente.
- El efecto de las estrellas utiliza tiempo no escalado, para poder animarse durante las preguntas.
- Se adaptó una llamada `FindObjectsByType` a la versión del juego principal.
- Se actualizaron los nombres de archivo de los scripts importados, los identificadores de clase y los tipos de los eventos de los botones para que coincidan con las clases aisladas.
- El portal responde al jugador y reanuda el tiempo antes de regresar al mapa.

Se mantuvieron la distribución, las imágenes y las preguntas del nivel Esther. No se añadió una pantalla de derrota nueva: se conserva el reinicio por caída del jugador que contiene ese nivel.

## Prueba antes de reemplazar tu copia de trabajo

1. Abre `Menu` y comprueba que puedes llegar al mapa.
2. Desde el mapa, entra al tercer nivel.
3. Comprueba el movimiento con las flechas y el salto con **Z**.
4. Responde las preguntas de las tres piedras. Verifica que los botones A/B/C funcionan, que el juego se reanuda y que se actualizan los puntos.
5. Después de la primera piedra, cierra la explicación con **Continuar** y también prueba la barra espaciadora.
6. Llega al portal y verifica que vuelves al mapa. Prueba también el reinicio por caída.
7. Revisa la pestaña **Console**. Si aparecen errores rojos, copia su texto o envía una captura.
8. Prueba brevemente los niveles 1 y 2 antes de usar esta copia como principal.

## Qué se pudo verificar

Se revisaron estáticamente los 49 archivos C# del proyecto, la sintaxis YAML de la escena, los GUID de recursos y scripts, las referencias internas, los métodos de los botones y la lista de escenas de compilación. No se encontraron errores en esas comprobaciones. También se compararon los archivos conservados con el proyecto original para confirmar que no se sobrescribieron otros niveles.

**No se ejecutó Unity Editor ni se realizó una prueba de jugabilidad o una compilación del juego en este entorno.** La comprobación estática no garantiza por sí sola que todo se vea y funcione correctamente en el editor; sigue las pruebas anteriores antes de sustituir tu copia original.

## GitHub

Este ZIP no contiene `.git` y no se subió a GitHub. Primero pruébalo en una carpeta nueva. Si está correcto, podrás incorporar los cambios a tu copia conectada a GitHub Desktop y hacer **Commit → Push origin**. No borres ni reemplaces la carpeta `.git` de tu repositorio existente.
