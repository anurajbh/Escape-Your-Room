using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepeatingBackground : MonoBehaviour
{
    //offset will be set to half of the image length and width in Start()
    Vector2 _offset;
    //keep track of player position at spawn of last background
    Vector2 _previousPlayerPos;
    //player transform
    [SerializeField] Transform _player;
    //container gameobject for instantiating new background
    GameObject _newBackground;
    //variables made to keep track of background width and height at start
    [SerializeField] float _backgroundWidth;
    [SerializeField] float _backgroundHeight;
    //previously set background
    [HideInInspector] public GameObject _previousBackground;


    void Start()
    {
        _backgroundWidth = GameManager.Instance._currentBackground.GetComponent<RectTransform>().rect.width/ 2.0f;
        _backgroundHeight = GameManager.Instance._currentBackground.GetComponent<RectTransform>().rect.height / 2.0f;
        _offset = new Vector2(_backgroundWidth, _backgroundHeight);
        _player = PlayerCharacter.Instance.transform;
        _previousPlayerPos = _player.position;

    }


    void Update()
    {
        if(_player == null)
        {
            return;
        }
        Vector2 _playerPos = _player.position;
        //if background is this
        if (GameManager.Instance._currentBackground == gameObject)
        {
            //check if player has moved equal to or more than half of sum of the player position at last spawn and offset
            if (_playerPos.x >= (_previousPlayerPos.x + _offset.x) && _playerPos.x < _previousPlayerPos.x + (_offset.x * 2.0f))
            {
                Vector2 newPos = new Vector2(transform.position.x + _offset.x * 2.0f, transform.position.y);

                _newBackground = Instantiate(gameObject, newPos, Quaternion.identity, transform.parent);

                GameManager.Instance._currentBackground = _newBackground;

            }
            else if (_playerPos.x >= _previousPlayerPos.x + _offset.x * 2.0f)
            {

                RemoveOldBackground();
            }
            //check if player has moved backwards to less than half of sum of the player position at last spawn and offset
            else if (_playerPos.x < _previousPlayerPos.x - _offset.x && _playerPos.x >= _previousPlayerPos.x - (_offset.x * 2.0f))
            {
                Vector2 newPos = new Vector2(transform.position.x - _offset.x*2.0f, transform.position.y);

                _newBackground = Instantiate(gameObject, newPos, Quaternion.identity, transform.parent);

                GameManager.Instance._currentBackground = _newBackground;

            }
            else if(_playerPos.x < _previousPlayerPos.x - _offset.x *2.0f)
            {
                RemoveOldBackground();
            }
        }
    }
    //method that removes previous backgrounds and keeps track of player position at spawn
    private void RemoveOldBackground()
    {

        if(_newBackground.GetComponent<RepeatingBackground>() != null) 
        {
            RepeatingBackground backgroundScript = _newBackground.GetComponent<RepeatingBackground>();

            backgroundScript._previousBackground = gameObject;

            _previousPlayerPos = _player.position;

            if (_previousBackground != null)
            {
                Destroy(_previousBackground);
            }
        }
    }

}
