using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveTest : MonoBehaviour
{
    public saveObject so;

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //save data
            SaveManager.save(so);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            //load data
            so = SaveManager.load();
        }
    }
}
