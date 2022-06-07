using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Fedorosh.Moving
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovingObject : MonoBehaviour
    {
        [SerializeField] private List<Transform> movingTransforms = new List<Transform>();
        private NavMeshAgent agent;
        private int index = 0;
        [SerializeField] private Rigidbody rb;
        private Vector3 transformDestination = Vector3.zero;
        private Coroutine towardsCoroutine = null;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(movingTransforms[0].position);
            //transformDestination = movingTransforms[0].position;
            //towardsCoroutine = StartCoroutine(MoveRBTowardsCoroutine());
        }

        private void Update()
        {
            Move();
            //MoveRB();
        }

        private IEnumerator MoveRBTowardsCoroutine()
        {
            while (true)
            {
                rb.MovePosition(Vector3.Lerp(rb.transform.position, transformDestination, Time.deltaTime));
                yield return null;
            }
        }

        private void Move()
        {
            Vector2 pos = new Vector2(agent.transform.position.x, agent.transform.position.z);
            Vector2 des = new Vector2(agent.destination.x, agent.destination.z);
            if (Vector2.Distance(pos,des) < 0.01f)
            {
                index++;
                //StopCoroutine(towardsCoroutine);
            }
            if (index == movingTransforms.Count) index = 0;
            if (agent.destination == movingTransforms[index].position) return;
            agent.destination = movingTransforms[index].position;
        }
        private void MoveRB()
        {
            Vector2 pos = new Vector2(rb.transform.position.x, rb.transform.position.z);
            Vector2 des = new Vector2(transformDestination.x, transformDestination.z);
            if (Vector2.Distance(pos, des) < 0.01f)
            {
                index++;
                StopCoroutine(towardsCoroutine);
            }
            if (index == movingTransforms.Count) index = 0;
            if (transformDestination == movingTransforms[index].position) return;
            transformDestination = movingTransforms[index].position;
            towardsCoroutine = StartCoroutine(MoveRBTowardsCoroutine());
        }
    }
}

