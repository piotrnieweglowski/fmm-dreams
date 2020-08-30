using Syncfusion.SfCalendar.XForms.iOS;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.iOS.Cards;
using Syncfusion.SfRating.XForms.iOS;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace fmmApp.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfComboBoxRenderer.Init();
            SfCalendarRenderer.Init();
            SfCardViewRenderer.Init();
            SfRatingRenderer.Init();
            SfAvatarViewRenderer.Init();
            SfBadgeViewRenderer.Init();
            SfBorderRenderer.Init();
            SfListViewRenderer.Init();
            SfButtonRenderer.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
