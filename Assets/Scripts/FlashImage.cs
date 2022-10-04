using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class FlashImage : MonoBehaviour
{
    Image _image = null;
    Coroutine _currentFlashRoutine = null;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForOneFlash, float maxAlpha, Color newColor)
    {
        _image.color = newColor;

        maxAlpha = Mathf.Clamp(maxAlpha, 0, 1);
        Debug.Log("Checkpoint 1/7");
        if (_currentFlashRoutine != null)
        {
            Debug.Log("Checkpoint 2/7");
            StopCoroutine(_currentFlashRoutine);
        }
            _currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash, maxAlpha));
    }

    IEnumerator Flash(float secondsForOneFlash, float maxAlpha)
    {
        Debug.Log("Checkpoint 3/7");
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t+= Time.deltaTime)
        {
            Debug.Log("Checkpoint 4/7");
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxAlpha, t / flashInDuration);
            _image.color = colorThisFrame;

            //wait until next frame
            yield return null;
        }
        Debug.Log("Checkpoint 5/7");
        float flashOutDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
        {
            Debug.Log("Checkpoint 6/7");
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(maxAlpha, 0, t / flashOutDuration);
            _image.color = colorThisFrame;
            yield return null;
        }

        Debug.Log("Checkpoint 7/7");
        //ensure alpha is set to zero
        _image.color = new Color32(0, 0, 0, 0);
    }
}
