using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class TypingGameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _password;
    [SerializeField] TextMeshProUGUI _playerTyping;

    private string _passwordTextLowerCase;
    private string _passwordText;
    private int _nextCharacterIndex;
    private KeyCode[] _keyCodes;

    // Start is called before the first frame update
    void Start()
    {
        _passwordTextLowerCase = _password.text.ToLowerInvariant();
        _passwordText = _password.text;
        _playerTyping.text = "";
        _keyCodes = System.Enum.GetValues(typeof(KeyCode)).Cast<KeyCode>().ToArray();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode vKey in _keyCodes)
            {
                if (Input.GetKey(vKey))
                {
                    Debug.Log("Detected key code: " + vKey);
                    var pressedChar = vKey == KeyCode.Space ? ' ' : vKey.ToString().ToLowerInvariant()[0];
                    if (pressedChar == _passwordTextLowerCase[_nextCharacterIndex])
                    {
                        _playerTyping.text += _passwordText[_nextCharacterIndex];
                        _nextCharacterIndex++;

                        if (_nextCharacterIndex == _passwordText.Length)
                        {
                            //win
                            Debug.Log("Has Ganado, yei...");
                        }
                    }
                    else
                    {
                        _playerTyping.text = "";
                        _nextCharacterIndex = 0;
                    }
                }
            }
        }
    }
}
