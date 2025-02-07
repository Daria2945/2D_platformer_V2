using UnityEngine;

public class CharacterChangerSpeed
{
    private Character _character;

    public CharacterChangerSpeed(Character character)
    {
        _character = character;
    }

    public void ChangeVelocityX(float direction, float moveSpeed)
    {
        float newVelocityX = direction * moveSpeed;

        _character.Rigidbody.velocity = new Vector2 (newVelocityX, _character.Rigidbody.velocity.y);
    }
}