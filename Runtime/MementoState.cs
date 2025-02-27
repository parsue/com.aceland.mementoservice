namespace AceLand.MementoService
{
    public abstract class MementoState : IMementoState
    {
        public virtual IMementoState Clone() => (IMementoState)MemberwiseClone();
    }
}