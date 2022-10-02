using UnityEngine;
using UnityEngine.UI;


public class DialogCharacter : MonoBehaviour
{
    [SerializeField] private Image _frontShadow;
    [SerializeField] private string _characterName;
    [SerializeField] private string _characterId;

    public string CharacterName => _characterName;
    public string CharacterId => _characterId;

    public void EnableShadow()
    {
        SetShadowAlpha(.5f);
    }

    public void DisableShadow()
    {
        SetShadowAlpha(0);
    }

    private void SetShadowAlpha(float value)
    {
        var color = _frontShadow.color;
        color.a = value;
        _frontShadow.color = color;
    }
}

