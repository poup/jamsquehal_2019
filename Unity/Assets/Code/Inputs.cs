using UnityEngine;

public static class Inputs
{
   public static string Horizontal(int playerId) => "Horizontal_" + playerId;
   public static string Vertical(int playerId) => "Vertical_" + playerId;
   public static string Fire1(int playerId) => "Fire1_" + playerId;
   public static string Fire2(int playerId) => "Fire2_" + playerId;
   

   public static float GetAxisHorizontal(int playerId)
   {
      return Input.GetAxis(Horizontal(playerId));
   } 
   
   public static float GetAxisVertical(int playerId)
   {
      return Input.GetAxis(Vertical(playerId));
   }
   
   public static bool GetFire1(int playerId)
   {
      return Input.GetButton(Fire1(playerId));
   } 
   
   public static bool GetFire1Up(int playerId)
   {
      return Input.GetButtonUp(Fire1(playerId));
   }
   
   public static float GetDebug()
   {
      return Input.GetAxis("Debug");
   }

   public static Vector3 GetAxis(int playerId)
   {
      return new Vector3(
         Input.GetAxis(Horizontal(playerId)),
         Input.GetAxis(Vertical(playerId))
         );
   }

   public static string Submit => "Submit";
}
