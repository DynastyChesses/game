#import "UnityAppController.h"
#import <UIKit/UIKit.h>
#import <IIAPObserver.h>
@interface CustomAppController : UnityAppController
@end

IMPL_APP_CONTROLLER_SUBCLASS (CustomAppController)


@implementation CustomAppController

- (BOOL)application:(UIApplication*)application didFinishLaunchingWithOptions:(NSDictionary*)launchOptions
{
    [super application:application didFinishLaunchingWithOptions:launchOptions];
    [IAPObserver instance];
    return YES;
}

@end