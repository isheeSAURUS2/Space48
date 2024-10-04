using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    [SerializeField] private Image itemImageHolder;
    private ShowMessageText textManager;
    private List<Color> items = new List<Color>();
    private int activeItemIndex = -1;
    private Move moveScript;
    private Shoot shootScript;

    private void Start()
    {
        textManager = GetComponent<ShowMessageText>();
        moveScript = GetComponent<Move>();
        shootScript = GetComponent<Shoot>();
    }
    private void Update()
    {
        UseItem();
        CycleItems();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject);
        }
    }
    void PickUpItem(GameObject item)
    {

        Color color = item.gameObject.GetComponent<Renderer>().material.color;

        Destroy(item);
        items.Add(color);

        activeItemIndex = items.Count - 1;

        itemImageHolder.color = items[activeItemIndex];
        itemImageHolder.enabled = true;
    }

    void CycleItems()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (items.Count > 0)
            {
                if (activeItemIndex < items.Count - 1)
                {
                    activeItemIndex++;
                }
                else
                {
                    activeItemIndex = 0;
                }
                itemImageHolder.color = items[activeItemIndex];
            }
            else
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }
        }
    }
    void UseItem()
    {

        if (Input.GetKeyDown(KeyCode.E) && items.Count > 0 && activeItemIndex != -1)
        {

            if (items[activeItemIndex] == Color.blue)
            {
                textManager.StartText(2f," +  Move Speed");
                moveScript.moveSpeed += 5;
            }
            else if (items[activeItemIndex] == Color.red)
            {
                textManager.StartText(2f, " + Fire Rate");
                shootScript.cooldownTime -= 0.1f;
            }
            else if (items[activeItemIndex] == Color.green)
            {
                textManager.StartText(2f, " + Rotation Speed");
                moveScript.rotationSpeed += 10;
            }
            items.RemoveAt(activeItemIndex);
            if (activeItemIndex > 0)
            {
                activeItemIndex--;
                itemImageHolder.color = items[activeItemIndex];
            }
            else if (items.Count == 0)
            {
                itemImageHolder.color = Color.white;
                activeItemIndex = -1;
                itemImageHolder.enabled = false;
            }

        }
    }
}
