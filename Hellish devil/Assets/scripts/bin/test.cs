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
            /*print("появился новый боб с возрастом " + randomAge);*/
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
                print("Боб найден, ему " + returnedBob.Age + " лет");
            }  
            
            else
            {
                print("ERROR! Боб не найден! Мы уже работаем над этой ошибкой, хотите ли вы отправить отчёт об это ошибке?");
            }
        }
    }

    public bob GetNewBob(int bobAge) // Создание боба
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
                return item; // при return функция заканчивается!
            }
        }

        /*throw null;*/ // так как ничего не вернулось через return, значение, которое надо было вернуть = ничему (null)
                        // и мы его выкидываем через окно и команду throw.

        return null;

    }
}

public class bob
{
    public int Age; // Свойство класса

    public bob(int age) // Конструктор класса
    {
        Age = age;
    }

    

    
}
