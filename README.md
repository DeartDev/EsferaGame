# EsferaGame

EsferaGame es un mini juego 3D hecho en **Unity** donde el jugador controla una esfera que avanza automáticamente por una pista, evita obstáculos móviles y llega a una meta para pasar a la siguiente escena.

El proyecto está pensado como un prototipo sencillo de aprendizaje: combina física con `Rigidbody`, colisiones, reinicio de nivel, cambio de escena, materiales, UI básica y animaciones de obstáculos.

## Tabla de contenido

- [Características](#características)
- [Gameplay](#gameplay)
- [Controles](#controles)
- [Requisitos](#requisitos)
- [Cómo abrir el proyecto](#cómo-abrir-el-proyecto)
- [Cómo ejecutar el juego](#cómo-ejecutar-el-juego)
- [Cómo generar una build](#cómo-generar-una-build)
- [Estructura del proyecto](#estructura-del-proyecto)
- [Escenas](#escenas)
- [Scripts principales](#scripts-principales)
- [Paquetes de Unity](#paquetes-de-unity)
- [Notas de desarrollo](#notas-de-desarrollo)
- [Solución de problemas](#solución-de-problemas)
- [Licencia](#licencia)

## Características

- Movimiento automático de la esfera hacia adelante.
- Movimiento lateral controlado por teclado.
- Obstáculos con colisión que reinician la escena actual.
- Zona de meta que carga la siguiente escena del Build Settings.
- Escena principal con pista, paredes, cámara, luz, obstáculos y UI de puntaje.
- Animaciones en bucle para obstáculos.
- Configuración base de Unity con soporte para UI, TextMeshPro, Timeline, Visual Scripting y Test Framework.

## Gameplay

1. La esfera comienza al inicio de la pista.
2. Avanza automáticamente hacia adelante usando fuerzas físicas.
3. El jugador debe moverse lateralmente para esquivar obstáculos.
4. Si la esfera choca contra un obstáculo o pared con el script de obstáculo, el nivel se reinicia.
5. Si la esfera llega a la meta, Unity carga la siguiente escena configurada.

## Controles

| Acción | Teclas |
| --- | --- |
| Mover a la derecha | `D` o `S` |
| Mover a la izquierda | `A` o `W` |

> Nota: los controles están definidos directamente en `Assets/Scripts/playerMove.cs`. Aunque el proyecto conserva los ejes clásicos de Unity (`Horizontal`, `Vertical`, etc.), el script usa `Input.GetKey(...)`.

## Requisitos

- **Unity Editor 2021.3.20f1** o una versión compatible de Unity 2021 LTS.
- Unity Hub recomendado para abrir el proyecto.
- Sistema con soporte para proyectos 3D de Unity.

La versión exacta registrada está en:

```text
ProjectSettings/ProjectVersion.txt
```

## Cómo abrir el proyecto

1. Clona o descarga este repositorio.
2. Abre **Unity Hub**.
3. Selecciona **Open / Add project from disk**.
4. Elige la carpeta raíz del proyecto: `EsferaGame`.
5. Abre el proyecto con **Unity 2021.3.20f1** o una versión compatible.
6. Espera a que Unity restaure la carpeta `Library/` y compile los scripts.

## Cómo ejecutar el juego

1. Abre la escena principal:

   ```text
   Assets/Scenes/Main.unity
   ```

2. Presiona **Play** en el Editor de Unity.
3. Controla la esfera con las teclas indicadas en [Controles](#controles).

## Cómo generar una build

1. En Unity, abre **File > Build Settings...**.
2. Verifica que estas escenas estén incluidas y habilitadas:

   ```text
   Assets/Scenes/Main.unity
   Assets/Scenes/SampleScene.unity
   ```

3. Selecciona la plataforma de destino.
4. Haz clic en **Build** o **Build And Run**.

El repositorio ignora carpetas de compilación comunes como `Build/`, `Builds/`, `Library/`, `Temp/`, `Obj/` y `Logs/`, por lo que las builds generadas no deberían subirse al control de versiones.

## Estructura del proyecto

```text
EsferaGame/
├── Assets/
│   ├── Material/          # Materiales usados por la esfera y obstáculos
│   ├── Scenes/            # Escenas del juego
│   ├── Scripts/           # Scripts C# de movimiento, obstáculos y victoria
│   └── animación/         # Clips y controladores de animación de obstáculos
├── Packages/
│   ├── manifest.json      # Dependencias del proyecto Unity
│   └── packages-lock.json # Bloqueo de versiones de paquetes
├── ProjectSettings/       # Configuración del proyecto Unity
├── .gitignore             # Reglas de exclusión para Unity y archivos generados
├── .gitattributes
└── README.md
```

## Escenas

| Escena | Ruta | Descripción |
| --- | --- | --- |
| Main | `Assets/Scenes/Main.unity` | Nivel principal con esfera, pista, obstáculos, paredes, cámara, UI y meta. |
| SampleScene | `Assets/Scenes/SampleScene.unity` | Escena incluida después de `Main`; funciona como escena siguiente al llegar a la meta. |

## Scripts principales

| Script | Ruta | Responsabilidad |
| --- | --- | --- |
| `playerMove` | `Assets/Scripts/playerMove.cs` | Aplica fuerza hacia adelante a la esfera y permite desplazamiento lateral con teclado. |
| `obstaculo` | `Assets/Scripts/obstaculo.cs` | Detecta colisiones con objetos etiquetados como `Player` y reinicia la escena actual. |
| `victoria` | `Assets/Scripts/victoria.cs` | Detecta colisión con el jugador y carga la siguiente escena del Build Settings. |

### Detalles de implementación

- La esfera debe tener la etiqueta `Player` para que los scripts de obstáculos y meta funcionen correctamente.
- `playerMove` requiere una referencia a un `Rigidbody` asignada desde el Inspector.
- En la escena `Main`, los valores configurados para movimiento son:
  - `velocidad`: `300`
  - `desplazamiento`: `700`
- El campo de UI `puntaje` existe en el script, pero la actualización del texto está comentada actualmente.
- `victoria` usa `SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)`, por lo que debe existir una escena posterior habilitada en Build Settings.

## Paquetes de Unity

El proyecto usa paquetes estándar de Unity definidos en `Packages/manifest.json`, entre ellos:

- `com.unity.ugui` para UI.
- `com.unity.textmeshpro` para texto avanzado.
- `com.unity.timeline` para Timeline.
- `com.unity.visualscripting` para Visual Scripting.
- `com.unity.test-framework` para pruebas de Unity.
- Integraciones de IDE para Rider, Visual Studio y VS Code.

## Notas de desarrollo

- El proyecto usa el sistema de entrada clásico de Unity (`activeInputHandler: 0`).
- Los nombres de algunas clases están en minúscula (`playerMove`, `obstaculo`, `victoria`), por lo que conviene mantener los nombres de archivo sincronizados si se refactorizan.
- La carpeta `Assets/animación/` contiene assets con caracteres especiales; si trabajas en sistemas distintos, asegúrate de conservar la codificación de nombres de archivo.
- Actualmente no hay pruebas automatizadas ni builds precompiladas incluidas en el repositorio.

## Solución de problemas

### La esfera no se mueve

- Verifica que el objeto de la esfera tenga un `Rigidbody`.
- Revisa que el campo `rb` del componente `playerMove` esté asignado en el Inspector.
- Confirma que el script `playerMove` esté activo.

### El nivel no se reinicia al chocar

- Verifica que la esfera tenga la etiqueta `Player`.
- Confirma que el obstáculo tenga collider y el script `obstaculo`.
- Asegúrate de que la colisión física pueda ocurrir entre ambos objetos.

### La meta no carga la siguiente escena

- Verifica que la meta tenga el script `victoria`.
- Confirma que `Assets/Scenes/SampleScene.unity` esté habilitada después de `Main` en Build Settings.
- Revisa que la esfera tenga la etiqueta `Player`.

### Unity muestra errores al abrir

- Usa Unity 2021.3.20f1 o una versión compatible de Unity 2021 LTS.
- Elimina carpetas generadas (`Library/`, `Temp/`, `Obj/`) y vuelve a abrir el proyecto si la importación queda corrupta.
- Espera a que Unity restaure los paquetes definidos en `Packages/manifest.json`.

## Licencia

Este repositorio no incluye un archivo de licencia. Agrega una licencia explícita antes de distribuir, publicar o reutilizar el proyecto fuera de su contexto original.
