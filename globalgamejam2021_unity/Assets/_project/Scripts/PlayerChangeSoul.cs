using UnityEngine;
using UnityEngine.InputSystem;
using DG.Tweening;

public class PlayerChangeSoul : MonoBehaviour
{

    [SerializeField] private float range = 5.0f;
    [SerializeField] public SoulColor soulColor;
    [SerializeField] private Color[] soulLightColors;
    [SerializeField] private Light soulLight;
    [SerializeField] private LayerMask emptyBodyLayer;

    [SerializeField] private GameObject emptyBodyPrefab;
    [SerializeField] private GameObject soulPrefab;

    [SerializeField] private GameObject body;

    private GameObject soulObj;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {

    }

    public void SetSoulColor(SoulColor soulColor) {

        soulObj = Instantiate(soulPrefab, this.transform.position + Vector3.up, this.transform.rotation);
        soulObj.GetComponent<Soul>().SetParticleByColor(soulColor);

        soulObj.transform.SetParent(this.transform);

        this.soulColor = soulColor;

        // Cor da luz interna
        soulLight.color = soulLightColors[(int)soulColor];

        // Teste
        Debug.Log("Alma alterada: " + soulColor);
    }


    private void OnFire() {
           
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, emptyBodyLayer))
        {
            if(Vector3.Distance(this.transform.position, hit.transform.position) <= range) {
                // soulObj.transform.position = this.transform.position + Vector3.up;
                // soulObj.SetActive(true);

                soulObj.transform.SetParent(null);
                // Move a alma até o corpo vazio
                soulObj.transform.DOMove(hit.transform.position + Vector3.up, 0.5f).OnComplete(() => RiseNewBody(hit));


                // Cria corpo vazio
                Instantiate(emptyBodyPrefab, this.transform.position, this.transform.rotation);

                body.SetActive(false);
            }
        }
    }

    private void RiseNewBody(RaycastHit hit)
    {
        body.SetActive(true);

        this.transform.position = hit.transform.position;

        gameObject.GetComponent<PlayerMove>().line = hit.transform.gameObject.GetComponent<EmptyBody>().line;
        // Destroi corpo vazio
        Destroy(hit.transform.gameObject);

        // Animação de levantar
        animator.SetTrigger("Up");

        soulObj.transform.SetParent(this.transform);


    }
}
