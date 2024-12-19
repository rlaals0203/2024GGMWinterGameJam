using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public abstract class Hover : MonoBehaviour
{
    [Header("HoverSeetting")]
    [SerializeField] protected List<GameObject> Button;
    [SerializeField] protected GraphicRaycaster GraphicRaycaster;
    [SerializeField] protected EventSystem EventSystem;
    protected GameObject CurrentHoveredButton;



    public virtual void OnMouse()
    {
        GameObject hoveredButton = GetHoveredButton();

        if (hoveredButton != CurrentHoveredButton)
        {
            CurrentHoveredButton = hoveredButton;

            foreach (GameObject button in Button)
            {
                if (button == null) continue;

                if (button == CurrentHoveredButton)
                    button.transform.DOScale(1.5f, 0.3f);
                else
                    button.transform.DOScale(0.8f, 0.3f);
            }
        }

        if (CurrentHoveredButton == null)
        {
            foreach (GameObject button in Button)
            {
                if (button == null) continue;

                button.transform.DOScale(1f, 0.3f);
            }
        }
    }

    public virtual GameObject GetHoveredButton()
    {
        if (GraphicRaycaster == null || EventSystem == null)
            return null;

        PointerEventData pointerData = new(EventSystem)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new();
        GraphicRaycaster.Raycast(pointerData, results);

        foreach (RaycastResult result in results)
            foreach (GameObject button in Button)
                if (result.gameObject == button)
                    return button;

        return null;
    }
}