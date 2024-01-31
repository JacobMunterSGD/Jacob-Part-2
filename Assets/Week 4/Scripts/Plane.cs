using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Plane : MonoBehaviour
{

    public List<Vector2> points;
    public float newPointThreshold;
    Vector2 lastPosition;
    Vector2 currentPlanePosition;

    LineRenderer lineRenderer;

    Rigidbody2D rb;

    public float speed;

    public AnimationCurve landing;

    float landingTimer;

    SpriteRenderer SpriteRenderer;

    float proximity = 1;

    bool isLanding = false;

    public int score = 0;

    void Start()
    {
        transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
        speed = Random.Range(1, 4);

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        rb = GetComponent<Rigidbody2D>();

        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {

        points = new List<Vector2>();
        Vector2 currentPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

    }
    void OnMouseDrag()
    {

        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(currentPosition, lastPosition) > newPointThreshold)
        {
            points.Add(currentPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, currentPosition);
            lastPosition = currentPosition;
        }

    }

    void FixedUpdate()
    {

        currentPlanePosition = new Vector2(transform.position.x, transform.position.y);
        
        if (points.Count > 0)
        {

            Vector2 direction = points[0] - currentPlanePosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

            rb.rotation = -angle;

        }
        rb.MovePosition(rb.position + (Vector2)transform.up * speed * Time.deltaTime);

    }

    void Update()
    {

        if (isLanding)
        {

            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);

            if (transform.localScale.z < 0.1f)
            {
                Destroy(gameObject);
            }

            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);

        }

        if (points.Count > 0)
        {
            if (Vector2.Distance(currentPlanePosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));
                }
                lineRenderer.positionCount --;

            }
        }

    }

    void OnTriggerStay2D(Collider2D col)
    {



        SpriteRenderer.color = new Color(255, 0, 0);
        UnityEngine.Debug.Log("collision");

        if (col.gameObject.tag != "runway" && Vector3.Distance(currentPlanePosition, col.transform.position) < proximity)
        {
            Destroy(gameObject);
        }

        if (col.gameObject.tag == "runway")
        {
            //&& col.overlapPoint == true
            score++;
            UnityEngine.Debug.Log(score);
            UnityEngine.Debug.Log("runway");
            isLanding = true;
        
        }

    }

    void OnTriggerExit2D()
    {

        SpriteRenderer.color = new Color(219, 219, 219);

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
