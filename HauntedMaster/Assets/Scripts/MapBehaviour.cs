using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    public List<Encounter> PossibleEncounters;
    private BattleStarter BS;

    private void Start()
    {
        BS = GameObject.Find("BattleStarter").GetComponent<BattleStarter>();
    }

    public void SpawnEncounter()
    {
        Encounter ChoosenEncounter = PossibleEncounters[Random.Range(0, PossibleEncounters.Count)];

        print("YES SIR");
        BS.StartFight(ChoosenEncounter.enemies);
    }


}
