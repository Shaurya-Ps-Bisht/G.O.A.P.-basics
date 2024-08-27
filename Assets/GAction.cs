using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public abstract class GAction : MonoBehaviour
{
    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public GameObject targetTag;
    public float duration = 0;
    public WorldState[] preConditionsInspec;
    public WorldState[] EffectsInspec;
    public NavMeshAgent agent;

    public Dictionary<string, int> preConditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBeliefs;

    public bool running = false;

    public GAction()
    {
        preConditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();

    }

    public void Awake()
    {
        agent = this.gameObject.GetComponent<NavMeshAgent>();

        if(preConditionsInspec != null)
        {
            foreach(WorldState w in preConditionsInspec)
            {
                preConditions.Add(w.key, w.value);
            }
        }

        if (EffectsInspec != null)
        {
            foreach (WorldState w in EffectsInspec)
            {
                effects.Add(w.key, w.value);
            }
        }
    }

    public bool isAchievable()
    {
        return true;
    }

    public bool isAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach(KeyValuePair<string, int> p in preConditions)
        {
            if(!conditions.ContainsKey(p.Key))
            {
                return false;
            }

        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
