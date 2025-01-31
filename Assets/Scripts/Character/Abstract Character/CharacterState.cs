public abstract class CharacterState
{
    protected Character Character;
    protected CharacterChangerRigidbody ChangerRigidbody;

    public CharacterState(Character character)
    {
        Character = character;
    }

    public void Inizialize()
    {
        ChangerRigidbody = new CharacterChangerRigidbody(Character);
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}