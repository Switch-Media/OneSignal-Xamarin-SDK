using System;
using System.Collections.Generic;
using Com.OneSignal.Abstractions;

namespace Com.OneSignal
{
   public class NotificationOpenedHandler : Java.Lang.Object, Android.OneSignal.IOSNotificationOpenedHandler
   {
      public void NotificationOpened(Android.OSNotificationOpenedResult result)
      {
         (OneSignal.Current as OneSignalImplementation).OnPushNotificationOpened(OSNotificationOpenedResultToNative(result));
      }

      public static OSNotificationOpenedResult OSNotificationOpenedResultToNative(Android.OSNotificationOpenedResult result)
      {

         OSNotificationAction.ActionType actionType = OSNotificationAction.ActionType.Opened;

         if (result.Action.Type == Android.OSNotificationAction.ActionType.Opened)
            actionType = OSNotificationAction.ActionType.Opened;
         else
            actionType = OSNotificationAction.ActionType.ActionTaken;

         var openresult = new OSNotificationOpenedResult();
         openresult.action = new OSNotificationAction();
         Android.OSNotificationAction action = result.Action;
         openresult.action.actionId = action.ActionId;
         openresult.action.type = actionType;

         openresult.notification = OSNotificationToNative(result.Notification);

         return openresult;
      }

      public static OSNotification OSNotificationToNative(Android.OSNotification notif)
      {
         var notification = new OSNotification();
         notification.notificationId = notif.NotificationId;
         notification.androidNotificationId = notif.AndroidNotificationId;

         notification.groupedNotifications = new List<OSNotification>();
         if (notif.GroupedNotifications != null)
         {
            foreach(Android.OSNotification osNotif in notif.GroupedNotifications)
            {
               notification.groupedNotifications.Add(OSNotificationToNative(osNotif));
            }
         }

         notification.actionButtons = new List<OSNotificationActionButton>();
         if (notif.ActionButtons != null)
         {
            foreach (Android.OSNotification.ActionButton button in notif.ActionButtons)
            {
               notification.actionButtons.Add(ToOSNotificationActionButton(button));
            }
         }

         notification.additionalData = new Dictionary<string, object>();
         if (notif.AdditionalData != null)
         {
            var iterator = notif.AdditionalData.Keys();
            while (iterator.HasNext)
            {
               var key = (string)iterator.Next();
               notification.additionalData.Add(key, notif.AdditionalData.Get(key));
            }
         }

         notification.body = notif.Body;
         notification.launchURL = notif.LaunchURL;
         notification.notificationId = notif.NotificationId;
         notification.sound = notif.Sound;
         notification.title = notif.Title;
         notification.bigPicture = notif.BigPicture;
         notification.fromProjectNumber = notif.FromProjectNumber;
         notification.groupKey = notif.GroupKey;
         notification.groupMessage = notif.GroupMessage;
         notification.largeIcon = notif.LargeIcon;
         notification.ledColor = notif.LedColor;
         notification.lockScreenVisibility = notif.LockScreenVisibility;
         notification.smallIcon = notif.SmallIcon;
         notification.smallIconAccentColor = notif.SmallIconAccentColor;
         notification.collapseId = notif.CollapseId;
         notification.priority = notif.Priority;

         return notification;
      }

      private static OSNotificationActionButton ToOSNotificationActionButton(Android.OSNotification.ActionButton actionButton)
      {
         return new OSNotificationActionButton()
         {
            icon = actionButton.Icon,
            text = actionButton.Text,
            id = actionButton.Id
         };
      }
   }
}