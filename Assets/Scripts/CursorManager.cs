using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Texture2D fireCursorTexture;
    [SerializeField] private Texture2D powerCursorTexture;
    bool isPowered = false;

    Coroutine _currentCursorRoutine = null;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(16, 16), CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void cursorFeedback(string CoroutineName)
    {
        if (_currentCursorRoutine != null)
        {
            StopCoroutine(_currentCursorRoutine);
        }
        _currentCursorRoutine = StartCoroutine(CoroutineName);
    }

    IEnumerator Fire()
    {
        if (isPowered == true) { Cursor.SetCursor(powerCursorTexture, new Vector2(16, 16), CursorMode.Auto); }
        else Cursor.SetCursor(fireCursorTexture, new Vector2(16, 16), CursorMode.Auto);

        yield return new WaitForSeconds(.15f);
        Cursor.SetCursor(cursorTexture, new Vector2(16, 16), CursorMode.Auto);
    }

    IEnumerator PoweredUp()
    {
        isPowered = true;
        yield return null;
    }
}
