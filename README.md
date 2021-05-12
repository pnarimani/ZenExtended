# ZenExtended
Utility classes for Zenject library to remove some of boilerplate code.

## MonoSpawnable
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

#### **It is good practice to always call `Dispose` to destroy an object regardless of pooling.**

### Example
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

## Spawnable
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

#### **It is good practice to always call `Dispose` to destroy an object regardless of pooling.**

### Example


## AnimatedPanel
Animated panels are available if you have `OpenJuice` and `UniTask` libraries.  
`AnimatedPanel` will be disabled if you don't have either of those libraries.  
You can install these libraries from here:


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
### Inheritance
Your main class for that panel should inherit from `AnimatedPanel` (`AnimatedPanel` has generic variations that support runtime parameters).
Closing the panel is handled by`AnimatedPanel`. It defines a field named "Close Button". Drag and drop your Close button to this field. 




### Composition
If you don't want to inherit from `AnimatedPanel`,You need to create a sub-container.

1. You need to Attach `GameObjectContext` to the root of your prefab/gameobject.
2. Add `AnimatedPanel`(non-generic) to your prefab/gameobject.
3. Install `AnimatedPanel` in your installer
4. In your main class (which inherits from `MonoSpawnable`), listen to the `DisposeRequested` event of `AnimatedPanel`.
5. When the event is called, call the `Dispose()` method of the base class `MonoSpawnable`.

### Example