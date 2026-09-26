//
//  GDMOBinding.m
//  Unity-iPhone
//
//  Created by Nick Miller on 5/24/12.
//  Copyright (c) 2012 Graveck. All rights reserved.
//

#import "GDMOBinding.h"
#import <AdSupport/AdSupport.h>

@implementation GDMOBinding

static DMOAnalytics * analyticsController;
static BOOL hasInit = false;

// for internal use
+ (DMOAnalytics*) instance
{
    @synchronized(self)
    {
        if (analyticsController == NULL)
                analyticsController = [DMOAnalytics alloc];
    }
    
    return (analyticsController);
}

// two ways to init the DMOAnalytics manager
+ (void) initWithAppKey:(NSString*)key secret:(NSString*)secret
{
	// don't init twice
	if (hasInit)
		return;
	else
		hasInit = YES;
	
    DMOAnalytics* inst = [GDMOBinding instance];
    [inst initWithAppKey:key secret:secret];
    
    // get the IDFA (ad tracking ID,) but only if we are allowed to
    ASIdentifierManager* adIDMan = [ASIdentifierManager sharedManager];
    if (adIDMan.advertisingTrackingEnabled)
        inst.DIIDA = [[adIDMan advertisingIdentifier] UUIDString];
    
	// Turn on debug logging so we can see our events in the console.
	//analyticsController.debugLogging = YES;
    
    // force this event, because it won't auto-trigger
	if ( [[GDMOBinding instance] respondsToSelector:@selector(logAppStart) ] )
		[[GDMOBinding instance] performSelector:@selector(logAppStart)];
}

+ (void) initWithAppKey:(NSString*)key secret:(NSString*)secret useNotifications:(BOOL)yn
{
	// don't init twice
	if (hasInit)
		return;
	else
		hasInit = YES;
	
    DMOAnalytics* inst = [GDMOBinding instance];
    [inst initWithAppKey:key secret:secret useNotifications:yn];
    
    // get the IDFA (ad tracking ID,) but only if we are allowed to
    ASIdentifierManager* adIDMan = [ASIdentifierManager sharedManager];
    if (adIDMan.advertisingTrackingEnabled)
        inst.DIIDA = [[adIDMan advertisingIdentifier] UUIDString];
   
	// Turn on debug logging so we can see our events in the console.
	//analyticsController.debugLogging = YES;
    
    // force this event, because it won't auto-trigger
	if ( [[GDMOBinding instance] respondsToSelector:@selector(logAppStart) ] )
		[[GDMOBinding instance] performSelector:@selector(logAppStart)];
}

// two ways to log an event
+ (void) logAnalyticsEvent:(NSString*)eventDescription
{
    [[GDMOBinding instance] logAnalyticsEvent:eventDescription];
}

+ (void) logAnalyticsEvent:(NSString*)scope withContext:(NSDictionary*)details
{
    [[GDMOBinding instance] logAnalyticsEvent:scope withContext:details];
}

// attempt to post any queue analytics events to the network
+ (void) flushAnalyticsQueue
{
    [[GDMOBinding instance] flushAnalyticsQueue];
}

// Converts C style string to NSString
NSString* CreateNSString (const char* string)
{
	if (string)
		return [NSString stringWithUTF8String: string];
	else
		return [NSString stringWithUTF8String: ""];
}

extern "C" {
    void _GDMOInitWithAppKey(const char* key, const char* secret)
    {
        [GDMOBinding initWithAppKey:CreateNSString(key) secret:CreateNSString(secret)];
    }
    
    void _GDMOInitWithAppKeyEx(const char* key, const char* secret, bool useNotifications)
    {
        [GDMOBinding initWithAppKey:CreateNSString(key) secret:CreateNSString(secret) useNotifications:useNotifications];
    }
    
    void _GDMOLogAnalyticsEvent(const char* eventDescription)
    {
        [GDMOBinding logAnalyticsEvent:CreateNSString(eventDescription)];
    }
    
    void _GDMOLogAnalyticsEventWithJSON(const char* scope, const char* json)
    {
        NSData* data = [[NSString stringWithUTF8String:json] dataUsingEncoding:NSUTF8StringEncoding];
        NSError* error = nil;
        NSDictionary* dictionary = [NSJSONSerialization JSONObjectWithData:data options:nil error:&error];
        
        [GDMOBinding logAnalyticsEvent:[NSString stringWithUTF8String:scope] withContext:dictionary];
    }
    
    void _GDMOFlushAnalyticsQueue()
    {
        [GDMOBinding flushAnalyticsQueue];
    }
}

@end
