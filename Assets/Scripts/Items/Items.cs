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

        CreateButtons();
    }

    private void CreateButtons()
    {
        for (int i = 0; i < items.Length; i++)
        {
            ItemHolder spawnedItemHolder = Instantiate(itemPrefab, itemsFrame.transform).GetComponent<ItemHolder>();
            itemButtons.Add(spawnedItemHolder);

            itemButtons[i].GetComponent<Text>().text = "*" + items[i].name;
            itemButtons[i].GetComponent<ItemHolder>().item = items[i];
        }
    }

    public void ShowItems()
    {
        if (itemButtons.Count > 0)
        {
            BattleManager.instance.textBox.HideTextBox();
            BattleManager.instance.ToggleBattleOptions(false);

            itemsFrame.SetActive(true);
            EventSystem.current.SetSelectedGameObject(itemButtons[0].gameObject);
        }
    }

    public void HideItems()
    {
        itemsFrame.SetActive(false);
    }

    public void UseItem(ItemHolder itemHolder)
    {
        itemButtons.Remove(itemHolder);
        Destroy(itemHolder.gameObject);
        BattleManager.instance.playerHealth.Heal(itemHolder.item.healing);

        HideItems();
        BattleManager.instance.textBox.SayText(itemHolder.item.name + " healed " + itemHolder.item.healing + " HP.", 15, 2, enemyTurnAfterItem);
    }
}
