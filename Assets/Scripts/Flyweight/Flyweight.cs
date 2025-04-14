using System.Collections.Generic;
using UnityEngine;

public class Flyweight : MonoBehaviour
{
    //The list that stores all aliens
    private List<Alien> allAliens = new List<Alien>();

    private List<Vector2> eyePositions;
    private List<Vector2> legPositions;
    private List<Vector2> armPositions;

    private void Start()
    {
        //List used when flyweight is enabled
        eyePositions = GetBodyPartPositions();
        legPositions = GetBodyPartPositions();
        armPositions = GetBodyPartPositions();

        //Create all aliens
        for (int i = 0; i < 10000; i++)
        {
            Alien newAlien = new Alien();

            //Add eyes and leg positions
            //Without flyweight
            newAlien.eyePositions = GetBodyPartPositions();
            newAlien.armPositions = GetBodyPartPositions();
            newAlien.legPositions = GetBodyPartPositions();

            //With flyweight
            /*newAlien.eyePositions = eyePositions;
            newAlien.armPositions = legPositions;
            newAlien.legPositions = armPositions;*/

            allAliens.Add(newAlien);
        }
    }

    //Generate a list with body part positions
    private List<Vector2> GetBodyPartPositions()
    {
        //Create a new list
        List<Vector2> bodyPartPositions = new List<Vector2>();

        //Add body part positions to the list
        for (int i = 0; i < 1000; i++)
        {
            bodyPartPositions.Add(new Vector2());
        }

        return bodyPartPositions;
    }
}

public class Alien
{
    public List<Vector2> eyePositions;
    public List<Vector2> legPositions;
    public List<Vector2> armPositions;
}