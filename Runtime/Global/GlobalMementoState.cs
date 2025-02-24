using System;

namespace AceLand.MementoService.Global
{
    [Serializable]
    public abstract class GlobalMementoState
    {
        public virtual void OnBeforeStateSave()
        {
            // called before saving the state
            // update the state here
        }

        public virtual void OnStateBeforeUndo()
        {
            // called before state undo
            // Do stuff with current state
        }

        public virtual void OnStateAfterUndo()
        {
            // called after state undo
            // Do stuff with undo state
        }
        
        public virtual void OnStateBeforeRedo()
        {
            // called before state redo
            // Do stuff with current state
        }
        
        public virtual void OnStateAfterRedo()
        {
            // called after state redo
            // Do stuff with redo state
        }
    }
}