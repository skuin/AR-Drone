using UnityEngine;
using System.Collections;

public class DroneCollision : MonoBehaviour {

    #region PUBLIC VARIABLES

    [Tooltip("Sparks GameObject prefab that will be created when crashing the drone.")]
    public GameObject sparks;

    bool flag = false;

    #endregion

    #region Mono Behaviour METHODS

    void Awake()
    {
        if (!sparks)
        {
            print("Missing sparks particle prefab!");
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.transform)
        {
            ContactPoint contact = other.contacts[0];
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal) * Quaternion.Euler(-90, 0, 0);
            Vector3 pos = contact.point;

            if (sparks)
            {
                GameObject spark = (GameObject)Instantiate(sparks, pos, rot);
                spark.transform.localScale = transform.localScale * 2;
                foreach (Transform _spark in spark.transform)
                {
                    _spark.localScale = transform.localScale * 2;
                }
                StartCoroutine(SparksCleaner(spark));
                if(!flag){
                    flag = true;
                    StartCoroutine("ScoreMinus");
                }
            }
            else
            {
                Debug.LogError("You did not assign a spark prefab effect, default is located in DroneController/Prefabs/...");
            }

        }
    }

    #endregion

    #region PRIVATE Coroutine METHODS

    IEnumerator SparksCleaner(GameObject _spark)
    {
        yield return new WaitForSeconds(1);
        Destroy(_spark);
    }
    
    IEnumerator ScoreMinus()
    {
        Debug.Log("Start");
        GameManager.instance.DowngradeScore();
        yield return new WaitForSeconds(3.0f);
        flag = false;
        Debug.Log("End");

    }

    #endregion

}
