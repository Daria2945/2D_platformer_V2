public abstract class CharacterState
{
    protected StateMachine StateMachine;
    protected CharacterChangerSpeed ChangerSpeed;

    private Character _character;

    public CharacterState(StateMachine stateMachine, Character character)
    {
        StateMachine = stateMachine;
        _character = character;
    }

    public void Inizialize()
    {
        ChangerSpeed = new CharacterChangerSpeed(_character);
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}