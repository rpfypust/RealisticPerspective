using UnityEngine;
using System.Collections;

public static class AnimationExtensions {
    public static IEnumerator WaitForFinished(this Animation animation) {
        animation.Play();
        yield return new WaitForSeconds(animation.clip.length);
    }
}
