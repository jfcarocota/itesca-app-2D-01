namespace Core.Movements
{
    using UnityEngine;

   public class Movements
   {
       
        ///<summary>
        ///This is the basic movement for player in topdown.
        ///<param name="t">Transform component of the player.</param>
        ///<param name="direction">Direction for translate in X and Y.</param>
        ///<param name="moveSpeed">The speed factor for the movement.</param>
        ///</summary>
       public static void PlayerBasicMovement(Transform t, Vector2 direction, float moveSpeed)
       {
           t.Translate(direction * moveSpeed);
       }
   }
}