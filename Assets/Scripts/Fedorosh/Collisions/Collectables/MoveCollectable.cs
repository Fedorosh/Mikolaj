using Fedorosh.Dying;
using System.Collections;
using System.Threading;
using UnityEngine;

namespace Fedorosh.Collisions.Collectables
{
    public class MoveCollectable : Collectable
    {
        [SerializeField] private Transform platform;
        [SerializeField] private Transform destination;

        [SerializeField] private float speed = 1f;
        [SerializeField] private float timeWaiting = 3f;
        [SerializeField] private float acceptedDistance = 0.01f;

        private bool isMoving = false;

        Vector3 startPosition;
        protected override void OnCollided(DyingObject collision)
        {
            if(!isMoving)
            {
                startPosition = platform.position;
                StartCoroutine(MoveCoroutine());
            }
        }

        private IEnumerator MoveCoroutine()
        {
            float timer = 0f;
            isMoving = true;
            while(Vector3.Distance(platform.position,destination.position) > acceptedDistance)
            {
                timer += Time.deltaTime * speed;
                platform.position = Vector3.Lerp(startPosition, destination.position, timer);
                yield return null;
            }
            yield return new WaitForSeconds(timeWaiting);
            timer = 0f;
            while (Vector3.Distance(platform.position, startPosition) > acceptedDistance)
            {
                timer += Time.deltaTime * speed;
                platform.position = Vector3.Lerp(destination.position, startPosition, timer);
                yield return null;
            }
            yield return null;
            isMoving = false;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                if (!isMoving)
                {
                    startPosition = platform.position;
                    StartCoroutine(MoveCoroutine());
                }
            }
        }
    }
}
