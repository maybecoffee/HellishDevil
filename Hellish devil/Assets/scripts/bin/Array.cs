using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{
    // public int[] a; // ���������� ������� � ����� ������ int
    // int[] a = { 7, 5, 8 }; // ��������� ���������� � ����

    public GameObject[] healItems;
    string[] myArray = { "Hi", "Hello" , "How are u bro?" };
    List<string> myList = new List<string>(); // ���������� ������ � ����� List

    private void Start()
    {
        print( myArray[ Random.Range( 0,myArray.Length ) ] );
        myList.Add("GoodBye");
        myList.Add("BB");
        myList.Add("Chao");

        int i = myList.IndexOf("BB");
        print(myList[i]);

    }
}
