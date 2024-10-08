using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor.Search;

public class SubGoal
{
    public Dictionary<string, int> sGoals;
    public bool remove;
    public SubGoal(string s, int i, bool r)
    {
        sGoals = new Dictionary<string, int>();
        sGoals.Add(s, i);
        remove = r;
    }
}

public class GAgent : MonoBehaviour
{
    public List<GAction> actions = new List<GAction>();
    public Dictionary<SubGoal, int> goals = new Dictionary<SubGoal, int>;
    GPlanner planner;
    Queue<GAction> actionQueue;
    public GAction currentAction;
    SubGoal currentGoal;


    // Start is called before the first frame update
    void Start()
    {
        GAction[] acts = this.GetComponents<GAction>();
        foreach(GAction a in acts)
        {
            actions.Add(a);
        }
    }

   void LateUpdate()
    {
                        
    }
}
