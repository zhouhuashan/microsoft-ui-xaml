﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using MUXControlsTestApp.Utilities;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Common;

#if USING_TAEF
using WEX.TestExecution;
using WEX.TestExecution.Markup;
using WEX.Logging.Interop;
#else
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
#endif

#if !BUILD_WINDOWS
using Scroller = Microsoft.UI.Xaml.Controls.Primitives.Scroller;
using ScrollSnapPointsAlignment = Microsoft.UI.Xaml.Controls.Primitives.ScrollSnapPointsAlignment;
using ScrollSnapPoint = Microsoft.UI.Xaml.Controls.Primitives.ScrollSnapPoint;
using RepeatedScrollSnapPoint = Microsoft.UI.Xaml.Controls.Primitives.RepeatedScrollSnapPoint;
using ZoomSnapPoint = Microsoft.UI.Xaml.Controls.Primitives.ZoomSnapPoint;
#endif

namespace Windows.UI.Xaml.Tests.MUXControls.ApiTests
{
    partial class ScrollerTests
    {
        [TestMethod]
        [TestProperty("Description", "Create a bunch of snap points with invalid arguments.")]
        public void SnapPointsWithInvalidArgsThrow()
        {
            RunOnUIThread.Execute(() =>
            {
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset:  10, interval:  0, start:  10, end: 100, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset:  10, interval: -1, start:  10, end: 100, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset:  10, interval: 10, start:  10, end:   1, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset:  10, interval: 10, start:  10, end:  10, alignment: ScrollSnapPointsAlignment.Near); });
#if ApplicableRangeType
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset:   1, interval: 10, start:   1, end:  10, applicableRange: -10, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset:   1, interval: 10, start:   1, end:  10, applicableRange:   0, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset:  50, interval: 10, start: 100, end: 200, applicableRange:   2, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new RepeatedScrollSnapPoint(offset: 250, interval: 10, start: 100, end: 200, applicableRange:   2, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new ScrollSnapPoint(snapPointValue: 0, applicableRange:  0, alignment: ScrollSnapPointsAlignment.Near); });
                Verify.Throws<ArgumentException>(() => { new ScrollSnapPoint(snapPointValue: 0, applicableRange: -1, alignment: ScrollSnapPointsAlignment.Near); });
#endif
            });
        }

        [TestMethod]
        [TestProperty("Description", "Verify that overlapping repeated snap points throw while adjacent ones do not.")]
        public void OverlappingRepeatedSnapPointsThrow()
        {
            RunOnUIThread.Execute(() =>
            {
                Scroller scroller = new Scroller();
                RepeatedScrollSnapPoint snapPoint1 = new RepeatedScrollSnapPoint(offset:  10, interval: 10, start:  10, end: 100, alignment: ScrollSnapPointsAlignment.Near);
                RepeatedScrollSnapPoint snapPoint2 = new RepeatedScrollSnapPoint(offset:  10, interval: 10, start:  10, end: 100, alignment: ScrollSnapPointsAlignment.Near);
                RepeatedScrollSnapPoint snapPoint3 = new RepeatedScrollSnapPoint(offset:   0, interval:  2, start:   0, end:  12, alignment: ScrollSnapPointsAlignment.Near);
                RepeatedScrollSnapPoint snapPoint4 = new RepeatedScrollSnapPoint(offset:   0, interval:  2, start:   0, end:  10, alignment: ScrollSnapPointsAlignment.Near);
                RepeatedScrollSnapPoint snapPoint5 = new RepeatedScrollSnapPoint(offset: 100, interval:  2, start: 100, end: 200, alignment: ScrollSnapPointsAlignment.Near);

                scroller.VerticalSnapPoints.Add(snapPoint1);
                Verify.Throws<ArgumentException>(() => { scroller.VerticalSnapPoints.Add(snapPoint2); });
                Verify.Throws<ArgumentException>(() => { scroller.VerticalSnapPoints.Add(snapPoint3); });
                scroller.HorizontalSnapPoints.Add(snapPoint4);
                scroller.HorizontalSnapPoints.Add(snapPoint5);
            });
        }

        [TestMethod]
        [TestProperty("Description", "Add and remove snap points and make sure the corresponding collections look correct.")]
        public void CanAddAndRemoveSnapPointsFromAScroller()
        {
            CanAddAndRemoveSnapPointsFromAScroller(ScrollSnapPointsAlignment.Near);
            CanAddAndRemoveSnapPointsFromAScroller(ScrollSnapPointsAlignment.Center);
            CanAddAndRemoveSnapPointsFromAScroller(ScrollSnapPointsAlignment.Far);
        }

        private void CanAddAndRemoveSnapPointsFromAScroller(ScrollSnapPointsAlignment alignment)
        { 
            Scroller scroller = null;
            ScrollSnapPoint snapPoint2 = null;
            RepeatedScrollSnapPoint snapPoint3 = null;
            RepeatedScrollSnapPoint snapPoint4 = null;

            RunOnUIThread.Execute(() =>
            {
                scroller = new Scroller();
                ScrollSnapPoint snapPoint1 = new ScrollSnapPoint(snapPointValue: 10, alignment: alignment);
                snapPoint2 = new ScrollSnapPoint(snapPointValue: 10, alignment: alignment);
                snapPoint3 = new RepeatedScrollSnapPoint(offset:  10, interval: 10, start:  10, end: 100, alignment: alignment);
                snapPoint4 = new RepeatedScrollSnapPoint(offset: 100, interval: 10, start: 100, end: 200, alignment: alignment);
                ZoomSnapPoint snapPoint5 = new ZoomSnapPoint(snapPointValue: 10);
                scroller.HorizontalSnapPoints.Add(snapPoint1);
                scroller.VerticalSnapPoints.Add(snapPoint1);
                scroller.ZoomSnapPoints.Add(snapPoint5);
            });
            
            IdleSynchronizer.Wait();
            
            RunOnUIThread.Execute(() =>
            {
                Verify.AreEqual<int>(1, scroller.HorizontalSnapPoints.Count);
                Verify.AreEqual<int>(1, scroller.VerticalSnapPoints.Count);
                Verify.AreEqual<int>(1, scroller.ZoomSnapPoints.Count);
                scroller.HorizontalSnapPoints.Add(snapPoint2);
                scroller.HorizontalSnapPoints.Add(snapPoint3);
                scroller.HorizontalSnapPoints.Add(snapPoint4);
            });
            
            IdleSynchronizer.Wait();

            RunOnUIThread.Execute(() =>
            {
                Verify.AreEqual<int>(4, scroller.HorizontalSnapPoints.Count);
                scroller.HorizontalSnapPoints.Remove(snapPoint2);
            });           

            IdleSynchronizer.Wait(); 

            RunOnUIThread.Execute(() =>
            {
                Verify.AreEqual<int>(3, scroller.HorizontalSnapPoints.Count);
                scroller.HorizontalSnapPoints.Remove(snapPoint2);
            });

            IdleSynchronizer.Wait();

            RunOnUIThread.Execute(() =>
            {
                Verify.AreEqual<int>(3, scroller.HorizontalSnapPoints.Count);
                scroller.HorizontalSnapPoints.Clear();
            });

            IdleSynchronizer.Wait();

            RunOnUIThread.Execute(() =>
            {
                Verify.AreEqual<int>(0, scroller.HorizontalSnapPoints.Count);
                Verify.AreEqual<int>(1, scroller.VerticalSnapPoints.Count);
                Verify.AreEqual<int>(1, scroller.ZoomSnapPoints.Count);
            });
        }

        [TestMethod]
        [TestProperty("Description", "Add scroll snap points with various alignments.")]
        public void CanAddScrollSnapPointsWithMixedAlignments()
        {
            Scroller scroller = null;

            RunOnUIThread.Execute(() =>
            {
                scroller = new Scroller();
                ScrollSnapPoint nearSnapPoint = new ScrollSnapPoint(snapPointValue: 10, alignment: ScrollSnapPointsAlignment.Near);
                ScrollSnapPoint centerSnapPoint = new ScrollSnapPoint(snapPointValue: 20, alignment: ScrollSnapPointsAlignment.Center);
                ScrollSnapPoint farSnapPoint = new ScrollSnapPoint(snapPointValue: 30, alignment: ScrollSnapPointsAlignment.Far);
                RepeatedScrollSnapPoint nearRepeatedScrollSnapPoint = new RepeatedScrollSnapPoint(offset: 50, interval: 10, start: 50, end: 100, alignment: ScrollSnapPointsAlignment.Near);
                RepeatedScrollSnapPoint centerRepeatedScrollSnapPoint = new RepeatedScrollSnapPoint(offset: 180, interval: 10, start: 175, end: 225, alignment: ScrollSnapPointsAlignment.Center);
                RepeatedScrollSnapPoint farRepeatedScrollSnapPoint = new RepeatedScrollSnapPoint(offset: 280, interval: 5, start: 280, end: 300, alignment: ScrollSnapPointsAlignment.Far);
                scroller.HorizontalSnapPoints.Add(nearSnapPoint);
                scroller.HorizontalSnapPoints.Add(centerSnapPoint);
                scroller.HorizontalSnapPoints.Add(farSnapPoint);
                scroller.VerticalSnapPoints.Add(nearSnapPoint);
                scroller.VerticalSnapPoints.Add(centerSnapPoint);
                scroller.VerticalSnapPoints.Add(farSnapPoint);
                scroller.HorizontalSnapPoints.Add(nearRepeatedScrollSnapPoint);
                scroller.HorizontalSnapPoints.Add(centerRepeatedScrollSnapPoint);
                scroller.HorizontalSnapPoints.Add(farRepeatedScrollSnapPoint);
                scroller.VerticalSnapPoints.Add(nearRepeatedScrollSnapPoint);
                scroller.VerticalSnapPoints.Add(centerRepeatedScrollSnapPoint);
                scroller.VerticalSnapPoints.Add(farRepeatedScrollSnapPoint);
            });

            IdleSynchronizer.Wait();

            RunOnUIThread.Execute(() =>
            {
                Verify.AreEqual<int>(6, scroller.HorizontalSnapPoints.Count);
                Verify.AreEqual<int>(6, scroller.VerticalSnapPoints.Count);
            });
        }
    }
}
