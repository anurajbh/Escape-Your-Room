using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoSingleton<UIManager>
{
    // Start is called before the first frame update
    public List<Sprite> lifeSprites;
    public Image lifeImage;
    public void UpdateLives()
    {
        lifeImage.sprite = lifeSprites[PlayerCharacter.Instance.Lives];
    }
}
