# TGC - MonoGame - TP Zero
[![BCH compliance](https://bettercodehub.com/edge/badge/tgc-utn/tgc-monogame-tp?branch=master)](https://bettercodehub.com/)
[![GitHub license](https://img.shields.io/github/license/tgc-utn/tgc-monogame-tp.svg)](https://github.com/tgc-utn/tgc-monogame-tp/blob/master/LICENSE)

[#BuiltWithMonoGame](http://www.monogame.net) and [.NET Core](https://dotnet.microsoft.com)

# Descripción
Trabajo práctico cero de la asignatura electiva [Técnicas de Gráficos por Computadora](http://tgc-utn.github.io/) (TGC)

## Consigna
* Cargar el modelo del auto y renderizarlo
* Implementar movimientos para el auto
  * <kbd>w</kbd> y <kbd>s</kbd> para acelerar y desacelerar
  * <kbd>a</kbd> y <kbd>d</kbd> para girar el auto

Bonus:
* Movimiento con aceleracion y velocidad por separado
* <kbd>espacio</kbd> para saltar

__No es necesario modificar la c&aacute;mara, la misma apunta al costado de la matriz CarWorld de manera intencional.__

## Requisitos tecnicos
* [.NET Core SDK](https://docs.microsoft.com/dotnet/core/install/sdk)
* El IDE que prefieran:
  * [Visual Studio Code](https://code.visualstudio.com) y [HLSL extension](https://marketplace.visualstudio.com/items?itemName=TimGJones.hlsltools)
  * [Visual Studio](https://visualstudio.microsoft.com/es/vs) y [HLSL extension](https://marketplace.visualstudio.com/items?itemName=TimGJones.HLSLToolsforVisualStudio)
  * [Visual Studio for Mac](https://visualstudio.microsoft.com/es/vs/mac)
  * [Rider](https://www.jetbrains.com/rider)
* [MGCB Editor](https://docs.monogame.net/articles/tools/mgcb_editor.html)
* [MGFXC](https://docs.monogame.net/articles/tools/mgfxc.html)
* [MonoGame.Framework.DesktopGL](https://www.nuget.org/packages/MonoGame.Framework.DesktopGL) (Se baja automáticamente al hacer build por primera vez)

Más información sobre [.NET Core CLI Tools telemetry](https://aka.ms/dotnet-cli-telemetry) y [Visual Studio Code telemetry](https://code.visualstudio.com/docs/getstarted/telemetry) ya que vienen activas por defecto.

## Configuración del entorno de desarrollo
 * [Windows 10](https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_windows.html)
   * Se puede usar Visual Studio Code o Rider. La documentación oficial solo explica Visual Studio, pero cada uno puede configurar el que les sea más cómodo.
 * [Linux (probado en Ubuntu 20.04)](https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_ubuntu.html)
 * [Mac (probado en macOS Big Sur)](https://docs.monogame.net/articles/getting_started/1_setting_up_your_development_environment_macos.html)

Afuera del mundo Windows, vas a necesitar la ayudar de [Wine](https://www.winehq.org) para los shaders, por lo menos por [ahora](https://github.com/MonoGame/MonoGame/issues/2167).

Los recursos usados se almacenan utilizando [Git LFS](https://git-lfs.github.com), con lo cual antes de clonar el repositorio les conviene tenerlo instalado así es automático el pull o si ya lo tienen pueden hacer ```git lfs pull```.

