using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject snapEffect;
    private void OnCollisionEnter2D(Collision2D collision)
    
    {
      
        if (collision.gameObject.name == "box")
        {
            bool no_bounce = false;
            Debug.Log("thjk");
            float boxBase = collision.transform.position.x;
            float boxBase2 = transform.position.x;
            Debug.Log($"{boxBase},{boxBase2}");
            
            GameObject target = GameObject.Find("box (1)");
            GameObject snapPosition = GameObject.Find("box");

            float snapAdjust = boxBase - boxBase2;



            if ((snapAdjust < 0.3) &&(snapAdjust>0)&&(no_bounce==false))
            {
                target.transform.position = new Vector3(boxBase, transform.position.y, transform.position.z);
                no_bounce = true;
                Debug.Log("move");
                GameObject effect = Instantiate(snapEffect, transform.position, Quaternion.identity);
                ParticleSystem ps = effect.GetComponent<ParticleSystem>();
                ps.Play();
            }
            else if ((snapAdjust > -0.3) && (snapAdjust < 0) && (no_bounce == false))
            {

                target.transform.position = new Vector3(boxBase, transform.position.y, transform.position.z);
                no_bounce = true;
                Debug.Log("moved");
                GameObject effect = Instantiate(snapEffect, transform.position, Quaternion.identity);
                ParticleSystem ps = effect.GetComponent<ParticleSystem>();
                ps.Play(); ;

            }




        }
        else if (collision.gameObject.name == "floor")
        {
            Debug.Log("freese");

        }


    }
}
