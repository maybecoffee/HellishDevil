using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inv_Manager : MonoBehaviour
{
    public Transform Content; // положение в иерархии
    public GameObject ItemPrefab; // префаб элемента инвентаря

    public List<ItemsStack> Inventory; // Инвентарь со списком стаков

    public Inv_Item[] TestItems; // Просто список тестовых предметов

    public void Start()
    {
        Inventory = new List<ItemsStack>(); // создание нового инвентаря, нужно для работы List ВСЕГДА

        foreach (var item in TestItems)
        {
            AddToInventory(item);
        }
    }

    /// <summary>
    /// Функция для добавления в инвентарь предметов
    /// </summary>
    /// <param name="item"></param>
    public void AddToInventory(Inv_Item item)
    {
        ItemsStack newStack = null;

            foreach (var Stack in Inventory)
            {
                if(Stack.StackID == item.ID)
                {
                    newStack = Stack;
                    break;
                }
            }

            if(newStack == null)
            {
                newStack = new ItemsStack(item.ID);
                Inventory.Add(newStack);
            }

        newStack.AddItem(item);
        // Ниже отрисовка UI


        if (newStack.UIController == null)
        {
            GameObject newPrefab = Instantiate(ItemPrefab, Content);

            Inv_ItemController controller = newPrefab.GetComponent<Inv_ItemController>();

            controller.Icon.sprite = item.Icon;
            newStack.UIController = controller;
            newStack.UIController.Value.text = "";   
        }
        else
        {
            newStack.UIController.Value.text = newStack.Items.Count.ToString();
        }
    }

    
}

[System.Serializable]
public class ItemsStack
{
    public string StackID; // ID предметов в этом стаке
    public List<Inv_Item> Items; // Список самих предметов (сам стак)
    public Inv_ItemController UIController; // ссылка на контроллер

    public ItemsStack(string stackID) // ItemStack stack = new ItemsStack(stackID)
    {
        StackID = stackID;
        Items = new List<Inv_Item>();
    }

    public void AddItem(Inv_Item item)
    {
        Items.Add(item);
    }
}
