using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace MunizCodeKit.Systems
{

    /// <summary>
    /// This class handles any type of Point System. Use available Constructors. The Class is entire based on int values
    /// </summary>
    [Serializable]
    public class PointsSystem
    {
        /// <summary>
        /// Max points of this instance
        /// </summary>
        public int maxPoints { get; private set; }
        /// <summary>
        /// Current points of this instance
        /// </summary>
        public int currentPoints;
        /// <summary>
        /// Event triggered whenever the current points of this instance is decreased
        /// </summary>
        public event EventHandler<OnPointsDataEventArgs> OnPointsDecreased;
        /// <summary>
        /// Event triggered whenever the current points of this instance is increased
        /// </summary>
        public event EventHandler<OnPointsDataEventArgs> OnPointsIncreased;
        /// <summary>
        /// Event triggered whenever the current points of this instance is changed, either by increasing or decreasing
        /// </summary>
        public event EventHandler<OnPointsDataEventArgs> OnPointsChanged;
        /// <summary>
        /// Event triggered whenever the current points of this instance hits 0
        /// </summary>
        public event EventHandler<OnPointsDataEventArgs> OnPointsZero;
        /// <summary>
        /// Event triggered whenever the current points of this instance hits the intance's Max Points
        /// </summary>
        public event EventHandler<OnPointsDataEventArgs> OnPointsMax;
        /// <summary>
        /// Class to store data to use in the events triggers
        /// </summary>
        public class OnPointsDataEventArgs : EventArgs
        {
            public int CurrentPointsEventArgs;

        }

        /// <summary>
        /// Constructor that requires <paramref name="maxpoints"/> and <paramref name="startingpoints"/> to be set
        /// <para>(<paramref name="maxpoints"/> = Int32.Max and <paramref name="startingpoints"/> = 0 by default)</para>
        /// </summary>
        /// <param name="maxpoints"> The max set of points which this instance will have.</param>
        /// <param name="startingpoints">The starting points of this instance.</param>
        public PointsSystem(int maxpoints = Int32.MaxValue, int startingpoints = 0)
        {
            maxPoints = maxpoints;
            currentPoints = startingpoints;
        }
        /// <summary>Removes X (<paramref name="value"/>) points from this PointSystem's Current Points (always use positive values, the calculation is made within the function).</summary>
        /// <remarks>  
        /// If, after the calculation, the amount
        /// of points is greater then 0, then it triggers OnPointsDecreased and OnPointsChanged events. However if, after the calculation, the amount
        /// of points is less or equal to 0 then it triggers OnPointsDecreased, OnPointsChanged and OnPointsZero events.
        ///</remarks>
        /// <param name="value">value to be subtracted from this PointSystem 's Current Points.</param> 
        public void RemovePoints(int value)
        {
            if (value > 0)
            {

                int aux = currentPoints - value;

                if (aux > 0)
                {

                    currentPoints = aux;
                    OnPointsDataEventArgs EventArgsData = new OnPointsDataEventArgs { CurrentPointsEventArgs = currentPoints };
                    OnPointsDecreased?.Invoke(this, EventArgsData);
                    OnPointsChanged?.Invoke(this, EventArgsData);

                }

                else
                {
                    currentPoints = 0;
                    OnPointsDataEventArgs EventArgsData = new OnPointsDataEventArgs { CurrentPointsEventArgs = currentPoints };
                    OnPointsDecreased?.Invoke(this, EventArgsData);
                    OnPointsChanged?.Invoke(this, EventArgsData);
                    OnPointsZero?.Invoke(this, EventArgsData);

                }
            }
            else
            {
                Debug.LogError("value can't be negative nor zero!");
            }
        }
        /// <summary>Adds X (<paramref name="value"/>) points to this PointSystem's Current Points.</summary>
        /// <remarks>
        /// If, after the calculation, the amount
        /// of points is less then MaxPoints, then it triggers OnPointsIncreased and OnPointsChanged events. However if, after the calculation, the amount
        /// of points is greater or equal to MaxPoints, then it triggers OnPointsIncreased, OnPointsChanged and OnPointsMax events.
        ///</remarks>
        /// <param name="value">value to be summed to this PointSystem's Current Points.</param>
        public void AddPoints(int value)
        {
            if (value > 0)
            {

                int aux = currentPoints + value;// Propriedade auxiliar para não precisar repetir função
                if (aux >= maxPoints)
                {
                    currentPoints = maxPoints;
                    OnPointsDataEventArgs EventArgsData = new OnPointsDataEventArgs { CurrentPointsEventArgs = currentPoints };
                    OnPointsMax?.Invoke(this, EventArgsData);

                    OnPointsIncreased?.Invoke(this, EventArgsData);
                    OnPointsChanged?.Invoke(this, EventArgsData);

                }
                else
                {
                    currentPoints = aux;
                    OnPointsDataEventArgs EventArgsData = new OnPointsDataEventArgs { CurrentPointsEventArgs = currentPoints };
                    OnPointsIncreased?.Invoke(this, EventArgsData);
                    OnPointsChanged?.Invoke(this, EventArgsData);
                }
            }
            else
            {
                Debug.LogError("value can't be negative nor zero!");
            }

        }
        /// <summary>
        /// Set CurrentPoints variable to 0
        /// </summary>
        /// <remarks>Triggers the OnPointsChanged and OnPointsZero events</remarks>
        public void ResetPoints()
        {
            currentPoints = 0;

            OnPointsDataEventArgs EventArgsData = new OnPointsDataEventArgs { CurrentPointsEventArgs = currentPoints };
            OnPointsChanged?.Invoke(this, EventArgsData);
            OnPointsZero?.Invoke(this, EventArgsData);

        }
        /// <summary>
        /// Set the MaxPoints of the PointsSystem instance
        /// </summary>
        public void SetMaxPoints(int maxpoints)
        {
            if (maxpoints > 0)
            {
                maxPoints = maxpoints;
            }
            else
            {
                Debug.LogError("value can't be negative nor zero!");
            }
        }
        /// <summary>
        /// Set currentPoints in the PointsSystem instance
        /// </summary>
        public void SetCurrentPoints(int currentpoints)
        {
            if (currentpoints > 0 && currentpoints <= maxPoints)
            {
                OnPointsDataEventArgs EventArgsData = new OnPointsDataEventArgs { CurrentPointsEventArgs = currentPoints };
                if (currentpoints == maxPoints) OnPointsMax?.Invoke(this, EventArgsData);
                currentPoints = currentpoints;
                OnPointsChanged?.Invoke(this, EventArgsData);



            }
            else
            {
                Debug.LogError("value can't be negative, zero nor greater then MaxPoints!");
            }
        }

        /// <summary>
        /// Returns the current amout of points
        /// </summary>
        /// <returns>Current points of this instance</returns>
        public int GetCurrentPoints()
        {
            return currentPoints;
        }
        /// <summary>
        /// Return current points percentage based on MaxPoints of the instance
        /// </summary>
        /// <returns>
        /// Returns a float value between 0 and 1
        /// </returns>
        public float GetPointsPercentage()
        {
            return (float)currentPoints / maxPoints;
        }
    }
}