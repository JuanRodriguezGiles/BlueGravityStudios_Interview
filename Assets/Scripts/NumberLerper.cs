using System.Collections;

using UnityEngine;

using TMPro;

public class NumberLerper : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private float duration = 1f;
    [SerializeField] private TextMeshProUGUI textMeshPro;
    #endregion

    #region PUBLIC_METHODS
    public void LerpNumber(int targetNumber)
    {
        StartCoroutine(Lerp(targetNumber));
    }
    #endregion

    #region PRIVATE_METHODS
    private IEnumerator Lerp(int targetNumber)
    {
        float initialNumber = float.Parse(textMeshPro.text);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            int currentValue =(int) Mathf.Lerp(initialNumber, targetNumber, elapsedTime / duration);
            textMeshPro.text = currentValue.ToString();
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        textMeshPro.text = targetNumber.ToString();
    }
    #endregion
}