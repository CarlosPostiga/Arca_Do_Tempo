using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Part : MonoBehaviour
{
    public int id;
    public bool inplace;

    private void Start()
    {
        inplace = false;
    }
    public bool AskNeighboor(GameObject neigbor)
    {
        Part temp = neigbor.GetComponent<Part>();
        if (!temp.inplace)
        {
            if (id + 1 == temp.id && id < 5)
            {
                neigbor.transform.position = new Vector3(this.transform.position.x - .1f, this.transform.position.y, this.transform.position.z);
                neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                inplace = true;
                temp.inplace = true;
                return true;
            }
            else if (temp.id > 5 && temp.id <= 10 && id + 5 == temp.id)
            {
                neigbor.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - .1f);
                neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                inplace = true;
                temp.inplace = true;
                return true;
            }
            else if (temp.id > 10 && id + 10 == temp.id)
            {
                neigbor.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + .1f, this.transform.position.z);
                neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                inplace = true;
                temp.inplace = true;
                return true;
            }
            else if (id - 1 == temp.id && id != 1 && id < 5)
            {
                neigbor.transform.position = new Vector3(this.transform.position.x + .1f, this.transform.position.y, this.transform.position.z);
                neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                inplace = true;
                temp.inplace = true;
                return true;
            }

        }
        return false;
    }

}
