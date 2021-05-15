# ZenExtended
Utility classes for Zenject library to remove some of boilerplate code.

# Table of Content
- [Mono Spawnable](#monospawnable)
- [Spawnable](#spawnable)
- [Animated Panel](#animatedpanel)
- [View Presenter Binder](#viewpresenterbinder)

## Installation
Add `https://github.com/mnarimani/Audoty.git` as git url package in Package Manager window.

Or add this line to your `manifest.json` file:  
`"com.mnarimani.zenextended": "https://github.com/mnarimani/ZenExtended.git"`

### Requirements
`ZenExtended` requires [Zenject](https://github.com/mnarimani/Extenject.git) library. It also has optional integrations with [UniTask](https://github.com/Cysharp/UniTask), [OpenJuice](https://github.com/yoyo-studio/openjuice), [Naughty Attributes](https://github.com/dbrizov/NaughtyAttributes) and [Odin Inspector](https://odininspector.com).

You can install everything with adding following lines to `manifest.json`:
```
"com.mnarimani.zenextended": "https://github.com/mnarimani/ZenExtended.git",
"com.svermeulen.extenject": "https://github.com/mnarimani/Extenject.git?path=UnityProject/Assets/Plugins/Zenject#no_samples",
"com.yoyo-studio.openjuice": "https://github.com/yoyo-studio/openjuice.git?path=Assets/YoYoStudio/OpenJuice",
"com.cysharp.unitask": "https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask",
"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm" 
```

## Classes
### MonoSpawnable
This is a base class used for all MonoBehaviours that get spawned/created in runtime.  
This class has nested `Factory` class and it also implements all the required methods for Pooling in Zenject.  
Your main class (Facade pattern in SubContainers or the main component on a prefab) should inherit from this class.  
There are some methods that you can override when inheriting from this class:

```c#
// ONLY WORKS WHEN OBJECT IS POOLED. Gets invoked when object gets spawned from pool 
protected virtual void OnPoolSpawned();
// Other variations when inherting from variations of MonoSpawnable:
// void OnPoolSpawned(TParam1 param1)
// void OnPoolSpawned(TParam1 param1, TParam2 param2)
// void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3)
// void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)

// ONLY WORKS WHEN OBJECT IS POOLED. Gets invoked when object gets despawned back to pool
protected virtual void OnPoolDespawned();

// Use this method to destroy the object. Works regardless of pooling. 
public virtual void Dispose();
```

**It is good practice to always call `Dispose` to destroy an object regardless of pooling.**

#### Example
This is an example of a pooled object that is using `MonoSpawnable`:
```c#
// Parameters to pass to Bullet
public struct BulletData
{
    public string Weapon;
    public Vector3 Start;
    public Vector3 Direction;
    public float Velocity;
    public float Range;
}

// This is a bullet class that is attached to a prefab
public class Bullet : MonoSpawnable<BulletData, Bullet>
{
    // Remember, This method only gets called when the object is pooled. 
    // If you want to get parameters that was passed to the factory in a non-pooled object, use normal injection (with [Inject] attribute). 
    protected override void OnPoolSpawned(BulletData data)
    {
        // Use BulletData that was passed to the factory class
    }
}

// In installer:
// Pool the bullets
Container.BindFactory<BulletData, Bullet, Bullet.Factory>()
    .FromMonoPoolableMemoryPool(x => x
        .WithInitialSize(400)
        .ExpandByDoubling()
        .FromComponentInNewPrefab(Bullet)
        .UnderTransformGroup("Bullet Pool")
    );

// When spawning bullet:
// Get _bulletFactory through injection
Bullet.Factory _bulletFactory;

var bulletData = new BulletData
{
    Start = _shootPoint.Point,
    Direction = direction,
    Range = CurrentWeaponDef.Range,
    Velocity = CurrentWeaponDef.ProjectileVelocity,
    Weapon = CurrentWeaponDef.Id
};

_bulletFactory.Create(bulletData);
```

This is an example of a non-pooled object using `MonoSpawnable`:

```c#
// Data to pass to factory
public struct UserId
{
    [HideLabel]
    public string Value;
    public UserId(string value)
    {
        Value = value;
    }
 }
 
public class Player : MonoSpawnable<UserId, Player>
{
    public UserId UserId { get; private set; }
    
    // When the object is not pooled, We get runtime parameters using normal injection.
    // Remember, when object is pooled, use OnPoolSpawned methods
    [Inject]
    public void Init(UserId userId)
    {
        UserId = userId;
    }
}

// In installer:
// non-pooled
Container.BindFactory<UserId, Player, Player.Factory>()
                .FromComponentInNewPrefab(PlayerPrefab);

// Spawning player:
// Get factory through injection
Player.Factory _factory;

Player player = _factory.Create(new UserId("player1"));
```

### Spawnable
This is a base class used for all non-MonoBehaviours that get spawned/created in runtime.  
Everything in this class is similar to `MonoSpawnable` class.  
There are some methods that you can override when inheriting from this class:

```c#
// ONLY WORKS WHEN OBJECT IS POOLED. Gets invoked when object gets spawned from pool 
protected virtual void OnPoolSpawned();
// Other variations when inherting from variations of MonoSpawnable:
// void OnPoolSpawned(TParam1 param1)
// void OnPoolSpawned(TParam1 param1, TParam2 param2)
// void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3)
// void OnPoolSpawned(TParam1 param1, TParam2 param2, TParam3 param3, TParam4 param4)

// ONLY WORKS WHEN OBJECT IS POOLED. Gets invoked when object gets despawned back to pool
protected virtual void OnPoolDespawned();

// Use this method to despawned a pooled object. This method does nothing if object is not pooled. (C# POCOs get garbage collected)  
public virtual void Dispose();
```

**It is good practice to always call `Dispose` to destroy an object regardless of pooling.**

#### Example


### AnimatedPanel
Animated panels are available if you have `OpenJuice` and `UniTask` libraries.  
`AnimatedPanel` will be disabled if you don't have either of those libraries.  
You can install these libraries from here:  
* [Install Open Juice](https://github.com/yoyo-studio/openjuice#installation)
* [Install UniTask](https://github.com/Cysharp/UniTask#install-via-git-url)

`AnimatedPanel` is a base class that inherits from `MonoSpawnable`.  
It adds support to play Intro and Outro animations using `OpenJuice` transitions for an UI panel.

This is the API of `AnimatedPanel`:
```c#
// If you want to do more initialization logic in Awake, override this method.
// Don't forget to call base.Awake() if you override this method. 
protected virtual void Awake();

// If you want to do more initialization logic in OnEnable, override this method.
// Don't forget to call base.OnEnable() if you override this method.
protected virtual void OnEnable();

// Closes the animated panel with playing outro animations. This has the same functionality has pressing the close button.
// If you don't want to play outro animations, use Dispose().
public void CloseAnimated();

// Waits until the close button is clicked (or CloseAnimated() is called).
public UniTask WaitUntilCloseClicked();
```

You can use `AnimatedPanel` in two ways:  
* Inheritance
* Composition

#### Inheritance
Your main class for that panel should inherit from `AnimatedPanel` (`AnimatedPanel` has generic variations that support runtime parameters).
Closing the panel is handled by`AnimatedPanel`. It defines a field named "Close Button". Drag and drop your Close button to this field. 




#### Composition
If you don't want to inherit from `AnimatedPanel`,You need to create a sub-container.

1. You need to Attach `GameObjectContext` to the root of your prefab/gameobject.
2. Add `AnimatedPanel`(non-generic) to your prefab/gameobject.
3. Install `AnimatedPanel` in your installer
4. In your main class (which inherits from `MonoSpawnable`), listen to the `DisposeRequested` event of `AnimatedPanel`.
5. When the event is called, call the `Dispose()` method of the base class `MonoSpawnable`.

#### Example


### ViewPresenterBinder
When working with **MVP** pattern, often times your `View` creates the `Presenter` and your `Presenter` gets a reference to the `View` using an interface.

This is a very small example of this pattern:

```c#
public interface IView
{
    string InputText { get; }
}

public class View : MonoBehaviour, IView
{
    public Button Confirm;
    
    private Presenter _presenter;
    
    public string InputText => "In real example you connect this to UI";

    private void Awake()
    {
        // We don't want this. Since it is violation of dependency injection patterns.
        // View should get presenter using injection.
        _presenter = new Presenter(this);
        Confirm.onClick.AddListener(_presenter.OnConfirmClicked);
    }
}

public class Presenter
{
    private readonly IView _view;
    
    // We only get an interface to the view. We can mock this later for Unit Tests
    public Presenter(IView view)
    {
        _view = view;
    }
    
    public void OnConfirmClicked()
    {
        // All the logic is handled in Presenter
        
        string input = _view.InputText;
        // Validate input and do whatever
    }
}
```

As you can see, `View` creates its `Presenter` which is not good. If we want to convert this example to use dependency injection, we need to convert our code to something like this:

```c#
public interface IView
{
    string InputText { get; }
}

public class View : MonoBehaviour, IView
{
    public Button Confirm;
    
    private Presenter _presenter;
    
    public string InputText => "In real example you connect this to UI";
    
    [Inject]
    public void Init(Presenter presenter)
    {
        // Get presenter using dependency injection
        _presenter = presenter;
    }
    
    private void Awake()
    {
        Confirm.onClick.AddListener(_presenter.OnConfirmClicked);
    }
}

public class Presenter
{
    private readonly IView _view;
    
    // We only get an interface to the view. We can mock this later for Unit Tests
    public Presenter(IView view)
    {
        _view = view;
    }
    
    public void OnConfirmClicked()
    {
        // All the logic is handled in Presenter
        
        string input = _view.InputText;
        // Validate input and do whatever
    }
}
```

Now there's another problem. Since we need one unique presenter for each view of same type (for example, Multiple instances of `View` should receive multiple, unique, instances of `Presenter`), We need to use `SubContainer` feature of Zenject.
SubContainers come with performance cost. Also, creating a SubContainer and writing an installer for each View-Presenter pair is not ideal.   
Here `ViewPresenterBinder` comes to the rescue. `ViewPresenterBinder` can create bindings between a View-Presenter pair without creating a SubContainer.  
What you need to do is to call extension method `BindPresenter` on `DiContainer` instance in the same context which your `View` is present.

For example, If your view is located in a scene, you need to call `BindPresenter` in a scene installer (Installer which is executed on SceneContext). If your `View` is a prefab and the factory binding is written in a project installer (installer which is executed on Project Context), You need to call `BindPresenter` in your project installer. 

### Example

For the first example, lets assume you have a view called `CardView` in the scene. In your scene installer (the installer that runs on `SceneContext`), you can bind Presenter pair like this:

```c#
public interface ICardView
{
}

public class CardView : MonoBehaviour, ICardView
{
    private CardPresenter _presenter;
    
    [Inject]
    public void Init(CardPresenter presenter)
    {
        _presenter = presenter;
    }
}

public class CardPresenter
{
    private readonly ICardView _view;
    public CardPresenter(ICardView view)
    {
        _view = view;
    }
}

public class MySceneInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        // There is no need to bind CardView here. The instance of CardView which requests for CardPresenter will be injected to CardPresenter.
    
        // Here we bind the presenter.
        // With this line of code, For every instance of CardView in the scene, a new CardPresenter will be created and injected into it. 
        Container.BindPresenter<CardView, CardPresenter>();
    }
}
```

The second example is for when your object/view is created using a factory. Lets say you have an enemy prefab which has `EnemyView` script on it.
```c#
public interface IEnemyView
{
}

// We don't request for Presenter in MonoSpawnable/Factory. It will be injected automatically.
public class EnemyView : MonoSpawnable<EnemyView>, IEnemyView
{
    private EnemyPresenter _presenter;
    
    [Inject]
    public void Init(EnemyPresenter presenter)
    {
        _presenter = presenter;
    }
}

public class EnemyPresenter
{
    private readonly IEnemyView _view;
    public EnemyPresenter(IEnemyView view)
    {
        _view = view;
    }
}

public class MySceneInstaller : MonoInstaller
{
    public EnemyView EnemyPrefab;
    
    public override void InstallBindings()
    {
        // Since EnemyView needs to be created in runtime, we bind the factory for it.
        Container.BindFactory<EnemyView, EnemyView.Factory>().FromComponentInNewPrefab(EnemyPrefab);
    
        // Binding for presenter stays the same. 
        // For every enemy that is spawned, a new enemy presenter is created and injected into that instance. 
        Container.BindPresenter<EnemyView, EnemyPresenter>();
    }
}
```

**It is very important that `View` doesn't request for `Presenter` in its constructor. Otherwise it creates a cyclic dependency which is impossible to resolve.  
In all these examples, `View` requests for `Presenter` in an injected method (`Init`)**