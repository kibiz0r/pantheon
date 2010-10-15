using System;
using System.Linq;
namespace Pantheon
{
    public static class ViewFactory
    {
        public static T CreateView<T>() where T : IView, new()
        {
            Console.WriteLine("Creating View!");
            foreach (var requiresWorldAttribute in
                typeof(T).GetCustomAttributes(typeof(RequiresWorldAttribute), true).Cast<RequiresWorldAttribute>())
            {
                var createWorld = typeof(WorldFactory).GetMethod("CreateWorld").MakeGenericMethod(requiresWorldAttribute.WorldType);
                var world = createWorld.Invoke(null, new object[0]) as IWorld;
                Application.World = world;
            }
            var view = new T();
            Application.Views.Add(view);
            return view;
        }
    }
}
