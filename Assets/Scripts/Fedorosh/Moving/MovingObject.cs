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
        [SerializeField] private TransformPath transformPath;
        private NavMeshAgent agent;
        private int index = 0;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            agent.SetDestination(transformPath.movingTransforms[0].position);
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            Vector2 pos = new Vector2(agent.transform.position.x, agent.transform.position.z);
            Vector2 des = new Vector2(agent.destination.x, agent.destination.z);
            if (Vector2.Distance(pos,des) < 0.01f)
            {
                index++;
            }
            if (index == transformPath.movingTransforms.Count) index = 0;
            if (agent.destination == transformPath.movingTransforms[index].position) return;
            agent.destination = transformPath.movingTransforms[index].position;
        }
    }
}

