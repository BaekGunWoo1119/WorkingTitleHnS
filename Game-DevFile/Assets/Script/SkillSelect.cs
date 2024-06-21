using UnityEngine;
using UnityEngine.UI;

public class SkillSelect : MonoBehaviour
{
    public ToggleGroup toggleGroup; // 특정 Toggle Group을 Inspector에서 지정

    private Toggle lastSelectedToggle;

    public GameObject dangerWindow;

    void Start()
    {
        if (toggleGroup != null)
        {
            // 토글 그룹의 각 토글에 대한 이벤트 리스너 추가
            Toggle[] toggles = toggleGroup.GetComponentsInChildren<Toggle>();
            foreach (Toggle toggle in toggles)
            {
                toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle); });
            }
        }
    }

    // 토글 값이 변경될 때 호출되는 함수
    private void OnToggleValueChanged(Toggle changedToggle)
    {
        if (changedToggle.isOn)
        {
            int selectedCount = 0;
            Toggle[] toggles = toggleGroup.GetComponentsInChildren<Toggle>();
            foreach (Toggle toggle in toggles)
            {
                if (toggle.isOn)
                {
                    selectedCount++;
                }
            }

            if (selectedCount > 2)
            {
                changedToggle.isOn = false;
                dangerWindow.transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                dangerWindow.transform.localScale = new Vector3(0, 0, 0);
                lastSelectedToggle = changedToggle;
            }
        }
        else if (changedToggle == lastSelectedToggle)
        {
            lastSelectedToggle = null;
        }
    }
}