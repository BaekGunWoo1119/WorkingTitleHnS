using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class SliderManager : MonoBehaviour
{
    public Slider slider;
    public string sceneName;
    public Button button;
    public string valueType;

    void Start()
    {
        button.onClick.AddListener(SaveAndLoadNextScene);
        // slider.onValueChanged.AddListener(OnSliderValueChanged);
    }
    public void SaveAndLoadNextScene()
    {
        // int selectedValue = GetNearestValue((int)slider.value);
        PlayerPrefs.SetFloat(valueType, slider.value);
        SceneManager.LoadScene(sceneName);
    }

    /* private void OnSliderValueChanged(float value)
    {
        int selectedValue = GetNearestValue(Mathf.RoundToInt(value));
        slider.value = selectedValue;
    }

    private int GetNearestValue(int value)
    {
        int closestValue = 0;
        int smallestDifference = int.MaxValue;

        foreach (int fixedValue in fixedValues)
        {
            int difference = Mathf.Abs(fixedValue - value);
            if (difference < smallestDifference)
            {
                closestValue = fixedValue;
                smallestDifference = difference;
            }
        }

        return closestValue;
    } */
}
