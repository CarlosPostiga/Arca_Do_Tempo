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
        if (temp.GetComponent<Part>() != null)
        {
            if (!temp.inplace)
            {
                if (id + 1 == temp.id && id < 4)
                {
                    neigbor.transform.rotation = Quaternion.Euler(-90,0,0);
                    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    neigbor.transform.position = new Vector3(this.transform.position.x - 0.062f, this.transform.position.y, this.transform.position.z);
                    neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    inplace = true;
                    temp.inplace = true;
                    return true;
                }
                else if (temp.id > 4 && temp.id <= 8 && id + 4 == temp.id)
                {
                    neigbor.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    neigbor.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.062f);
                    neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    inplace = true;
                    temp.inplace = true;
                    return true;
                }
                else if (temp.id > 8 && temp.id <= 12 && id + 4 == temp.id)
                {
                    neigbor.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    neigbor.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.062f);
                    neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    inplace = true;
                    temp.inplace = true;
                    return true;
                }
                else if (temp.id > 12 && temp.id <= 16 && id + 4 == temp.id)
                {
                    neigbor.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    neigbor.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.062f);
                    neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    inplace = true;
                    temp.inplace = true;
                    return true;
                }
                else if (temp.id > 16 && id + 16 == temp.id)
                {
                    neigbor.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    neigbor.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.062f, this.transform.position.z);
                    neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    inplace = true;
                    temp.inplace = true;
                    return true;
                }
                else if (id - 1 == temp.id && id != 1 && id < 4)
                {
                    neigbor.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    this.transform.rotation = Quaternion.Euler(-90, 0, 0);
                    neigbor.transform.position = new Vector3(this.transform.position.x + 0.062f, this.transform.position.y, this.transform.position.z);
                    neigbor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
                    inplace = true;
                    temp.inplace = true;
                    return true;
                }

            }
        }
        return false;
    }

}
