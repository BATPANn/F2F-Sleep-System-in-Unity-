using UnityEngine;
using TMPro;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class F2FSleepSystem : MonoBehaviour
{


    [Header("Interaction")]
    public bool Caninteract = true;
    [SerializeField] private GameObject BlackPanel_GO;
    [SerializeField] private FirstPersonController FPSSCript;


    [Header("UI")]
    [SerializeField] private TextMeshProUGUI Subtext;
    private string Holder;
    private float WriteSpeed = 0.25f;

    // Update is called once per frame
    void Update()
    {
        

        if(Caninteract == true)
        {

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 5f))
            {

                if (hit.collider.CompareTag("Bed"))
                {

                    if (Input.GetKeyDown(KeyCode.E))
                    {

                        // sleep
                        StartCoroutine(SleepCO());

                    }


                }



            }


        }


    }



    IEnumerator SleepCO()
    {

        BlackPanel_GO.SetActive(true);
        Caninteract = false;
        FPSSCript.enabled = false;

        yield return new WaitForSeconds(1f);

        // write night

        Subtext.text = "";
        Holder = "Night 391";
        foreach(char c in Holder)
        {

            Subtext.text += c;
            yield return new WaitForSeconds(WriteSpeed);

        }

        // write night

        yield return new WaitForSeconds(1f);

        // load the next scene

        SceneManager.LoadScene(1);
        Debug.Log("Loaded the next scene");


    }


}
