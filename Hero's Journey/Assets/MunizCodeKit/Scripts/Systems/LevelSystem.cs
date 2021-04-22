using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MunizCodeKit.Systems
{
    public class LevelSystem
    {
        public PointsSystem experiencePointsSystem { get; private set; }
        public PointsSystem levelPointsSystem { get; private set; }
        float experienceFactor;
        bool isThereExperienceFactor;
        public LevelSystem(int maxexperience = 100, int maxlevel = 60)
        {
            experiencePointsSystem = new PointsSystem(maxexperience);
            levelPointsSystem = new PointsSystem(maxlevel, 1);

        }

        public LevelSystem(int maxexperience = 100, int maxlevel = 60, float experiencefactor = 1.2f)
        {
            experiencePointsSystem = new PointsSystem(maxexperience);
            levelPointsSystem = new PointsSystem(maxlevel, 1);
            if (experiencefactor < 1) experiencefactor = 1; // can't be less then 1
            experienceFactor = experiencefactor;
            isThereExperienceFactor = true;

        }

        public void AddExperience(int value)
        {
            if (value <= 0) return;
            int aux = value + experiencePointsSystem.currentPoints;
            //DEBUG
            Debug.Log("Lixos Coletados:" + experiencePointsSystem.currentPoints);
            Debug.Log("Dificuldade atual:" + levelPointsSystem.currentPoints);
            //
            if (aux < experiencePointsSystem.maxPoints)
            {
                experiencePointsSystem.AddPoints(value);
                return;
            }//if it didn't leveled up yet
            while (aux > experiencePointsSystem.maxPoints)//if it leveled up and how many times it did
            {
                aux -= experiencePointsSystem.maxPoints;
                levelPointsSystem.AddPoints(1);
                if (isThereExperienceFactor) experiencePointsSystem.SetMaxPoints((int)(experiencePointsSystem.maxPoints * experienceFactor));
            }
            experiencePointsSystem.ResetPoints();
            experiencePointsSystem.AddPoints(aux);
           
        }

        public void AddLevel(int value)
        {
            int aux = value + levelPointsSystem.currentPoints;
            if (aux < levelPointsSystem.maxPoints)
            {
                levelPointsSystem.AddPoints(value);
            }
            else
            {
                levelPointsSystem.ResetPoints();
                levelPointsSystem.AddPoints(levelPointsSystem.maxPoints);
            }
        }

    }
}