using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TGC.MonoGame.TP.Zero;

/// <summary>
///     Clase principal del juego.
/// </summary>
public class TGCGame : Game
{
    public const string ContentFolder3D = "Models/";
    public const string ContentFolderEffects = "Effects/";
    public const string ContentFolderMusic = "Music/";
    public const string ContentFolderSounds = "Sounds/";
    public const string ContentFolderSpriteFonts = "SpriteFonts/";
    public const string ContentFolderTextures = "Textures/";

    private Model _carModel;
    private Matrix _carWorld;
    private CityScene _city;
    private FollowCamera _followCamera;

    private readonly GraphicsDeviceManager _graphics;

    /// <summary>
    ///     Constructor del juego.
    /// </summary>
    public TGCGame()
    {
        // Se encarga de la configuracion y administracion del Graphics Device.
        _graphics = new GraphicsDeviceManager(this);

        // Carpeta donde estan los recursos que vamos a usar.
        Content.RootDirectory = "Content";

        // Hace que el mouse sea visible.
        IsMouseVisible = true;
    }

    /// <summary>
    ///     Llamada una vez en la inicializacion de la aplicacion.
    ///     Escribir aca todo el codigo de inicializacion: Todo lo que debe estar precalculado para la aplicacion.
    /// </summary>
    protected override void Initialize()
    {
        // Enciendo Back-Face culling.
        // Configuro Blend State a Opaco.
        var rasterizerState = new RasterizerState();
        rasterizerState.CullMode = CullMode.CullCounterClockwiseFace;
        GraphicsDevice.RasterizerState = rasterizerState;
        GraphicsDevice.BlendState = BlendState.Opaque;

        // Configuro las dimensiones de la pantalla.
        _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - 100;
        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - 100;
        _graphics.ApplyChanges();

        // Creo una camara para seguir a nuestro auto.
        _followCamera = new FollowCamera(GraphicsDevice.Viewport.AspectRatio);

        // Configuro la matriz de mundo del auto.
        _carWorld = Matrix.Identity;

        base.Initialize();
    }

    /// <summary>
    ///     Llamada una sola vez durante la inicializacion de la aplicacion, luego de Initialize, y una vez que fue configurado
    ///     GraphicsDevice.
    ///     Debe ser usada para cargar los recursos y otros elementos del contenido.
    /// </summary>
    protected override void LoadContent()
    {
        // Creo la escena de la ciudad.
        _city = new CityScene(Content, ContentFolder3D, ContentFolderEffects);

        // La carga de contenido debe ser realizada aca.

        base.LoadContent();
    }

    /// <summary>
    ///     Es llamada N veces por segundo. Generalmente 60 veces pero puede ser configurado.
    ///     La logica general debe ser escrita aca, junto al procesamiento de mouse/teclas.
    /// </summary>
    protected override void Update(GameTime gameTime)
    {
        // Capturo el estado del teclado.
        var keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.Escape))
        {
            // Salgo del juego.
            Exit();
        }

        // La logica debe ir aca.

        // Actualizo la camara, enviandole la matriz de mundo del auto.
        _followCamera.Update(gameTime, _carWorld);

        base.Update(gameTime);
    }
    
    /// <summary>
    ///     Llamada para cada frame.
    ///     La logica de dibujo debe ir aca.
    /// </summary>
    protected override void Draw(GameTime gameTime)
    {
        // Limpio la pantalla.
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Dibujo la ciudad.
        _city.Draw(gameTime, _followCamera.View, _followCamera.Projection);

        // El dibujo del auto debe ir aca.

        base.Draw(gameTime);
    }

    /// <summary>
    ///     Libero los recursos cargados.
    /// </summary>
    protected override void UnloadContent()
    {
        // Libero los recursos cargados dessde Content Manager.
        Content.Unload();

        base.UnloadContent();
    }
}