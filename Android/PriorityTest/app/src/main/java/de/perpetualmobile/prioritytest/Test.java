package de.perpetualmobile.prioritytest;

import android.util.Log;

public class Test {

    public static final String TAG = Test.class.getName();

    private static int count = 0;

    public void run() {
        Thread lowestThread = new Thread(low());
        lowestThread.setPriority(Thread.MIN_PRIORITY);
        lowestThread.start();
        try {
            Thread.sleep(1000);
        } catch (InterruptedException e) {
            Log.d(TAG, e.getMessage());
        }

        for(int i = 0; i < 40; i++){
            Thread highestThread = new Thread(high());
            highestThread.setPriority(Thread.MAX_PRIORITY);
            highestThread.start();
        }
    }

    public Runnable low() {
        return new Runnable() {
            @Override
            public void run() {
                Log.d(TAG, "Low priority task started");
                while (true) {
                    try {
                        Thread.sleep(1000);
                        Log.d(TAG, "Low priority tast can still process stuff " + count);
                    } catch (InterruptedException e) {
                        Log.d(TAG, e.getMessage());
                    }
                }
            }
        };
    }

    public Runnable high() {
        return new Runnable() {
            @Override
            public void run() {
                Log.d(TAG, "High priority task started");

                while (true)
                    count++;
            }
        };
    }

}
