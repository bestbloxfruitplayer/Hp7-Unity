using Unity.VisualScripting;
using UnityEngine;

public class UnleaseLava : MonoBehaviour
{
    public GameObject UnleaseSkill;
    public GameObject GBoss;
    public Vector3 target;


    void Start()
    {
      target = GBoss.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        DoDmg();
    }

    void DoDmg()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, 5f * Time.deltaTime);
        if (Vector3.Distance(transform.position, target) < 0.01f)
        {
            UnleaseSkill.SetActive(false); 
        }
    }
}
