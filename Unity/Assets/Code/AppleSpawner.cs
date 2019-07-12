using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class AppleSpawner : MonoBehaviour
{
   public float radius = 3.0f;
   public float defaultInterval = 0.02f;

   public float probaPowerUp = 5.0f / 20.0f;
   public float scale = 5.0f;

   public Apple m_appleNormalPrefab;
   public Apple[] m_powerUpsPrefab;

   public void Clear()
   {
      for(int i = transform.childCount-1; i >= 0; --i)
      {
         Destroy(transform.GetChild(i).gameObject);
      }
   }

   public void StartSpawn(int count)
   {
      StartSpawn(count, defaultInterval);
   } 
   
   public void StartSpawn(int count, float interval)
   {
      StartCoroutine(Spawn(count, interval));
   }

   private IEnumerator Spawn(int count, float interval)
   {
      var s = new Vector3(scale, scale, scale);
      Vector3 pos = Random.insideUnitSphere * radius;

      for (int i = 0; i < count; ++i)
      {
         var prefab = GetRandomPrefab();
         var apple = Instantiate(prefab, pos, Random.rotationUniform, transform);
         apple.transform.localScale = s;
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
