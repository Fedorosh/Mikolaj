using Fedorosh.Dying;
using System.CodeDom;
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

        Transform previousParent = null;
        Vector3 startPosition;
        protected override void OnCollided(DyingObject collision)
        {
            previousParent = collision.transform.parent;
            collision.transform.SetParent(transform);
            if(!isMoving)
            {
                startPosition = platform.position;
                StartCoroutine(MoveCoroutine(collision.GetComponent<CharacterController>()));
            }
        }

        protected override void OnUncollided(DyingObject collision)
        {
            collision.transform.SetParent(previousParent);
            previousParent = null;
        }

        private IEnumerator MoveCoroutine(CharacterController player)
        {
            isMoving = true;
            yield return new WaitForSeconds(timeWaiting);
            while(Vector3.Distance(platform.position,destination.position) > acceptedDistance)
            {
                platform.Translate(platform.right * Time.deltaTime * speed);
                if(player != null && player.transform.parent == transform)
                    player.Move(platform.right * Time.deltaTime * speed);
                yield return new WaitForFixedUpdate();
            }

            yield return new WaitForSeconds(timeWaiting);

            while (Vector3.Distance(platform.position, startPosition) > acceptedDistance)
            {
                platform.Translate(-platform.right * Time.deltaTime * speed);
                if (player != null && player.transform.parent == transform)
                    player.Move(-platform.right * Time.deltaTime * speed);
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForFixedUpdate();

            isMoving = false;
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                if (!isMoving)
                {
                    startPosition = platform.position;
                    StartCoroutine(MoveCoroutine(null));
                }
            }
        }
    }
}
