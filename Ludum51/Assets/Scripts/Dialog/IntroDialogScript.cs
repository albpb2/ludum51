using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;


public class IntroDialogScript : MonoBehaviour
{
    [SerializeField] private DialogLine[] _lines;
    [SerializeField] private AudioClip _textAudio;

    private TMP_Text _textBox;

    private AudioSource _audioSource;

    private Dictionary<string, DialogCharacter> _characterByIds;
    private int _currentLineIndex;

    public bool IsStarted => _currentLineIndex >= 0;
    public bool IsFinished => _currentLineIndex >= _lines.Length;

    private void Awake()
    {
        _currentLineIndex = -1;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _textBox = GameObject.FindWithTag("DialogLineTextBox").GetComponent<TMP_Text>();

        SetUpCharacters();
    }

    public bool TryPlayNextLine()
    {
        if (_characterByIds == null) return false;

        if (_currentLineIndex >= 0)
        {
            GetCurrentLineCharacter().EnableShadow();
            GetCurrentLineCharacter().EnableShadow();
        }

        _currentLineIndex++;

        if (_currentLineIndex < _lines.Length)
        {

            _audioSource.pitch = 1 + Random.Range(-0.1f, 0.1f);
            _audioSource.PlayOneShot(_textAudio, 0.3f);

            GetCurrentLineCharacter().DisableShadow();
            _textBox.text = FormatLine(_lines[_currentLineIndex]);
        }
        return true;
    }

    private void SetUpCharacters()
    {
        _characterByIds = new Dictionary<string, DialogCharacter>();

        var characters = FindObjectsOfType<DialogCharacter>();
        foreach (var mapDialogCharacter in characters)
        {
            _characterByIds[mapDialogCharacter.CharacterId] = mapDialogCharacter;
        }
    }

    private DialogCharacter GetCurrentLineCharacter()
    {
        return _characterByIds[_lines[_currentLineIndex].CharacterId];
    }

    private string FormatLine(DialogLine dialogLine)
    {
            return $"<b>{GetCurrentLineCharacter().CharacterName}</b> {dialogLine.TextLine}";
    }
}

