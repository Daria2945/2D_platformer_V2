public abstract class CharacterState
{
    protected Character Character;
    protected CharacterChangerSpeed ChangerSpeed;

    public CharacterState(Character character)
    {
        Character = character;
    }

    public void Inizialize()
    {
        ChangerSpeed = new CharacterChangerSpeed(Character);
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}