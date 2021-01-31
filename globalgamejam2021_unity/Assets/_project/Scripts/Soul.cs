using UnityEngine;

public class Soul : MonoBehaviour{
    [SerializeField] private GameObject[] particles;

    public void SetParticleByColor(SoulColor soulColor) {
        particles[(int)soulColor].SetActive(true);
    }
}
