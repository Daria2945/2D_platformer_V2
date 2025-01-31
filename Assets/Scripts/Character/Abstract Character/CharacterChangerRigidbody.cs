using UnityEngine;

public class CharacterChangerRigidbody
{
    private Character _character;

    public CharacterChangerRigidbody(Character character)
    {
        _character = character;
    }

    public void ChangeVelocityX(float direction, float moveSpeed)
    {
        float newVelocityX = direction * moveSpeed;

        _character.Rigidbody.velocity = new Vector2 (newVelocityX, _character.Rigidbody.velocity.y);
    }
}