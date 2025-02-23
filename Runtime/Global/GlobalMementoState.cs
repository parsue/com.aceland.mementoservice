using System;

namespace AceLand.MementoService.Global
{
    [Serializable]
    public abstract class GlobalMementoState
    {
        public virtual void OnBeforeSave()
        {
            // called before saving the state
            // update the data here
        }

        public virtual void OnStateChanged()
        {
            // called after state undo / redo
            // update objects with new data here
        }
    }
}