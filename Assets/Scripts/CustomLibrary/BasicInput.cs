
namespace Core.BasicInput
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class BasicInput
    {
        ///<summary>
        ///This function returns the default Axis H and V.
        ///</summary>
        public static Vector2 Axis
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        ///<summary>
        ///This function returns the default Axis H and V in normalized vector.
        ///</summary>
        public static Vector2 AxisNormalized
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }

        ///<summary>
        ///This function returns the default Axis H and V multiplied by deltatime.
        ///</summary>
        public static Vector2 AxisDeltaTime
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime;
        }

        ///<summary>
        ///This function returns the default Axis H and V multiplied by deltatime and normalized vector.
        ///</summary>
        public static Vector2 AxisNormDeltaTime
        {
            get => new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * Time.deltaTime;
        }
    }
}

