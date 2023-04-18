using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public List<bob> bobs;


    private void Start()
    {

        bobs = new List<bob>();

        for (int i = 0; i < 100; i++)
        {
            int randomAge = Random.Range(9, 98);
            bobs.Add( GetNewBob(randomAge) );
            /*print("�������� ����� ��� � ��������� " + randomAge);*/
        }

        List<int> Ages = new List<int>();

        for (int i = 0; i < 10; i++)
        {
            Ages.Add(Random.Range(2, 100));
        }

        foreach (int item in Ages)
        {
            bob returnedBob = GetBobByAge(item);
            if (returnedBob != null)
            {
                print("��� ������, ��� " + returnedBob.Age + " ���");
            }  
            
            else
            {
                print("ERROR! ��� �� ������! �� ��� �������� ��� ���� �������, ������ �� �� ��������� ����� �� ��� ������?");
            }
        }
    }

    public bob GetNewBob(int bobAge) // �������� ����
    {


        bob result = new bob(bobAge);
        return result;
    }

    

    private bob GetBobByAge(int age)
    {

        foreach (bob item in bobs)
        {
            if(item.Age == age)
            {
                return item; // ��� return ������� �������������!
            }
        }

        /*throw null;*/ // ��� ��� ������ �� ��������� ����� return, ��������, ������� ���� ���� ������� = ������ (null)
                        // � �� ��� ���������� ����� ���� � ������� throw.

        return null;

    }
}

public class bob
{
    public int Age; // �������� ������

    public bob(int age) // ����������� ������
    {
        Age = age;
    }

    

    
}
