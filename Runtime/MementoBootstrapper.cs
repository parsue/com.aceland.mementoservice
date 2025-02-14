using UnityEngine;

namespace AceLand.MementoService
{
    internal static class MementoBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Initialization()
        {
            Memento.Initialization();
        }
    }
}