using UnityEngine;

public static class Inputs
{
   public static string Horizontal(int playerId) => "Horizontal_" + playerId;
   public static string Vertical(int playerId) => "Vertical_" + playerId;
   public static string Fire1(int playerId) => "Fire1_" + playerId;
   public static string Fire2(int playerId) => "Fire2_" + playerId;
   
   
   public static bool GetFire1(int playerId)
   {
      return Input.GetButton(Fire1(playerId));
   } 
   
   public static bool GetFire1Up(int playerId)
   {
      return Input.GetButtonUp(Fire1(playerId));
   }

   public static Vector3 GetAxis(int playerId)
   {
      return new Vector3(
         Input.GetAxis(Horizontal(playerId)),
         Input.GetAxis(Vertical(playerId))
         );
   }
}
