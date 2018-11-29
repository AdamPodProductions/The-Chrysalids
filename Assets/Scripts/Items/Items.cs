using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    public GameObject itemsFrame;
    public GameObject itemPrefab;

    public Item[] items;

    public delegate void EnemyTurnAfterItem();
    public EnemyTurnAfterItem enemyTurnAfterItem;

    private List<ItemHolder> itemButtons = new List<ItemHolder>();

    private void Start()
    {
        enemyTurnAfterItem = BattleManager.instance.EnemyTurn;
    }

    public void ShowItems()
    {
        BattleManager.instance.textBox.HideTextBox();
        itemsFrame.SetActive(true);

        itemButtons = new List<ItemHolder>();
        for (int i = 0; i < items.Length; i++)
        {
            ItemHolder spawnedItemHolder = Instantiate(itemPrefab, itemsFrame.transform).GetComponent<ItemHolder>();
            itemButtons.Add(spawnedItemHolder);

            itemButtons[i].GetComponent<Text>().text = "*" + items[i].name;
            itemButtons[i].GetComponent<ItemHolder>().item = items[i];
        }

        EventSystem.current.SetSelectedGameObject(itemButtons[0].gameObject);
    }

    public void HideItems()
    {
        itemsFrame.SetActive(false);

        foreach (ItemHolder itemHolder in itemButtons)
        {
            Destroy(itemHolder.gameObject);
        }
    }

    public void UseItem(ItemHolder itemHolder)
    {
        itemButtons.Remove(itemHolder);
        BattleManager.instance.playerHealth.Heal(itemHolder.item.healing);

        HideItems();
        BattleManager.instance.textBox.SayText(itemHolder.item.name + " healed " + itemHolder.item.healing + " HP", 15, 2, enemyTurnAfterItem);
    }
}
