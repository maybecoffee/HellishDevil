using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : Interactable
{

    public List<Inv_Item> Loot;

    public bool isOpen = false;

    public override void Start()
    {
        base.Start();
        //
        this.transform.Find("ButtonE").gameObject.SetActive(false);
        //
    }

    public override void Update()
    {
        base.Update();
        //
        if(isOpen == false)
        {
                if (Vector3.Distance(CurrentPlayer.transform.position, this.gameObject.transform.position) < UseDistance)
                {
                    this.transform.Find("ButtonE").gameObject.SetActive(true);
                }
                else
                        {
                            this.transform.Find("ButtonE").gameObject.SetActive(false);
                        }


        }
        if (isOpen == true)
        {
            this.transform.Find("ButtonE").gameObject.SetActive(false);
        }

        //
    }

    public override void Use()
    {
        base.Use();

        this.GetComponent<Animator>().SetTrigger("Open");

        foreach (var item in Loot)
        {
            /*FindObjectOfType<Inv_Manager>().AddToInventory(item);*/

            Vector2 force = new Vector2(Random.Range(-0.3f,0.3f), Random.Range(0.7f, 1));

            GameObject prefab = Resources.Load<GameObject>("Collectable");
            GameObject newItem = Instantiate(prefab, this.transform.position, this.transform.rotation);
            newItem.GetComponent<Collectable>().Create(item, force * 500);
        }

        Loot.Clear();
        isOpen = true;
    }
}
