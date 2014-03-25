using UnityEngine;
using System.Collections;

public class CompIceRink : MonoBehaviour {
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == Tags.player)
        {
            GameObject player = other.transform.parent.gameObject;
            player.GetComponent<CharControl>().enabled = false;
            player.AddComponent<IceSkateControl>();
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag == Tags.player)
        {
            GameObject player = other.transform.parent.gameObject;
            Destroy(player.GetComponent<IceSkateControl>());
            player.GetComponent<CharControl>().enabled = true;
        }
    }
}
