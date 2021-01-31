using UnityEngine;

public class Soul : MonoBehaviour{
    [SerializeField] private GameObject[] particles;

    [SerializeField] private Transform emptyBodyTransform;

    private bool isMoving = false;

    private PlayerChangeSoul playerChangeSoul;
    private Vector3 initialPosition;

    public void MoveSoul(Transform emptyBodyTransform, Vector3 initialPosition) {
        isMoving = true;
        this.emptyBodyTransform = emptyBodyTransform;
        this.initialPosition = initialPosition;
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(initialPosition, emptyBodyTransform.position + Vector3.up);
   
    }

    private void Update() {
        if(isMoving) {
            // this.transform.position = Vector3.Lerp(this.transform.position, emptyBodyTransform.position, 1);

            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(initialPosition, emptyBodyTransform.position + Vector3.up, fractionOfJourney);

            if(transform.position == emptyBodyTransform.position + Vector3.up) {
                ArriveBody();
            }
        }
    }

    private void ArriveBody() {
        isMoving = false;

        playerChangeSoul.body.SetActive(true);

        playerChangeSoul.transform.position = emptyBodyTransform.position;

        playerChangeSoul.GetComponent<PlayerMove>().line = emptyBodyTransform.gameObject.GetComponent<EmptyBody>().line;
        // Destroi corpo vazio
        Destroy(emptyBodyTransform.gameObject);

        // Animação de levantar
        playerChangeSoul.animator.SetTrigger("Up");

        transform.SetParent(playerChangeSoul.soulTransform, true);


    }

    public void SetParticleByColor(SoulColor soulColor, PlayerChangeSoul playerChangeSoul) {
        particles[(int)soulColor].SetActive(true);
        this.playerChangeSoul = playerChangeSoul;
    }



    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 10.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    
}
