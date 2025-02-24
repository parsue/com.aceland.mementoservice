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

        public virtual void OnStateUndo()
        {
            // called before state undo
            // update objects with old state here
        }

        public virtual void OnStateRedo()
        {
            // called after state redo
            // update objects with new state here
        }
    }
}