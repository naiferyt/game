//
//  GDMOBinding.h
//  Unity-iPhone
//
//  Created by Nick Miller on 5/24/12.
//  Copyright (c) 2012 Graveck. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "DMOAnalytics.h"

@interface GDMOBinding : NSObject

// singleton interface
+ (DMOAnalytics*) instance;

// two ways to init the DMOAnalytics manager
+ (void) initWithAppKey:(NSString*)key secret:(NSString*)secret;
+ (void) initWithAppKey:(NSString*)key secret:(NSString*)secret useNotifications:(BOOL)yn;

// two ways to log an event
+ (void) logAnalyticsEvent:(NSString*)eventDescription;
+ (void) logAnalyticsEvent:(NSString*)scope withContext:(NSDictionary*)details;

// attempt to post any queue analytics events to the network
+ (void) flushAnalyticsQueue;

@end
