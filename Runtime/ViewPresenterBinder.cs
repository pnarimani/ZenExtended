using System;
using UnityEngine;

namespace ZenExtended
{
    public static class ViewPresenterBinder
    {
        public static void BindPresenter<TView, TPresenter>(this global::Zenject.DiContainer container) where TView : MonoBehaviour
        {
            container.Bind<TPresenter>()
                .FromMethod(context =>
                {
                    if (context.ObjectInstance == null)
                    {
                        throw new InvalidOperationException($"Cannot bind view presenter {typeof(TView)} and {typeof(TPresenter)} because context does not have an instance of {typeof(TView)}." +
                                                            "This seems to be a case of cyclic dependency. " +
                                                            $"Make sure {typeof(TView)} doesn't depend on {typeof(TPresenter)} in its constructor.");
                    }

                    // When view asks for presenter, we try to "Resolve" the presenter using the container.
                    // If we don't create another binding with WhenNotInjectedInto, It will be an infinite recursive function calls.
                    container.Bind<TPresenter>()
                        .WithId(context.ObjectInstance)
                        .FromNew()
                        .WithArguments(context.ObjectInstance)
                        .WhenNotInjectedInto<TView>();

                    var result = container.ResolveId<TPresenter>(context.ObjectInstance);

                    container.UnbindId<TPresenter>(context.ObjectInstance);

                    return result;
                })
                .AsTransient()
                // Note the WhenInjectedInto. This is very important to avoid infinite recursive function calls.
                .WhenInjectedInto<TView>();
        }
    }
}