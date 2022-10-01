using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterPortraitController : MonoBehaviour
{
    Image _portrait;
    [SerializeField] Image _staticLayer;

    [SerializeField] Sprite _idle;
    [SerializeField] Sprite _firing;
    [SerializeField] Sprite _hurt;
    [SerializeField] Sprite _enraged;
    [SerializeField] Sprite _dead;

    [SerializeField] public bool isEnraged = false;
    [SerializeField] public bool isDead = false;
    [SerializeField] public bool isFiring = false;
    [SerializeField] public bool isHurt = false;

    void Start()
    {
        _portrait = GetComponent<Image>();
    }

    private void Update()
    {
        if (isDead == true)
        {
            isEnraged = false;
            _portrait.sprite = _dead;
        }

        else if (isEnraged == true)
        {
            _portrait.sprite = _enraged;
        }

        else if (isFiring == true && isEnraged == false)
        {
            _portrait.sprite = _firing;
        }

        else if (isHurt == true)
        {
            _portrait.sprite = _hurt;
        }

        else _portrait.sprite = _idle;
    }

    public IEnumerator Firing()
    {
        isFiring = true;
        yield return new WaitForSeconds(.2f);
        isFiring = false;
    }

    public IEnumerator Hurt()
    {
        isHurt = true;
        yield return new WaitForSeconds(1f);
        isHurt = false;
    }

}
