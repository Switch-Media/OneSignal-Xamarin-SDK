using System;
using System.Collections.Generic;

namespace Com.OneSignal.Abstractions {
   public class OSNotification {
      public enum DisplayType {
         // Notification shown in the notification shade.
         Notification,

         // Notification shown as an in app alert.
         InAppAlert,

         // Notification was silent and not displayed.
         None
      }

      //public bool isAppInFocus;
      //public bool shown;
      //public bool silentNotification;
      public int androidNotificationId;
      public string notificationId;

      public List<OSNotification> groupedNotifications;
      //public DisplayType displayType;

      public string sound;
      public string title;
      public string body;
      public string subtitle;
      public string launchURL;
      public Dictionary<string, object> additionalData;
      public List<Dictionary<string, object>> actionButtonsDictionary;
      public List<OSNotificationActionButton> actionButtons;
      public bool contentAvailable;
      public int badge;
      public string smallIcon;
      public string largeIcon;
      public string bigPicture;
      public string smallIconAccentColor;
      public string ledColor;
      public int lockScreenVisibility = 1;
      public string groupKey;
      public string groupMessage;
      public string fromProjectNumber;
      public string collapseId;
      public int priority;
   }
}
