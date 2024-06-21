using UnityEngine;
using UnityEngine.UI;

public class SkillSelect : MonoBehaviour
{
    public ToggleGroup toggleGroup; // Ư�� Toggle Group�� Inspector���� ����

    private Toggle lastSelectedToggle;

    public GameObject dangerWindow;

    void Start()
    {
        if (toggleGroup != null)
        {
            // ��� �׷��� �� ��ۿ� ���� �̺�Ʈ ������ �߰�
            Toggle[] toggles = toggleGroup.GetComponentsInChildren<Toggle>();
            foreach (Toggle toggle in toggles)
            {
                toggle.onValueChanged.AddListener(delegate { OnToggleValueChanged(toggle); });
            }
        }
    }

    // ��� ���� ����� �� ȣ��Ǵ� �Լ�
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