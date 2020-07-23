using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager {
    private static float timeFlow = 1.0f;

    public static void setTimeFlow(float val) {
        timeFlow = val;

        return;
    }

    public static float getTimeFlow() {
        return timeFlow;
    }
}
