using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleSpawner : MonoBehaviour
{
   public float radius = 3.0f;
   public float interval = 0.02f;

   public float probaPowerUp = 1.0f / 20.0f;

   public Apple m_appleNormalPrefab;
   public Apple[] m_powerUpsPrefab;


   public void StartSpawn(int count)
   {
      StartCoroutine(Spawn(count));
   }

   private IEnumerator Spawn(int count)
   {
      Vector3 pos = Random.insideUnitSphere * radius;

      for (int i = 0; i < count; ++i)
      {
         var prefab = GetRandomPrefab();
         var apple = Instantiate(prefab, pos, Random.rotationUniform, transform);
         apple.transform.localScale = Vector3.one;
         yield return new WaitForSecondsRealtime(interval);
      }
   }

   private Apple GetRandomPrefab()
   {
      float r = Random.value;
      if (r > probaPowerUp || m_powerUpsPrefab == null)
         return m_appleNormalPrefab;


      var index = (int)(Random.value * m_powerUpsPrefab.Length);
      return m_powerUpsPrefab[index];
   }


   private void OnDrawGizmosSelected()
   {
      Gizmos.DrawWireSphere(transform.position, radius);
   }

}
