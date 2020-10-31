using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;

public enum WorldStates
{
    OurWorld = 1,
    OtherWorld = 2
}
public class GWorld
{
    private static GWorld instance;

    public static WorldStates WorldState { get; private set; }

    private GWorld()
    {
        Reset();
    }

    public static void Reset()
    {
        WorldState = WorldStates.OtherWorld;
    }

    public static GWorld getInstance()
    {
        if (instance == null)
            instance = new GWorld();
        return instance;
    }

    public static void ChangeState() => WorldState = WorldState == WorldStates.OurWorld ? WorldStates.OtherWorld : WorldStates.OurWorld;

    public static bool IsOurWorld()
    {
        return WorldState == WorldStates.OurWorld;
    }
}

