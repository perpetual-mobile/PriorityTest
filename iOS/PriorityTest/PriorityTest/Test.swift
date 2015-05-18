//
//  Test.swift
//  PriorityTest
//
//  Created by Sascha Willam on 18.05.15.
//  Copyright (c) 2015 Perpetual Mobile GmbH. All rights reserved.
//

import Foundation

class Test:NSObject {
    
    var count = 0
    
    func run(){
        let lowestThread = NSThread(target:self, selector:"low", object:nil)
        lowestThread.threadPriority = 0.0
        lowestThread.start()
        NSThread.sleepForTimeInterval(1.0)

        // If using more than one high priority thread the low priority thread doesn't 
        // get called frequently any more on a real device (tested on a iPad 2 Mini)
        for i in 1...2 {
            let highestThread = NSThread(target:self, selector:"high", object:nil)
            highestThread.threadPriority = 1.0
            highestThread.start()
        }
    }
    
    func low(){
        NSLog("Low priority task started")
        
        while(true){
            NSThread.sleepForTimeInterval(1.0)
            NSLog("Low priority task can still process stuff \(count)")
        }
    }
    
    func high(){
        NSLog("High priority task started")
        
        while(true){
            count++
        }
    }
    
}