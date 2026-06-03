using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class ToastMessage : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float displayDuration = 2f;
    [SerializeField] private float fadeDuration = 0.25f;
    [SerializeField] private bool hideOnAwake = true;

    private Coroutine showRoutine;

    private void Awake()
    {
        if (canvasGroup == null)
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        if (canvasGroup == null)
        {
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        if (messageText == null)
        {
            messageText = GetComponentInChildren<Text>();
        }

        if (hideOnAwake)
        {
            SetVisible(false);
        }
    }

    public void Show(string message)
    {
        if (messageText != null)
        {
            messageText.text = message;
        }

        if (showRoutine != null)
        {
            StopCoroutine(showRoutine);
        }

        showRoutine = StartCoroutine(ShowToast());
    }

    public void Hide()
    {
        if (showRoutine != null)
        {
            StopCoroutine(showRoutine);
            showRoutine = null;
        }

        SetVisible(false);
    }

    private IEnumerator ShowToast()
    {
        SetInputEnabled(true);
        yield return FadeTo(1f);
        yield return new WaitForSeconds(displayDuration);
        yield return FadeTo(0f);
        SetInputEnabled(false);
        showRoutine = null;
    }

    private IEnumerator FadeTo(float targetAlpha)
    {
        if (canvasGroup == null || fadeDuration <= 0f)
        {
            if (canvasGroup != null)
            {
                canvasGroup.alpha = targetAlpha;
            }

            yield break;
        }

        float startAlpha = canvasGroup.alpha;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = targetAlpha;
    }

    private void SetVisible(bool visible)
    {
        canvasGroup.alpha = visible ? 1f : 0f;
        SetInputEnabled(visible);
    }

    private void SetInputEnabled(bool visible)
    {
        canvasGroup.interactable = visible;
        canvasGroup.blocksRaycasts = visible;
    }
}
